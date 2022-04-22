using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance; // GameManager

    private List<Item> _inventoryList;
    private List<Item> _shopList;

    public List<Item>[] itemsLists;

    private Dictionary<int, ItemDetails> _itemDetailsDictionary;

    [Header("Scriptable Object - Items")] [SerializeField]
    private SO_itemsList itemsList;

    private void Start()
    {
        Instance = this;
        _inventoryList = new List<Item>();
        _shopList = new List<Item>();

        CreateItemDetailsDictionary();
    }


    public void AddItems(Item item)
    {
        if (item.SO.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.SO.itemName == item.SO.itemName))
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
        if (item.SO.isStackable)
        {
            bool itemAlreadyInShop = false;

            foreach (Item itemInShop in _shopList.Where(itemInShop =>
                         itemInShop.SO.itemName == item.SO.itemName || itemInShop.SO.shop == item.SO.shop))
            {
                itemInShop.quantity += item.quantity;
                itemAlreadyInShop = true;
            }

            if (!itemAlreadyInShop)
            {
                _shopList.Add(item);
            }
        }

        else
        {
            _shopList.Add(item);
        }
    }

    public void SellItem(Item item)
    {
        Debug.Log($"OnSellItem invoked for {GetItemDetails(item.ItemCode).itemName}");

        if (item.SO.isStackable)
        {
            Item inventoryItem = null;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory => itemInInventory.SO.itemName ==
                         item.SO.itemName))
            {
                itemInInventory.quantity--;
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.quantity <= 0)
            {
                _inventoryList.Remove(inventoryItem);
                Debug.Log($"stacked {item.SO.itemName} sold and now empty");
            }
        }

        else
        {
            _inventoryList.Remove(item);
            Debug.Log($"{item.SO.itemName} sold");
        }

        Actions.OnSellItem?.Invoke(item); // Broadcast | subscribers: Thulgran, MenuManager, CoinsManager
    }

    public void UseAndRemoveItem(Item item, int selectedCharacterUse, Vector2 target)
    {
        Debug.Log("Use & Remove initiated");

        if (item.SO.isStackable)
        {
            Item inventoryItem = null;
            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory => itemInInventory.SO.itemName ==
                         item.SO.itemName))
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
            target); // Broadcast | subscribers: Thulgran, MenuManager, CoinsManager
        Debug.Log($"OnUseItem has broadcast for: {GetItemDetails(item.ItemCode).itemName}");
    }

    public void BuyItem(Item item)
    {
        if (GetItemDetails(item.ItemCode).isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (Item itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.SO.itemName == GetItemDetails(item.ItemCode).itemName))
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

        _shopList.Remove(item);
        item.SO.isShopItem = false;
        Thulgran.ThulgranGold -= item.SO.valueInCoins;
        Debug.Log("stackable item " + item.SO.itemName + " removed from shop and added to Inventory");
    }

    public List<Item> GetItemsList()
    {
        return _inventoryList;
    }

    public List<Item> GetShopList()
    {
        return _shopList;
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

    #region SAVE

    private string SaveableUniqueID { get; set; }

    #endregion SAVE
}