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

        //Set up item stats in side panel. Reset values call values based on item type
        
        if (itemOnButton.itemType == ItemsManager.ItemType.Weapon )
        {
            MenuManager.instance.itemWeaponPower.text = "+" + itemOnButton.itemWeaponPower.ToString();
            MenuManager.instance.itemDamage.text = "+" + itemOnButton.itemWeaponPower.ToString();
            MenuManager.instance.itemDamageBox.SetActive(true);
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            Debug.Log("Item is a weapon: " + itemOnButton.itemWeaponPower);
        }
        else if (itemOnButton.itemType == ItemsManager.ItemType.Armour)
        {
            MenuManager.instance.itemArmourDefence.text = "+" + itemOnButton.itemArmourDefence.ToString();
            MenuManager.instance.itemArmour.text = "+" + itemOnButton.itemArmourDefence.ToString();
            MenuManager.instance.itemArmourBox.SetActive(true);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            Debug.Log("Item is armour: " + itemOnButton.itemArmourDefence);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Potion)
        {
            MenuManager.instance.itemPotion.text = "+" + itemOnButton.amountOfEffect.ToString();
            if (itemOnButton.itemName == "Speed Potion") MenuManager.instance.itemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(true);
            Debug.Log("Item is a potion: " + itemOnButton.amountOfEffect);

        }
        
        else
        {
            MenuManager.instance.itemArmourDefence.text = "";
            MenuManager.instance.itemPotionPower.text = "";
            MenuManager.instance.itemWeaponPower.text = "";
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            Debug.Log("Item is an item: " + itemOnButton.itemName);
        }

        MenuManager.instance.activeItem = itemOnButton;
        GameManager.instance.activeItem = itemOnButton;
 
        itemOnButton.itemSelected = MenuManager.instance.activeItem;
        itemOnButton.itemSelected = GameManager.instance.activeItem;

        MenuManager.instance.UpdateItemsInventory();

    }

   



}
