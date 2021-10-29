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

    public void RemoveItem(ItemsManager item)
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
                    item.itemSold = true;
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
            item.itemSold = true;
            MenuManager.instance.UpdateStats();

            // implementing the coinAnimation
            coinsManager.updateCoins();
            coinsManager.AddCoins(item.valueInCoins);
            player.thulGold += item.valueInCoins;
        }
    }



    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

}
