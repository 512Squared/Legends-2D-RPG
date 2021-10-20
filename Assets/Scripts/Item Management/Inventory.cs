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
        //Debug.Log("New inventory has been created");
    }



    public void AddItems(ItemsManager item)
    {
        //print(item.itemName + " has been added to the inventory");
        itemsList.Add(item);
        print("Items in the inventory: " + itemsList.Count);
        
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }
}
