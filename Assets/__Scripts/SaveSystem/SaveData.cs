using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class SaveData
{
    #region JSON Stuff

    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

    #endregion

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
        public string uniqueGuid;
        public int completedStages;
        public bool questRewardClaimed;
        public bool isExpanded;
        public bool toggleSub;
        public bool isActive;
        public bool isDone;
        public bool hasQuestElement;
        public bool resetChildren;


        public QuestData([NotNull] string uniqueGuid, int completedStages,
            bool questRewardClaimed, bool isExpanded, bool toggleSub, bool isActive, bool isDone, bool
                hasQuestElement, bool resetChildren)
        {
            this.uniqueGuid = uniqueGuid ?? throw new ArgumentNullException(nameof(uniqueGuid));
            this.completedStages = completedStages;
            this.questRewardClaimed = questRewardClaimed;
            this.isExpanded = isExpanded;
            this.toggleSub = toggleSub;
            this.isActive = isActive;
            this.isDone = isDone;
            this.hasQuestElement = hasQuestElement;
            this.resetChildren = resetChildren;
        }
    }

    public List<QuestData> questDataList = new();

    #endregion

    #region Quest Elements Data

    [Serializable]
    public struct QuestElementsData
    {
        public QuestElementsData(bool isActivated, bool isCompleted, string elementGuid, bool activate, bool
            complete, bool hasTriggered)
        {
            this.isActivated = isActivated;
            this.isCompleted = isCompleted;
            this.elementGuid = elementGuid;
            this.activate = activate;
            this.complete = complete;
            this.hasTriggered = hasTriggered;
        }

        public bool isActivated, isCompleted;
        public string elementGuid;
        public bool activate, complete;
        public bool hasTriggered;
    }

    public List<QuestElementsData> questElementsList = new();

    #endregion

    [Serializable]
    public struct QuestManager
    {
        public QuestManager(int nofifyQuestReward, int nofifyActiveQuest, int nofifyRelicActive, bool firstPopulate)
        {
            this.nofifyQuestReward = nofifyQuestReward;
            this.nofifyActiveQuest = nofifyActiveQuest;
            this.nofifyRelicActive = nofifyRelicActive;
            this.firstPopulate = firstPopulate;
        }

        public int nofifyQuestReward, nofifyActiveQuest, nofifyRelicActive;
        public bool firstPopulate;
    }

    public QuestManager QuestManagerData;


    #region Items Data

    [Serializable]
    public struct ItemsData
    {
        public ItemsData(string itemGuid, int quantity, bool isPickedUp, bool isNewItem, bool isShopItem, SpriteRenderer
            spriteRenderer, PolygonCollider2D polyCollider)
        {
            this.itemGuid = itemGuid;
            this.quantity = quantity;
            this.isPickedUp = isPickedUp;
            this.isNewItem = isNewItem;
            this.isShopItem = isShopItem;
            this.spriteRenderer = spriteRenderer;
            this.polyCollider = polyCollider;
        }

        public string itemGuid;
        public int quantity;
        public bool isNewItem;
        public bool isPickedUp;
        public bool isShopItem;
        public SpriteRenderer spriteRenderer;
        public PolygonCollider2D polyCollider;
    }

    public List<ItemsData> itemsData = new();

    #endregion

    #region Dialogue Data

    [Serializable]
    public struct DialogueData
    {
        public int runCount;
        public string dialogueGuid;

        public DialogueData(int runCount, string dialogueGuid)
        {
            this.runCount = runCount;
            this.dialogueGuid = dialogueGuid;
        }
    }

    public List<DialogueData> dialoguesList = new();

    #endregion

    #region NPC Data

    [Serializable]
    public struct CharacterData
    {
        public CharacterData(string npcGuid, int characterLevel, int characterMana, int characterHp,
            int characterIntelligence, int characterPerception, int characterBaseAttack, int characterBaseDefence,
            bool isTeamMember, bool isAvailable, bool isNew, Item characterWeapon, Item characterArmour,
            Item characterHelmet, Item characterShield, int characterAttackTotal, int characterDefenceTotal,
            Sprite characterWeaponImage, Sprite characterArmourImage, Sprite characterHelmetImage,
            Sprite characterShieldImage, Sprite[] skills)
        {
            this.npcGuid = npcGuid;
            this.characterLevel = characterLevel;
            this.characterMana = characterMana;
            this.characterHp = characterHp;
            this.characterIntelligence = characterIntelligence;
            this.characterPerception = characterPerception;
            this.characterBaseAttack = characterBaseAttack;
            this.characterBaseDefence = characterBaseDefence;
            this.isTeamMember = isTeamMember;
            this.isAvailable = isAvailable;
            this.isNew = isNew;
            this.characterWeapon = characterWeapon;
            this.characterArmour = characterArmour;
            this.characterHelmet = characterHelmet;
            this.characterShield = characterShield;
            this.characterAttackTotal = characterAttackTotal;
            this.characterDefenceTotal = characterDefenceTotal;
            this.characterWeaponImage = characterWeaponImage;
            this.characterArmourImage = characterArmourImage;
            this.characterHelmetImage = characterHelmetImage;
            this.characterShieldImage = characterShieldImage;
            this.skills = skills;
        }

        public string npcGuid;
        public int characterLevel;
        public int characterMana, characterHp;
        public int characterIntelligence, characterPerception;
        public int characterBaseAttack, characterBaseDefence;
        public bool isTeamMember, isAvailable, isNew;
        public Item characterWeapon, characterArmour, characterHelmet, characterShield;
        public int characterAttackTotal, characterDefenceTotal;
        public Sprite characterWeaponImage, characterArmourImage, characterHelmetImage, characterShieldImage;
        public Sprite[] skills;
    }

    public List<CharacterData> characterDataList = new();

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

    #region Inventory

    [Serializable]
    public struct InventoryData
    {
        public InventoryData(List<Item> inventoryItemsList, List<Item> shopsItemsList)
        {
            this.inventoryItemsList = inventoryItemsList;
            this.shopsItemsList = shopsItemsList;
        }

        public List<Item> inventoryItemsList;
        public List<Item> shopsItemsList;
    }

    public InventoryData inventoryDatas;
    public List<InventoryData> inventoryDataList = new();

    #endregion
}