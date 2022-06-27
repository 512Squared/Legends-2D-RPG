using System.Linq;
using System.Collections;
using System.Net;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class QuestElement : MonoBehaviour, ISaveable
{
    #region SERIALIZATION

    [DetailedInfoBox("Click for info about this component...",
        "Quest elements control triggers and items: A trigger can: \n 1. activate a quest \n 2. complete a quest \n 3. Enable an element (trigger or item) \n 4. complete this element \n 5. disable or enable after meeting conditions \n 6. be enabled after a dialogue \n 7. enable subquests")]
    [Space] [GUIColor(.5f, 0.8f, 0.215f)] [Required]
    public Quest quest;

    [ShowIf("isItem")] [Required] [GUIColor(.5f, 0.8f, 0.215f)] [PropertyTooltip("drag Item component into this box")]
    public Item questItem;

    [TitleGroup("GameObject", AnimateVisibility = true, HorizontalLine = true)]
    [Space]
    [GUIColor(.1f, 0.8f, 0.215f)]
    public PolygonCollider2D polyCollider;

    [ShowIf("isItem", false)] [Required] [GUIColor(.1f, 0.8f, 0.215f)]
    public SpriteRenderer spriteRenderer;

    [ShowIf("changeAnObject", false)] [Required] [GUIColor(.1f, 0.8f, 0.215f)]
    public PolygonCollider2D changedObjectCollider;

    [ShowIf("changeAnObject", false)] [Required] [GUIColor(.1f, 0.8f, 0.215f)]
    public SpriteRenderer changedObjectRenderer;

    [ShowIf("secondaryCollider", false)] [Required] [GUIColor(.1f, 0.8f, 0.215f)]
    public PolygonCollider2D secondCollider;

    #region Conditions

    [Space] [TitleGroup("Conditions", AnimateVisibility = true, HorizontalLine = true)]
    [GUIColor(.5f, 0.8f, 0.815f)]
    public bool meetConditions;

    [Space] [PropertyTooltip("This quest must be activated before this element becomes active")]
    [ShowIf("meetConditions", false)] [GUIColor(.5f, 0.8f, 0.815f)] [SerializeField]
    private Quest activateThisQuestFirst;

    [PropertyTooltip("This quest must be completed before this element becomes active")]
    [GUIColor(.5f, 0.8f, 0.815f)] [ShowIf("meetConditions", false)] [SerializeField]
    private Quest completeThisQuestFirst;

    [Space] [PropertyTooltip("A quest must be activated before this element becomes active")]
    [ShowIf("meetConditions", false)] [GUIColor(.5f, 0.8f, 0.815f)]
    public bool thenActivateThisQuest;

    [PropertyTooltip("This quest must be completed before this element becomes active")]
    [ShowIf("meetConditions", false)] [GUIColor(.5f, 0.8f, 0.815f)]
    public bool thenCompleteThisQuest;

    // quest to be completed first

    #endregion


    [Space] [PropertyTooltip("If this item is a relic, drag the appropriate relicBox from the Relics UI panel")]
    [GUIColor(.5f, 0.8f, 0.215f)] [ShowIf("itemIsRelic", false)]
    public RectTransform relicBox;

    [TitleGroup("Quest Bools")] [Space]
    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isItem;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)] [ShowIf("isItem")] [Indent]
    public bool itemIsRelic;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool secondaryCollider;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool activateSubQuests;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool activateOnEnter;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool completeOnEnter;

    [Space] [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDialogue;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDone;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool changeAnObject;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [ShowIf("changeAnObject", false)] [Indent]
    public bool revealObject;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [ShowIf("changeAnObject", false)] [Indent]
    public bool hideObject;


    [TitleGroup("For information only")] [Space]
    [GUIColor(0.1f, 0.886f, 1)] [IconTag("@EditorIcons.Info")]
    public bool elementActivated;

    [GUIColor(0.1f, 0.886f, 1)] [IconTag("@EditorIcons.Info")]
    public bool elementCompleted;

    [GUIColor(0.1f, 0.886f, 1)] [IconTag("@EditorIcons.Info")]
    public bool hasTriggered;

    [HideInInspector]
    public string questElementGUID;

    private bool isLoading;

    #endregion

    #region CALLBACKS

    private void Start()
    {
        questElementGUID = GetComponent<GenerateGUID>().GUID;
    }

    private void OnEnable()
    {
        Actions.OnDoQuestStuffAfterDialogue += OnCheckQuestElementAfterDialogue;
    }


    private void OnDisable()
    {
        Actions.OnDoQuestStuffAfterDialogue -= OnCheckQuestElementAfterDialogue;
    }

    #endregion


    #region ONTRIGGER

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        if (questItem && !questItem.isQuestObject) { return; }

        CheckQuestElement(quest.questGUID);
    }

    #endregion

    #region METHODS

    public void CheckQuestElement(string questID)
    {
        // Do an ID check first
        if (questID != quest.questGUID) { return; }

        // The quest element triggers via the OnTrigger event, either completion or activation of the element 
        // HasMetConditions ensures preconditions are met first, like activate or complete another quest
        // Once conditions are met, hasTriggered avoids multiple triggering or having to track before and after states
        // hasTriggered can also be used in the LoadSave to re-establish the triggered state

        // CheckConditions only reports HasMetConditions to the Console.Log


        if (HasMetConditions() && !hasTriggered)
        {
            ActivateQuestOnEnter();
            CompleteQuestOnEnter();
            EnableAfterDialogue();
            EnableSubElements();
            HandleMasterQuest();
            HideOrRevealAnObject();
            SecondaryCollider();
            hasTriggered = true;
            if (isLoading) { Debug.Log($"Loading of element completed: {quest.questName}"); }
        }

        else if (!HasMetConditions())
        {
            Debug.Log($"Conditions not met: {quest.questName}");
        }

        // 1. activate a quest
        // 2. complete a quest
        // 3. activate (and thereby enable) an element
        // 4. complete this element
        // 5. handle new states
        // 6. be enabled after a dialogue
        // 7. call (enable or activate other elements) subquests
        // 8. handle masterQuests
    }

    private void SecondaryCollider()
    {
        if (!secondaryCollider || !elementActivated) { return; }

        if (secondaryCollider) { secondCollider.enabled = true; }

        Debug.Log($"Secondary collider enabled");
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.556f)]
    private void HideOrRevealAnObject()
    {
        if (!changeAnObject) { return; }

        if (revealObject)
        {
            if (changedObjectRenderer) { changedObjectRenderer.enabled = revealObject; }

            if (changedObjectCollider) { changedObjectCollider.enabled = revealObject; }

            Debug.Log($"Reveal Notification: object visible: {changedObjectRenderer.enabled}");
        }

        if (hideObject)
        {
            if (changedObjectRenderer) { changedObjectRenderer.enabled = !hideObject; }

            if (changedObjectCollider) { changedObjectCollider.enabled = !hideObject; }

            Debug.Log($"Hide Notification - Object visible: {changedObjectRenderer.enabled}");
        }

        changeAnObject = false;
    }


    private void ActivateQuestOnEnter()
    {
        if (!activateOnEnter) { return; }

        quest.isActive = true;
        elementActivated = true;
        // activate element handled in HandleNewStates
        if (!quest.isSubQuest)
        {
            MenuManager.Instance.notifyActiveQuest++;
            Debug.Log($"Notify ActiveQuest++ {MenuManager.Instance.notifyActiveQuest} | {quest.questName}");
        }

        if (spriteRenderer) { spriteRenderer.enabled = true; }

        if (polyCollider) { polyCollider.enabled = true; }

        if (!isLoading) { StartCoroutine(DelayedMessage()); }

        //Debug.Log($"ActivateQuest called: {quest.questName}");
    }

    private void CompleteQuestOnEnter()
    {
        if (!completeOnEnter) { return; }

        quest.MarkThisQuestAsDone(quest.questGUID);

        CompleteElement(); // takes care of collider and renderer
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.482f, 0.486f, 0.156f)]
    private void HandleNewStates()
    {
        if (activateThisQuestFirst)
        {
            if (thenActivateThisQuest) // this means the other quest MUST have been activated before this one can activate
            {
                if (spriteRenderer)
                {
                    spriteRenderer.enabled = true;
                    Debug.Log($"Poly - Activate | {quest.questName} | Visible: {spriteRenderer.enabled}");
                }

                if (polyCollider)
                {
                    polyCollider.enabled = true;
                    Debug.Log($"Poly - Activate | {quest.questName} | Active: {polyCollider.enabled}");
                }
            }

            if (thenCompleteThisQuest) // this means the other quest MUST have been activated before this one can complete
            {
                if (spriteRenderer)
                {
                    spriteRenderer.enabled = enabledAfterDone;
                    Debug.Log($"Poly - Activate | {quest.questName} | Visible: {spriteRenderer.enabled}");
                }

                if (polyCollider)
                {
                    polyCollider.enabled = enabledAfterDone;
                    Debug.Log($"Poly - Activate | {quest.questName} | Active: {polyCollider.enabled}");
                }

                quest.MarkThisQuestAsDone(quest.questGUID);
                CompleteElement();
            }
        }


        if (completeThisQuestFirst) // quest that has to have been completed
        {
            if (thenActivateThisQuest)
            {
                if (spriteRenderer)
                {
                    spriteRenderer.enabled = true;
                    Debug.Log($"Poly - Activate | {quest.questName} | Visible: {spriteRenderer.enabled}");
                }

                if (polyCollider)
                {
                    polyCollider.enabled = true;
                    Debug.Log($"Poly - Activate | {quest.questName} | Active: {polyCollider.enabled}");
                }

                elementActivated = true;
            }

            if (thenCompleteThisQuest) // the condition means another quest MUST have been completed before this can be completed
            {
                if (spriteRenderer)
                {
                    spriteRenderer.enabled = enabledAfterDone;
                    Debug.Log($"Poly - Complete | {quest.questName} | Visible: {spriteRenderer.enabled}");
                }

                if (polyCollider)
                {
                    polyCollider.enabled = enabledAfterDone;
                    Debug.Log($"Poly - Complete | {quest.questName} | Active: {polyCollider.enabled}");
                }

                quest.MarkThisQuestAsDone(quest.questGUID);
                CompleteElement();
            }
        }
    }


    private void EnableAfterDialogue()
    {
        if (!enabledAfterDialogue) { return; }

        if (spriteRenderer) { spriteRenderer.enabled = true; }

        if (polyCollider)
        {
            polyCollider.enabled = true;
            Debug.Log($"Poly: AfterDialogue {quest.questName} | poly status: {polyCollider.enabled}");
        }

        quest.isActive = true;
        if (!quest.isSubQuest)
        {
            MenuManager.Instance.notifyActiveQuest++;
            Debug.Log($"Notify ActiveQuest++ {MenuManager.Instance.notifyActiveQuest} | {quest.questName}");
        }

        elementActivated = true;
    }

    private void EnableSubElements()
    {
        if (!activateSubQuests) { return; }

        foreach (Quest sub in quest.subQuests)
        {
            if (!sub.questElement.HasMetConditions()) { continue; }

            Debug.Log($"Processing subs - Quest: {quest.questName} | SubQuest: {sub.questElement.quest.questName}");
            sub.ActivateQuest(sub.questName);
            sub.questElement.elementActivated = true;
            sub.questElement.HandleNewStates();
        }
    }


    private void CompleteElement()
    {
        elementCompleted = true;
        if (polyCollider)
        {
            polyCollider.enabled = enabledAfterDone;
            Debug.Log($"Quest: {quest.questName} | polyCollider: {polyCollider.enabled}");
        }

        if (spriteRenderer)
        {
            spriteRenderer.enabled = enabledAfterDone;
            Debug.Log($"Quest: {quest.questName} | spriteRender: {spriteRenderer.enabled}");
        }
    }

    private void OnCheckQuestElementAfterDialogue(string trigger, Quest questToActivate, Quest
        questToComplete)
    {
        // Do an ID check first
        if (questToActivate.questGUID != quest.questGUID) { return; }

        // if subquests, then check if they have conditions being met

        //Debug.Log($"AfterDialogue called: {trigger} + {questToActivate}");

        switch (trigger)
        {
            case "activate":
                CheckQuestElement(questToActivate.questGUID);
                StartCoroutine(DelayedMessage());
                break;
            case "complete":
                quest.MarkThisQuestAsDone(quest.questGUID);
                break;
            case "both":
                quest.MarkThisQuestAsDone(quest.questGUID);
                CheckQuestElement(questToActivate.questGUID);
                break;
        }
    }

    private IEnumerator DelayedMessage()
    {
        Debug.Log($"ActivateMessage called");
        yield return new WaitForSeconds(0.2f);
        NotificationFader.instance.CallFadeInOut(
            $"You have activated a new quest: <color=#E0A515>{quest.questName}</color>.{quest.onActivateMessage}",
            quest.questImage,
            5f, 1000, 30);
    }

    private bool HasMetConditions()
    {
        // nothing happens unless conditions are met

        switch (meetConditions)
        {
            case true:
                {
                    bool returnValue = false;
                    if (completeThisQuestFirst && completeThisQuestFirst.isDone)
                    {
                        returnValue = true;
                    }

                    else if (activateThisQuestFirst && activateThisQuestFirst.isActive)
                    {
                        returnValue = true;
                    }

                    if (completeThisQuestFirst && !completeThisQuestFirst.isDone)
                    {
                        returnValue = false;
                    }

                    else if (activateThisQuestFirst && !activateThisQuestFirst.isActive)
                    {
                        returnValue = false;
                    }

                    if (!activateThisQuestFirst && !completeThisQuestFirst)
                    {
                        returnValue = false;
                    }

                    return returnValue;
                }
            default: return true;
        }
    }

    private void HandleMasterQuest()
    {
        if (quest.masterQuest) // if quest has a master quest
        {
            Debug.Log($"Master Quest: {quest.masterQuest.questName} | isComplete? {quest.IsMasterComplete()}");
            if (quest.IsMasterComplete())
            {
                quest.masterQuest.MarkThisQuestAsDone(quest.masterQuest.questGUID);
                quest.masterQuest.questElement.CompleteElement();
                Debug.Log($"Master Quest completed: {quest.masterQuest.questName}");
            }
        }

        if (!quest.isMasterQuest) { return; }

        // no need to keep the colliders active once it has been activated
        if (spriteRenderer) { spriteRenderer.enabled = false; }

        if (polyCollider) { polyCollider.enabled = false; }
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.156f)]
    public void CheckConditions()
    {
        Debug.Log(HasMetConditions()
            ? $"Conditions met for {quest.questName}"
            : $"Conditions not met {quest.questName}");
    }

    #endregion


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.QuestElementsData qed = new(elementActivated, elementCompleted, questElementGUID,
            thenActivateThisQuest, thenCompleteThisQuest, hasTriggered);

        a_SaveData.questElementsList.Add(qed);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        questElementGUID = GetComponent<GenerateGUID>()?.GUID;

        foreach (SaveData.QuestElementsData qed in a_SaveData.questElementsList.Where(qed =>
                     qed.elementGuid == questElementGUID))
        {
            // Save data is ONLY data that can change during the game
            elementActivated = qed.isActivated;
            elementCompleted = qed.isCompleted;
            thenActivateThisQuest = qed.activate;
            thenCompleteThisQuest = qed.complete;
            hasTriggered = qed.hasTriggered;

            if (elementActivated && elementCompleted && hasTriggered)
            {
                if (polyCollider) { polyCollider.enabled = enabledAfterDone; }

                if (spriteRenderer) { spriteRenderer.enabled = enabledAfterDone; }
            }

            if (elementActivated && !elementCompleted && !hasTriggered)
            {
                if (polyCollider) { polyCollider.enabled = true; }

                if (spriteRenderer) { spriteRenderer.enabled = true; }
            }
        }
    }

    #endregion
}