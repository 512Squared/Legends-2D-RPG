using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[System.Serializable]
public class Quest : MonoBehaviour
{

    #region SERIALIZATION
    [HorizontalGroup("Quests", 100)]
    [BoxGroup("Quests/Image"), HideLabel]
    [GUIColor(1f, 0.1f, 0.715f)]
    public Sprite questImage;
    [HorizontalGroup("Quests", 100)]
    [BoxGroup("Quests/Image"), HideLabel]
    [GUIColor(1f, 0.1f, 0.715f)]
    public Sprite questReward;
    [TextArea(14, 20)]
    [HorizontalGroup("Quests", LabelWidth = 20)]
    [BoxGroup("Quests/Name"), HideLabel]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public string questName;
    [TextArea(14, 20)]
    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Description"), HideLabel]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    public string questDescription;
    [TextArea(14, 20)]
    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Done Message"), HideLabel]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public string onDoneMessage;
    [Space]
    [HorizontalGroup("Info")]
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public int questID;
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public int trophiesAwarded = 10;
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public float messageFadeTime = 5f;
    [Space]
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    public int thisStage;
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    [ShowIf("isMasterQuest")]
    public int totalMasterStages = 1;
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    public int completedStages = 0;


    [Space]
    [HorizontalGroup("Bools"), TableColumnWidth(1200)]
    [VerticalGroup("Bools/a"), LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isActive;
    [VerticalGroup("Bools/a"), LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isDone;
    [VerticalGroup("Bools/a"), LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isItem;
    [VerticalGroup("Bools/a"), LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isSubQuest;
    [Space]
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMasterQuest;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool hasSubQuests;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnEnter;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnClick;
    [Space]
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDone;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool questRewardClaimed;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [ShowIf("isItem")]
    public bool itemIsRelic;

    [Space]
    [ShowInInspector]
    [GUIColor(1f, 0.886f, 0.780f)]
    public QuestRewards rewards;

    [Space]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("If there are no subQuests, this should be empty")]
    [ShowIf("hasSubQuests")]
    public Quest[] subQuests;
    [ShowIf("isSubQuest"), Required]
    [GUIColor(.5f, 0.8f, 0.215f)]
    public Quest masterQuest;
    [HideIf("isMasterQuest")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("drag quest item into this box from hierarchy")]
    [ShowIf("isItem")]
    [SerializeField] PolygonCollider2D polyCollider;
    [ShowIf("isItem")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [PropertyTooltip("drag quest item into this box from hierarchy")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [PropertyTooltip("If this item is a relic, drag the appropriate relicBox from the Relics UI panel")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [ShowIf("itemIsRelic")]
    [SerializeField] RectTransform relicBox;
    [Space]



    [TextArea(2, 15)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public string onActivateMessage;
    [Space]
    [InfoBox("IF THE QUEST IS SET TO INACTIVE AT THE START OF THE GAME, REMEMBER TO DISABLE BOTH THE RENDERER AND THE COLLIDER SO THAT THE OBJECT IS NOT VISIBLE AND NOT ACCIDENTALLY ADDED TO INVENTORY. WHEN THE QUEST IS ACTIVED, THESE WILL BE ACTIVATED AUTOMATICALLY TOO.", InfoMessageType.Warning, "showWarnings")]
    public bool showWarnings = true;

    private bool markAfterClick;
    private Quest[] childQuests;
    private ItemsManager item;
    [HideInInspector]
    public int masterStages;



    #endregion SERIALIZATION


    private void Start()
    {
        QuestManager.instance.AddQuests(this);
        item = GetComponent<ItemsManager>();

        if (isMasterQuest)
        {
            childQuests = GetComponentsInChildren<Quest>();
            trophiesAwarded = 0;
            for (int i = 0; i < childQuests.Length; i++)
            {
                trophiesAwarded += childQuests[i].trophiesAwarded + 15;
            }
        }
    }

    private void OnEnable()
    {
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

    private void Update()
    {
        if (markAfterClick && Input.GetButtonDown("Fire1"))
        {
            markAfterClick = false;
            MarkTheQuest();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive && collision.CompareTag("Player"))
        {
            if (markOnEnter)
            {
                MarkTheQuest();
            }
            else if (markOnClick)
            {
                markAfterClick = true;
            }
        }
    }

    public void MarkTheQuest()
    {
        if (isActive && !isDone)
        {
            isDone = true;
            
            if (isItem && item != null) Inventory.instance.AddItems(item);

            Actions.OnQuestCompleted?.Invoke(questName);
            
            MenuManager.instance.newClaimQuestReward++;
            MenuManager.instance.QuestCompletePanel(this);

            if (item != null && item.pickUpNotice == true) NotifyPlayer();

            ActivateSubQuests(questName);

            Debug.Log($"Quest Completed: {questName}");

            if (!isMasterQuest && !isSubQuest) completedStages++;

            if (isSubQuest)
            {
                masterQuest.completedStages++;
                Debug.Log($"masterQuest: {masterQuest.questName} | subQuest: {questName} | Stages: {masterQuest.completedStages} / {masterQuest.totalMasterStages} ");
                if (masterQuest.MasterQuestComplete())
                {
                    Actions.MarkQuestCompleted?.Invoke(masterQuest.questName);
                }
            }
                        
            if (spriteRenderer != null && isItem) spriteRenderer.enabled = enabledAfterDone;
            if (polyCollider != null && isItem) polyCollider.enabled = enabledAfterDone;
              

        }

        else
        {
            isDone = false;
        }
    }

    private void NotifyPlayer()
    {
        NotificationFader.instance.CallFadeInOut($"You have completed the quest <color=#E0A515>{questName}</color>. {onDoneMessage}", questImage, messageFadeTime, 1000, 30);        
    }

    private void UpdateQuestStatus(string questCompleted)
    {
        if (questCompleted == questName) MarkTheQuest(); // basic but core
    }

    private void ActivateQuest(string questToActivate)
    {
        if (questToActivate == questName)
        {
            isActive = true;
            MenuManager.instance.newQuestActive++;
            if (polyCollider != null)
                polyCollider.enabled = true;
            if (spriteRenderer != null)
                spriteRenderer.enabled = true;
        }
    }

    private void ActivateSubQuests(string activator)
    {
        if (activator == questName)
        {
            if (subQuests.Length > 0)
            {
                for (int i = 0; i < subQuests.Length; i++)
                {
                    subQuests[i].isActive = true;
                }
            }             
        }
    }

    private void ActivateAfterDialogue(string trigger, string questToActivate, string questToComplete)
    {

        if (questToActivate == questName && trigger == "activate")
        {
            ActivateQuest(questToActivate);
            ActivateSubQuests(questToActivate);
            NotificationFader.instance.CallFadeInOut($"You have activated a new quest: <color=#E0A515>{questName}</color>.{onActivateMessage}", questImage, 5f, 1000, 30);
        }
        if (questToComplete == questName && trigger == "complete")
        {
            MarkTheQuest();
        }
        if (questToComplete == questName && trigger == "both")
        {
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
    }

    IEnumerator DelayedMessage()
    {
        yield return new WaitForSeconds(5.1f);
        NotificationFader.instance.CallFadeInOut($"You have activated a new quest: <color=#E0A515>{questName}</color>.{onActivateMessage}", questImage, 5f, 1000, 30);
    }

    private bool MasterQuestComplete()
    {
        if (isMasterQuest)
        {
            for (int i = 1; i < childQuests.Length; i++)
            {
                if (childQuests[i].isDone == false) return false;
            }

            return true;
        }
        else
            return false;
    }

    public bool IsMasterComplete()
    {
        if (masterQuest != null && masterQuest.completedStages == masterQuest.totalMasterStages)
        {
            isActive = false;
            return true;
        }
        else return false;
    }
    
    private void ClaimQuestReward(Quest quest)
    {
        if (quest.questName == questName && !quest.questRewardClaimed)
        {
            Debug.Log($"Quest Reward called: {quest.questName}");
            questRewardClaimed = true;
            MenuManager.instance.newClaimQuestReward--;
            questID += QuestManager.instance.questNumberLimit;

            QuestManager.instance.HandOutReward(rewards);
            MenuManager.instance.UpdateQuestNotifications();

            if (item != null && item.isRelic)
            {
                Debug.Log($"Item: {item.itemName} | isRelic: {item.isRelic}");
                MenuManager.instance.newQuestRelicActive++;

                // DISABLE GRAYSCALE ON RELIC OBJECT IN UI
                Transform[] relicTransforms = relicBox.GetComponentsInChildren<Transform>();
                foreach (Transform t in relicTransforms)
                {
                    t.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    t.GetComponent<Image>().material = null;
                }
                relicBox.GetComponent<Image>().color = new Color32(13, 15, 41, 255);
            }
        }
    }

    public bool MasterHasUnclaimedSubs()
    {
        if (isMasterQuest)
        {
            for (int i = 1; i < childQuests.Length; i++)
            {
                if (childQuests[i].isDone && !childQuests[i].questRewardClaimed) return true;
            }

            return false;
        }
        else
            return false;
    }

}
