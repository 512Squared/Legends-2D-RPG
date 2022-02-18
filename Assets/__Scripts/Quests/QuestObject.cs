using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestObject : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] string questToCheck;
    [SerializeField] bool activateIfComplete;
    [SerializeField] string onCompleteMessage;
    [SerializeField] float fadeTime;


    private void Awake()
    {
        //QuestsManager.instance.AddQuest(this);
    }
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckForCompletion();
            Debug.Log($"Player picked up a quest object: {questToCheck}");

        }
    }

    public void CheckForCompletion()
    {
        if (QuestsManager.instance.CheckIfComplete(questToCheck) == false)
        {
            QuestsManager.instance.pSystem.Play();
            objectToActivate.SetActive(true);
            NotificationFader.instance.CallFadeInOut($"You have completed the <color=#E0A515>{questToCheck}</color> quest. {onCompleteMessage}", gameObject.GetComponent<SpriteRenderer>().sprite, fadeTime, 1000);
            Debug.Log($"Quest completed: {questToCheck}  | New quest: {objectToActivate.name}");

        }
        else Debug.Log($"Quest not completed: {questToCheck}");
    }


}
