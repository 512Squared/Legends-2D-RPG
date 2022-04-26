using System.Collections;
using UnityEngine;
using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[Serializable]
[RequireComponent(typeof(GenerateGUID))]
public class Quest : MonoBehaviour, ISaveable
{
    #region SERIALIZATION

    [HorizontalGroup("Quests", 100)] [BoxGroup("Quests/Image")] [HideLabel] [GUIColor(1f, 0.1f, 0.715f)]
    public Sprite questImage;

    [HorizontalGroup("Quests", 100)] [BoxGroup("Quests/Image")] [HideLabel] [GUIColor(1f, 0.1f, 0.715f)]
    public Sprite questReward;

    [TextArea(14, 20)]
    [HorizontalGroup("Quests", LabelWidth = 20)]
    [BoxGroup("Quests/Name")]
    [HideLabel]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public string questName;

    [TextArea(14, 20)]
    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Description")]
    [HideLabel]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    public string questDescription;

    [TextArea(14, 20)]
    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Done Message")]
    [HideLabel]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public string onDoneMessage;

    [Space] [HorizontalGroup("Info")] [VerticalGroup("Info/a")] [GUIColor(1f, 1f, 0.215f)]
    public int questID;

    [VerticalGroup("Info/a")] [GUIColor(1f, 1f, 0.215f)]
    public int trophiesAwarded = 10;

    [VerticalGroup("Info/a")] [GUIColor(1f, 1f, 0.215f)]
    public float messageFadeTime = 5f;

    [Space] [VerticalGroup("Info/b")] [GUIColor(1f, 1f, 0.215f)]
    public int thisStage;

    [VerticalGroup("Info/b")] [GUIColor(1f, 1f, 0.215f)] [ShowIf("isMasterQuest")]
    public int totalMasterStages = 1;

    [VerticalGroup("Info/b")] [GUIColor(1f, 1f, 0.215f)]
    public int completedStages = 0;


    [Space]
    [HorizontalGroup("Bools")]
    [TableColumnWidth(1200)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isActive;

    [VerticalGroup("Bools/a")] [LabelWidth(90)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isDone;

    [VerticalGroup("Bools/a")] [LabelWidth(90)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isItem;

    [VerticalGroup("Bools/a")] [LabelWidth(90)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isSubQuest;

    [Space] [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMasterQuest;

    [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool hasSubQuests;

    [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnEnter;

    [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool activateOnEnter;

    [Space] [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDone;

    [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool questRewardClaimed;

    [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool hasElement; // but is not an item, i.e. it's a collider

    [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)] [ShowIf("isItem")]
    public bool itemIsRelic;

    [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool bonusRewardItem;

    [Space] [ShowInInspector] [GUIColor(1f, 0.886f, 0.780f)]
    public QuestRewards rewards;

    [Space]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("If there are no subQuests, this should be empty")]
    [ShowIf("hasSubQuests")]
    public Quest[] subQuests;

    [Space]
    [ShowIf("isSubQuest")] [Required] [GUIColor(.5f, 0.8f, 0.215f)]
    public Quest masterQuest;

    [Space]
    [PropertyTooltip("If this item is a relic, drag the appropriate relicBox from the Relics UI panel")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [ShowIf("itemIsRelic")]
    [SerializeField]
    private RectTransform relicBox;

    [ShowIf("isItem")] [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("drag quest item into this box from hierarchy")]
    public Item questItem;

    [ShowIf("hasElement")] [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("drag quest element into this box from hierarchy")]
    public QuestElement questElement;


    [Space] [TextArea(2, 15)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public string onActivateMessage;

    [GUIColor(0.4f, 0.886f, 0.780f)] public bool notifyOnActivate;

    [Space]
    [InfoBox(
        "IF THE QUEST IS SET TO INACTIVE AT THE START OF THE GAME, REMEMBER TO DISABLE BOTH THE RENDERER AND THE COLLIDER ON THE GAMEOBJECT SO THAT THE OBJECT IS NOT VISIBLE AND NOT ACCIDENTALLY ADDED TO INVENTORY. WHEN THE QUEST IS ACTIVATED, THESE WILL BE ACTIVATED AUTOMATICALLY TOO.",
        InfoMessageType.Warning, "showWarnings")]
    public bool showWarnings = true;

    private Quest[] _childQuests; // child quests are all the Master's subquests

    [HideInInspector] public int masterStages;

    //[HideInInspector]
    public bool isExpanded = true;

    //[HideInInspector]
    public bool toggleMasterSub;

    [HideInInspector]
    public bool resetChildren; // when Master Quest reward is claimed, all toggle settings in children are reset

    private string _questGuid;

    #endregion SERIALIZATION

    #region Methods

    private void Start()
    {
        if (isMasterQuest)
        {
            _childQuests = GetComponentsInChildren<Quest>();
        }

        _questGuid = GetComponent<GenerateGUID>().GUID;
    }

    private void OnEnable()
    {
        //QuestManager.instance.AddQuests(this);
        Actions.MarkQuestCompleted += ActivateSubQuests;
        Actions.MarkQuestCompleted += UpdateQuestStatus;
        Actions.OnActivateQuest += ActivateQuest;
        Actions.OnDoQuestStuffAfterDialogue += ActivateAfterDialogue;
        Actions.OnClaimQuestRewards += ClaimQuestReward;
    }

    private void OnDisable()
    {
        Actions.MarkQuestCompleted -= UpdateQuestStatus;
        Actions.MarkQuestCompleted -= ActivateSubQuests;
        Actions.OnActivateQuest -= ActivateQuest;
        Actions.OnDoQuestStuffAfterDialogue -= ActivateAfterDialogue;
        Actions.OnClaimQuestRewards -= ClaimQuestReward;
    }

    public void MarkTheQuest()
    {
        if (isActive && !isDone)
        {
            isDone = true;
            if (questElement != null) { questElement.elementCompleted = true; }

            questID -= 1000;
            if (isMasterQuest)
            {
                questID -= 500;
            }

            if (isItem && questItem != null)
            {
                Inventory.Instance.AddItems(questItem);
            }

            Actions.OnQuestCompleted?.Invoke(questName);

            MenuManager.Instance.notifyQuestReward++;
            MenuManager.Instance.notifyActiveQuest--;
            MenuManager.Instance.QuestCompletePanel(this, GetChildQuests());

            if (questItem != null && questItem.pickUpNotice)
            {
                NotifyPlayer();
            }

            ActivateSubQuests(questName);

            if (!isMasterQuest && !isSubQuest)
            {
                completedStages++;
            }

            if (isSubQuest)
            {
                masterQuest.completedStages++;
                if (masterQuest.MasterQuestComplete())
                {
                    Actions.MarkQuestCompleted?.Invoke(masterQuest.questName);
                }
            }

            if (isItem)
            {
                questItem.spriteRenderer.enabled = enabledAfterDone;
                questItem.polyCollider.enabled = enabledAfterDone;
                Debug.Log($"Quest element. Renderer disabled: {questItem.itemName}");
            }

            if (hasElement)
            {
                questElement.spriteRenderer.enabled = enabledAfterDone;
                questElement.polyCollider.enabled = enabledAfterDone;
            }

            if (activateOnEnter) { ActivateAfterEnter(); }
        }

        else
        {
            isDone = false;
        }
    }

    private void NotifyPlayer()
    {
        NotificationFader.instance.CallFadeInOut(
            $"You have completed the quest <color=#E0A515>{questName}</color>. {onDoneMessage}", questImage,
            messageFadeTime, 1000, 30);
    }

    private void UpdateQuestStatus(string questCompleted)
    {
        if (questCompleted == questName)
        {
            MarkTheQuest(); // basic but core
        }
    }

    private void ActivateQuest(string questToActivate)
    {
        if (questToActivate == questName)
        {
            isActive = true;
            MenuManager.Instance.notifyActiveQuest++;
            if (isItem)
            {
                questItem.polyCollider.enabled = true;
                questItem.spriteRenderer.enabled = true;
                Debug.Log($"Renderer enabled: {questItem.itemName}");
            }
        }
    }

    private void ActivateSubQuests(string activator)
    {
        if (activator != questName) { return; }

        if (subQuests.Length <= 0) { return; }

        foreach (Quest q in subQuests)
        {
            q.isActive = true;
        }
    }

    private void ActivateAfterDialogue(string trigger, string questToActivate, string questToComplete)
    {
        if (questToActivate == questName && trigger == "activate")
        {
            ActivateQuest(questToActivate);
            ActivateSubQuests(questToActivate);
            NotificationFader.instance.CallFadeInOut(
                $"You have activated a new quest: <color=#E0A515>{questName}</color>.{onActivateMessage}", questImage,
                5f, 1000, 30);
        }

        if (questToComplete == questName && trigger == "complete")
        {
            MarkTheQuest();
        }

        if (questToComplete != questName || trigger != "both") { return; }

        if (questToComplete == questName)
        {
            MarkTheQuest();
        }

        if (questToActivate == questName)
        {
            ActivateQuest(questToActivate);
            StartCoroutine(DelayedMessage());
        }
    }

    public void ActivateAfterEnter()
    {
        ActivateQuest(questName);
        ActivateSubQuests(questName);
        if (notifyOnActivate)
        {
            NotificationFader.instance.CallFadeInOut(
                $"You have activated a new quest: <color=#E0A515>{questName}</color>.{onActivateMessage}", questImage,
                5f, 1000, 30);
        }
    }

    private IEnumerator DelayedMessage()
    {
        yield return new WaitForSeconds(5.1f);
        NotificationFader.instance.CallFadeInOut(
            $"You have activated a new quest: <color=#E0A515>{questName}</color>.{onActivateMessage}", questImage, 5f,
            1000, 30);
    }

    private bool MasterQuestComplete()
    {
        if (isMasterQuest)
        {
            for (int i = 1; i < _childQuests.Length; i++)
            {
                if (_childQuests[i].isDone == false)
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsMasterComplete()
    {
        if (masterQuest != null && masterQuest.completedStages == masterQuest.totalMasterStages)
        {
            isActive = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ClaimQuestReward(Quest quest)
    {
        if (quest.questName != questName || quest.questRewardClaimed) { return; }

        Debug.Log($"Quest Reward called: {quest.questName} | questID: {quest.questID}");
        questRewardClaimed = true;
        MenuManager.Instance.notifyQuestReward--;

        QuestManager.Instance.HandOutReward(rewards);
        MenuManager.Instance.UpdateQuestNotifications();

        if (questItem == null || !questItem.isRelic) { return; }

        Debug.Log($"Item: {questItem.itemName} | isRelic: {questItem.isRelic}");
        MenuManager.Instance.notifyRelicActive++;

        DisableGreyScale();
    }

    private void DisableGreyScale()
    {
        // DISABLE GRAYSCALE ON RELIC OBJECT IN UI
        Transform[] relicTransforms = relicBox.GetComponentsInChildren<Transform>();
        foreach (Transform t in relicTransforms)
        {
            t.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            t.GetComponent<Image>().material = null;
        }

        relicBox.GetComponent<Image>().color = new Color32(13, 15, 41, 255);
    }

    public bool MasterHasUnclaimedSubs()
    {
        if (isMasterQuest)
        {
            for (int i = 1; i < _childQuests.Length; i++)
            {
                if (_childQuests[i].isDone && !_childQuests[i].questRewardClaimed)
                {
                    return true;
                }
            }

            return false;
        }
        else
        {
            return false;
        }
    }

    public Quest[] GetChildQuests()
    {
        return isMasterQuest ? _childQuests : null;
    }

    #endregion

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.QuestData qd = new(_questGuid, questName, completedStages, questRewardClaimed,
            isExpanded, toggleMasterSub, isActive, isDone);

        a_SaveData.questDataList.Add(qd);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.QuestData questData in a_SaveData.questDataList.Where(questData =>
                     questData.uniqueGuid == _questGuid))
        {
            completedStages = questData.completedStages;
            questRewardClaimed = questData.questRewardClaimed;
            isExpanded = questData.isExpanded;
            toggleMasterSub = questData.toggleSub;
            isActive = questData.isActive;
            isDone = questData.isDone;
            switch (isDone)
            {
                case true when questRewardClaimed && itemIsRelic:
                    DisableGreyScale();
                    questItem.polyCollider.enabled = false;
                    questItem.spriteRenderer.enabled = false;
                    Debug.Log($"quest relic saved: {questName}");
                    break;

                case true when !questRewardClaimed && itemIsRelic:
                    if (questItem == null)
                    {
                        Debug.Log($"Null Check: {questName}");
                    }
                    else
                    {
                        questItem.polyCollider.enabled = false;
                        questItem.spriteRenderer.enabled = false;
                    }

                    break;
            }

            break;
        }
    }
}