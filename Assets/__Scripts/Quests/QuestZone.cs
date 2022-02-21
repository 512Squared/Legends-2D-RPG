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

    [Space]
    [SerializeField] string onDoneMessage;
    [SerializeField] float fadeTime;



    private void Update()
    {
        if (markOnOther && Input.GetButtonDown("Fire1"))
        {
            markOnOther = false;
            MarkTheQuest();
        }

    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        if (setAsDoneAfterMarking)
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
            
            NotificationFader.instance.CallFadeInOut($"<color=#E0A515>{questToMark}</color> completed. {onDoneMessage}", gameObject.GetComponentInChildren<SpriteRenderer>().sprite, fadeTime, 1000);
        }
        else
        {
            QuestManager.instance.MarkQuestIncomplete(questToMark);
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = enabledAfterMarking;
    }

}
