using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.ParticleSystemJobs;

public class QuestManager : MonoBehaviour
{
    #region SINGLETON

    public static QuestManager instance;

    #endregion SINGLETON

    #region FIELDS

    

    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION

    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Quests")]
    [GUIColor(1f, 0.1f, 0.715f)]
    [SerializeField] string[] questNames;
    [HorizontalGroup("Quests", 120)]
    [BoxGroup("Quests/Complete"), ]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    [SerializeField] bool[] questDoneArray; // each quest also has its own bool for completed - this is the array for the manager to keep track
    [Space]
    public ParticleSystem pSystem;

    #endregion SERIALIZATION

    #region CALLBACKS

    private void Awake()
    {

    }

    private void Start()
    {
        instance = this;
        questDoneArray = new bool[questNames.Length]; // structs always initialise to false
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < questNames.Length; i++)
            {
                print($"Quest: {questNames[i]} | isDone: {CheckIfComplete(questNames[i])}");
            }                        
        }
    }

    #endregion CALLBACKS

    #region SUBSCRIBERS

    private void OnEnable()
    {



    }

    private void OnDisable()
    {



    }

    #endregion SUBSCRIBERS

    #region INVOCATIONS



    #endregion INVOCATIONS

    #region COROUTINES



    #endregion COROUTINES

    #region METHODS

    public int GetQuestNumber(string questToFind)
    {
        for (int i = 0; i < questNames.Length; i++)
        {
            if (questNames[i] == questToFind && i != 0)
            {
                return i;
            }
        }
        return 0;
    }

    public bool CheckIfComplete(string questToCheck)
    {
        int questNumberToCheck = GetQuestNumber(questToCheck);
        if (questNumberToCheck != 0)
        {
            return questDoneArray[questNumberToCheck];
        }
        return false;

    }    

    public void MarkQuestComplete(string questToMark)
    {
        int questNumberToCheck = GetQuestNumber(questToMark);
        questDoneArray[questNumberToCheck] = true;
        Debug.Log($"MarkQuest Complete: {questToMark}");
        UpdateQuestElements(); // check if new elements need activating
    }

    public void MarkQuestIncomplete(string questToMark)
    {
        int questNumberToCheck = GetQuestNumber(questToMark);
        questDoneArray[questNumberToCheck] = false;
        UpdateQuestElements(); // check if new elements need activating
    }

    public void UpdateQuestElements()
    {
        Actions.OnQuestMarkedComplete?.Invoke();
    }


    #endregion METHODS

}

