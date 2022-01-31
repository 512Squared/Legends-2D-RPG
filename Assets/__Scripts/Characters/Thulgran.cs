using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class Thulgran : MonoBehaviour
{

    public static Thulgran instance;
    [ShowInInspector]
    public static int thulgranGold { get; private set; } = 11;
    [ShowInInspector]
    public static int thulgranMana { get; private set; } = 22;
    [ShowInInspector]
    public static int thulgranHP { get; private set; } = 33;

    public static int maxThulgranHP { get; private set; } = 300;
    public static int maxThulgranMana { get; private set; } = 200;

    [SerializeField] TextMeshProUGUI[] goldStats, manaStats, hpStats;
    [SerializeField] Slider[] hpSliders;
    [SerializeField] Slider[] manaSliders;


    void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        UpdateAll();
        Debug.Log($"Thulgran's stats: Gold {thulgranGold} | Mana {thulgranMana} | HP {thulgranHP}");
    }

    private void OnEnable()
    {
        Actions.OnSellItem += SellItem;
        Actions.OnBuyItem += BuyItem;
        Actions.OnUseItem += UseItem;
        Actions.OnCoinAdd += AddCoin;
    }

    private void OnDisable()
    {
        Actions.OnSellItem -= SellItem;
        Actions.OnBuyItem -= BuyItem;
        Actions.OnUseItem -= UseItem;
        Actions.OnCoinAdd -= AddCoin;
    }

    public void SellItem(ItemsManager item)
    {
        //AddGold(item);
        Debug.Log($"Thulgran's purse: {thulgranGold}");
    }

    public void BuyItem(ItemsManager item)
    {
        RemoveGold(item);
    }

    public void UseItem(ItemsManager item, int character, Vector2 target)
    {

        if (character == 0)
        {
            Debug.Log($"Use item called | Item: {item.itemName} | CharacterSlot: {character}");
            if (item.affectType == ItemsManager.AffectType.HP) AddHp(item);
            else if (item.affectType == ItemsManager.AffectType.Mana) AddMana(item);
        }
        UpdateAfterUseItem();
    }

    public void RemoveGold(ItemsManager item)
    {
        thulgranGold -= item.valueInCoins;
        UpdateAll();
        //Actions._cUpdate?.Invoke(item); // broadcast | subscribers: coinsManager
        Debug.Log($"Remove Gold | Value: {item.valueInCoins}");
    }

    public void AddGold(ItemsManager item)
    {
        thulgranGold += item.valueInCoins;

        for (int i = 0; i < goldStats.Length; i++)
        {
            if (i != 0)
                goldStats[i].text = thulgranGold.ToString();
        }
        Debug.Log($"Add Gold | Value: {item.valueInCoins}");
    }

    public void AddHp(ItemsManager item)
    {
        thulgranHP += item.amountOfEffect;
        Debug.Log($"Add HP | Amount: {item.amountOfEffect}");
    }

    public void AddMana(ItemsManager item)
    {
        thulgranMana += item.amountOfEffect;
        Debug.Log($"Add Mana: | Amount: {item.amountOfEffect}");
    }

    public void UpdateAll()
    {
        for (int i = 0; i < manaStats.Length; i++)
        {
            if (i == 0 || i == 1) // front screen format
            {
                manaStats[i].text = thulgranMana.ToString() + " / " + maxThulgranMana;
            }

            else
            {
                manaStats[i].text = thulgranMana.ToString();
            }
        }

        for (int i = 0; i < hpStats.Length; i++)
        {

            if (i == 0 || i == 1) // front screen format
            {
                hpStats[i].text = thulgranHP.ToString() + " / " + maxThulgranHP;
            }

            else
            {
                hpStats[i].text = thulgranHP.ToString();
            }
        }

        for (int i = 0; i < goldStats.Length; i++)
        {
            goldStats[i].text = thulgranGold.ToString();
        }

        for (int i = 0; i < hpSliders.Length; i++)
        {
            hpSliders[i].value = thulgranMana;
        }

        for (int i = 0; i < manaSliders.Length; i++)
        {
            manaSliders[i].value = thulgranMana;
        }
    }

    public void UpdateAfterUseItem()
    {
        for (int i = 0; i < manaStats.Length; i++)
        {
            if (i == 1) // front screen format
            {
                manaStats[i].text = thulgranMana.ToString() + " / " + maxThulgranMana;
            }

            else if (i != 0 && i != 1)
            {
                manaStats[i].text = thulgranMana.ToString();
            }
        }

        for (int i = 0; i < hpStats.Length; i++)
        {

            if (i == 1) // front screen format
            {
                hpStats[i].text = thulgranHP.ToString() + " / " + maxThulgranHP;
            }

            else if (i != 0 && i != 1)
            {
                hpStats[i].text = thulgranHP.ToString();
            }
        }

        for (int i = 0; i < hpSliders.Length; i++)
        {
            if (i != 0) hpSliders[i].value = thulgranHP;
        }

        for (int i = 0; i < manaSliders.Length; i++)
        {
            if (i != 0) manaSliders[i].value = thulgranMana;
        }
    }

    public void AddCoin(int coin)
    {
        thulgranGold += coin;
        for (int i = 0; i < goldStats.Length; i++)
        {
            if (i != 0)
                goldStats[i].text = thulgranGold.ToString();
        }
        Debug.Log($"Coin added to Thulgran gold: {thulgranGold}");
    }

}


