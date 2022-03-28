using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
    private List<ItemsManager> relicList;

    public Rewardable<QuestRewards>[] rewardables;

    private bool isInitialized;


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
        instance = this; 
        questList = new List<Quest>();
        relicList = new List<ItemsManager>();
        questProgress = new Dictionary<string, bool>();
        questId = new Dictionary<int, string>();
        GetAllQuests();
        StartCoroutine(InitializeQuestManager());
        rewardables = FindObjectsOfType<Rewardable<QuestRewards>>();
        Debug.Log($"IRewardable Array: {rewardables.Length}");
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
    
    public IEnumerator InitializeQuestManager()
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
        foreach (Quest go in Resources.FindObjectsOfTypeAll(typeof(Quest)) as Quest[])
        {
            questList.Add(go);            
        }       
        
        return questList;
    }
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
        //questList = questList.OrderBy(o => o.questID).ToList();
        if (!isInitialized)
        {
            foreach (Quest quest in questList)
            {
                if (quest.isMasterQuest) quest.questID -= 500;
                if (quest.isSubQuest) quest.questID -= 500;
                Debug.Log($"Quest order: {quest.questName} | Quest ID: {quest.questID}");
            }
            isInitialized = true;
            return questList;
        }
        else return questList;
    }

    public void AddQuests(Quest quest)
    {
        questList.Add(quest);
    }

    public void UpdateQuestProgress(string empty) // QuestDone panel in Inspector
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
            if (questArray[i].isActive) MenuManager.instance.notifyActiveQuest++;
            if (questArray[i].itemIsRelic) relicList.Add(questArray[i].GetComponent<ItemsManager>()); // useful place to build the relic list too           
        }
        questList = questArray.ToList();
        Debug.Log($"Quest List: {questList.Count}");
        Debug.Log($"Relic List: {relicList.Count} items");

    }
    
    public void HandOutReward(QuestRewards rewardType) // invoked by a specific quest only
    {
        Debug.Log($"Hand out reward: {rewardType}");
        for (int i = 0; i < rewardables.Length; i++)
        {
            rewardables[i].Reward(rewardType);
        }
    }
    
    public List<ItemsManager> GetRelicList()
    {
        return relicList;
    }


    #endregion METHODS
}

