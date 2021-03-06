using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;


public class Inventory : MonoBehaviour, ISaveable
{
    public static Inventory Instance; // GameManager

    private List<Item> _inventoryList;
    public List<Item> shopList;
    private List<Item> _initializeShop;

    public GameObject itemPrefab;


    private Dictionary<int, ItemDetails> _itemDetailsDictionary;

    [Header("Scriptable Object - Items")] [SerializeField]
    private SO_itemsList itemsList;

    private void Start()
    {
        Instance = this;
        _inventoryList = new List<Item>();
        _initializeShop = new List<Item>();
        shopList = new List<Item>();
    }

    private void Awake()
    {
        Instance = this;
        CreateItemDetailsDictionary();
    }


    public void AddItems(Item item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.quantity += item.quantity;
                itemAlreadyInInventory = true;
            }

            if (itemAlreadyInInventory)
            {
                item.SelfDestruct();
                return;
            }

            _inventoryList.Add(item);
        }
        else
        {
            _inventoryList.Add(item);
        }
    }

    public void AddShopItems(Item item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInShop = false;

            foreach (Item itemInShop in shopList.Where(itemInShop =>
                         itemInShop.itemName == item.itemName || itemInShop.shop == item.shop))
            {
                itemInShop.quantity += item.quantity;
                itemAlreadyInShop = true;
            }

            if (!itemAlreadyInShop)
            {
                shopList.Add(item);
            }
        }

        else
        {
            shopList.Add(item);
        }
    }

    public void InitializeShop(Item item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInShop = false;

            foreach (Item itemInShop in shopList.Where(itemInShop =>
                         itemInShop.itemName == item.itemName || itemInShop.shop == item.shop))
            {
                itemInShop.quantity += item.quantity;
                itemAlreadyInShop = true;
            }

            if (!itemAlreadyInShop)
            {
                _initializeShop.Add(item);
            }
        }

        else
        {
            _initializeShop.Add(item);
        }
    }

    public void DropItem(Item item)
    {
        if (item.isStackable)
        {
            Item inventoryItem = null;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory => itemInInventory.itemName ==
                         item.itemName))
            {
                itemInInventory.quantity--;
                Debug.Log($"Quantity of {itemInInventory.itemName}s in Inventory is {itemInInventory.quantity}");
                inventoryItem = itemInInventory;
                break;
            }

            if (inventoryItem != null && inventoryItem.quantity <= 0)
            {
                Debug.Log($"Inventory now empty of {inventoryItem.itemName}s");
                // this resets the item quantity to 1, since previously it served as the inventory counter
                Actions.OnDropItem?.Invoke(inventoryItem);
                _inventoryList.Remove(inventoryItem);
                return;
            }

            if (inventoryItem != null && inventoryItem.quantity >= 1)
            {
                NewObjects.Instance.InstantiateDroppedObject(item);
            }
        }
        else
        {
            Actions.OnDropItem?.Invoke(item);
            _inventoryList.Remove(item);
            Debug.Log($"{item.itemName} dropped");
        }
    }


    public void SellItem(Item item)
    {
        Debug.Log($"OnSellItem invoked for {item.itemName}");

        if (item.isStackable)
        {
            Item inventoryItem = null;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory => itemInInventory.itemName ==
                         item.itemName))
            {
                itemInInventory.quantity--;
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.quantity <= 0)
            {
                Actions.OnSellItem?.Invoke(inventoryItem);
                _inventoryList.Remove(inventoryItem);
                Debug.Log($"stacked {item.itemName} sold and now empty");
            }
        }

        else
        {
            Actions.OnSellItem?.Invoke(item);
            _inventoryList.Remove(item);
            Debug.Log($"{item.itemName} sold");
        }
    }

    public void UseAndRemoveItem(Item item, int selectedCharacterUse, Vector2 target)
    {
        Debug.Log("Use & Remove initiated");

        if (item.isStackable)
        {
            Item inventoryItem = null;
            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory => itemInInventory.itemName ==
                         item.itemName))
            {
                itemInInventory.quantity--;
                Debug.Log("Inventory stack subtraction");
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.quantity <= 0)
            {
                Debug.Log("Item stack empty - item removed");
                _inventoryList.Remove(inventoryItem);
            }
        }

        else // same code as above but for non-stackable items
        {
            _inventoryList.Remove(item);
            Debug.Log("Item removed");
        }

        Actions.OnUseItem?.Invoke(item, selectedCharacterUse, target);
    }

    public void BuyItem(Item item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.quantity += item.quantity;
                itemAlreadyInInventory = true;
            }

            if (!itemAlreadyInInventory)
            {
                _inventoryList.Add(item);
            }
        }

        else
        {
            _inventoryList.Add(item);
        }

        shopList.Remove(item);
        item.isShopItem = false;
        Thulgran.ThulgranGold -= item.valueInCoins;
        Debug.Log("stackable item " + item.itemName + " removed from shop and added to Inventory");
    }

    public List<Item> GetItemsList()
    {
        return _inventoryList;
    }

    public List<Item> GetShopList()
    {
        return shopList;
    }

    public List<Item> GetInitialShopList()
    {
        return _initializeShop;
    }

    public static void AddMagic(MagicManager selectedCharacter)
    {
    }

    /// <summary>
    /// Returns the itemDetails (from the SO_ItemList) for the itemCode, or null if the item code doesn't exist
    /// </summary>
    public ItemDetails GetItemDetails(int itemCode)
    {
        return _itemDetailsDictionary.TryGetValue(itemCode, out ItemDetails getItemDetails) ? getItemDetails : null;
    }

    private void CreateItemDetailsDictionary()
    {
        _itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails createItemDetails in itemsList.itemsDetails.Where(createItemDetails =>
                     !_itemDetailsDictionary.ContainsKey(createItemDetails.itemCode)))
        {
            _itemDetailsDictionary.Add(createItemDetails.itemCode, createItemDetails);
        }

        Debug.Log($"Item dictionary: {_itemDetailsDictionary.Count} items");
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.inventoryDatas.inventoryItemsList = _inventoryList;
        a_SaveData.inventoryDatas.shopsItemsList = shopList;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _inventoryList = a_SaveData.inventoryDatas.inventoryItemsList;
        foreach (Item item in _inventoryList)
        {
            item.GetItemDetailsFromScriptObject(item);
        }

        shopList = a_SaveData.inventoryDatas.shopsItemsList;
    }

    #endregion
}