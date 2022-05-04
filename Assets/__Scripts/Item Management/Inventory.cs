using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Inventory : MonoBehaviour, ISaveable
{
    public static Inventory Instance; // GameManager

    private List<Item> _inventoryList;
    public List<Item> shopList;
    private List<Item> _initializeShop;


    private Dictionary<int, ItemDetails> _itemDetailsDictionary;

    [Header("Scriptable Object - Items")] [SerializeField]
    private SO_itemsList itemsList;

    private void Start()
    {
        Instance = this;
        _inventoryList = new List<Item>();
        _initializeShop = new List<Item>();
        shopList = new List<Item>();
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
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.quantity <= 0)
            {
                _inventoryList.Remove(inventoryItem);
                Actions.OnDropItem?.Invoke(item);
                Debug.Log($"{item.itemName} dropped");
            }
        }

        else
        {
            _inventoryList.Remove(item);
            Actions.OnDropItem?.Invoke(item);
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
                _inventoryList.Remove(inventoryItem);
                Debug.Log($"stacked {item.itemName} sold and now empty");
            }
        }

        else
        {
            _inventoryList.Remove(item);
            Debug.Log($"{item.itemName} sold");
        }

        Actions.OnSellItem?.Invoke(item); // Broadcast | subscribers: Thulgran, MenuManager, CoinsManager
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
                _inventoryList.Remove(inventoryItem);
                Debug.Log("Item stack empty - item removed");
            }
        }

        else // same code as above but for non-stackable items
        {
            _inventoryList.Remove(item);
            Debug.Log("Item removed");
        }

        Actions.OnUseItem?.Invoke(item, selectedCharacterUse,
            target);
        MenuManager.Instance.UpdateItemsInventory(); // Broadcast | subscribers: Thulgran, MenuManager, CoinsManager
        Debug.Log($"OnUseItem has broadcast for: {item.itemName}");
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