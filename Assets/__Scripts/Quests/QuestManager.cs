using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Collections;

//using UnityEngine.ParticleSystemJobs;

public class QuestManager : SerializedMonoBehaviour
{
    #region SINGLETON

    public static QuestManager Instance;

    #endregion SINGLETON

   
    #region FIELDS

    [InlineEditor]
    public List<Quest> questList;
    private Dictionary<string, bool> _questProgress;
    private Dictionary<int, string> _questId;
    [HideInInspector]
    public Quest[] questArray;
    private List<ItemsManager> _relicList;

    public Rewardable<QuestRewards>[] rewardables;

    private bool _isInitialized;


    #endregion FIELDS

    #region PROPERTIES



    #endregion PROPERTIES

    #region SERIALIZATION


    // each quest also has its own bool for completed - this is the array for the manager to keep track

    [Space]
    public ParticleSystem pSystem;

    #endregion SERIALIZATION

    #region CALLBACKS

    public void Start()
    {
        Instance = this;
        questList = new List<Quest>();
        _relicList = new List<ItemsManager>();
        _questProgress = new Dictionary<string, bool>();
        _questId = new Dictionary<int, string>();
        GetAllQuests();
        StartCoroutine(InitializeQuestManager());
        rewardables = FindObjectsOfType<Rewardable<QuestRewards>>();
        Debug.Log($"IRewardable Array: {rewardables.Length}");
    }

    private void Update()
    {
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

    private IEnumerator InitializeQuestManager()
    {
        yield return null;
        InitializeQuestID();
        GetQuestList();
        UpdateQuestProgress("");
        Debug.Log($"Initialization complete");
    }

    #endregion COROUTINES

    #region METHODS

    private List<Quest> GetAllQuests()
    {
        foreach (Quest go in (Quest[]) Resources.FindObjectsOfTypeAll(typeof(Quest)))
        {
            questList.Add(go);
        }

        return questList;
    }
    public bool CheckIfComplete(string questToCheck)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questName == questToCheck && quest.isDone)
                return true;
        }

        return false;
    }

    public void SaveQuestData()
    {
        foreach (Quest quest in questList)
        {
            PlayerPrefs.SetInt("QuestMarker_" + quest.questName, quest.isDone ? 1 : 0);

            PlayerPrefs.SetInt("QuestReward_" + quest.questName, quest.questRewardClaimed ? 1 : 0);
        }
    }

    public void LoadQuestData(string keyToUse)
    {
        foreach (Quest quest in questList)
        {
            int valueToSet = 0;
            keyToUse = "QuestMarker_" + quest.questName;

            if (PlayerPrefs.HasKey(keyToUse))
            {
                valueToSet = PlayerPrefs.GetInt(keyToUse);
            }

            quest.isDone = valueToSet != 0; //  if valueToSet == 0, quest.isDone = true + inverse

            keyToUse = "QuestReward_" + quest.questName;

            quest.questRewardClaimed = valueToSet != 0;

        }
    }

    public List<Quest> GetQuestList()
    {
        //questList = questList.OrderBy(o => o.questID).ToList();
        if (!_isInitialized)
        {
            foreach (Quest quest in questList)
            {
                if (quest.isMasterQuest) quest.questID -= 500;
                if (quest.isSubQuest) quest.questID -= 500;
            }
            _isInitialized = true;
            return questList;
        }
        else return questList;
    }

    public void AddQuests(Quest quest)
    {
        questList.Add(quest);
    }

    private void UpdateQuestProgress(string empty) // QuestDone panel in Inspector
    {
        _questProgress.Clear();
        _questId.Clear();
        foreach (Quest quest in questList)
        {
            _questProgress.Add(quest.questName, quest.isDone);
            _questId.Add(quest.questID, quest.questName);
        }
    }

    private void InitializeQuestID()
    {
        questArray = questList.ToArray();
        HierarchicalSorting.Sort(questArray);
        for (int i = 0; i < questArray.Length; i++)
        {
            questArray[i].questID = i + 1001;
            if (questArray[i].isActive) MenuManager.instance.notifyActiveQuest++;
            if (questArray[i].itemIsRelic) _relicList.Add(questArray[i].GetComponent<ItemsManager>()); // useful place to build the relic list too           
        }
        questList = questArray.ToList();
        Debug.Log($"Quest List: {questList.Count}");
        Debug.Log($"Relic List: {_relicList.Count} items");

    }

    public void HandOutReward(QuestRewards rewardType) // invoked by a specific quest only
    {
        Debug.Log($"Hand out reward: {rewardType}");
        foreach (var t in rewardables)
        {
            t.Reward(rewardType);
        }
    }

    public List<ItemsManager> GetRelicList()
    {
        return _relicList;
    }


    #endregion METHODS
}

