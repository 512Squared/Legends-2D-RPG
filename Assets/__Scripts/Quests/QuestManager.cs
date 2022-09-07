using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Collections;

//using UnityEngine.ParticleSystemJobs;

public class QuestManager : SerializedMonoBehaviour, ISaveable
{
    #region SINGLETON

    public static QuestManager Instance;

    #endregion SINGLETON


    #region FIELDS

    [InlineEditor] public List<Quest> questList;
    public Dictionary<string, bool> _questProgress;
    public Dictionary<int, string> _questId;
    [HideInInspector] public Quest[] questArray;
    private List<Item> _relicList;

    public Rewardable<QuestRewards>[] rewardables;

    private bool _isInitialized;

    #endregion FIELDS

    #region PROPERTIES

    #endregion PROPERTIES

    #region SERIALIZATION

    // each quest also has its own bool for completed - this is the array for the manager to keep track

    private int _nofifyQuestReward;
    private int _nofifyActiveQuest;
    private int _notifyRelicActive;

    [Space] public ParticleSystem pSystem;
    private bool _firstPopulate;

    #endregion SERIALIZATION

    #region CALLBACKS

    public void Start()
    {
        Instance = this;
        questList = new List<Quest>();
        _relicList = new List<Item>();
        _questProgress = new Dictionary<string, bool>();
        _questId = new Dictionary<int, string>();
        GetAllQuests();
        StartCoroutine(InitializeQuestManager());
        rewardables = FindObjectsOfType<Rewardable<QuestRewards>>(true);
        if (GameManager.Instance.initialization) { Debug.Log($"IRewardable Array: {rewardables.Length}"); }
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
        yield return new WaitForEndOfFrame();
        InitializeQuestID();
        GetQuestList();
        UpdateQuestProgress("");
    }

    #endregion COROUTINES

    #region METHODS

    private List<Quest> GetAllQuests()
    {
        foreach (Quest go in (Quest[])Resources.FindObjectsOfTypeAll(typeof(Quest)))
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
            {
                return true;
            }
        }

        return false;
    }

    public List<Quest> GetQuestList()
    {
        //questList = questList.OrderBy(o => o.questID).ToList();
        if (!_isInitialized)
        {
            foreach (Quest quest in questList)
            {
                if (quest.isMasterQuest)
                {
                    quest.questID -= 500;
                }

                if (quest.isSubQuest)
                {
                    quest.questID -= 500;
                }
            }

            _isInitialized = true;
            return questList;
        }
        else
        {
            return questList;
        }
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

        MenuManager.Instance.notifyActiveQuest = 0;
        MenuManager.Instance.notifyRelicActive = 0;
        MenuManager.Instance.notifyQuestReward = 0;

        if (GameManager.Instance.quests)
        {
            Debug.Log($"Reset: Notify ActiveQuest: {MenuManager.Instance.notifyActiveQuest}");
        }

        if (GameManager.Instance.quests)
        {
            Debug.Log($"Reset: Notify QuestReward: {MenuManager.Instance.notifyQuestReward}");
        }

        if (GameManager.Instance.quests)
        {
            Debug.Log($"Reset: Notify RelicActive: {MenuManager.Instance.notifyRelicActive}");
        }

        for (int i = 0; i < questArray.Length; i++)
        {
            questArray[i].questID = i + 1001;

            if (!_firstPopulate)
            {
                if (questArray[i].isActive && !questArray[i].questRewardClaimed && !questArray[i].isDone &&
                    !questArray[i].isSubQuest)
                {
                    MenuManager.Instance.notifyActiveQuest++;
                    if (GameManager.Instance.quests)
                    {
                        Debug.Log(
                            $"Initialize: Notify ActiveQuest++ {MenuManager.Instance.notifyActiveQuest} | {questArray[i].questName}");
                    }
                }

                if (questArray[i].isDone && !questArray[i].questRewardClaimed)
                {
                    MenuManager.Instance.notifyQuestReward++;
                    if (GameManager.Instance.quests)
                    {
                        Debug.Log($"Initialize: Notify QuestReward++ {MenuManager.Instance.notifyQuestReward}");
                    }
                }
            }

            if (!questArray[i].hasQuestElement && questArray[i].questElement != null && !questArray[i]
                    .questElement
                    .itemIsRelic)
            {
                continue;
            }

            if (questArray[i].questElement != null && questArray[i].questElement.itemIsRelic && questArray[i]
                    .questElement
                    .questItem
                != null)
            {
                _relicList.Add(questArray[i]
                    .questElement.questItem); // useful place to build the relic list too           
            }
        }

        questList = questArray.ToList();

        if (_firstPopulate)
        {
            MenuManager.Instance.notifyActiveQuest = _nofifyActiveQuest;
            MenuManager.Instance.notifyQuestReward = _nofifyQuestReward;
            MenuManager.Instance.notifyRelicActive = _notifyRelicActive;
            if (GameManager.Instance.quests)
            {
                Debug.Log($"Replace: Notify ActiveQuest: {MenuManager.Instance.notifyActiveQuest}");
            }

            if (GameManager.Instance.quests)
            {
                Debug.Log($"Replace: Notify QuestReward: {MenuManager.Instance.notifyQuestReward}");
            }

            if (GameManager.Instance.quests)
            {
                Debug.Log($"Replace: Notify RelicActive: {MenuManager.Instance.notifyRelicActive}");
            }
        }

        if (GameManager.Instance.initialization) { Debug.Log($"Quest List: {questList.Count}"); }

        if (GameManager.Instance.initialization) { Debug.Log($"Relic List: {_relicList.Count} items"); }
    }

    public void HandOutReward(QuestRewards rewardType) // invoked by a specific quest only
    {
        Debug.Log($"Hand out reward: {rewardType}");
        foreach (Rewardable<QuestRewards> t in rewardables)
        {
            t.Reward(rewardType);
        }
    }

    public List<Item> GetRelicList()
    {
        return _relicList;
    }

    #endregion METHODS

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        _firstPopulate = true;

        _nofifyActiveQuest = MenuManager.Instance.notifyActiveQuest;
        _nofifyQuestReward = MenuManager.Instance.notifyQuestReward;
        _notifyRelicActive = MenuManager.Instance.notifyRelicActive;

        SaveData.QuestManager sd = new(_nofifyQuestReward, _nofifyActiveQuest, _notifyRelicActive, _firstPopulate);
        a_SaveData.QuestManagerData = sd;
        if (GameManager.Instance.quests)
        {
            Debug.Log($"Save: Notify ActiveQuest: {MenuManager.Instance.notifyActiveQuest}");
        }

        if (GameManager.Instance.quests)
        {
            Debug.Log($"Save: Notify QuestReward: {MenuManager.Instance.notifyQuestReward}");
        }

        if (GameManager.Instance.quests)
        {
            Debug.Log($"Save: Notify RelicActive: {MenuManager.Instance.notifyRelicActive}");
        }
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _nofifyQuestReward = a_SaveData.QuestManagerData.nofifyQuestReward;
        _nofifyActiveQuest = a_SaveData.QuestManagerData.nofifyActiveQuest;
        _notifyRelicActive = a_SaveData.QuestManagerData.nofifyRelicActive;
        _firstPopulate = a_SaveData.QuestManagerData.firstPopulate;

        if (GameManager.Instance.quests) { Debug.Log($"Load: Notify ActiveQuest: {_nofifyActiveQuest}"); }

        if (GameManager.Instance.quests) { Debug.Log($"Load: Notify QuestReward: {_nofifyQuestReward}"); }

        if (GameManager.Instance.quests) { Debug.Log($"Load: Notify RelicActive: {_notifyRelicActive}"); }
    }

    #endregion
}