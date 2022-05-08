﻿using System.Linq;
using UnityEngine;

public class DropItem : MonoBehaviour, ISaveable
{
    public int itemPickupPlace;
    public Item item;
    private Vector3 _itemPosition;
    public string _itemDropGUID;

    private void Validate()
    {
        _itemDropGUID = GetComponent<GenerateGUID>().GUID;
    }

    private void OnEnable()
    {
        Actions.OnDropItem += DropAnItem;
    }

    private void OnDisable()
    {
        Actions.OnDropItem -= DropAnItem;
    }

    private void DropAnItem(Item droppedItem)
    {
        if (droppedItem.itemGuid != item.itemGuid) { return; }

        Debug.Log($"DropItem called: {item.itemName}");
        SelfActivate();
        item.isPickedUp = false;
        DropItemPosition(item);
        NotificationFader.instance.CallFadeInOut($"You dropped the {droppedItem.itemName}", droppedItem.itemsImage,
            3f, 1400f,
            30);
    }

    private void DropItemPosition(Item itemToDrop)
    {
        itemPickupPlace = PlayerGlobalData.Instance.currentSceneIndex;
        SetItemParent(GameManager.Instance.pickupParents[itemPickupPlace], true);
        Transform playerTransform = PlayerGlobalData.Instance.gameObject.GetComponent<Transform>();
        transform.position = playerTransform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y - 1.34f, transform
            .position.z);
        Debug.Log(
            $"Dropped Item Position: {itemToDrop.itemName} | itemPickupPlace: {itemPickupPlace} | position: {transform.position}");
    }

    private void SelfActivate()
    {
        item.spriteRenderer.enabled = true;
        item.polyCollider.enabled = true;
        Debug.Log($"Dropped {item.itemName} | Visible: {item.spriteRenderer.enabled} | Position: {transform.position}");
    }

    public void SetItemParent(Transform newParent, bool worldSpace)
    {
        transform.SetParent(newParent, worldSpace);
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        _itemPosition = transform.position;
        SaveData.DroppedItemsData did = new(_itemPosition, itemPickupPlace, _itemDropGUID);
        a_SaveData.droppedItemsData.Add(did);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _itemDropGUID = GetComponent<GenerateGUID>().GUID;       


        foreach (SaveData.DroppedItemsData did in a_SaveData.droppedItemsData.Where(did =>
                     did.itemDropGUID == _itemDropGUID))
        {
            _itemPosition = did.itemPosition;
            itemPickupPlace = did.itemPickupPlace;
            transform.position = did.itemPosition;
            Debug.Log($"Item: {item.itemName} | Item PickUpPlace: {itemPickupPlace} | Item position: {_itemPosition}");
            SetItemParent(
                item.isPickedUp
                    ? GameManager.Instance.pickedUpItems.transform
                    : GameManager.Instance.pickupParents[itemPickupPlace], true);
        }
    }

    #endregion
}