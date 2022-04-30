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

    [TextArea(14, 20)] [HorizontalGroup("Quests")] [BoxGroup("Quests/Description")] [HideLabel]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    public string questDescription;

    [TextArea(14, 20)] [HorizontalGroup("Quests")] [BoxGroup("Quests/Done Message")] [HideLabel]
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

    [Space] [HorizontalGroup("Bools")] [TableColumnWidth(1200)] [VerticalGroup("Bools/a")] [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isActive;

    [VerticalGroup("Bools/a")] [LabelWidth(90)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isSubQuest;

    [Space] [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    [PropertyTooltip("Top level of complex quest")]
    public bool isMasterQuest;

    [VerticalGroup("Bools/b")] [LabelWidth(110)] [GUIColor(0.4f, 0.886f, 0.780f)]
    [PropertyTooltip("A subquest can also have subquests")]
    public bool hasSubQuests;

    [Space] [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool bonusRewardItem;

    [VerticalGroup("Bools/c")] [LabelWidth(160)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool hasQuestElement = true;

    [Space] [GUIColor(.5f, 0.8f, 0.215f)] [ShowIf("hasQuestElement")] [Required]
    [PropertyTooltip("drag questElement into this box")] [CannotBeNullObjectField]
    public QuestElement questElement;

    [Space] [GUIColor(.5f, 0.8f, 0.215f)] [PropertyTooltip("If there are no subQuests, this should be empty")]
    [ShowIf("hasSubQuests")]
    public Quest[] subQuests;

    [Space] [ShowIf("isSubQuest")] [Required] [GUIColor(.5f, 0.8f, 0.215f)]
    public Quest masterQuest;

    [TitleGroup("For information only")] [Space]
    [GUIColor(0.1f, 0.886f, 1)]
    [IconTag("@EditorIcons.Info")] [TableColumnWidth(160, true)]
    public bool isDone;

    [GUIColor(0.1f, 0.886f, 1)]
    [IconTag("@EditorIcons.Info")] [TableColumnWidth(160, true)]
    public bool questRewardClaimed;

    [Space] [ShowInInspector] [GUIColor(1f, 0.886f, 0.780f)]
    public QuestRewards rewards;

    [Space] [TextArea(2, 15)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public string onActivateMessage;

    [GUIColor(0.4f, 0.886f, 0.780f)] public bool notifyOnActivate;

    [Space] [InfoBox(
        "IF THE QUEST IS SET TO INACTIVE AT THE START OF THE GAME, REMEMBER TO DISABLE BOTH THE RENDERER AND THE COLLIDER ON THE QUEST ELEMENT SO THAT THE OBJECT IS NOT VISIBLE AND NOT ACCIDENTALLY ADDED TO INVENTORY. WHEN THE QUEST IS ACTIVATED, THESE WILL BE ACTIVATED AUTOMATICALLY TOO.",
        InfoMessageType.Warning, "showWarnings")]
    public bool showWarnings = true;

    private Quest[] _childQuests; // child quests are all the Master's subquests

    [HideInInspector]
    public int masterStages;

    [HideInInspector]
    public bool isExpanded = true;

    [HideInInspector]
    public bool toggleMasterSub;

    [HideInInspector]
    public bool resetChildren; // when Master Quest reward is claimed, all toggle settings in children are reset


    [HideInInspector]
    public string questGUID;

    #endregion SERIALIZATION

    #region METHODS

    private void Start()
    {
        if (isMasterQuest)
        {
            _childQuests = GetComponentsInChildren<Quest>();
        }

        questGUID = GetComponent<GenerateGUID>().GUID;
    }

    private void OnEnable()
    {
        //QuestManager.instance.AddQuests(this);
        Actions.MarkQuestCompleted += ActivateSubQuests;
        Actions.MarkQuestCompleted += UpdateQuestStatus;
        Actions.OnActivateQuest += ActivateQuest;
        Actions.OnClaimQuestRewards += ClaimQuestReward;
    }

    private void OnDisable()
    {
        Actions.MarkQuestCompleted -= UpdateQuestStatus;
        Actions.MarkQuestCompleted -= ActivateSubQuests;
        Actions.OnActivateQuest -= ActivateQuest;
        Actions.OnClaimQuestRewards -= ClaimQuestReward;
    }

    public void MarkThisQuestAsDone(string questID_)
    {
        // Do an ID check first
        if (questGUID != questID_) { return; }

        if (!isActive || isDone) { return; }

        Debug.Log($"Quest completed: {questName}");
        isDone = true;
        completedStages++;

        // some modifications to help with UI sorting 
        questID -= 1000;
        if (isMasterQuest)
        {
            questID -= 500;
        }

        if (questElement && questElement.isItem)
        {
            Inventory.Instance.AddItems(questElement.questItem);
        }

        // invoke a popup notification on quest completion
        Actions.OnQuestCompleted?.Invoke(questName);

        // UI stuff
        MenuManager.Instance.notifyQuestReward++;
        MenuManager.Instance.notifyActiveQuest--;
        MenuManager.Instance.QuestCompletePanel(this, GetChildQuests());

        // notification for subquest completion - enable or disable with 'pickUpNotice' bool
        if (questElement && questElement.questItem && questElement.questItem.pickUpNotice)
        {
            NotifyPlayer();
        }

        // completing some quests enables subquests
        ActivateSubQuests(questName);


        // SUBQUEST PROCESSING

        switch (isSubQuest)
        {
            case true:
                {
                    masterQuest.completedStages++;

                    // check if master quest is now complete, if so, mark as complete
                    if (masterQuest.MasterQuestComplete())
                    {
                        Actions.MarkQuestCompleted?.Invoke(masterQuest.questName);
                    }

                    break;
                }
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
        if (questCompleted != questName) { return; }

        Debug.Log($"Update called: {questCompleted}");
        MarkThisQuestAsDone(questGUID); // basic but core
    }

    public void ActivateQuest(string questToActivate)
    {
        if (questToActivate != questName) { return; }

        isActive = true;
        MenuManager.Instance.notifyActiveQuest++;
    }

    public void ActivateSubQuests(string questsToActivate)
    {
        if (questsToActivate != questName) { return; }


        if (subQuests.Length <= 0) { return; }

        foreach (Quest q in subQuests)
        {
            q.isActive = true;
            Debug.Log($"SubQuest activated: {q.questName}");
        }
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

        if (questElement == null || questElement.questItem == null || !questElement.questItem.isRelic) { return; }

        Debug.Log($"Item: {questElement.questItem.itemName} | isRelic: {questElement.questItem.isRelic}");

        MenuManager.Instance.notifyRelicActive++;
        DisableGreyScale();
    }

    private void DisableGreyScale()
    {
        // DISABLE GRAYSCALE ON RELIC OBJECT IN UI
        Transform[] relicTransforms = questElement.relicBox.GetComponentsInChildren<Transform>();
        foreach (Transform t in relicTransforms)
        {
            t.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            t.GetComponent<Image>().material = null;
        }

        questElement.relicBox.GetComponent<Image>().color = new Color32(13, 15, 41, 255);
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

    #region IMPLEMENTATION OF ISAVEABLE

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.QuestData qd = new(questGUID, completedStages, questRewardClaimed,
            isExpanded, toggleMasterSub, isActive, isDone, hasQuestElement);

        a_SaveData.questDataList.Add(qd);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.QuestData questData in a_SaveData.questDataList.Where(questData =>
                     questData.uniqueGuid == questGUID))
        {
            completedStages = questData.completedStages;
            questRewardClaimed = questData.questRewardClaimed;
            isExpanded = questData.isExpanded;
            toggleMasterSub = questData.toggleSub;
            isActive = questData.isActive;
            isDone = questData.isDone;
            hasQuestElement = questData.hasQuestElement;


            switch (isDone)
            {
                case true when questElement != null && questRewardClaimed && questElement.itemIsRelic:
                    DisableGreyScale();
                    questElement.polyCollider.enabled = false;
                    questElement.spriteRenderer.enabled = false;
                    Debug.Log($"quest relic saved: {questName}");
                    break;

                case true when questElement != null && !questRewardClaimed && questElement.itemIsRelic:
                    if (questElement.questItem == null)
                    {
                        Debug.Log($"Null Check: {questName}");
                    }
                    else
                    {
                        questElement.polyCollider.enabled = false;
                        questElement.spriteRenderer.enabled = false;
                    }

                    break;
            }

            break;
        }
    }

    #endregion
}