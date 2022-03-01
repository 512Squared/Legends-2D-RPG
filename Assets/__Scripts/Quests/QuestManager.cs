using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;
using System;
using UnityEngine.ParticleSystemJobs;

public class QuestManager : MonoBehaviour
{
    #region SINGLETON

    public static QuestManager instance;

    #endregion SINGLETON

    #region FIELDS

    [TableList]
    public List<QuestZone> questList;


    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION

    [HorizontalGroup("Quests", 280)]
    [BoxGroup("Quests/Quests")]
    [GUIColor(1f, 0.1f, 0.715f)]
    public string[] questNames;
    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Description")]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    public string[] questDescription;
    [HorizontalGroup("Quests", 80)]
    [BoxGroup("Quests/Complete")]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    public bool[] questDoneArray;
    [HorizontalGroup("Images")]
    [BoxGroup("Images/Image")]
    [GUIColor(0.9f, 0.5f, 0.615f)]
    public Sprite[] questImage;

    // each quest also has its own bool for completed - this is the array for the manager to keep track

    [Space]
    public ParticleSystem pSystem;

    #endregion SERIALIZATION

    #region CALLBACKS

    private void Start()
    {
        instance = this;
        questDoneArray = new bool[questNames.Length]; // structs always initialise to false
        questList = new List<QuestZone>();
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

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log($"Data has been saved");
            SaveQuestData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log($"Data has been loaded");
            LoadQuestData();
        }
    }

    #endregion CALLBACKS

    #region SUBSCRIBERS

    private void OnEnable()
    {
        Actions.OnMarkQuestComplete += MarkQuestComplete;
        Actions.OnMarkQuestComplete += MarkQuestIncomplete;
    }

    private void OnDisable()
    {
        Actions.OnMarkQuestComplete -= MarkQuestComplete;
        Actions.OnMarkQuestComplete -= MarkQuestIncomplete;
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
            //Debug.Log($"Quest checked: {i}");
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

    public void SaveQuestData()
    {
        for (int i = 0; i < questNames.Length; i++)
        {
            if (questDoneArray[i])
            {
                PlayerPrefs.SetInt("QuestMarker_" + questNames[i], 1);
            }
            else
            {
                PlayerPrefs.SetInt("QuestMarker_" + questNames[i], 0);
            }
        }
    }

    public void LoadQuestData()
    {
        for (int i = 0; i < questNames.Length; i++)
        {
            int valueToSet = 0;
            string keyToUse = "QuestMarker_" + questNames[i];

            if (PlayerPrefs.HasKey(keyToUse))
            {
                valueToSet = PlayerPrefs.GetInt(keyToUse);
            }

            if (valueToSet == 0)
                questDoneArray[i] = false;
            else questDoneArray[i] = true;
        }
    }

    public QuestManager GetQuestList()
    {
        return this;

    }

    public void AddQuests(QuestZone quest)
    {
        questList.Add(quest);
    }
    #endregion METHODS

}

