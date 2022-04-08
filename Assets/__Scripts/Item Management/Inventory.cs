using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Inventory : MonoBehaviour, ISaveable
{
    public static Inventory Instance; // GameManager

    private List<ItemsManager> _inventoryList;
    private List<ItemsManager> _shopList;

    public List<ItemsManager>[] itemsLists;

    private Dictionary<int, ItemDetails> _itemDetailsDictionary;

    [SerializeField] private SO_itemsList itemsList;


    private void Start()
    {
        Instance = this;
        _inventoryList = new List<ItemsManager>();
        _shopList = new List<ItemsManager>();

        SaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameItemsSave = new GameItemsSave();

        CreateItemDetailsDictionary();
    }

    private void OnEnable()
    {
        SaveableRegister();
    }

    private void OnDisable()
    {
        SaveableDeregister();
    }

    public void AddItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (ItemsManager itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.amount += item.amount;
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
    }

    public void AddShopItems(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInShop = false;

            foreach (ItemsManager itemInShop in _shopList.Where(itemInShop =>
                         itemInShop.itemName == item.itemName || itemInShop.shop == item.shop))
            {
                itemInShop.amount += item.amount;
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

    public void SellItem(ItemsManager item)
    {
        Debug.Log($"OnSellItem invoked for {item.itemName}");

        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.amount--;
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
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

    public void UseAndRemoveItem(ItemsManager item, int selectedCharacterUse, Vector2 target)
    {
        Debug.Log("Use & Remove initiated");

        if (item.isStackable)
        {
            ItemsManager inventoryItem = null;
            foreach (ItemsManager itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.amount--;
                Debug.Log("Inventory stack subtraction");
                inventoryItem = itemInInventory;
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
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
        Debug.Log($"OnUseItem has broadcast for: {item.itemName}");
    }

    public void BuyItem(ItemsManager item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (ItemsManager itemInInventory in _inventoryList.Where(itemInInventory =>
                         itemInInventory.itemName == item.itemName))
            {
                itemInInventory.amount += item.amount;
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
        item.shopItem = false;
        Thulgran.ThulgranGold -= item.valueInCoins;
        Debug.Log("stackable item " + item.itemName + " removed from shop and added to Inventory");
    }

    public List<ItemsManager> GetItemsList()
    {
        return _inventoryList;
    }

    public List<ItemsManager> GetShopList()
    {
        return _shopList;
    }

    public static void AddMagic(MagicManager selectedCharacter)
    {
    }

    public string SaveableUniqueID { get; set; }
    public GameItemsSave GameItemsSave { get; set; }

    public void SaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public void SaveableDeregister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    }

    public GameItemsSave SaveableSave()
    {
        // Add scene save for gameobject
        GameItemsSave.InventoryLists = new Dictionary<ItemLists, List<ItemsManager>>
        {
            {ItemLists.Inventory, _inventoryList}, {ItemLists.Shop, _shopList}
        };
        return GameItemsSave;
    }

    public void SaveableLoad(GameSave gameSave)
    {
        if (!gameSave.GameItemsData.TryGetValue(SaveableUniqueID, out GameItemsSave gameItemsSave))
        {
            return;
        }

        GameItemsSave = gameItemsSave;

        if (gameItemsSave == null)
        {
            return;
        }

        _shopList = GameItemsSave.InventoryLists[ItemLists.Shop];
        _inventoryList = GameItemsSave.InventoryLists[ItemLists.Inventory];
    }

    public void SaveableStoreScene(string sceneName)
    {
        throw new NotImplementedException("Saveable store scene not implemented");
    }

    public void SaveableRestoreScene(string sceneName)
    {
        throw new NotImplementedException("Restore scene not implemented");
    }

    /// <summary>
    /// Returns the itemDetails (from the SO_ItemList) for the itemCode, or null if the item code doesn't exist
    /// </summary>
    public ItemDetails GetItemDetails(int itemCode)
    {
        return _itemDetailsDictionary.TryGetValue(itemCode, out ItemDetails itemDetails) ? itemDetails : null;
    }

    private void CreateItemDetailsDictionary()
    {
        _itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails itemDetails in itemsList.itemDetail.Where(itemDetails =>
                     !_itemDetailsDictionary.ContainsKey(itemDetails.itemCode)))
        {
            _itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }
}