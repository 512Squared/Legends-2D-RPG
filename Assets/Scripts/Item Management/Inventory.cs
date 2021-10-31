using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    // inventory sits on the GameManager


    public static Inventory instance;

    private List<ItemsManager> itemsList;
    public PlayerStats player;
    [SerializeField] CoinsManager coinsManager;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
        coinsManager = FindObjectOfType<CoinsManager>();
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
        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in itemsList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                    player.thulGold += item.valueInCoins;
                    MenuManager.instance.UpdateStats();

                    // implementing the coinAnimation
                    coinsManager.updateCoins();
                    coinsManager.AddCoins(item.valueInCoins);

                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
                MenuManager.instance.UpdateStats();


            }
        }

        else
        {
            itemsList.Remove(item);
            MenuManager.instance.UpdateStats();

            // implementing the coinAnimation
            coinsManager.updateCoins();
            coinsManager.AddCoins(item.valueInCoins);
            player.thulGold += item.valueInCoins;
        }
    }

    public void UseAndRemoveItem(ItemsManager item)
    {

        Debug.Log("UseItem being discarded");
        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in itemsList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    Debug.Log("Inventory amount updated");
                    inventoryItem = itemInInventory;
                    MenuManager.instance.UpdateStats();
                    Debug.Log("Item removed");
                    coinsManager.updateHP();
                    coinsManager.UIAddHp(item.amountOfEffect);
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
                MenuManager.instance.UpdateStats();            }
        }

        else
        {
            itemsList.Remove(item);
            Debug.Log("Item removed");
            MenuManager.instance.UpdateStats();
            coinsManager.updateHP();
            coinsManager.UIAddHp(item.amountOfEffect);
        }
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }


}


