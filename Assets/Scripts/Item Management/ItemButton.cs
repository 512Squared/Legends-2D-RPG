using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Linq;

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
        MenuManager.instance.effectText.text = itemOnButton.amountOfEffect.ToString();
        
        MenuManager.instance.activeItem = itemOnButton;
        GameManager.instance.activeItem = itemOnButton;
        
        itemOnButton.itemSelected = MenuManager.instance.activeItem;
        itemOnButton.itemSelected = GameManager.instance.activeItem;

        GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable = true;

        MenuManager.instance.UpdateItemsInventory();

    }

   



}
