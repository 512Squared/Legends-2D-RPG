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

            foreach(ItemsManager itemInInventory in itemsList)

            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                    Debug.Log("Stackable discard"); 
                    player.thulGold += item.valueInCoins;
                    item.itemSold = true;
                    MenuManager.instance.UpdateStats();

                    // implementing the coinAnimation

                    coinsManager.AddCoins(12);
                    Debug.Log("AddCoins in inventory called");
                }
            }

            if(inventoryItem != null && inventoryItem.amount <= 0)
            {
                Debug.Log("was last item");
                //item.GetComponent<Animator>().SetTrigger("sell");
                itemsList.Remove(inventoryItem);
                MenuManager.instance.UpdateStats();


            }
        }

        else
        {
            Debug.Log("non-Stackable discard");

            itemsList.Remove(item);
            player.thulGold += item.valueInCoins;
            item.itemSold = true;
            MenuManager.instance.UpdateStats();

            // implementing the coinAnimation

            coinsManager.AddCoins(12);
            Debug.Log("AddCoins called from inventory");
        }
    }



    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

}
