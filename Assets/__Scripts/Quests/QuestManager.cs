using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine.ParticleSystemJobs;

public class QuestManager : SerializedMonoBehaviour
{
    #region SINGLETON

    public static QuestManager instance;

    #endregion SINGLETON

    #region FIELDS

    [InlineEditor]
    public List<Quest> questList;
    public Dictionary<string, bool> questProgress;


    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION


    // each quest also has its own bool for completed - this is the array for the manager to keep track

    [Space]
    public ParticleSystem pSystem;

    #endregion SERIALIZATION

    #region CALLBACKS

    private void Start()
    {
        instance = this;
        questList = new List<Quest>();
        GetQuestList();
        questProgress = new Dictionary<string, bool>();
        UpdateQuestProgress("");  
    }


    private void Update()
    {
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
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateQuestProgress("");
        }
    }

    #endregion CALLBACKS

    #region SUBSCRIBERS
    private void OnEnable()
    {
        Actions.OnQuestCompleted += UpdateQuestProgress;        
    }
    private void OnDisable()
    {
        Actions.OnQuestCompleted -= UpdateQuestProgress;
    }

    #endregion SUBSCRIBERS

    #region INVOCATIONS



    #endregion INVOCATIONS

    #region COROUTINES



    #endregion COROUTINES

    #region METHODS


    public bool CheckIfComplete(string questToCheck)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questName == questToCheck && quest.isDone == true)
                return true;
        }

        return false;
    }

    public void SaveQuestData()
    {
        foreach (Quest quest in questList)
        {
            if (quest.isDone)
            {
                PlayerPrefs.SetInt("QuestMarker_" + quest.questName, 1);
            }
            else
            {
                PlayerPrefs.SetInt("QuestMarker_" + quest.questName, 0);
            }
        }
    }

    public void LoadQuestData()
    {
        foreach (Quest quest in questList)
        {
            int valueToSet = 0;
            string keyToUse = "QuestMarker_" + quest.questName;

            if (PlayerPrefs.HasKey(keyToUse))
            {
                valueToSet = PlayerPrefs.GetInt(keyToUse);
            }

            if (valueToSet == 0)
                quest.isDone = false;
            else quest.isDone = true;
        }
    }

    public List<Quest> GetQuestList()
    {
        questList = questList.OrderBy(o => o.questID).ToList();
        return questList;
    }

    public void AddQuests(Quest quest)
    {
        questList.Add(quest);
    }

    public void UpdateQuestProgress(string empty)
    {
        questProgress.Clear();
        foreach (Quest quest in questList)
        {
            questProgress.Add(quest.questName, quest.isDone);
        }
    }

    #endregion METHODS
}

