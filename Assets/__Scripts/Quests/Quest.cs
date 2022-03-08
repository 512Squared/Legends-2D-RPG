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
    [SerializeField] string onDoneMessage;
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
    public int totalStages = 1;
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    public int completedStages = 0;
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    public int thisStage;


    [Space]
    [HorizontalGroup("Bools"), TableColumnWidth(1000)]
    [VerticalGroup("Bools/a"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isActive;
    [VerticalGroup("Bools/a"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isDone;
    [VerticalGroup("Bools/a"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isSubQuest;
    [Space]
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMasterQuest;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMarkable;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnEnter;
    [Space]
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnClick;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterDone;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool questRewardClaimed;


    [Space]
    [GUIColor(.5f, 0.8f, 0.215f)]
    public Quest[] subQuests;
    [ShowIf("isSubQuest"), Required]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] Quest masterQuest;
    [HideIf("isMasterQuest")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] PolygonCollider2D polyCollider;
    [HideIf("isMasterQuest")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Space]

    [TextArea(2, 15)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public string onActivateMessage;
    [Space]
    [InfoBox("IF THE QUEST IS SET TO INACTIVE AT THE START OF THE GAME, REMEMBER TO DISABLE BOTH THE RENDERER AND THE COLLIDER SO THAT THE OBJECT IS NOT VISIBLE AND NOT ACCIDENTALLY ADDED TO INVENTORY. WHEN THE QUEST IS ACTIVED, THESE WILL BE ACTIVATED AUTOMATICALLY TOO.", InfoMessageType.Warning, "InstanceShowInfoBoxField"), HideLabel]
    public bool InstanceShowInfoBoxField = true;

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
    }

    private void OnDisable()
    {
        Actions.MarkQuestCompleted -= UpdateQuestStatus;
        Actions.MarkQuestCompleted -= ActivateSubQuests;
        Actions.OnActivateQuest -= ActivateQuest;
        Actions.OnDoQuestStuffAfterDialogue -= ActivateAfterDialogue;
    }

    private void Update()
    {
        if (markAfterClick && isMarkable && Input.GetButtonDown("Fire1"))
        {
            markAfterClick = false;
            MarkTheQuest();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive && isMarkable && collision.CompareTag("Player"))
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
        if (isActive && isMarkable && !isDone)
        {
            isDone = true;
            NotifyPlayer();
            ActivateSubQuests(questName);
            Actions.OnQuestCompleted?.Invoke(questName);
            Debug.Log($"Quest Completed: {questName}");

            if (!isMasterQuest && !isSubQuest) completedStages++;

            if (isSubQuest)
            {
                masterQuest.completedStages++;
                Debug.Log($"masterQuest: {masterQuest.questName} | Stages: {masterQuest.completedStages} / {masterQuest.totalStages}");
                if (masterQuest.MasterQuestComplete())
                {
                    Actions.MarkQuestCompleted?.Invoke(masterQuest.questName);
                }
            }

            if (item != null) item.isQuestObject = false;

            if (spriteRenderer != null) spriteRenderer.enabled = enabledAfterDone;
        }

        else
        {
            isDone = false;
        }

    }


    private void NotifyPlayer()
    {
        NotificationFader.instance.CallFadeInOut($"You have completed the quest <color=#E0A515>{questName}</color>. {onDoneMessage}", questImage, messageFadeTime, 1000, 30);
        isMarkable = false;
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
            for (int i = 0; i < subQuests.Length; i++)
            {
                subQuests[i].isActive = true;
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
            Debug.Log($"childQuests No: {childQuests.Length}");
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
        if (masterQuest != null && masterQuest.completedStages == masterQuest.totalStages)
        {
            isActive = false;
            return true;
        }
        else return false;
    }
}
