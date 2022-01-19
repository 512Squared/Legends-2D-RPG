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
    private SecretShopSection secretShop;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Transform shopItemBoxParent;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] int secretShopItemsCount;
    [SerializeField] int shopItemsCount;
    public Transform[] shops;


    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI shopItemName, shopItemDescription, shopItemDamage, shopItemArmour, shopItemPotion, shopItemFood, shopItemValue;
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
    public GameObject shopItemBox, shopItemDamageBox, shopItemArmourBox, shopItemPotionBox, shopItemFoodBox, shopEffectBox, messageContainer;


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
    public bool isShopUIOn = false, isPlayerInsideShop = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool shopWeaponBool, shopArmourBool, shopItemBool, shopSpellBool, shopPotionBool;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopArmouryOpen = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopInstantiated = false;

    private readonly Tween fadeText;

    public ItemsManager.Shop shopType;
    private int foodItems, weaponItems, potionItems, itemItems, armourItems;

    private int shop1NormalItems, shop1SecretItems, shop2NormalItems, shop2SecretItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        ShopArmoury();
    }

    public void OpenShop()
    {
        currentThulGold.text = playerStats.thulGold.ToString();
        currentThulGold2.text = playerStats.thulGold.ToString();
        isShopUIOn = true;
        UpdateShopItemsInventory();
    }

    public void UpdateShopItemsInventory()
    {

        shopCurrentNewItems = 0;
        foodItems = 0; // debug stuff
        potionItems = 0;
        weaponItems = 0;
        itemItems = 0;
        armourItems = 0;

        foreach (Transform itemSlot in shopItemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetShopList())
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

                switch (item.itemType)
                {
                    case ItemsManager.ItemType.Food:
                        foodItems++;
                        break;
                    case ItemsManager.ItemType.Potion:
                        potionItems++;
                        break;
                    case ItemsManager.ItemType.Item:
                        itemItems++;
                        break;
                    case ItemsManager.ItemType.Weapon:
                        weaponItems++;
                        break;
                    case ItemsManager.ItemType.Armour:
                        armourItems++;
                        break;
                }

                // new items - needs to run here to count how many new items

                if (item.isNewItem == true)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopCurrentNewItems++;
                }

                // Stuff to activate ONLY when inside a shop

                if (isShopUIOn == true)
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

                    // SORTING - SELECTED ITEM

                    else if (item.itemSelected == true) // if item has been selected
                    {
                        item.itemSelected = false;
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = true;

                        // ITEM SELECTED animation

                        itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

                        // NEW ITEM tagging

                        item.isNewItem = false; // switch off new item tag after selection
                        itemSlot.Find("New Item").GetComponent<Image>().enabled = false;

                        // EFFECT RESET

                        shopEffectBox.GetComponent<CanvasGroup>().alpha = 0; // necessary reset


                        //  EFFECTS - POTIONS

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

                            else if (item.itemName == "Red Healing Potion" || item.itemName == "Green Healing Potion" || item.itemName == "Red Healing Potion Large")
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

                        // EFFECTS - ARMOUR

                        if (item.itemType == ItemsManager.ItemType.Armour)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName + " | Shop no: " + item.shop);
                        }

                        // EFFECTS - FOOD

                        if (item.itemType == ItemsManager.ItemType.Food)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                            shopEffectText.text = "+" + item.amountOfEffect.ToString();
                            Debug.Log("Food restoration amount Healing potion effect amount: " + item.amountOfEffect + " | " + "Alpha status: " + GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha);

                        }

                        // EFFECTS - WEAPON

                        if (item.itemType == ItemsManager.ItemType.Weapon)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        }

                        // EFFECTS - ITEMS

                        if (item.itemType == ItemsManager.ItemType.Item)
                        {
                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        }
                    }

                    //SORTING - ITEMS(plural)

                    if (shopWeaponBool == true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Potion ||
                            item.itemType == ItemsManager.ItemType.Armour ||
                            item.itemType == ItemsManager.ItemType.Item ||
                            item.itemType == ItemsManager.ItemType.Skill ||
                            item.itemType == ItemsManager.ItemType.Food)
                        {
                            Destroy(itemSlot.gameObject);
                        }
                    }

                    else if (shopArmourBool == true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Potion ||
                            item.itemType == ItemsManager.ItemType.Weapon ||
                            item.itemType == ItemsManager.ItemType.Item ||
                            item.itemType == ItemsManager.ItemType.Skill ||
                            item.itemType == ItemsManager.ItemType.Food)
                        {
                            Destroy(itemSlot.gameObject);
                        }
                    }

                    else if (shopItemBool == true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Potion ||
                            item.itemType == ItemsManager.ItemType.Armour ||
                            item.itemType == ItemsManager.ItemType.Weapon ||
                            item.itemType == ItemsManager.ItemType.Spell)
                        {
                            Destroy(itemSlot.gameObject);
                        }
                    }

                    else if (shopSpellBool == true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Potion ||
                            item.itemType == ItemsManager.ItemType.Armour ||
                            item.itemType == ItemsManager.ItemType.Item ||
                            item.itemType == ItemsManager.ItemType.Weapon ||
                            item.itemType == ItemsManager.ItemType.Food)
                        {
                            Destroy(itemSlot.gameObject);
                        }
                    }

                    else if (shopPotionBool == true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Weapon ||
                            item.itemType == ItemsManager.ItemType.Armour ||
                            item.itemType == ItemsManager.ItemType.Item ||
                            item.itemType == ItemsManager.ItemType.Spell ||
                            item.itemType == ItemsManager.ItemType.Food)
                        {
                            Destroy(itemSlot.gameObject);
                        }
                    }

                    // SORTING - WHEN ARMOURY IS CLOSED

                    if (isShopArmouryOpen != true)
                    {
                        if (item.itemType == ItemsManager.ItemType.Weapon) Destroy(itemSlot.gameObject);
                        if (item.itemType == ItemsManager.ItemType.Armour) Destroy(itemSlot.gameObject);
                        if (item.itemType == ItemsManager.ItemType.Spell) Destroy(itemSlot.gameObject);
                    }
                }
                // SORTING - NOFIFY

                if (item.shop != shopType && item.isNewItem == true)
                {
                    shopCurrentNewItems--;
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                if (isShopArmouryOpen == false && item.shop == shopType && item.isNewItem == true)
                {
                    if (item.itemType == ItemsManager.ItemType.Weapon || item.itemType == ItemsManager.ItemType.Armour || item.itemType == ItemsManager.ItemType.Spell)
                    {
                        shopCurrentNewItems--;
                    }
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                else if (isShopArmouryOpen == true && item.shop == shopType)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                if (shopCurrentNewItems == 0)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }

                if (item.shop != shopType)
                {
                    Destroy(itemSlot.gameObject);
                }

                if (isPlayerInsideShop == false)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                    Destroy(itemSlot.gameObject);
                }
            }
        }
    }


    public void ShopSortByItemType(string boolName)
    {

        shopWeaponBool = shopArmourBool = shopItemBool = shopPotionBool = shopSpellBool = false;


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
        else if (boolName == "spell")
        {
            shopSpellBool = true;

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
            activeItem.GetComponent<SpriteRenderer>().sprite = null;
        }

        else if (activeItem.valueInCoins > playerStats.thulGold)
        {
            NotificationFader.instance.CallFadeInOut("<color=#C60B0B>You're too poor!</color> The item costs <color=#E0A515>" + activeItem.valueInCoins + " </color>and you have <color=#E0A515>" + playerStats.thulGold + "</color> gold coins.", activeItem.itemsImage, 3f, 1400f);
            ItemNotSoldAnim();

        }
    }

    public void ShopBackAndHome() // tidying for back and home buttons
    {
        shopCurrentNewItems = 0;
        isShopUIOn = false;
        GameManager.instance.isItemSelected = false;
        NofifyOnly();
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
            .Append(shopItemImage.GetComponent<Transform>().DOScale(2f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(1.8f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(2f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(1.8f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(2f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(1.8f, 0.1f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(2f, 0.1f))
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
        shopItemFoodBox.SetActive(false);
    }

    public void ShopArmouryBool()
    {
        isShopArmouryOpen = !isShopArmouryOpen;
        Debug.Log("Is the shop armoury open? " + isShopArmouryOpen);
    }


    public void ShopArmoury()
    {
        if (isShopInstantiated == false)
        {
            ItemsManager item;

            secretShopItemsCount = 0;

            for (int i = 0; i < shops.Length; i++)
            {
                foreach (Transform child in shops[i]) // one armoury, but sorted by shop1, shop2 etc
                {
                    item = child?.GetComponent<ItemsManager>();
                    if (child.GetComponent<ItemsManager>() != null)
                    {
                        if (isShopInstantiated == false)
                        {
                            if (item.itemType == ItemsManager.ItemType.Armour || item.itemType == ItemsManager.ItemType.Weapon || item.itemType == ItemsManager.ItemType.Spell)
                            {
                                Inventory.instance.AddShopItems(item);
                                secretShopItemsCount++;
                            }

                            else if (item.itemType == ItemsManager.ItemType.Food || item.itemType == ItemsManager.ItemType.Item || item.itemType == ItemsManager.ItemType.Potion)
                            {
                                Inventory.instance.AddShopItems(item);
                                shopItemsCount++;
                            }
                        }
                    }
                }

                if (i == 0)
                {
                    shop1NormalItems = shopItemsCount;
                    shop1SecretItems = secretShopItemsCount;
                    Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + shopItemsCount + " | Secret items: " + secretShopItemsCount);
                }

                else if (i == 1)
                {
                    Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + (shopItemsCount - shop1NormalItems) + " | Secret items: " + (secretShopItemsCount - shop1SecretItems));
                    shop2NormalItems = shopItemsCount;
                    shop2SecretItems = secretShopItemsCount;
                }

                else if (i == 2)
                {
                    Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + (shopItemsCount - shop2NormalItems) + " | Secret items: " + (secretShopItemsCount - shop2SecretItems));
                }

            }

        }
        isShopInstantiated = true; // armoury is instantiated on first shop onload
        Debug.Log("Shops fully Instantiated");
        ShopManager.instance.UpdateShopItemsInventory();
    }


    public void ShopType(ItemsManager.Shop shopType)
    {
        this.shopType = shopType;
    }



    public void ShopArmouryReset()
    {
        secretShop.OpenSecretPanel();
    }

    public void NofifyOnly()
    {
        shopCurrentNewItems = 0;
        foodItems = 0; // debug stuff
        potionItems = 0;
        weaponItems = 0;
        itemItems = 0;
        armourItems = 0;

        foreach (Transform itemSlot in shopItemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetShopList())
        {
            if (item.shopItem == true)
            {
                if (item.isNewItem == true)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopCurrentNewItems++;
                }


                if (item.shop != shopType && item.isNewItem == true)
                {
                    shopCurrentNewItems--;
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                if (isShopArmouryOpen == false && item.shop == shopType && item.isNewItem == true)
                {
                    if (item.itemType == ItemsManager.ItemType.Weapon || item.itemType == ItemsManager.ItemType.Armour || item.itemType == ItemsManager.ItemType.Spell)
                    {
                        shopCurrentNewItems--;
                    }
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                else if (isShopArmouryOpen == true && item.shop == shopType)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    shopNewItemsText.text = shopCurrentNewItems.ToString();
                }

                if (shopCurrentNewItems == 0)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }
                if (isPlayerInsideShop == false)
                {
                    GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }
            }
        }
    }

}
