using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using DG.Tweening;

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

        ShopManager.instance.shopItemName.text = itemOnButton.itemName;
        ShopManager.instance.shopItemDescription.text = itemOnButton.itemDescription;
        ShopManager.instance.shopItemImage.sprite = itemOnButton.itemsImage;
        ShopManager.instance.shopItemValue.text = itemOnButton.valueInCoins.ToString();
        ShopManager.instance.shopEffectText.text = itemOnButton.amountOfEffect.ToString();

        //Set up item stats in side panel. Reset values call values based on item type

        if (itemOnButton.itemType == ItemsManager.ItemType.Weapon)
        {
            MenuManager.instance.itemDamageBox.SetActive(true);
            MenuManager.instance.itemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemsManager.ItemType.Armour || itemOnButton.itemType == ItemsManager.ItemType.Helmet || itemOnButton.itemType == ItemsManager.ItemType.Shield)
        {
            MenuManager.instance.itemArmourBox.SetActive(true);
            MenuManager.instance.itemArmour.text = "+" + itemOnButton.itemDefence.ToString();
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Potion)
        {
            MenuManager.instance.itemPotionBox.SetActive(true);
            MenuManager.instance.itemPotion.text = "+" + itemOnButton.amountOfEffect.ToString();
            if (itemOnButton.itemName == "Speed Potion") MenuManager.instance.itemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Item)
        {
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Food)
        {
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemDamageBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(true);
            MenuManager.instance.itemFood.text = "+" + itemOnButton.amountOfEffect.ToString();
        }

        if (itemOnButton.itemType == ItemsManager.ItemType.Weapon)
        {
            ShopManager.instance.shopItemDamageBox.SetActive(true);
            ShopManager.instance.shopItemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            ShopManager.instance.shopItemArmourBox.SetActive(false);
            ShopManager.instance.shopItemPotionBox.SetActive(false);
            ShopManager.instance.shopItemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemsManager.ItemType.Armour || itemOnButton.itemType == ItemsManager.ItemType.Helmet || itemOnButton.itemType == ItemsManager.ItemType.Shield)
        {
            ShopManager.instance.shopItemArmourBox.SetActive(true);
            ShopManager.instance.shopItemArmour.text = "+" + itemOnButton.itemDefence.ToString();
            ShopManager.instance.shopItemDamageBox.SetActive(false);
            ShopManager.instance.shopItemPotionBox.SetActive(false);
            ShopManager.instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Potion)
        {
            ShopManager.instance.shopItemPotionBox.SetActive(true);
            ShopManager.instance.shopItemPotion.text = "+" + itemOnButton.amountOfEffect.ToString();
            if (itemOnButton.itemName == "Speed Potion") ShopManager.instance.shopItemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            ShopManager.instance.shopItemArmourBox.SetActive(false);
            ShopManager.instance.shopItemDamageBox.SetActive(false);
            ShopManager.instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Item)
        {
            ShopManager.instance.shopItemArmourBox.SetActive(false);
            ShopManager.instance.shopItemDamageBox.SetActive(false);
            ShopManager.instance.shopItemPotionBox.SetActive(false);
            ShopManager.instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Food)
        {
            ShopManager.instance.shopItemArmourBox.SetActive(false);
            ShopManager.instance.shopItemDamageBox.SetActive(false);
            ShopManager.instance.shopItemPotionBox.SetActive(false);
            ShopManager.instance.shopItemFoodBox.SetActive(true);
            ShopManager.instance.shopItemFood.text = "+" + itemOnButton.amountOfEffect.ToString();
        }



        GameManager.instance.activeItem = itemOnButton;
        MenuManager.instance.activeItem = itemOnButton;
        ShopManager.instance.activeItem = itemOnButton;

        itemOnButton.itemSelected = GameManager.instance.activeItem;

        if (itemOnButton.shopItem == true)
        {
            itemOnButton.itemSelected = ShopManager.instance.activeItem;
            ShopManager.instance.UpdateShopItemsInventory();
        }
        else if (itemOnButton.shopItem == false)
        {
            itemOnButton.itemSelected = MenuManager.instance.activeItem;
            MenuManager.instance.UpdateItemsInventory();
        }
    }
}
