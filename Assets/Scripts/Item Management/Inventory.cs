using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    private List<ItemsManager> itemsList;

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

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }
}
