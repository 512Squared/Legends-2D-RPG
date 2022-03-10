using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Thulgran : IRewardable<QuestRewards>, IDamageable
{

    #region Singleton

    public static Thulgran instance;

    #endregion


    #region Core stats

    private static int s_thulgranGold = 10;
    [ShowInInspector]
    public static int ThulgranGold
    {
        get { return s_thulgranGold; }
        set
        {
            s_thulgranGold = value;
            UI.instance.UpdateGoldUI(s_thulgranGold);
        }
    }

    private static int s_thulgranHP = 10;
    [ShowInInspector]
    public static int ThulgranHP
    {
        get { return s_thulgranHP; }
        set
        {
            s_thulgranHP = value;
            UI.instance.UpdateGoldUI(s_thulgranHP);
        }
    }

    private static int s_thulgranMana = 10;
    [ShowInInspector]
    public static int ThulgranMana
    {
        get { return s_thulgranMana; }
        set
        {
            s_thulgranMana = value;
            UI.instance.UpdateGoldUI(s_thulgranMana);
        }
    }


    public static int maxThulgranHP { get; private set; } = 300;
    public static int maxThulgranMana { get; private set; } = 200;

    public bool immuneToDragonBreath;
    #endregion

    #region Callbacks
    void Start()
    {
        instance = this;
    }

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
        Debug.Log($"Reward called {rewards.rewardType}");
        if (rewards.playerClass == QuestRewards.PlayerClasses.Thulgran || rewards.playerClass == QuestRewards.PlayerClasses.all)
        {
            if (rewards.rewardType == QuestRewards.RewardTypes.gold) ThulgranGold += rewards.rewardAmount;
            if (rewards.rewardType == QuestRewards.RewardTypes.hp) ThulgranHP += rewards.rewardAmount;
            if (rewards.rewardType == QuestRewards.RewardTypes.immuneToDragonBreath) immuneToDragonBreath = true;
        }

    }

    public void SellItem(ItemsManager item)
    {
        //AddGold(item);
        Debug.Log($"Thulgran's purse: {ThulgranGold}");
    }

    public void UseItem(ItemsManager item, int character, Vector2 target)
    {

        if (character == 0)
        {
            Debug.Log($"Use item called | Item: {item.itemName} | CharacterSlot: {character}");
            if (item.affectType == ItemsManager.AffectType.HP)
            {
                AddHp(item);
                UI.instance.UpdateHPUI(0);
            }
            else if (item.affectType == ItemsManager.AffectType.Mana)
            {
                AddMana(item);
                UI.instance.UpdateManaUI(0);
            }

        }
    }

    public void AddGold(ItemsManager item)
    {
        ThulgranGold += item.valueInCoins;

        for (int i = 0; i < UI.instance.goldStats.Length; i++)
        {
            if (i != 0)
                UI.instance.goldStats[i].text = ThulgranGold.ToString();
        }
        Debug.Log($"Add Gold | Value: {item.valueInCoins}");
    }

    public void AddHp(ItemsManager item)
    {
        ThulgranHP += item.amountOfEffect;
        if (ThulgranHP > maxThulgranHP)
        {
            ThulgranHP = maxThulgranHP;
            NotificationFader.instance.CallFadeInOut("Thulgran's HP is <color=#E0A515>full</color> - well done!", Sprites.instance.hpSprite,
                2f,
                1400, 30);
        }
        Debug.Log($"Added HP | Amount: {item.amountOfEffect}");
    }

    public void AddMana(ItemsManager item)
    {
        ThulgranMana += item.amountOfEffect;
        if (ThulgranMana > maxThulgranMana)
        {
            ThulgranMana = maxThulgranMana;
            NotificationFader.instance.CallFadeInOut("Thulgran's Mana is <color=#E0A515>full</color> - well done!</size>", Sprites.instance.manaSprite,
                2f,
                1400, 30);
        }
        Debug.Log($"Added Mana: | Amount: {item.amountOfEffect}");
    }


}


