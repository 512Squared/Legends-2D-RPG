using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class QuestElement : MonoBehaviour, ISaveable
{
    [SerializeField] private GameObject questElement;
    [SerializeField] private Quest completeQuestFirst; // quest to be completed first
    [SerializeField] private Quest activateQuestFirst;
    [SerializeField] private bool enableAfterConditionMet;
    [SerializeField] private bool disableAfterConditionsMet;
    public bool isGameObject;
    public bool isItem;
    public bool elementCompleted;
    public bool isActivated;

    private Item _item;
    public PolygonCollider2D polyCollider;

    public SpriteRenderer spriteRenderer;
    public Quest quest;
    private string _questElementGUID;

    private void Start()
    {
        if (isItem)
        {
            _item = gameObject.GetComponent<Item>();
        }

        _questElementGUID = GetComponent<GenerateGUID>().GUID;
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
        if (!collision.CompareTag("Player")) { return; }

        if (elementCompleted) { return; } // i.e. element has been triggered

        if (quest.isActive && quest.markOnEnter)
        {
            quest.MarkTheQuest();
        }

        if (disableAfterConditionsMet)
        {
            polyCollider.enabled = false;
            Debug.Log($"Poly disabled: {quest.questName}");
            elementCompleted = true;
        }

        Debug.Log($"Quest activate called: {quest.questName}");
        if (quest.activateOnEnter) { quest.ActivateAfterEnter(); }
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
        SaveData.QuestElementsData qed = new(isActivated, elementCompleted, _questElementGUID, polyCollider, spriteRenderer);

        a_SaveData.questElementsList.Add(qed);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _questElementGUID = GetComponent<GenerateGUID>()?.GUID;

        foreach (SaveData.QuestElementsData qed in a_SaveData.questElementsList.Where(qed =>
                     qed.elementGuid == _questElementGUID))
        {
            Debug.Log($"Quest Element Loaded: {quest.questName}");
            isActivated = qed.isActivated;
            elementCompleted = qed.isCompleted;
            polyCollider = qed.polyCollider;
            spriteRenderer = qed.spriteRenderer;

            switch (elementCompleted)
            {
                case true:
                    {
                        Debug.Log($"QuestElement Activated and disabled: {quest.questName}");
                        if (polyCollider != null) { polyCollider.enabled = false; }

                        if (spriteRenderer != null) { spriteRenderer.enabled = false; }

                        break;
                    }
            }
        }
    }

    #endregion
}