using UnityEngine;


public class QuestElement : MonoBehaviour, ISaveable
{
    [SerializeField] private GameObject questElement;
    [SerializeField] private Quest completeQuestFirst; // quest to be completed first
    [SerializeField] private Quest activateQuestFirst;
    [SerializeField] private bool enableAfterConditionMet;
    [SerializeField] private bool disableAfterConditionsMet;
    public bool isGameObject;
    public bool isItem;
    private bool _isActive;

    private Item _item;
    public Quest quest;

    private void Start()
    {
        if (isItem)
        {
            _item = gameObject.GetComponent<Item>();
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

        if (_isActive || !quest.activateOnEnter) { return; }

        _isActive = true;
        Debug.Log($"Quest activate called: {quest.questName}");
        quest.ActivateAfterEnter();
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

            _item.spriteRenderer.enabled = enableAfterConditionMet; // is now visible


            _item.polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
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
        if (activateQuestFirst == null) { return; }

        if (enableAfterConditionMet && onQuestActivated == activateQuestFirst.questName)
        {
            quest.isActive = true;
            Debug.Log($"Quest activated: {quest.questName}");
            _item.spriteRenderer.enabled = enableAfterConditionMet; // is now visible
            GetComponent<Item>().polyCollider.enabled = enableAfterConditionMet; // can now be picked up   
        }

        switch (disableAfterConditionsMet)
        {
            case true:
                {
                    //polyCollider.isTrigger = true;
                    GetComponent<Item>().spriteRenderer.enabled = false;

                    if (questElement.GetComponent<FadeObject>() != null)
                    {
                        questElement.GetComponent<FadeObject>().SpriteFade();
                    }

                    break;
                }
        }
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        // a_SaveData.questData.isActiveElement = _isActive;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        // _isActive = a_SaveData.questData.isActiveElement;
    }

    #endregion
}