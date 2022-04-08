using System.Collections.Generic;

[System.Serializable]
public class GameItemsSave
{
    // string key = enum item list type (shop, inventory)
    public Dictionary<ItemLists, List<ItemsManager>> InventoryLists;

    public GameItemsSave()
    {
        InventoryLists = new Dictionary<ItemLists, List<ItemsManager>>();
    }

    public GameItemsSave(Dictionary<ItemLists, List<ItemsManager>> inventoryLists)
    {
        InventoryLists = inventoryLists;
    }
}