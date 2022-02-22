using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestElement : MonoBehaviour
{
    [SerializeField] GameObject questElement;
    [SerializeField] string questToComplete; // which quest to have completed first
    [SerializeField] bool enabledAfterDone; // is this element activated on completion of a quest?




    private void OnEnable()
    {
        Actions.OnQuestMarkedComplete += CheckForCompletion;
    }


    private void OnDisable()
    {
        Actions.OnQuestMarkedComplete -= CheckForCompletion;
    }

    public void CheckForCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToComplete))
        {
            Debug.Log($"Check completion: {questElement.name}");
            questElement.GetComponent<SpriteRenderer>().enabled = enabledAfterDone;
            questElement.GetComponent<ItemsManager>().isQuestObject = false;    
            //QuestManager.instance.pSystem.Play();
        }

        else Debug.Log($"Quest not yet completed: {questToComplete}");
    }

}
