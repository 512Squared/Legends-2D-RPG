using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Inventory : MonoBehaviour
{
    public static Inventory instance; // GameManager

    private List<ItemsManager> inventoryList;
    private List<ItemsManager> shopList;

    void Start()
    {
        instance = this;
        inventoryList = new List<ItemsManager>();
        shopList = new List<ItemsManager>();
    }

    public void AddItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAleadyInInventory = false;

            foreach (ItemsManager itemInInventory in inventoryList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount += item.amount;
                    itemAleadyInInventory = true;
                }
            }

            if (!itemAleadyInInventory)
            {
                inventoryList.Add(item);
            }
        }
        else
        {
            inventoryList.Add(item);
        }
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

    public void SellItem(ItemsManager item)
    {
        Debug.Log($"OnSellItem invoked for {item.itemName}");

        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in inventoryList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                inventoryList.Remove(inventoryItem);
                Debug.Log($"stacked {item.itemName} sold and now empty");
            }
        }

        else
        {
            inventoryList.Remove(item);
            Debug.Log($"{item.itemName} sold");
        }

        Actions.OnSellItem?.Invoke(item);// Broadcast | subscribers: Thulgran, MenuManager, CoinsManager

        Debug.Log($"Gold before sale: {Thulgran.ThulgranGold} | InvocationList: {Actions.OnSellItem.GetInvocationList().Length} | Info: {Actions.OnSellItem.Method}");
    }

    public void UseAndRemoveItem(ItemsManager item, int selectedCharacterUse, Vector2 target)
    {
        Debug.Log("Use & Remove initiated");

        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;
            foreach (ItemsManager itemInInventory in inventoryList)
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
                inventoryList.Remove(inventoryItem);
                Debug.Log("Item stack empty - item removed");
            }
        }

        else // same code as above but for non-stackable items
        {
            inventoryList.Remove(item);
            Debug.Log("Item removed");
        }

        Actions.OnUseItem?.Invoke(item, selectedCharacterUse, target); // Broadcast | subscribers: Thulgran, MenuManager, CoinsManager
        Debug.Log($"OnUseItem has broadcasted for: {item.itemName}");
    }

    public void BuyItem(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAleadyInInventory = false;

            foreach (ItemsManager itemInInventory in inventoryList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount += item.amount;
                    itemAleadyInInventory = true;
                }
            }

            if (!itemAleadyInInventory)
            {
                inventoryList.Add(item);
            }
        }

        else
        {
            inventoryList.Add(item);
        }

        shopList.Remove(item);
        item.shopItem = false;
        Thulgran.ThulgranGold -= item.valueInCoins;
        Debug.Log("stackable item " + item.itemName + " removed from shop and added to Inventory");

    }

    public List<ItemsManager> GetItemsList()
    {
        return inventoryList;
    }

    public List<ItemsManager> GetShopList()
    {
        return shopList;
    }

    public void AddMagic(MagicManager selectedCharacter)
    {

    }
}


