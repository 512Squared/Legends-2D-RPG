using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

    #region Scene Data

    [Serializable]
    public struct SceneData
    {
        public string currentScene;
        public int sceneObjects;
    }

    public SceneData sceneData;

    #endregion

    #region Quest Data

    [Serializable]
    public struct QuestData
    {
        public IEnumerable<Quest> QuestSaves;
        
        public string questName;
        public int completedStages;
        public bool questRewardClaimed;
        public bool isExpanded;
        public bool toggleSub;
        public bool isActive;
        public bool isDone;
        public bool isActiveElement;

        public QuestData(IEnumerable<Quest> questSaves)
        {
            QuestSaves = questSaves;
            questName = "";
            completedStages = 0;
            questRewardClaimed = false;
            isExpanded = false;
            toggleSub = false;
            isActive = false;
            isDone = false;
            isActiveElement = false;
        }
    }

    public QuestData questData;

    #endregion

    #region Items Data

    [Serializable]
    public struct ItemsData
    {
    }

    public ItemsData itemsData = new();

    #endregion

    #region NPC Data

    [Serializable]
    public struct CharacterData
    {
    }

    public CharacterData characterData;

    #endregion

    #region Thulgran Data

    [Serializable]
    public struct ThulgranData
    {
        public int hitPoints;
        public Vector3 position;

        public bool controllerSwitch;

        public int moveSpeed;
        public int gold;
        public int trophies;
        public int mana;
        public int maxHp;
        public int maxMana;
    }

    public ThulgranData thulgranData;

    #endregion
}