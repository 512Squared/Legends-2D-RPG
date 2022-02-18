using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestObject : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] string questToCheck;
    [SerializeField] bool activateIfComplete;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CheckForCompletion();
            Debug.Log($"Player picked up a quest object: {questToCheck}");
            
        }
    }

    public void CheckForCompletion()
    {
        if(QuestsManager.instance.CheckIfComplete(questToCheck) == false)
        {
            QuestsManager.instance.pSystem.Play();
            objectToActivate.SetActive(true);
            Debug.Log($"New Quest Activated: {objectToActivate.name}");
             
        }
        else Debug.Log($"Quest not completed: {questToCheck}");
    }


}
