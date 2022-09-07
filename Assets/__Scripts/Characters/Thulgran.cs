using System;
using UnityEngine;
using Sirenix.OdinInspector;


public class Thulgran : Rewardable<QuestRewards>, ISaveable
{
    #region Core stats

    [ShowInInspector]
    [Title("Stats")]
    private static PlayerStats stats;

    private static int _thulgranGold = 300;

    public static int ThulgranGold
    {
        get => _thulgranGold;
        set
        {
            _thulgranGold = value;
            UI.instance.UpdateGoldUI(_thulgranGold);
        }
    }

    [ShowInInspector]
    private static int _thulgranHp;

    public static int ThulgranHp
    {
        get => _thulgranHp;
        set
        {
            _thulgranHp = value;
            stats.characterHp = ThulgranHp;
            UI.instance.UpdateHPUI(_thulgranHp);
            if (_thulgranHp <= 0) { ThulgranDies(); }
        }
    }


    private static int _thulgranMana = 10;

    [ShowInInspector]
    public static int ThulgranMana
    {
        get => _thulgranMana;
        set
        {
            _thulgranMana = value;
            UI.instance.UpdateManaUI(_thulgranMana);
        }
    }

    private static int _thulgranTrophies;

    [ShowInInspector]
    public static int ThulgranTrophies
    {
        get => _thulgranTrophies;
        set
        {
            _thulgranTrophies = value;
            UI.instance.UpdateGoldUI(_thulgranMana);
        }
    }

    public static int MaxThulgranHp { get; private set; } = 300;

    public static int MaxThulgranMana { get; private set; } = 200;

    [Title("Attack properties")]
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRange;

    [SerializeField]
    private LayerMask attackMask;


    [Title("Special abilities")]
    public bool immuneToDragonBreath;

    #endregion


    #region Callbacks

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        Actions.OnUseItem += UseItem;
    }

    private void OnDisable()
    {
        Actions.OnUseItem -= UseItem;
    }

    #endregion


    public override void Reward(QuestRewards rewards)
    {
        if (rewards.playerClass != QuestRewards.PlayerClasses.Thulgran &&
            rewards.playerClass != QuestRewards.PlayerClasses.all) { return; }

        Debug.Log($"Player class: {rewards.playerClass} | Reward called {rewards.rewardType}");
        if (rewards.rewardType == QuestRewards.RewardTypes.gold)
        {
            ThulgranGold += rewards.rewardAmount;
        }

        if (rewards.rewardType == QuestRewards.RewardTypes.hp)
        {
            ThulgranHp += rewards.rewardAmount;
        }

        if (rewards.rewardType == QuestRewards.RewardTypes.immuneToDragonBreath)
        {
            immuneToDragonBreath = true;
        }
    }

    private static void ThulgranDies()
    {
        PlayerGlobalData.Instance.Death();
    }

    private static void UseItem(Item item, int character, Vector2 target)
    {
        if (character != 0) { return; }

        if (GameManager.Instance.inventory)
        {
            Debug.Log($"Use item called | Item: {item.itemName} | CharacterSlot: {character}");
        }

        switch (item.affectType)
        {
            case AffectType.Hp:
                AddHp(item);
                UI.instance.UpdateHPUI(0);
                break;
            case AffectType.Mana:
                AddMana(item);
                UI.instance.UpdateManaUI(0);
                break;
            case AffectType.Defence: break;
            case AffectType.Attack: break;
            case AffectType.Perception: break;
            case AffectType.Speed: break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public static void AddGold(Item item)
    {
        ThulgranGold += item.valueInCoins;

        for (int i = 0; i < UI.instance.goldStats.Length; i++)
        {
            if (i != 0)
            {
                UI.instance.goldStats[i].text = ThulgranGold.ToString();
            }
        }

        Debug.Log($"Add Gold | Value: {item.valueInCoins}");
    }

    public static void AddGold(int amountToAdd)
    {
        ThulgranGold += amountToAdd;

        for (int i = 0; i < UI.instance.goldStats.Length; i++)
        {
            if (i != 0)
            {
                UI.instance.goldStats[i].text = ThulgranGold.ToString();
            }
        }

        Debug.Log($"Add Gold | Value: {amountToAdd}");
    }

    public static void AddTrophies(int trophiesToAdd)
    {
        ThulgranTrophies += trophiesToAdd;

        for (int i = 0; i < UI.instance.thulgranTrophies.Length; i++)
        {
            UI.instance.thulgranTrophies[i].text = ThulgranTrophies.ToString() + " / <color=#DECEB7>500</color>";
        }

        for (int i = 0; i < UI.instance.thulgranTrophySliders.Length; i++)
        {
            UI.instance.thulgranTrophySliders[i].value = ThulgranTrophies;
        }

        Debug.Log($"Add Trophies | Value: {trophiesToAdd}");
    }

    private static void AddHp(Item item)
    {
        ThulgranHp += item.amountOfEffect;
        if (ThulgranHp > MaxThulgranHp)
        {
            ThulgranHp = MaxThulgranHp;
            NotificationFader.instance.CallFadeInOut("Thulgran's HP is <color=#E0A515>full</color> - well done!",
                Sprites.instance.hpSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added HP | Amount: {item.amountOfEffect}");
    }

    private static void AddMana(Item item)
    {
        ThulgranMana += item.amountOfEffect;
        if (ThulgranMana > MaxThulgranMana)
        {
            ThulgranMana = MaxThulgranMana;
            NotificationFader.instance.CallFadeInOut(
                "Thulgran's Mana is <color=#E0A515>full</color> - well done!</size>", Sprites.instance.manaSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added Mana: | Amount: {item.amountOfEffect}");
    }

    public void Damage(int damage)
    {
        ThulgranHp -= damage; // defence and attack bonuses calculated in enemies attack method  
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.thulgranData.hitPoints = ThulgranHp;
        a_SaveData.thulgranData.gold = ThulgranGold;
        a_SaveData.thulgranData.mana = ThulgranMana;
        a_SaveData.thulgranData.trophies = ThulgranTrophies;
        a_SaveData.thulgranData.maxMana = MaxThulgranMana;
        a_SaveData.thulgranData.maxHp = MaxThulgranHp;
    }


    public void LoadFromSaveData(SaveData a_SaveData)
    {
        ThulgranHp = a_SaveData.thulgranData.hitPoints;
        ThulgranGold = a_SaveData.thulgranData.gold;
        ThulgranMana = a_SaveData.thulgranData.mana;
        ThulgranTrophies = a_SaveData.thulgranData.trophies;
        MaxThulgranMana = a_SaveData.thulgranData.maxMana;
        MaxThulgranHp = a_SaveData.thulgranData.maxHp;
    }

    #endregion
}