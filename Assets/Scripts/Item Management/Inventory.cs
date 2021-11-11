using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    // inventory sits on the GameManager


    public static Inventory instance;

    private List<ItemsManager> itemsList;
    public PlayerStats mainCharacter;

    [SerializeField] CoinsManager coinsManager;

    private bool isTeamMember;

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
                    // run the update on the main stats


                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;

                    // implementing the sell
                   
                    mainCharacter.thulGold += item.valueInCoins;
                    item.itemSold = true;
                    coinsManager.updateCoins();
                    coinsManager.UIAddCoins(item.valueInCoins);
                    MenuManager.instance.UpdateStats();



                    Debug.Log(item.itemName + " removed from stack and sold");

                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {

                Debug.Log(item.itemName + " removed from Inventory UI");
                itemsList.Remove(inventoryItem);
                MenuManager.instance.UpdateStats();


            }
        }

        else
        {
 


            // implementing the coinAnimation
            Debug.Log(item.itemName + " sold");
            coinsManager.updateCoins();
            coinsManager.UIAddCoins(item.valueInCoins);
            mainCharacter.thulGold += item.valueInCoins;
            itemsList.Remove(item);
            MenuManager.instance.UpdateStats();
            
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
                    Debug.Log("Inventory stack subtraction");
                    inventoryItem = itemInInventory;
                    
                    

                    // implementing EQUIP, GIVE or USE ANIMATIONS


                    if (item.itemType == ItemsManager.ItemType.Potion)
                    {
                        if (item.itemName == "Mana Potion")
                        {
                            // animations
                            coinsManager.updateMana();
                            coinsManager.UIAddMana(item.amountOfEffect);
                            MenuManager.instance.UpdateStats();

                        }

                        else if (item.itemName == "Healing Potion")
                        {
                            // animations
                            coinsManager.updateHP();
                            coinsManager.UIAddHp(item.amountOfEffect);
                            MenuManager.instance.UpdateStats();

                        }
                    }

                    // Add code HERE for weapons, items and armour OR UseItem in ItemsManager???
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
                Debug.Log("Item stack empty - item removed");
                MenuManager.instance.UpdateStats();
            }
        }

        else
        {
            itemsList.Remove(item);
            Debug.Log("Item removed");
            

            if (item.itemType == ItemsManager.ItemType.Potion)
            {

                if (item.itemName == "Mana Potion")
                {
                    // animations ONLY
                    coinsManager.updateMana();
                    coinsManager.UIAddMana(item.amountOfEffect);
                    MenuManager.instance.UpdateStats();

                }

                else if (item.itemName == "Healing Potion")
                {
                    // animations ONLY
                    coinsManager.updateHP();
                    coinsManager.UIAddHp(item.amountOfEffect);
                    MenuManager.instance.UpdateStats();

                }
            }

            // Add code HERE for weapons, items and armour
        }
    }


    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }


}


