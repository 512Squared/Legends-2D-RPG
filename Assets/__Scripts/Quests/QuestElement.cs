using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestElement : MonoBehaviour
{
    [SerializeField] GameObject questElement;
    [SerializeField] string questToComplete; // which quest to have completed first
    [SerializeField] bool enabledAfterDone; // is this element activated on completion of a quest?
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
    }


    private void OnDisable()
    {
        Actions.OnQuestCompleted -= CheckForCompletion;
    }

    public void CheckForCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToComplete)) // returns true if completed
        {
            Debug.Log($"Check completion: {questElement.name}");
            spriteRenderer.enabled = enabledAfterDone; // is now visible
            polyCollider.enabled = enabledAfterDone; // can now be picked up   
            item.isQuestObject = false; // can now add to Inventory

            //QuestManager.instance.pSystem.Play();
        }

        else if (!QuestManager.instance.CheckIfComplete(questToComplete))
        {
            Debug.Log($"Quest not yet completed: {questToComplete} | Quest status: {QuestManager.instance.CheckIfComplete(questToComplete)}");
        }
    }


}
