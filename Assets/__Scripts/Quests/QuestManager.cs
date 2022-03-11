using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Collections;
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
    public Dictionary<int, string> questId;
    [HideInInspector]
    public Quest[] questArray;
    
    public Rewardable<QuestRewards>[] rewardables;

    public QuestRewards reward;


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
        questProgress = new Dictionary<string, bool>();
        questId = new Dictionary<int, string>();
        StartCoroutine(InitializeQuestManager());
        rewardables = FindObjectsOfType<Rewardable<QuestRewards>>();
        Debug.Log($"IRewardable Array: {rewardables.Length}");
    }

    public IEnumerator InitializeQuestManager()
    {
        yield return null;
        InitializeQuestID();
        GetQuestList();
        UpdateQuestProgress("", reward);
   
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
            UpdateQuestProgress("", reward);
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

    public void UpdateQuestProgress(string empty, QuestRewards empty2)
    {
        questProgress.Clear();
        questId.Clear();
        foreach (Quest quest in questList)
        {
            questProgress.Add(quest.questName, quest.isDone);
            questId.Add(quest.questID, quest.questName);
        }
    }

    public void InitializeQuestID()
    {
        questArray = questList.ToArray();
        HierarchicalSorting.Sort(questArray);
        for (int i = 0; i < questArray.Length; i++)
        {
            questArray[i].questID = i + 1001;
        }
        questList = questArray.ToList();
    }
    public void HandOutReward(QuestRewards rewardType)
    {
        for (int i = 0; i < rewardables.Length; i++)
        {
            rewardables[i].Reward(rewardType);
        }
    }


    #endregion METHODS
}

