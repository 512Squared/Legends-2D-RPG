using System;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    
    public int itemPickupPlace;
    public Item item;
    private void OnEnable()
    {
        Actions.OnDropItem += DropAnItem;
    }

    private void OnDisable()
    {
        Actions.OnDropItem -= DropAnItem;
    }

    private void Start()
    {
        item = GetComponent<Item>();
    }

    private void DropAnItem(Item droppedItem)
    {
        if (droppedItem._itemGuid != item._itemGuid) { return; }
        
        Debug.Log($"DropItem called: {item.itemName}");
        SelfActivate();
        item.isPickedUp = false;
        DropItemPosition(item);
        NotificationFader.instance.CallFadeInOut($"You dropped the {droppedItem.itemName}", droppedItem.itemsImage,
            3f, 1400f,
            30);
    }
    
    private void DropItemPosition(Item item)
    {
        itemPickupPlace = PlayerGlobalData.Instance.currentSceneIndex;
        item.transform.SetParent(null);
        SetItemParent(GameManager.Instance.pickupParents[itemPickupPlace]);
        Transform playerTransform = PlayerGlobalData.Instance.gameObject.GetComponent<Transform>();
        transform.position = playerTransform.position;
        transform.position = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);
        Debug.Log(
            $"Dropped Item Position: {item.itemName} | itemPickupPlace: {itemPickupPlace} | position: {transform.position}");
    }
    
    private void SelfActivate()
    {
        item.spriteRenderer.enabled = true;
        item.polyCollider.enabled = true;
        Debug.Log($"Dropped {item.itemName} | Visible: {item.spriteRenderer.enabled} | Position: {transform.position}");
    }
 
    public void SetItemParent(Transform newParent)
    {
        transform.SetParent(newParent, false);
    }

}