using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.ParticleSystemJobs;

public class QuestsManager : MonoBehaviour
{
    #region SINGLETON

    public static QuestsManager instance;

    #endregion SINGLETON

    #region FIELDS

    private List<QuestObject> questList;

    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION

    [HorizontalGroup("Quests")]
    [BoxGroup("Quests/Quests")]
    [GUIColor(1f, 0.1f, 0.715f)]
    [SerializeField] string[] questNames;
    [HorizontalGroup("Quests", 120)]
    [BoxGroup("Quests/Done"), ]
    [GUIColor(0.5f, 0.4f, 0.315f)]
    [SerializeField] bool[] questDone;
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
        questDone = new bool[questNames.Length];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(CheckIfComplete("Find a red gem"));
            MarkQuestComplete("Defeat a dragon");
            MarkQuestInComplete("Add two people to your character party");
        }

        //UpdateQuestObjects();
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
            if (questNames[i] == questToFind)
            {
                Debug.Log($"Quest found: {questToFind}");
                return i;
            }
        }
        Debug.Log($"Quest {questToFind} does not exist");
        return 0;
    }

    public bool CheckIfComplete(string questToCheck)
    {
        int questNumberToCheck = GetQuestNumber(questToCheck);
        if (questNumberToCheck != 0)
        {
            Debug.Log($"Bool: {questDone[questNumberToCheck]}");
            return questDone[questNumberToCheck];
        }
        return false;

    }    

    public void MarkQuestComplete(string questToMark)
    {
        int questNumberToCheck = GetQuestNumber(questToMark);
        questDone[questNumberToCheck] = true;   
    }

    public void MarkQuestInComplete(string questToMark)
    {
        int questNumberToCheck = GetQuestNumber(questToMark);
        questDone[questNumberToCheck] = false;
    }

    public void UpdateQuestObjects()
    {
       if(questList.Count > 0)
        {
            foreach (QuestObject questObject in questList)
            {
                questObject.CheckForCompletion();
                Debug.Log($"Quest list length: {questList.Count}");
            }
        }
    }

    public void AddQuest(QuestObject questObject)
    {
        questList.Add(questObject);
    }

    public void UpdateQuestList()
    {

    }

    #endregion METHODS

}

