using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    private List<ItemsManager> itemsList;
    public PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
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

            foreach(ItemsManager itemInInventory in itemsList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                    Debug.Log("Stackable discard"); 
                    player.thulGold += item.valueInCoins;
                    MenuManager.instance.UpdateStats();
                }
            }

            if(inventoryItem != null && inventoryItem.amount <= 0)
            {
                Debug.Log("was last item");
                itemsList.Remove(inventoryItem);
                MenuManager.instance.UpdateStats();
            }
        }

        else
        {
            Debug.Log("non-Stackable discard");
            itemsList.Remove(item);
            player.thulGold += item.valueInCoins;
            MenuManager.instance.UpdateStats();
        }
    }



    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }
}
