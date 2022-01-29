using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Inventory : MonoBehaviour
{
    public static Inventory instance; // GameManager

    private List<ItemsManager> itemsList;
    private List<ItemsManager> shopList;

    public PlayerStats[] characterArray;
    [SerializeField] PlayerStats thulgran;


    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
        shopList = new List<ItemsManager>();
        characterArray = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();
    }

    public void AddItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAleadyInInventory = false;

            foreach (ItemsManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount += item.amount;
                    itemAleadyInInventory = true;
                }
            }

            if (!itemAleadyInInventory)
            {
                itemsList.Add(item);
            }
        }
        else
        {
            itemsList.Add(item);
        }
    }

    public void SellItem(ItemsManager item)
    {
        Actions.OnSellItem?.Invoke(item);
        Debug.Log($"OnSellItem invoked for {item.itemName}");


        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in itemsList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                    thulgran.thulGold += item.valueInCoins;
                    Debug.Log($"stacked {item.itemName} sold. {thulgran.playerName} has received the dosh");
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {

                itemsList.Remove(inventoryItem);
                Debug.Log($"stacked {item.itemName} sold and now empty");
            }
        }

        else
        {
            thulgran.thulGold += item.valueInCoins;
            itemsList.Remove(item);
            Debug.Log($"{item.itemName} sold");
        }

        MenuManager.instance.UpdateStats();
    }

    public void UseAndRemoveItem(ItemsManager item, int selectedCharacterUse, Vector2 target)
    {
        Debug.Log("UseItem being discarded");

        Actions.OnUseItem?.Invoke(item, selectedCharacterUse, target);

        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;
            foreach (ItemsManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    Debug.Log("Inventory stack subtraction");
                    inventoryItem = itemInInventory;
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
                Debug.Log("Item stack empty - item removed");
            }
        }

        else // same code as above but for non-stackable items
        {
            itemsList.Remove(item);
            Debug.Log("Item removed");
        }

        MenuManager.instance.UpdateStats();
    }

    public void BuyItem(ItemsManager item)
    {


        item.shopItem = false;

        // implementing the sell

        thulgran.PayUpTheGold(item.valueInCoins);
        ShopManager.instance.currentThulGold.text = characterArray[0].thulGold.ToString();
        ShopManager.instance.currentThulGold2.text = characterArray[0].thulGold.ToString();
        MenuManager.instance.goldEquipTopBar.text = characterArray[0].thulGold.ToString();
        MenuManager.instance.UpdateStats();
        if (item.isStackable)
        {
            bool itemAleadyInInventory = false;

            foreach (ItemsManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount += item.amount;
                    itemAleadyInInventory = true;
                }
            }

            if (!itemAleadyInInventory)
            {
                itemsList.Add(item);
            }
        }
        else
        {
            itemsList.Add(item);
        }
        shopList.Remove(item);
        Debug.Log("stackable item " + item.itemName + " removed from shop and added to Inventory");
    }

    public void AddMagic(MagicManager selectedCharacter)
    {

    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

    public List<ItemsManager> GetShopList()
    {
        return shopList;
    }

    public void AddShopItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAleadyInShop = false;

            foreach (ItemsManager itemInShop in shopList)
            {
                if (itemInShop.itemName == item.itemName && itemInShop.shop == item.shop)
                {
                    itemInShop.amount += item.amount;
                    itemAleadyInShop = true;
                }
            }

            if (!itemAleadyInShop)
            {
                shopList.Add(item);
            }
        }

        else
        {
            shopList.Add(item);
        }
    }
}


