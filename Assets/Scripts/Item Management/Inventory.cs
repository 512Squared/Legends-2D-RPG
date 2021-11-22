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
    public PlayerStats[] characterArray;

    [SerializeField] CoinsManager coinsManager;


    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
        coinsManager = FindObjectOfType<CoinsManager>();

        characterArray = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();


        //DontDestroyOnLoad(this);
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

    public void SellItem(ItemsManager item, int selectedCharacterSell)
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

                    characterArray[selectedCharacterSell].thulGold += item.valueInCoins;
                    item.itemSold = true;
                    if (selectedCharacterSell == 0)
                    {
                        coinsManager.updateCoins();
                        coinsManager.UIAddCoins(item.valueInCoins, selectedCharacterSell);
                        MenuManager.instance.UpdateStats();
                        Debug.Log(item.itemName + " removed from stack and sold (Thulgran)");
                    }
                    else if (selectedCharacterSell != 0)
                    {
                        MenuManager.instance.UpdateStats();
                        Debug.Log(item.itemName + " removed from stack and sold (notThulgran");
                    }
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
            if (selectedCharacterSell == 0)
            {

                characterArray[selectedCharacterSell].thulGold += item.valueInCoins;
                itemsList.Remove(item); 
                coinsManager.updateCoins();
                coinsManager.UIAddCoins(item.valueInCoins, selectedCharacterSell);

                Debug.Log(item.itemName + " removed from inventory UI 1");
                MenuManager.instance.UpdateStats();
            }

            else if (selectedCharacterSell != 0)
            {
                characterArray[selectedCharacterSell].thulGold += item.valueInCoins;
                itemsList.Remove(item);
                Debug.Log(item.itemName + " removed from inventory UI 2");

                MenuManager.instance.UpdateStats();
            }
            Debug.Log("Debugs bypassed");
        }
    }

    public void UseAndRemoveItem(ItemsManager item, int selectedCharacterUse)
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

                            // animation only runs for Thulgren

                            if (selectedCharacterUse == 0)
                            {
                                Debug.Log("Animation call sent (Thulgran)");
                                coinsManager.updateMana();
                                coinsManager.UIAddMana(item.amountOfEffect);
                                MenuManager.instance.UpdateStats();
                            }

                            else
                            {
                                MenuManager.instance.UpdateStats();
                                Debug.Log("Animation call not sent (notThulgran)");
                            }

                        }

                        else if (item.itemName == "Healing Potion")
                        {
                            // animations

                            // animation only runs for Thulgren

                            if (selectedCharacterUse == 0)
                            {
                                Debug.Log("Animation call sent (Thulgran)");
                                coinsManager.updateHP();
                                coinsManager.UIAddHp(item.amountOfEffect);
                                MenuManager.instance.UpdateStats();
                            }

                            else
                            {
                                MenuManager.instance.UpdateStats();
                                Debug.Log("Animation not sent (notThulgran)");
                            }

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
                    // animations 

                    // animation only runs for Thulgren

                    if (selectedCharacterUse == 0)
                    {
                        Debug.Log("3_Animation should work, because it's Thulgran");
                        coinsManager.updateMana();
                        coinsManager.UIAddMana(item.amountOfEffect);
                        MenuManager.instance.UpdateStats();
                    }

                    else
                    {
                        MenuManager.instance.UpdateStats();
                    }

                }

                else if (item.itemName == "Healing Potion")
                {
                    // animations

                    // animation only runs for Thulgren

                    if (selectedCharacterUse == 0)

                    {
                        Debug.Log("4_Animation should work, because it's Thulgran");
                        coinsManager.updateHP();
                        coinsManager.UIAddHp(item.amountOfEffect);
                        MenuManager.instance.UpdateStats();
                    }

                    else
                    {
                        MenuManager.instance.UpdateStats();
                    }

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


