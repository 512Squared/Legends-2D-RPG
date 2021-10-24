using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ItemButton : MonoBehaviour
{

    public ItemsManager itemOnButton;


    [TabGroup("Buttons"), Button]
    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;
        MenuManager.instance.itemImage.sprite = itemOnButton.itemsImage;
        MenuManager.instance.itemValue.text = itemOnButton.valueInCoins.ToString();
        MenuManager.instance.activeItem = itemOnButton;
        itemOnButton.itemSelected = MenuManager.instance.activeItem;
        MenuManager.instance.UpdateItemsInventory();
    }

}