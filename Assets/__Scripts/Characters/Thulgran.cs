using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Thulgran : Rewardable<QuestRewards>, IDamageable
{
    #region Singleton

    public static Thulgran instance;

    #endregion


    #region Core stats

    private static int s_thulgranGold = 10;

    [ShowInInspector]
    public static int ThulgranGold
    {
        get => s_thulgranGold;
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
        get => s_thulgranHP;
        set
        {
            s_thulgranHP = value;
            UI.instance.UpdateHPUI(s_thulgranHP);
        }
    }

    private static int s_thulgranMana = 10;

    [ShowInInspector]
    public static int ThulgranMana
    {
        get => s_thulgranMana;
        set
        {
            s_thulgranMana = value;
            UI.instance.UpdateManaUI(s_thulgranMana);
        }
    }

    private static int s_thulgranTrophies = 0;

    [ShowInInspector]
    public static int ThulgranTrophies
    {
        get => s_thulgranTrophies;
        set
        {
            s_thulgranTrophies = value;
            UI.instance.UpdateGoldUI(s_thulgranMana);
        }
    }


    public static int maxThulgranHP { get; private set; } = 300;
    public static int maxThulgranMana { get; private set; } = 200;

    public bool immuneToDragonBreath;

    #endregion

    #region Callbacks

    private void Start()
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
        if (rewards.playerClass == QuestRewards.PlayerClasses.Thulgran ||
            rewards.playerClass == QuestRewards.PlayerClasses.all)
        {
            Debug.Log($"Player class: {rewards.playerClass} | Reward called {rewards.rewardType}");
            if (rewards.rewardType == QuestRewards.RewardTypes.gold)
            {
                ThulgranGold += rewards.rewardAmount;
            }

            if (rewards.rewardType == QuestRewards.RewardTypes.hp)
            {
                ThulgranHP += rewards.rewardAmount;
            }

            if (rewards.rewardType == QuestRewards.RewardTypes.immuneToDragonBreath)
            {
                immuneToDragonBreath = true;
            }
        }
    }

    public void SellItem(Item item)
    {
        //AddGold(item);
        Debug.Log($"Thulgran's purse: {ThulgranGold}");
    }

    public void UseItem(Item item, int character, Vector2 target)
    {
        if (character == 0)
        {
            Debug.Log($"Use item called | Item: {item.SO.itemName} | CharacterSlot: {character}");
            if (item.SO.affectType == AffectType.Hp)
            {
                AddHp(item);
                UI.instance.UpdateHPUI(0);
            }
            else if (item.SO.affectType == AffectType.Mana)
            {
                AddMana(item);
                UI.instance.UpdateManaUI(0);
            }
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

    public void AddHp(Item item)
    {
        ThulgranHP += item.SO.amountOfEffect;
        if (ThulgranHP > maxThulgranHP)
        {
            ThulgranHP = maxThulgranHP;
            NotificationFader.instance.CallFadeInOut("Thulgran's HP is <color=#E0A515>full</color> - well done!",
                Sprites.instance.hpSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added HP | Amount: {item.SO.amountOfEffect}");
    }

    public void AddMana(Item item)
    {
        ThulgranMana += item.SO.amountOfEffect;
        if (ThulgranMana > maxThulgranMana)
        {
            ThulgranMana = maxThulgranMana;
            NotificationFader.instance.CallFadeInOut(
                "Thulgran's Mana is <color=#E0A515>full</color> - well done!</size>", Sprites.instance.manaSprite,
                2f,
                1400, 30);
        }

        Debug.Log($"Added Mana: | Amount: {item.SO.amountOfEffect}");
    }
}