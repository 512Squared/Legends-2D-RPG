using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class QuestElement : MonoBehaviour
{
    [SerializeField] private GameObject questElement;
    [SerializeField] private Quest completeQuestFirst; // quest to be completed first
    [SerializeField] private Quest activateQuestFirst;
    [SerializeField] private bool enableAfterConditionMet;
    [SerializeField] private bool disableAfterConditionsMet;
    public bool isGameObject;
    public bool isItem;
    private bool _isActive;

    private Item item;
    public Quest quest;

    private void Start()
    {
        if (isItem)
        {
            item = gameObject.GetComponent<Item>();
        }
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (!quest.activateOnEnter && _isActive)
        {
            Debug.Log($"Quest not activated on enter: {quest.questName}");
        }

        if (quest.isActive && quest.markOnEnter)
        {
            quest.MarkTheQuest();
        }

        if (quest.activateOnEnter)
        {
            _isActive = true;
            Debug.Log($"Quest activate called: {quest.questName}");
            quest.ActivateAfterEnter();
        }
    }


    public void CheckForCompletion(string questCompleted)
    {
        if (completeQuestFirst == null)
        {
            return;
        }

        if (questCompleted == completeQuestFirst.questName) // returns true if completed
        {
            quest.isActive = true;

            if (item.spriteRenderer.enabled != null)
            {
                item.spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            }

            if (item.polyCollider != null)
            {
                item.polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
            }
            //QuestManager.instance.pSystem.Play();            
        }

        else if (questCompleted == completeQuestFirst.questName)
        {
            Debug.Log(
                $"Quest not yet completed: {completeQuestFirst} | Quest status: {QuestManager.Instance.CheckIfComplete(completeQuestFirst.questName)}");
        }
    }

    public void ActivateElement(string onQuestActivated) // activates from dialogue controller
    {
        if (activateQuestFirst != null)
        {
            if (enableAfterConditionMet && onQuestActivated == activateQuestFirst.questName)
            {
                quest.isActive = true;
                Debug.Log($"Quest activated: {quest.questName}");
                item.spriteRenderer.enabled = enableAfterConditionMet; // is now visible
                GetComponent<Item>().polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
            }

            if (disableAfterConditionsMet)
            {
                //polyCollider.isTrigger = true;
                GetComponent<Item>().spriteRenderer.enabled = false;

                if (questElement.GetComponent<FadeObject>() != null)
                {
                    questElement.GetComponent<FadeObject>().SpriteFade();
                }
            }
        }
    }
}