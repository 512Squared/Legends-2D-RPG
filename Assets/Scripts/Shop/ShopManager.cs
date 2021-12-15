using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] TextMeshProUGUI currentThulGold, currentThulGold2, shopEffectText, shopNewItemsText;
    

    [SerializeField] private PlayerStats playerStats;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Transform shopItemBoxParent;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] GameObject shopItemBox, shopItemDamageBox, shopItemArmourBox, shopItemPotionBox, shopEffectBox;


    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public Button shopTabsAllHolder, shopTabsWeaponsHolder, shopTabsArmourHolder, shopTabsItemsHolder, shopTabsPotionsHolder;
    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public TextMeshProUGUI shopTabsAllText;
    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public GameObject shopTabsAllFocus, shopTabsWeaponsFocus, shopTabsArmourFocus, shopTabsItemsFocus, shopTabsPotionsFocus;


    public ItemsManager activeItem;
    private int shopCurrentNewItems = 0;
    private bool isShopOn = false;
    public bool shopWeaponBool, shopArmourBool, shopItemBool, shopSkillBool, shopPotionBool;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        currentThulGold.text = playerStats.thulGold.ToString();
        currentThulGold2.text = playerStats.thulGold.ToString();
    }

    public void UpdateShopItemsInventory()     // create  UI Equip table and side panel. Item sorting at the bottom
    {

        shopCurrentNewItems = 0;


        foreach (Transform itemSlot in shopItemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetItemsList())
        {
            if (item.shopItem == true)
            {
                RectTransform itemSlot = Instantiate(shopItemBox, shopItemBoxParent).GetComponent<RectTransform>();


                // show item image

                Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
                itemImage.sprite = item.itemsImage;

                TextMeshProUGUI itemsAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
                if (item.amount > 1)
                {
                    itemsAmountText.text = item.amount.ToString();
                }
                else
                {
                    itemsAmountText.text = "";
                }

                itemSlot.GetComponent<ItemButton>().itemOnButton = item; // this is a really important method


                // new items - needs to run here to count how many new items

                if (item.isNewItem == true)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopCurrentNewItems++;
                }


                // Stuff to activate ONLY when inside inventory

                if (isShopOn == true)
                {

                    // Removing focus from previously selected items 

                    if (item.itemSelected == false)
                    {
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = false;
                        GameManager.instance.isItemSelected = false;

                        if (item.isNewItem == true)
                        {
                            itemSlot.Find("New Item").GetComponent<Image>().enabled = true;
                        }
                        // new items - set red marker; count item

                        if (item.isNewItem == false)
                        {
                            itemSlot.Find("New Item").GetComponent<Image>().enabled = false;
                        }
                    }

                    // ITEM SORTING FOR SELECTED ITEM

                    else if (item.itemSelected == true) // if item has been selected
                    {
                        item.itemSelected = false;
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = true;

                        // ITEM SELECTED animation

                        itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");
                        Debug.Log("Animation should have been called");

                        // NEW ITEM tagging

                        item.isNewItem = false; // switch off new item tag after selection
                        itemSlot.Find("New Item").GetComponent<Image>().enabled = false;

                        // SORTING BY ITEM TYPE

                        shopEffectBox.GetComponent<CanvasGroup>().alpha = 0; // necessary reset


                        //  SORT BY POTIONS

                        if (item.itemType == ItemsManager.ItemType.Potion)
                        {
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);

                            

                            // EFFECT MODIFIER (on item info)

                            if (item.itemName == "Speed Potion")
                            {
                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                shopEffectText.text = "x" + item.amountOfEffect.ToString();
                            }

                            else if (item.itemName == "Mana Potion")
                            {
                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                shopEffectText.text = "+" + item.amountOfEffect.ToString();
                            }

                            else if (item.itemName == "Red Healing Potion" || item.itemName == "Green Healing Potion")
                            {
                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                shopEffectText.text = "+" + item.amountOfEffect.ToString();
                                Debug.Log("Healing potion effect amount: " + item.amountOfEffect + " | " + "Alpha status: " + GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha);
                            }

                            else
                            {
                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                                Debug.Log("Healing potion effect amount: " + item.amountOfEffect + " | " + "Alpha status: " + GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha);
                            }

                        }

                        // SORT BY ARMOUR

                        if (item.itemType == ItemsManager.ItemType.Armour)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        }

                        // SORT BY WEAPON

                        if (item.itemType == ItemsManager.ItemType.Weapon)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                            
                        }

                        // SORT BY NORMAL ITEMS

                        if (item.itemType == ItemsManager.ItemType.Item)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                            
                        }
                    }
                }

                // sorting strategy - destroy everything else but the chosen type

                if (shopWeaponBool == true)

                {
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
           (item.itemType == ItemsManager.ItemType.Armour) ||
           (item.itemType == ItemsManager.ItemType.Item) ||
           (item.itemType == ItemsManager.ItemType.Skill))
                    {
                        Destroy(itemSlot.gameObject);
                    }

                }
                else if (shopArmourBool == true)

                {
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
           (item.itemType == ItemsManager.ItemType.Weapon) ||
           (item.itemType == ItemsManager.ItemType.Item) ||
           (item.itemType == ItemsManager.ItemType.Skill))
                    {
                        Destroy(itemSlot.gameObject);
                    }
                }
                else if (shopItemBool == true)

                {
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
           (item.itemType == ItemsManager.ItemType.Armour) ||
           (item.itemType == ItemsManager.ItemType.Weapon) ||
           (item.itemType == ItemsManager.ItemType.Skill))
                    {
                        Destroy(itemSlot.gameObject);
                    }
                }
                else if (shopSkillBool == true)

                {
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
           (item.itemType == ItemsManager.ItemType.Armour) ||
           (item.itemType == ItemsManager.ItemType.Item) ||
           (item.itemType == ItemsManager.ItemType.Weapon))
                    {
                        Destroy(itemSlot.gameObject);
                    }
                }
                else if (shopPotionBool == true)

                {
                    if ((item.itemType == ItemsManager.ItemType.Weapon) ||
           (item.itemType == ItemsManager.ItemType.Armour) ||
           (item.itemType == ItemsManager.ItemType.Item) ||
           (item.itemType == ItemsManager.ItemType.Skill))
                    {
                        Destroy(itemSlot.gameObject);
                    }
                }

                // new items - nofify on Main Menu. Items picked up are all set to 'new'. This code doesn't have to run until inventory has been built (above)

                if (shopCurrentNewItems == 0)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }

                else if (shopCurrentNewItems > 0)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                GameManager.instance.shopCurrentNewItems = shopCurrentNewItems;
                //Debug.Log("No. of new Items: " + currentNewItems);


            }
        }
    }


    public void ShopSortByItemType(string boolName)
    {

        shopWeaponBool = shopArmourBool = shopItemBool = shopPotionBool = shopSkillBool = false;


        if (boolName == "weapon")
        {
            shopWeaponBool = true;
            shopTabsAllFocus.SetActive(false);
            shopTabsWeaponsFocus.SetActive(true);
            shopTabsArmourFocus.SetActive(false);
            shopTabsItemsFocus.SetActive(false);
            shopTabsPotionsFocus.SetActive(false);

        }
        else if (boolName == "armour")
        {
            shopArmourBool = true;
            shopTabsAllFocus.SetActive(false);
            shopTabsWeaponsFocus.SetActive(false);
            shopTabsArmourFocus.SetActive(true);
            shopTabsItemsFocus.SetActive(false);
            shopTabsPotionsFocus.SetActive(false);

        }
        else if (boolName == "item")
        {
            shopItemBool = true;
            shopTabsAllFocus.SetActive(false);
            shopTabsWeaponsFocus.SetActive(false);
            shopTabsArmourFocus.SetActive(false);
            shopTabsItemsFocus.SetActive(true);
            shopTabsPotionsFocus.SetActive(false);
        }
        else if (boolName == "potion")
        {
            shopPotionBool = true;
            shopTabsAllFocus.SetActive(false);
            shopTabsWeaponsFocus.SetActive(false);
            shopTabsArmourFocus.SetActive(false);
            shopTabsItemsFocus.SetActive(false);
            shopTabsPotionsFocus.SetActive(true);
        }
        else if (boolName == "skill")
        {
            shopSkillBool = true;

        }
        if (boolName != "all")
        {
            shopTabsAllText.GetComponent<TextMeshProUGUI>().color = new Color32(82, 77, 80, 255);
        }

        if (boolName == "all")
        {
            shopTabsAllText.GetComponent<TextMeshProUGUI>().color = new Color32(236, 216, 150, 255);
            shopTabsAllFocus.SetActive(true);
            shopTabsWeaponsFocus.SetActive(false);
            shopTabsArmourFocus.SetActive(false);
            shopTabsItemsFocus.SetActive(false);
            shopTabsPotionsFocus.SetActive(false);
        }
        UpdateShopItemsInventory();
        Debug.Log("Sort by item initiated: " + boolName);
    }


    public void CallToBuyItem()
    {
        Debug.Log("Buy item initiated | Item: " + activeItem.itemName);
        Inventory.instance.BuyItem(activeItem);
        UpdateShopItemsInventory();
    }


    public void turnShopOn()
    {
        isShopOn = !isShopOn;
        GameManager.instance.isShopOn = !GameManager.instance.isShopOn;
        Debug.Log("IsEquip status: " + isShopOn);
    }

    public void shopBackAndHome() // tidying for back and home buttons
    {

        turnShopOn();
        shopCurrentNewItems = 0;
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
        GameManager.instance.isItemSelected = false;
        UpdateShopItemsInventory();

    }

}
