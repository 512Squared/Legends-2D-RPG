using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;


    [SerializeField] private PlayerStats playerStats;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Transform shopItemBoxParent;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] int secretShopItemsCount;
    public Transform shopSecretArmoury, shop;


    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI shopItemName, shopItemDescription, shopItemDamage, shopItemArmour, shopItemPotion, shopItemValue;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image shopItemImage;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Sprite shopMasking, bagOfGold;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public CanvasGroup itemSoldMessage;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI shopEffectText, shopItemArmourDefence, shopItemWeaponPower;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject shopItemBox, shopItemDamageBox, shopItemArmourBox, shopItemPotionBox, shopEffectBox, messageContainer;


    [TabGroup("Weapon Group", "Shop Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public Button shopTabsAllHolder, shopTabsWeaponsHolder, shopTabsArmourHolder, shopTabsItemsHolder, shopTabsPotionsHolder;
    [TabGroup("Weapon Group", "Shop Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public TextMeshProUGUI shopTabsAllText, currentThulGold, currentThulGold2, shopNewItemsText;
    [TabGroup("Weapon Group", "Shop Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public GameObject shopTabsAllFocus, shopTabsWeaponsFocus, shopTabsArmourFocus, shopTabsItemsFocus, shopTabsPotionsFocus; 


    public ItemsManager activeItem;
    private int shopCurrentNewItems = 0;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopOn = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool shopWeaponBool, shopArmourBool, shopItemBool, shopSkillBool, shopPotionBool;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopArmouryOpen = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isSecretArmouryBool1 = false;

    private readonly Tween fadeText;

    public ItemsManager.Shop shopType;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
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
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
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

                // sort by shop location: Shop1 (shopItem is already true, so inventory not needed here)

                
                if (item.shop != shopType)
                {
                    Destroy(itemSlot.gameObject);
                }

                //if (shopArmourBool == false) Destroy(itemSlot.gameObject);

                // new items - nofify on Main Menu. Items picked up are all set to 'new'. This code doesn't have to run until inventory has been built (above)

                if (shopCurrentNewItems == 0)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }

                else if (shopCurrentNewItems > 0)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
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
        if (activeItem.valueInCoins <= playerStats.thulGold)
        {
            Debug.Log("Buy item initiated | Item: " + activeItem.itemName);
            Inventory.instance.BuyItem(activeItem);
            NotificationFader.instance.CallFadeInOut("You have bought a " + activeItem.itemName + " for <color=#E0A515>" + activeItem.valueInCoins + "</color> gold coins. Item has been added to your inventory.", activeItem.itemsImage, 3f, 1400f);
            UpdateShopItemsInventory();
            ItemSoldAnim();
        }

        else if (activeItem.valueInCoins > playerStats.thulGold)
        {
            NotificationFader.instance.CallFadeInOut("<color=#C60B0B>You're too poor!</color> The item costs <color=#E0A515>" + activeItem.valueInCoins + " </color>and you have <color=#E0A515>" + playerStats.thulGold + "</color> gold coins.", activeItem.itemsImage, 3f, 1400f);
            ItemNotSoldAnim();

        }
    }


    public void TurnShopOn()
    {
        isShopOn = !isShopOn;
        GameManager.instance.isShopOn = !GameManager.instance.isShopOn;
        Debug.Log("IsShopOn status: " + isShopOn);
    }

    public void ShopBackAndHome() // tidying for back and home buttons
    {

        TurnShopOn();
        shopCurrentNewItems = 0;
        GameManager.instance.isItemSelected = false;
        UpdateShopItemsInventory();

    }




    public void ItemSoldAnim()
    {
        StartCoroutine(ItemSoldCoR());
    }

    public void ItemNotSoldAnim()
    {
        StartCoroutine(ItemNotSoldCoR());
    }

    IEnumerator ItemSoldCoR()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        var sequence = DOTween.Sequence()
                .Append(shopItemImage.GetComponent<Transform>().DOScale(1.8f, 0.3f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(0f, 1f));
        sequence.SetLoops(1, LoopType.Yoyo);
        yield return new WaitForSecondsRealtime(2f);
        ShopItemInfoReset();
        yield return new WaitForSecondsRealtime(0.1f);
        shopItemImage.GetComponentInParent<Transform>().localScale = new Vector3(1f, 1f, 1f);
    }

    IEnumerator ItemNotSoldCoR()
    {
        yield return new WaitForSecondsRealtime(0.1f);
            var sequence = DOTween.Sequence()
                .Append(shopItemImage.GetComponent<Transform>().DOScale(3f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(2.8f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(3f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(2.8f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(3f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(2.8f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(3f, 0.1f))
                .Append(shopItemImage.GetComponent<Transform>().DOScale(1f, 1f));
            sequence.SetLoops(1, LoopType.Yoyo);        
    }

    public void ShopItemInfoReset()
    {
            activeItem = null;    
            shopItemName.text = "Select an item";
            shopItemDescription.text = "";
            instance.shopItemValue.text = "";
            shopEffectText.text = "+0";
            shopItemDamage.text = "";
            shopItemImage.sprite = shopMasking;
            shopItemDamageBox.SetActive(false);
            shopItemArmourBox.SetActive(false);
            shopItemPotionBox.SetActive(false);
            Debug.Log("Item info panel has been reset");
    }

    public void ShopArmouryBool()
    {
        isShopArmouryOpen = !isShopArmouryOpen;
        Debug.Log("Is the shop armoury open? " + isShopArmouryOpen);
    }


    public void GetChildObjects(string shoptype)
    {
        ItemsManager item;
        Debug.Log("Get Child Objects called");

        ItemsManager.Shop parsed_enum = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), shoptype);

        secretShopItemsCount = 0;
        
        foreach (Transform child in shopSecretArmoury)
        {
            item = child.GetComponent<ItemsManager>();
            if (!isSecretArmouryBool1)
            {
                Inventory.instance.AddItems(item);
            }
            secretShopItemsCount++;
            Debug.Log("Shop type: " + parsed_enum + " | Secret shop items: " + secretShopItemsCount + " | Item: " + item.itemName);
            ShopManager.instance.UpdateShopItemsInventory();
        }
        isSecretArmouryBool1 = true;
    }

    public void ShopType(ItemsManager.Shop shopType)
    {
        this.shopType = shopType;
    }


}
