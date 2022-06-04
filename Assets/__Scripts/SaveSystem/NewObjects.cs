using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewObjects : SingletonMonobehaviour<NewObjects>, ISaveable
{
    public GameObject itemPrefab;

    public List<Item> Objects { get; set; }

    private void Start()
    {
        itemPrefab = Resources.Load("itemPrefab") as GameObject;
        Objects = new List<Item>();
    }


    public NewObjects(List<Item> newObjects)
    {
        Objects = newObjects;
    }

    public void AddNewObjectToSaveList(Item item)
    {
        Objects.Add(item);
    }

    public void InstantiateDroppedObject(Item item)
    {
        GameObject newObject = Instantiate(itemPrefab,
            GameManager.Instance.pickupParents[PlayerGlobalData.Instance.currentSceneIndex]);
        newObject.name = $"{item.itemName}_new";
        Item it = newObject.GetComponent<Item>();
        it.GetComponent<GenerateGUID>().CreateNewGUID();
        it.itemGuid = it.GetComponent<GenerateGUID>().GUID;
        it.ItemCode = item.ItemCode;
        it.GetItemDetailsFromScriptObject(it);
        it.quantity = 1;
        it.hasBeenDropped = true;
        it.isPrefab = true;
        it.spriteRenderer.sprite = it.itemsImage;
        it.polyCollider.TryUpdateShapeToAttachedSprite();
        Debug.Log(
            $"New object created: {it.itemName} | GUID: {it.itemGuid} | Image: {it.spriteRenderer.sprite} | CurrentSceneIndex: {PlayerGlobalData.Instance.currentSceneIndex}");
        OnDropItem(it);
        AddNewObjectToSaveList(it);
    }

    public void RemoveItem(Item item)
    {
        Debug.Log($"Prefab Object List: {Objects.Count}");
        if (Objects.Any(prefabObject => item.itemGuid == prefabObject.itemGuid)) { Objects.Remove(item); }

        Debug.Log($"Prefab Object List: {Objects.Count}");
    }


    public static void OnDropItem(Item it)
    {
        Actions.OnDropItem?.Invoke(it);
    }

    public void SetItemParent(Transform newParent, bool worldSpace)
    {
        transform.SetParent(newParent, worldSpace);
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.DroppedItemsData did in Objects.Select(item => new SaveData.DroppedItemsData(item.ItemCode,
                     item.itemGuid, item.itemName, item.quantity, item.pickup, item.isPickedUp, item.isShopItem,
                     item.isNewItem,
                     item.spriteRenderer, item.polyCollider, item.itemPosition, item.itemPickupPlace,
                     item.isDeletedStack, item
                         .boughtFromShop)))
        {
            string guid = did.itemGuid[..8];

            a_SaveData.droppedItems.Add(did);

            Debug.Log($"Dropped Item Saved: {did.itemName} | GUID: {guid}");
        }

        Debug.Log($"Dropped NewObjects List: {Objects.Count}");
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.DroppedItemsData did in a_SaveData.droppedItems)
        {
            string guid = did.itemGuid[..8];

            GameObject newObj = Instantiate(itemPrefab, GameManager.Instance.pickupParents[did.itemPickupPlace]);
            newObj.name = $"{did.itemName}_rebuilt";
            newObj.transform.position = did.itemPosition;
            newObj.GetComponent<GenerateGUID>().GUID = did.itemGuid;

            Item id = newObj.GetComponent<Item>();

            id.ItemCode = did.itemCode;
            id.GetItemDetailsFromScriptObject(id); // this is necessary to retrieve the right image

            id.isPrefab = true;
            id.itemGuid = did.itemGuid;
            id.pickup = did.pickup;
            id.itemPickupPlace = did.itemPickupPlace;
            id.itemPosition = did.itemPosition;
            id.quantity = did.quantity;
            id.isPickedUp = did.isPickedUp;
            id.isNewItem = did.isNewItem;
            id.isShopItem = did.isShopItem;
            id.isDeletedStack = did.isDeletedStack;

            if (id.spriteRenderer) { id.spriteRenderer.sprite = id.itemsImage; }

            if (id.polyCollider) { id.polyCollider.TryUpdateShapeToAttachedSprite(); }

            if (id.isPickedUp)
            {
                id.polyCollider.enabled = false;
                id.spriteRenderer.enabled = false;
            }

            id.SetItemParent(
                id.isPickedUp
                    ? GameManager.Instance.pickedUpItems.transform
                    : GameManager.Instance.pickupParents[id.itemPickupPlace], true);

            id.itemName += "_rebuilt";

            AddNewObjectToSaveList(id);

            Debug.Log($"Dropped Item Rebuilt: {id.itemName} | GUID: {guid}");

            //id.polyCollider = newObj.GetComponent<PolygonCollider2D>();
            //id.spriteRenderer = newObj.GetComponentInChildren<SpriteRenderer>();
        }
    }

    #endregion
}