using System.Collections.Generic;

[System.Serializable]
public class GameItemsSave
{
    // string key = enum item list type (shop, inventory)
    public Dictionary<ItemLists, List<Item>> InventoryLists;

    public GameItemsSave()
    {
        InventoryLists = new Dictionary<ItemLists, List<Item>>();
    }

    public GameItemsSave(Dictionary<ItemLists, List<Item>> inventoryLists)
    {
        InventoryLists = inventoryLists;
    }
}