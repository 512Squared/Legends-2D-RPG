using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    #region SERIALIZATION

    private SecretShopSection _secretShop;

    public CanvasGroup shopUIPanel;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField]
    private Transform shopItemBoxParent;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField]
    private int secretShopItemsCount;

    [SerializeField] private int shopItemsCount;
    public Transform[] shops;


    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI shopItemName,
        shopItemDescription,
        shopItemDamage,
        shopItemArmour,
        shopItemPotion,
        shopItemFood,
        shopItemValue;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image shopItemImage;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Sprite shopMasking, bagOfGold;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public CanvasGroup itemSoldMessage;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI shopEffectText;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject shopItemBox,
        shopItemDamageBox,
        shopItemArmourBox,
        shopItemPotionBox,
        shopItemFoodBox,
        shopEffectBox,
        messageContainer;


    [TabGroup("Weapon Group", "Shop Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public Button shopTabsAllHolder,
        shopTabsWeaponsHolder,
        shopTabsArmourHolder,
        shopTabsItemsHolder,
        shopTabsPotionsHolder;

    [TabGroup("Weapon Group", "Shop Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public TextMeshProUGUI shopTabsAllText, shopNewItemsText;

    [TabGroup("Weapon Group", "Shop Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public GameObject shopTabsAllFocus,
        shopTabsWeaponsFocus,
        shopTabsArmourFocus,
        shopTabsItemsFocus,
        shopTabsPotionsFocus;


    public Item activeItem;
    private int _shopCurrentNewItems;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isPlayerInsideShop;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool shopWeaponBool, shopArmourBool, shopItemBool, shopSpellBool, shopPotionBool;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopArmouryOpen;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopInstantiated;

    private readonly Tween _fadeText;

    public Shop shopType;
    private int _foodItems, _weaponItems, _potionItems, _itemItems, _armourItems, _helmetItems, _shieldItems;

    private int _shop1NormalItems, _shop1SecretItems, _shop2NormalItems, _shop2SecretItems;

    public ShopManager(SecretShopSection secretShop)
    {
        _secretShop = secretShop;
    }

    #endregion


    #region CALLBACKS

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        //FindObjectOfType<PlayerStats>();
        InitializeShopAndArmoury();
    }

    #endregion

    #region SUBSCRIBERS

    private void OnEnable()
    {
        Actions.OnHomeButton += HomeButton;
        Actions.OnMainMenuButton += MainMenuButton;
    }


    private void OnDisable()
    {
        Actions.OnHomeButton -= HomeButton;
        Actions.OnMainMenuButton -= MainMenuButton;
    }

    #endregion


    private void MainMenuButton()
    {
        NofifyOnly();
    }

    #region METHODS

    public void CallToBuyItem()
    {
        if (activeItem.valueInCoins <= Thulgran.ThulgranGold)
        {
            string guid;
            guid = activeItem.itemGuid[..8];
            Debug.Log($"Buy item initiated | Item: {activeItem.itemName} | GUID: {guid}");
            Inventory.Instance.BuyItem(activeItem);
            NotificationFader.instance.CallFadeInOut(
                "You have bought a " + activeItem.itemName + " for <color=#E0A515>" + activeItem.valueInCoins +
                "</color> gold coins. Item has been added to your inventory.", activeItem.itemsImage, 3f, 1400f, 30);
            UpdateShopItemsInventory();
            ItemSoldAnim();
            activeItem.GetComponentInChildren<SpriteRenderer>().enabled = false;
            activeItem.SetItemParent(GameManager.Instance.pickedUpItems.transform, true);
            activeItem.shop = Shop.PickUpItem;
            activeItem.boughtFromShop = true;
            activeItem.isPickedUp = true;
            activeItem.isNewItem = true;
            AudioManager.Instance.PlaySfxClip(4);
        }

        else if (activeItem.valueInCoins > Thulgran.ThulgranGold)
        {
            NotificationFader.instance.CallFadeInOut(
                "<color=#C60B0B>You're too poor!</color> The item costs <color=#E0A515>" + activeItem.valueInCoins +
                " </color>and you have <color=#E0A515>" + Thulgran.ThulgranGold + "</color> gold coins.",
                activeItem.itemsImage, 3f, 1400f, 30);
            ItemNotSoldAnim();
        }
    }

    public void ItemNotSoldAnim()
    {
        StartCoroutine(ItemNotSoldCoR());
    }

    public void ItemSoldAnim()
    {
        StartCoroutine(ItemSoldCoR());
    }

    public void NofifyOnly()
    {
        _shopCurrentNewItems = 0;
        _foodItems = 0; // debug stuff
        _potionItems = 0;
        _weaponItems = 0;
        _itemItems = 0;
        _armourItems = 0;

        foreach (Transform itemSlot in shopItemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (Item item in Inventory.Instance.GetShopList().Where(item => item && item.isShopItem))
        {
            if (item.isNewItem)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                _shopCurrentNewItems++;
            }


            if (item.shop != shopType && item.isNewItem)
            {
                _shopCurrentNewItems--;
                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            if (isShopArmouryOpen == false && item.shop == shopType && item.isNewItem)
            {
                if (item.itemType is ItemType.Weapon or ItemType.Armour or ItemType.Spell or ItemType.Shield
                    or ItemType.Helmet)
                {
                    _shopCurrentNewItems--;
                }

                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            else if (isShopArmouryOpen && item.shop == shopType)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            if (_shopCurrentNewItems == 0)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
            }

            if (isPlayerInsideShop == false)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    public void OpenShop()
    {
        Debug.Log($"OpenShop called");
        GameManager.Instance.isShopUIOn = true;
        UpdateShopItemsInventory();
    }

    [SuppressMessage("ReSharper", "Unity.NoNullPropagation")]
    public void InitializeShopAndArmoury()
    {
        if (isShopInstantiated == false)
        {
            secretShopItemsCount = 0;

            for (int i = 0; i < shops.Length; i++)
            {
                foreach (Transform child in shops[i]) // one armoury, but sorted by shop1, shop2 etc
                {
                    Item item = child?.GetComponent<Item>();

                    if (child == null || child.GetComponent<Item>() == null) { continue; }

                    item.GetItemDetailsFromScriptObject(item);

                    if (isShopInstantiated == false)
                    {
                        switch (item.itemType)
                        {
                            case ItemType.Armour or ItemType.Weapon or ItemType.Spell or ItemType.Shield
                                or ItemType.Helmet:
                                Inventory.Instance.InitializeShop(item);
                                secretShopItemsCount++;
                                break;
                            case ItemType.Food or ItemType.Item or ItemType.Potion:
                                Inventory.Instance.InitializeShop(item);
                                shopItemsCount++;
                                break;
                        }
                    }
                }

                switch (i)
                {
                    case 0:
                        _shop1NormalItems = shopItemsCount;
                        _shop1SecretItems = secretShopItemsCount;
                        Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + shopItemsCount + " | Secret items: " +
                                  secretShopItemsCount);
                        break;
                    case 1:
                        Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + (shopItemsCount - _shop1NormalItems) +
                                  " | Secret items: " + (secretShopItemsCount - _shop1SecretItems));
                        _shop2NormalItems = shopItemsCount;
                        _shop2SecretItems = secretShopItemsCount;
                        break;
                    case 2:
                        Debug.Log("Shop no: " + (i + 1) + " | Normal items: " + (shopItemsCount - _shop2NormalItems) +
                                  " | Secret items: " + (secretShopItemsCount - _shop2SecretItems));
                        break;
                }
            }
        }

        isShopInstantiated = true; // armoury is instantiated on first shop onload
        Debug.Log("Shops fully Instantiated");
    }

    public void ShopArmouryBool()
    {
        isShopArmouryOpen = !isShopArmouryOpen;
        Debug.Log("Is the shop armoury open? " + isShopArmouryOpen);
    }

    public void ShopArmouryReset()
    {
        _secretShop.OpenSecretPanel();
    }

    public void HomeButton() // tidying for back and home buttons
    {
        _shopCurrentNewItems = 0;
        NofifyOnly();
    }

    public void ShopItemInfoReset()
    {
        activeItem = null;
        shopItemName.text = "Select an item";
        shopItemDescription.text = "";
        Instance.shopItemValue.text = "";
        shopEffectText.text = "+0";
        shopItemDamage.text = "";
        shopItemImage.sprite = shopMasking;
        shopItemDamageBox.SetActive(false);
        shopItemArmourBox.SetActive(false);
        shopItemPotionBox.SetActive(false);
        shopItemFoodBox.SetActive(false);
    }

    public void ShopSortByItemType(string boolName)
    {
        shopWeaponBool = shopArmourBool = shopItemBool = shopPotionBool = shopSpellBool = false;


        switch (boolName)
        {
            case "weapon":
                shopWeaponBool = true;
                shopTabsAllFocus.SetActive(false);
                shopTabsWeaponsFocus.SetActive(true);
                shopTabsArmourFocus.SetActive(false);
                shopTabsItemsFocus.SetActive(false);
                shopTabsPotionsFocus.SetActive(false);
                break;
            case "armour":
                shopArmourBool = true;
                shopTabsAllFocus.SetActive(false);
                shopTabsWeaponsFocus.SetActive(false);
                shopTabsArmourFocus.SetActive(true);
                shopTabsItemsFocus.SetActive(false);
                shopTabsPotionsFocus.SetActive(false);
                break;
            case "item":
                shopItemBool = true;
                shopTabsAllFocus.SetActive(false);
                shopTabsWeaponsFocus.SetActive(false);
                shopTabsArmourFocus.SetActive(false);
                shopTabsItemsFocus.SetActive(true);
                shopTabsPotionsFocus.SetActive(false);
                break;
            case "potion":
                shopPotionBool = true;
                shopTabsAllFocus.SetActive(false);
                shopTabsWeaponsFocus.SetActive(false);
                shopTabsArmourFocus.SetActive(false);
                shopTabsItemsFocus.SetActive(false);
                shopTabsPotionsFocus.SetActive(true);
                break;
            case "spell":
                shopSpellBool = true;
                break;
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

    public void ShopType(string scene)
    {
        Shop enumShopType = (Shop)System.Enum.Parse(typeof(Shop), scene);
        Debug.Log($"Enum shop type: {enumShopType}");
        shopType = enumShopType;
    }

    public void UpdateShopItemsInventory()
    {
        _shopCurrentNewItems = 0;
        _foodItems = 0; // debug stuff
        _potionItems = 0;
        _weaponItems = 0;
        _itemItems = 0;
        _armourItems = 0;
        _shieldItems = 0;
        _helmetItems = 0;

        foreach (Transform itemSlot in shopItemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (Item item in Inventory.Instance.GetShopList())
        {
            if (!item.isShopItem) { continue; }

            RectTransform itemSlot = Instantiate(shopItemBox, shopItemBoxParent).GetComponent<RectTransform>();

            // show item image

            Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
            itemImage.sprite = item.itemsImage;

            TextMeshProUGUI itemsAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
            itemsAmountText.text = item.quantity > 1 ? item.quantity.ToString() : "";

            itemSlot.GetComponent<ItemButton>().itemOnButton = item; // this is a really important method

            int i = -1;
            i = item.itemType switch
            {
                ItemType.Food => _foodItems++,
                ItemType.Potion => _potionItems++,
                ItemType.Item => _itemItems++,
                ItemType.Weapon => _weaponItems++,
                ItemType.Armour => _armourItems++,
                ItemType.Helmet => _armourItems++,
                ItemType.Shield => _armourItems++,
                _ => i
            };


            // new items - needs to run here to count how many new items

            if (item.isNewItem)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                _shopCurrentNewItems++;
            }

            // Stuff to activate ONLY when inside a shop

            if (GameManager.Instance.isShopUIOn)
            {
                // Removing focus from previously selected items 

                switch (item.itemSelected)
                {
                    case false:
                        {
                            itemSlot.Find("Focus").GetComponent<Image>().enabled = false;
                            GameManager.Instance.isItemSelected = false;

                            itemSlot.Find("New Item").GetComponent<Image>().enabled = item.isNewItem switch
                            {
                                true => true,
                                // new items - set red marker; count item
                                false => false
                            };

                            break;
                        }
                    // SORTING - SELECTED ITEM
                    // if item has been selected
                    case true:
                        {
                            item.itemSelected = false;
                            itemSlot.Find("Focus").GetComponent<Image>().enabled = true;

                            // ITEM SELECTED animation

                            itemSlot.GetComponent<ButtonBounce>().AnimateItemSelection();

                            // NEW ITEM tagging

                            item.isNewItem = false; // switch off new item tag after selection
                            itemSlot.Find("New Item").GetComponent<Image>().enabled = false;

                            // EFFECT RESET

                            shopEffectBox.GetComponent<CanvasGroup>().alpha = 0; // necessary reset


                            //  EFFECTS - POTIONS

                            switch (item.itemType)
                            {
                                case ItemType.Potion:
                                    {
                                        Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);

                                        // EFFECT MODIFIER (on item info)

                                        switch (item.itemName)
                                        {
                                            case "Speed Potion":
                                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                                shopEffectText.text = "x" + item.amountOfEffect.ToString();
                                                break;
                                            case "Mana Potion":
                                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                                shopEffectText.text = "+" + item.amountOfEffect.ToString();
                                                break;
                                            case "Red Healing Potion":
                                            case "Green Healing Potion":
                                            case "Red Healing Potion Large":
                                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                                shopEffectText.text = "+" + item.amountOfEffect.ToString();
                                                Debug.Log("Healing potion effect amount: " + item.amountOfEffect +
                                                          " | " +
                                                          "Alpha status: " +
                                                          GameObject.FindGameObjectWithTag("Effect")
                                                              .GetComponent<CanvasGroup>()
                                                              .alpha);
                                                break;
                                            default:
                                                shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                                                Debug.Log("Healing potion effect amount: " + item.amountOfEffect +
                                                          " | " +
                                                          "Alpha status: " +
                                                          GameObject.FindGameObjectWithTag("Effect")
                                                              .GetComponent<CanvasGroup>()
                                                              .alpha);
                                                break;
                                        }

                                        break;
                                    }
                                // EFFECTS - ARMOUR
                                case ItemType.Armour:
                                case ItemType.Helmet:
                                case ItemType.Shield:
                                    shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                                    Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName +
                                              " | Shop no: " +
                                              item.shop);
                                    break;
                                // EFFECTS - FOOD
                                case ItemType.Food:
                                    shopEffectBox.GetComponent<CanvasGroup>().alpha = 1;
                                    shopEffectText.text = "+" + item.amountOfEffect.ToString();
                                    Debug.Log("Food restoration amount Healing potion effect amount: " +
                                              item.amountOfEffect +
                                              " | " + "Alpha status: " + GameObject.FindGameObjectWithTag("Effect")
                                                  .GetComponent<CanvasGroup>()
                                                  .alpha);
                                    break;
                                // EFFECTS - WEAPON
                                case ItemType.Weapon:
                                    shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                                    Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                                    break;
                                // EFFECTS - ITEMS
                                case ItemType.Item:
                                    shopEffectBox.GetComponent<CanvasGroup>().alpha = 0;
                                    Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                                    break;
                            }

                            break;
                        }
                }

                //SORTING - ITEMS(plural)

                if (shopWeaponBool)
                {
                    if (item.itemType is ItemType.Potion or ItemType.Armour or ItemType.Item or ItemType.Skill
                        or ItemType.Food or ItemType.Helmet or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                else if (shopArmourBool)
                {
                    if (item.itemType is ItemType.Potion
                        or ItemType.Weapon
                        or ItemType.Item
                        or ItemType.Skill
                        or ItemType.Food
                        or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                else if (shopItemBool)
                {
                    if (item.itemType is ItemType.Potion
                        or ItemType.Armour
                        or ItemType.Weapon
                        or ItemType.Spell
                        or ItemType.Helmet
                        or ItemType.Shield)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                else if (shopSpellBool)
                {
                    if (item.itemType is ItemType.Potion
                        or ItemType.Armour
                        or ItemType.Item
                        or ItemType.Weapon
                        or ItemType.Helmet
                        or ItemType.Shield
                        or ItemType.Food
                        or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                else if (shopPotionBool)
                {
                    if (item.itemType is ItemType.Weapon
                        or ItemType.Armour
                        or ItemType.Item
                        or ItemType.Spell
                        or ItemType.Food
                        or ItemType.Helmet
                        or ItemType.Shield
                        or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                // SORTING - WHEN ARMOURY IS CLOSED

                if (isShopArmouryOpen != true)
                {
                    if (item.itemType is ItemType.Weapon
                        or ItemType.Armour
                        or ItemType.Spell
                        or ItemType.Helmet
                        or ItemType.Shield
                        or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
            }
            // SORTING - NOFIFY

            if (item.shop != shopType && item.isNewItem)
            {
                _shopCurrentNewItems--;
                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            if (isShopArmouryOpen == false && item.shop == shopType && item.isNewItem)
            {
                if (item.itemType is ItemType.Weapon or ItemType.Armour or ItemType.Spell or ItemType.Helmet
                    or ItemType.Shield)
                {
                    _shopCurrentNewItems--;
                }

                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            else if (isShopArmouryOpen && item.shop == shopType)
            {
                GameObject.FindGameObjectWithTag("NewShopItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                shopNewItemsText.text = _shopCurrentNewItems.ToString();
            }

            if (_shopCurrentNewItems == 0)
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

    private IEnumerator ItemNotSoldCoR()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Sequence sequence = DOTween.Sequence()
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

    private IEnumerator ItemSoldCoR()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Sequence sequence = DOTween.Sequence()
            .Append(shopItemImage.GetComponent<Transform>().DOScale(1.8f, 0.3f))
            .Append(shopItemImage.GetComponent<Transform>().DOScale(0f, 1f));
        sequence.SetLoops(1, LoopType.Yoyo);
        yield return new WaitForSecondsRealtime(2f);
        ShopItemInfoReset();
        yield return new WaitForSecondsRealtime(0.1f);
        shopItemImage.GetComponentInParent<Transform>().localScale = new Vector3(1f, 1f, 1f);
    }

    #endregion
}