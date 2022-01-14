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
    private List<ItemsManager> shopList;
    public PlayerStats[] characterArray;
    [SerializeField] PlayerStats thulgran;

    [SerializeField] CoinsManager coinsManager;


    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
        shopList = new List<ItemsManager>();
        coinsManager = FindObjectOfType<CoinsManager>();
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

    public void UseAndRemoveItem(ItemsManager item, int selectedCharacterUse, Vector2 target)
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


                    if (item.itemType == ItemsManager.ItemType.Potion || item.itemType == ItemsManager.ItemType.Food)
                    {
                        if (item.itemName == "Mana Potion")
                        {
                            // animations

                            // animation only runs for Thulgren

                            if (selectedCharacterUse == 0)
                            {
                                Debug.Log("Mana animation called (Thulgran)");
                                coinsManager.updateMana();
                                coinsManager.UIAddMana(item.amountOfEffect, target, selectedCharacterUse);
                                MenuManager.instance.UpdateStats();
                            }

                            else
                            {
                                coinsManager.updateMana();
                                coinsManager.UIAddMana(item.amountOfEffect, target, selectedCharacterUse);
                                MenuManager.instance.UpdateStats();
                                Debug.Log("Mana animation called (notThulgran)");
                            }

                        }

                        else if (item.itemName == "Red Healing Potion" || item.itemName == "Red Healing Potion Large" || item.itemName == "Green Healing Potion" || item.itemType == ItemsManager.ItemType.Food)
                        {
                            // animations

                            if (selectedCharacterUse == 0)
                            {
                                Debug.Log("Animation call sent (Thulgran)");
                                coinsManager.updateHP();
                                coinsManager.UIAddHp(item.amountOfEffect, target, selectedCharacterUse);
                                MenuManager.instance.UpdateStats();
                            }

                            else
                            {
                                // now adding same anim for other characters
                                coinsManager.updateHP();
                                coinsManager.UIAddHp(item.amountOfEffect, target, selectedCharacterUse);

                                MenuManager.instance.UpdateStats();
                                Debug.Log("HP animation called (notThulgran)");
                            }
                        }
                    }
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
                Debug.Log("Item stack empty - item removed");
                MenuManager.instance.UpdateStats();
            }
        }

        else // same code as above but for non-stackable items
        {
            itemsList.Remove(item);
            Debug.Log("Item removed");


            if (item.itemType == ItemsManager.ItemType.Potion || item.itemType == ItemsManager.ItemType.Food)
            {

                if (item.itemName == "Mana Potion")
                {
                    // animations 

                    if (selectedCharacterUse == 0)
                    {
                        Debug.Log("Mana animation called (Thulgran)");
                        coinsManager.updateMana();
                        coinsManager.UIAddMana(item.amountOfEffect, target, selectedCharacterUse);
                        MenuManager.instance.UpdateStats();
                    }

                    else
                    {

                        Debug.Log("Mana animation called (notThulgran)");
                        coinsManager.updateMana();
                        coinsManager.UIAddMana(item.amountOfEffect, target, selectedCharacterUse); MenuManager.instance.UpdateStats();
                    }

                }

                else if (item.itemName == "Green Healing Potion" || item.itemName == "Red Healing Potion" || item.itemName == "Red Healing Potion Large" || item.itemType == ItemsManager.ItemType.Food)
                {
                    // animations

                    if (selectedCharacterUse == 0)

                    {
                        Debug.Log("HP animation called (Thulgran)");
                        coinsManager.updateHP();
                        coinsManager.UIAddHp(item.amountOfEffect, target, selectedCharacterUse);
                        MenuManager.instance.UpdateStats();
                    }

                    else
                    {
                        Debug.Log("HP animation called (notThulgran)");
                        coinsManager.updateHP();
                        coinsManager.UIAddHp(item.amountOfEffect, target, selectedCharacterUse);
                        MenuManager.instance.UpdateStats();
                    }

                }
            }



            // Add code HERE for weapons, items and armour OR UseItem in ItemsManager???


        }
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
        itemsList.Add(item);
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


