using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestElement : MonoBehaviour
{
    [SerializeField] GameObject questElement;
    [SerializeField] string completeQuestFirst; // which quest to have completed first
    [SerializeField] string activateQuestFirst;
    [SerializeField] bool enableAfterConditionMet; // is this element activated on completion of a quest?
    private PolygonCollider2D polyCollider;
    private SpriteRenderer spriteRenderer;
    private ItemsManager item;

    private void Start()
    {
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        item = gameObject.GetComponent<ItemsManager>();        
    }

    private void OnEnable()
    {
        Actions.OnQuestCompleted += CheckForCompletion;
        Actions.OnActivateQuest += ActivateElement;
    }


    private void OnDisable()
    {
        Actions.OnQuestCompleted -= CheckForCompletion;
        Actions.OnActivateQuest -= ActivateElement;
    }

    public void CheckForCompletion(string questCompleted)
    {
        if (questCompleted == completeQuestFirst) // returns true if completed
        {
            //Debug.Log($"Check completion: {questElement.name}");
            spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
            ////item.isQuestObject = false; // can now add to Inventory

            //QuestManager.instance.pSystem.Play();            
        }

        else if (questCompleted == completeQuestFirst)
        {
            Debug.Log($"Quest not yet completed: {completeQuestFirst} | Quest status: {QuestManager.instance.CheckIfComplete(completeQuestFirst)}");
        }
    }

    public void ActivateElement(string onQuestActivated)
    {
        if (enableAfterConditionMet && onQuestActivated == activateQuestFirst)
        {
            spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
        }

    }




}
