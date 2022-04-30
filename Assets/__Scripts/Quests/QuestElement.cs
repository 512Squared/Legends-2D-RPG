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

    [ShowIf("isItem")] [Required] [GUIColor(.1f, 0.8f, 0.215f)]
    public SpriteRenderer spriteRenderer;

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
    [GUIColor(.5f, 0.8f, 0.215f)] [ShowIf("itemIsRelic")]
    public RectTransform relicBox;

    [TitleGroup("Quest Bools")] [Space]
    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isItem;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Left")]
    [GUIColor(0.4f, 0.886f, 0.780f)] [ShowIf("isItem")]
    public bool itemIsRelic;

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
    public bool activateSubQuests;

    [HorizontalGroup("Quest Bools/Split")] [VerticalGroup("Quest Bools/Split/Right")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDone;

    [TitleGroup("For information only")] [Space]
    [GUIColor(0.1f, 0.886f, 1)] [IconTag("@EditorIcons.Info")]
    public bool elementActivated;

    [GUIColor(0.1f, 0.886f, 1)] [IconTag("@EditorIcons.Info")]
    public bool elementCompleted;

    [HideInInspector]
    public string questElementGUID;

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

        CheckQuestElement(quest.questGUID);
    }

    #endregion

    #region METHODS

    public void CheckQuestElement(string questID)
    {
        // Do an ID check first
        if (questID != quest.questGUID) { return; }

        if (HasMetConditions())
        {
            ActivateQuestOnEnter();
            CompleteQuest();
            DisableOrEnableElement();
            EnableAfterDialogue();
            EnableSubElements();
            HandleMasterQuest();
        }

        else if (!HasMetConditions()) { Debug.Log($"Conditions not met: {quest.questName}"); }

        // 1. activate a quest
        // 2. complete a quest
        // 3. activate (and thereby enable) an element
        // 4. complete this element
        // 5. disable or  enable a renderer/collider
        // 6. be enabled after a dialogue
        // 7. call (enable or activate other elements) subquests
        // 8. handle masterQuests
    }


    private void ActivateQuestOnEnter()
    {
        if (!activateOnEnter) { return; }

        quest.isActive = true;
        elementActivated = true;
        Debug.Log($"ActivateQuest called: {quest.questName}");
    }


    private void CompleteQuest()
    {
        if (!quest.isActive || !completeOnEnter) { return; }

        quest.MarkThisQuestAsDone(quest.questGUID);
        CompleteElement(); // completing the quest completes the element
    }

    private void DisableOrEnableElement()
    {
        switch (thenActivateThisQuest && !quest.isDone)
        {
            case true:
                {
                    if (spriteRenderer) { spriteRenderer.enabled = true; }

                    if (polyCollider) { polyCollider.enabled = true; }

                    Debug.Log($"Renderers enabled: {quest.questName} | isDone: {quest.isDone}");

                    break;
                }
        }


        switch (quest.isDone || thenCompleteThisQuest)
        {
            case true:
                {
                    if (spriteRenderer) { spriteRenderer.enabled = enabledAfterDone; }

                    if (polyCollider) { polyCollider.enabled = enabledAfterDone; }

                    Debug.Log($"Switch off: {quest.questName} | renderer is on?: {enabledAfterDone}");
                    break;
                }
        }
    }


    private void EnableAfterDialogue()
    {
        if (!enabledAfterDialogue) { return; }

        Debug.Log($"EnableAfterDialogue called: {quest.questName}");

        if (spriteRenderer) { spriteRenderer.enabled = true; }

        if (polyCollider) { polyCollider.enabled = true; }

        quest.isActive = true;
        elementActivated = true;
    }

    private void EnableSubElements()
    {
        if (!activateSubQuests) { return; }

        quest.ActivateSubQuests(quest.questName);


        foreach (Quest sub in quest.subQuests)
        {
            if (!sub.questElement.HasMetConditions()) { continue; }

            sub.ActivateQuest(sub.questName);
            sub.questElement.elementActivated = true;
            sub.questElement.DisableOrEnableElement();
        }
    }


    private void CompleteElement()
    {
        Debug.Log($"CompleteElement called: {quest.questName}");
        elementCompleted = true;
    }

    private void OnCheckQuestElementAfterDialogue(string trigger, Quest questToActivate, Quest
        questToComplete)
    {
        // Do an ID check first
        if (questToActivate.questGUID != quest.questGUID) { return; }

        // if subquests, then check if they have conditions being met


        Debug.Log($"AfterDialogue called: {trigger} + {questToActivate}");

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
        yield return new WaitForSeconds(0.2f);
        NotificationFader.instance.CallFadeInOut(
            $"You have activated a new quest: <color=#E0A515>{quest.questName}</color>.{quest.onActivateMessage}",
            quest.questImage,
            5f,
            1000, 30);
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
                        Debug.Log($"isDone: {true}");
                        if (!activateThisQuestFirst) { meetConditions = false; }
                    }

                    else if (activateThisQuestFirst && activateThisQuestFirst.isActive)
                    {
                        returnValue = true;
                        Debug.Log($"isActive: {true}");
                        if (!completeThisQuestFirst) { meetConditions = false; }
                    }

                    if (completeThisQuestFirst && !completeThisQuestFirst.isDone)
                    {
                        returnValue = false;
                        Debug.Log($"isDone: {false}");
                    }

                    else if (activateThisQuestFirst && !activateThisQuestFirst.isActive)
                    {
                        returnValue = false;
                        Debug.Log($"isActive: {false}");
                    }

                    if (!activateThisQuestFirst && !completeThisQuestFirst)
                    {
                        returnValue = false;
                        Debug.LogError(
                            $"Quest present: {(bool)activateThisQuestFirst} | {(bool)completeThisQuestFirst}");
                    }

                    if (activateThisQuestFirst && completeThisQuestFirst && completeThisQuestFirst.isDone &&
                        activateThisQuestFirst.isActive) { meetConditions = false; }


                    return returnValue;
                }
            default: return true;
        }
    }

    private void HandleMasterQuest()
    {
        if (!quest.isMasterQuest) { return; }

        if (quest.isDone) { return; }

        if (!quest.isActive) { return; }

        foreach (Quest q in quest.subQuests)
        {
            // will also check if conditions are met for activation/completion
            Debug.Log($"MasterQuest Handling: {q.questName}");
            q.questElement.DisableOrEnableElement();
        }
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.156f)]
    public void CheckConditions()
    {
        Debug.Log(HasMetConditions()
            ? $"Conditions met: {quest.questName}"
            : $"Conditions not met: {quest.questName}");
    }

    #endregion


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.QuestElementsData qed = new(elementActivated, elementCompleted, questElementGUID);

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

            switch (elementCompleted)
            {
                case true:
                    {
                        Debug.Log($"QuestElement Activated and disabled: {quest.questName}");
                        if (polyCollider) { polyCollider.enabled = false; }

                        if (spriteRenderer) { spriteRenderer.enabled = false; }

                        break;
                    }
            }
        }
    }

    #endregion
}