using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestZone : MonoBehaviour
{
    [SerializeField] string questToMark;

    [SerializeField] bool setAsDoneAfterMarking; // set as done
    [SerializeField] bool markOnEnter; // set as done activated onEnter
    private bool markOnOther;  // alternative to OnEnter, e.g. OnFire button

    public bool enabledAfterMarking;
    public bool isMarkable;    

    [Space]
    [SerializeField] string onDoneMessage;
    [SerializeField] float fadeTime;



    private void Update()
    {
        if (markOnOther && isMarkable && Input.GetButtonDown("Fire1"))
        {
            markOnOther = false;
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
                markOnOther = true;
            }
        }
    }

    public void MarkTheQuest()
    {
        if (isMarkable && setAsDoneAfterMarking)
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
            
            NotificationFader.instance.CallFadeInOut($"You have completed the quest <color=#E0A515>{questToMark}</color>. {onDoneMessage}", gameObject.GetComponentInChildren<SpriteRenderer>().sprite, fadeTime, 1000);
            isMarkable = false;
            Debug.Log($"Quest Marked: {questToMark}");
        }
        else
        {
            QuestManager.instance.MarkQuestIncomplete(questToMark);
        }

        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = enabledAfterMarking;
    }

}
