using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

[System.Serializable]
public class Quest : MonoBehaviour
{
    
    public int questID;
    public string questName;
    [TextArea(1,5)]
    public string questDescription;
    [Space]
    [FoldoutGroup("Quest Bools", expanded: true)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isMarkable, enabledAfterMarking, markOnEnter, markOnClick, setAsDoneAfterMarking, isDone, isSubquest, hasSubQuest, questRewardClaimed;
    [Space]
    [PreviewField]
    public Sprite questImage;
    [PreviewField]
    public Sprite questReward;
    public int totalStages = 1;
    public int completedStages = 0;
    public int stageNumber;
    private PolygonCollider2D polyCollider;
    private SpriteRenderer spriteRenderer;


    [SerializeField] string onDoneMessage;
    [SerializeField] float messageFadeTime;

    private void Start()
    {
        QuestManager.instance.AddQuests(this);
        polyCollider = gameObject.GetComponent<PolygonCollider2D>(); 
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
    }

    private void OnEnable()
    {
        Actions.OnQuestMarkedComplete += EnablePoly;
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
        if (isMarkable && collision.CompareTag("Player"))
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
        if (isMarkable && setAsDoneAfterMarking)
        {
            QuestManager.instance.MarkQuestComplete(questName);
            
            NotificationFader.instance.CallFadeInOut($"You have completed the quest <color=#E0A515>{questName}</color>. {onDoneMessage}", spriteRenderer.sprite, messageFadeTime, 1000);
            isMarkable = false;
            Debug.Log($"Quest Marked: {questName}");
        }
        else
        {
            QuestManager.instance.MarkQuestIncomplete(questName);
        }

        spriteRenderer.enabled = enabledAfterMarking;
    }

    public void EnablePoly()
    {
        if(polyCollider != null)
        polyCollider.enabled = true;
    }

}
