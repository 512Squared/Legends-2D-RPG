using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[System.Serializable]
public class Quest : MonoBehaviour
{

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
    [BoxGroup("Quests/Message"), HideLabel]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] string onDoneMessage;
    [Space]
    [HorizontalGroup("Info")]
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public int questID;
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public int totalStages = 1;
    [VerticalGroup("Info/a")]
    [GUIColor(1f, 1f, 0.215f)]
    public int completedStages = 0;
    [Space]
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    public int stageNumber;
    [VerticalGroup("Info/b")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] float messageFadeTime;

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
    public bool isSubquest;
    [VerticalGroup("Bools/a"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool hasSubQuest;
    [Space]
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMarkable;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnEnter;
    [VerticalGroup("Bools/b"), LabelWidth(100)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool markOnClick;
    [Space]
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool questRewardClaimed;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool enabledAfterMarking;
    [VerticalGroup("Bools/c"), LabelWidth(160)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool setAsDoneAfterMarking;
    [Space]


    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] PolygonCollider2D polyCollider;
    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] SpriteRenderer spriteRenderer;

    private Quest[] quests;

    private void Start()
    {
        QuestManager.instance.AddQuests(this);
        quests = GetComponentsInChildren<Quest>();
        for (int i = 0; i < quests.Length; i++)
        {
            Debug.Log($"MainQuest: {questName} | SubQuests: {quests[i].questName}");
        }
    }

    private void OnEnable()
    {
        Actions.MarkQuestCompleted += UpdateQuestStatus;
        Actions.OnActivateQuest += ActivateQuest;
    }

    private void OnDisable()
    {
        Actions.MarkQuestCompleted -= UpdateQuestStatus;
        Actions.OnActivateQuest -= ActivateQuest;
    }

    private void Update()
    {
        if (markOnClick && isMarkable && Input.GetButtonDown("Fire1"))
        {
            markOnClick = false;
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
            else
            {
                markOnClick = true;
            }
        }
    }

    public void MarkTheQuest()
    {
        if (isActive && isMarkable && setAsDoneAfterMarking)
        {
            isDone = true;
            EnablePoly();
            NotifyPlayer();
            ActivateSubQuests(questName);
            Actions.OnQuestCompleted?.Invoke();
            Debug.Log($"Quest Completed: {questName}");
        }

        else
        {
            isDone = false;
        }

        spriteRenderer.enabled = enabledAfterMarking;
    }

    public void EnablePoly()
    {
        if (polyCollider != null)
            polyCollider.enabled = true;
    }
    private void NotifyPlayer()
    {
        NotificationFader.instance.CallFadeInOut($"You have completed the quest <color=#E0A515>{questName}</color>. {onDoneMessage}", spriteRenderer.sprite, messageFadeTime, 1000, 30);
        isMarkable = false;
    }

    private void UpdateQuestStatus(string questCompleted)
    {
        if (questCompleted == questName) MarkTheQuest();
    }

    private void ActivateQuest(string questToActivate)
    {
        if (questToActivate == questName) isActive = true;
    }

    private void ActivateSubQuests(string questCompleted)
    {
        if (questCompleted == questName)
        {
            Quest[] quests = GetComponentsInChildren<Quest>();
            for (int i = 0; i < quests.Length; i++)
            {
                quests[i].isActive = true;
            }
        }
    }

}
