using UnityEngine;
using Sirenix.OdinInspector;
using System;


public class Thulgran : Rewardable<QuestRewards>, IDamageable, ISaveable
{
    #region Core stats

    private static int _thulgranGold = 10;

    [ShowInInspector]
    public static int ThulgranGold
    {
        get => _thulgranGold;
        set
        {
            _thulgranGold = value;
            UI.instance.UpdateGoldUI(_thulgranGold);
        }
    }

    private static int _thulgranHp = 10;

    [ShowInInspector]
    public static int ThulgranHp
    {
        get => _thulgranHp;
        set
        {
            _thulgranHp = value;
            UI.instance.UpdateHPUI(_thulgranHp);
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


    private static Vector3 _thulgranPosition;

    public static Vector3 ThulgranPosition
    {
        get => _thulgranPosition;
        set => _thulgranPosition = value;
    }

    public static int MaxThulgranHp { get; private set; } = 300;

    public static int MaxThulgranMana { get; private set; } = 200;

    public bool immuneToDragonBreath;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        Actions.OnSellItem += SellItem;
        Actions.OnUseItem += UseItem;
    }

    private void OnDisable()
    {
        Actions.OnSellItem -= SellItem;
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

    private static void SellItem(Item item)
    {
        //AddGold(item);
        Debug.Log($"Thulgran's purse: {ThulgranGold}");
    }

    private static void UseItem(Item item, int character, Vector2 target)
    {
        if (character != 0) { return; }

        Debug.Log($"Use item called | Item: {item.SO.itemName} | CharacterSlot: {character}");
        switch (item.SO.affectType)
        {
            case AffectType.Hp:
                AddHp(item);
                UI.instance.UpdateHPUI(0);
                break;
            case AffectType.Mana:
                AddMana(item);
                UI.instance.UpdateManaUI(0);
                break;
            case AffectType.Defence:
            case AffectType.Attack:
            case AffectType.Perception:
            case AffectType.Speed:
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public void AddGold(Item item)
    {
        ThulgranGold += item.SO.valueInCoins;

        for (int i = 0; i < UI.instance.goldStats.Length; i++)
        {
            if (i != 0)
            {
                UI.instance.goldStats[i].text = ThulgranGold.ToString();
            }
        }

        Debug.Log($"Add Gold | Value: {item.SO.valueInCoins}");
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
        ThulgranHp += item.SO.amountOfEffect;
        if (ThulgranHp > MaxThulgranHp)
        {
            ThulgranHp = MaxThulgranHp;
            NotificationFader.instance.CallFadeInOut("Thulgran's HP is <color=#E0A515>full</color> - well done!",
                Sprites.instance.hpSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added HP | Amount: {item.SO.amountOfEffect}");
    }

    private static void AddMana(Item item)
    {
        ThulgranMana += item.SO.amountOfEffect;
        if (ThulgranMana > MaxThulgranMana)
        {
            ThulgranMana = MaxThulgranMana;
            NotificationFader.instance.CallFadeInOut(
                "Thulgran's Mana is <color=#E0A515>full</color> - well done!</size>", Sprites.instance.manaSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added Mana: | Amount: {item.SO.amountOfEffect}");
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        Debug.Log($"Thulgran data loaded | hitpoints: {_thulgranHp} | position {_thulgranPosition}");
        a_SaveData.thulgranData.hitPoints = ThulgranHp; // Twinning
        a_SaveData.thulgranData.position = ThulgranPosition;
    }


    public void LoadFromSaveData(SaveData a_SaveData)
    {
        ThulgranHp = a_SaveData.thulgranData.hitPoints;
        ThulgranPosition = a_SaveData.thulgranData.position;
        transform.position = _thulgranPosition;
    }

    #endregion
}