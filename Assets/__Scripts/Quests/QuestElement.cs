using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class QuestElement : MonoBehaviour
{
    [SerializeField] GameObject questElement;
    [SerializeField] Quest completeQuestFirst; // quest to be completed first
    [SerializeField] Quest activateQuestFirst;
    [SerializeField] bool enableAfterConditionMet;
    [SerializeField] bool disableAfterConditionsMet;
    public bool isGameObject;
    public bool isItem;
    private bool isActive;
    
    public PolygonCollider2D polyCollider;
    public SpriteRenderer spriteRenderer;
    private ItemsManager item;
    public Quest quest;

    private void Start()
    {
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (isItem) item = gameObject.GetComponent<ItemsManager>();        
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
        if (collision.CompareTag("Player"))
        {
            if (quest.isActive && quest.markOnEnter) quest.MarkTheQuest();

            if (quest.activateOnEnter && !isActive)
            {
                isActive = true;
                quest.ActivateAfterEnter();
            }
        }
    }


    public void CheckForCompletion(string questCompleted)
    {
        if (completeQuestFirst == null) return;
        if (questCompleted == completeQuestFirst.questName) // returns true if completed
        {
            quest.isActive = true;

            if (spriteRenderer != null) spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            if (polyCollider != null) polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
            //QuestManager.instance.pSystem.Play();            
        }

        else if (questCompleted == completeQuestFirst.questName)
        {
            Debug.Log($"Quest not yet completed: {completeQuestFirst} | Quest status: {QuestManager.instance.CheckIfComplete(completeQuestFirst.questName)}");
        }
    }

    public void ActivateElement(string onQuestActivated)
    {
        if (activateQuestFirst == null) return;
        if (enableAfterConditionMet && onQuestActivated == activateQuestFirst.questName)
        {
            quest.isActive = true;
            spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
        }

        if (disableAfterConditionsMet)
        {
            polyCollider.isTrigger = true;
            spriteRenderer.enabled = false;
            if (questElement.GetComponent<FadeObject>() != null) questElement.GetComponent<FadeObject>().SpriteFade();
        }
    }
}
