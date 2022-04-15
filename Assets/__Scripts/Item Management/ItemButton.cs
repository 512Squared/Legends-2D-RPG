using UnityEngine;
using Sirenix.OdinInspector;

public class ItemButton : MonoBehaviour
{
    public Item itemOnButton;

    [TabGroup("Buttons")]
    [Button]
    public void Press()
    {
        MenuManager.Instance.itemName.text = itemOnButton.SO.itemName;
        MenuManager.Instance.itemDescription.text = itemOnButton.SO.itemDescription;
        MenuManager.Instance.itemImage.sprite = itemOnButton.SO.itemsImage;
        MenuManager.Instance.itemValue.text = itemOnButton.SO.valueInCoins.ToString();
        MenuManager.Instance.effectText.text = itemOnButton.SO.amountOfEffect.ToString();

        ShopManager.Instance.shopItemName.text = itemOnButton.SO.itemName;
        ShopManager.Instance.shopItemDescription.text = itemOnButton.SO.itemDescription;
        ShopManager.Instance.shopItemImage.sprite = itemOnButton.SO.itemsImage;
        ShopManager.Instance.shopItemValue.text = itemOnButton.SO.valueInCoins.ToString();
        ShopManager.Instance.shopEffectText.text = itemOnButton.SO.amountOfEffect.ToString();

        //Set up item stats in side panel. Reset values call values based on item type

        if (itemOnButton.SO.itemType == ItemType.Weapon)
        {
            MenuManager.Instance.itemDamageBox.SetActive(true);
            MenuManager.Instance.itemDamage.text = "+" + itemOnButton.SO.itemAttack.ToString();
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }
        else if (itemOnButton.SO.itemType == ItemType.Armour ||
                 itemOnButton.SO.itemType == ItemType.Helmet ||
                 itemOnButton.SO.itemType == ItemType.Shield)
        {
            MenuManager.Instance.itemArmourBox.SetActive(true);
            MenuManager.Instance.itemArmour.text = "+" + itemOnButton.SO.itemDefence.ToString();
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Potion)
        {
            MenuManager.Instance.itemPotionBox.SetActive(true);
            MenuManager.Instance.itemPotion.text = "+" + itemOnButton.SO.amountOfEffect.ToString();
            if (itemOnButton.SO.itemName == "Speed Potion")
            {
                MenuManager.Instance.itemPotion.text = "x" + itemOnButton.SO.amountOfEffect.ToString();
            }

            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Item)
        {
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Food)
        {
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(true);
            MenuManager.Instance.itemFood.text = "+" + itemOnButton.SO.amountOfEffect.ToString();
        }

        if (itemOnButton.SO.itemType == ItemType.Weapon)
        {
            ShopManager.Instance.shopItemDamageBox.SetActive(true);
            ShopManager.Instance.shopItemDamage.text = "+" + itemOnButton.SO.itemAttack.ToString();
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }
        else if (itemOnButton.SO.itemType == ItemType.Armour ||
                 itemOnButton.SO.itemType == ItemType.Helmet ||
                 itemOnButton.SO.itemType == ItemType.Shield)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(true);
            ShopManager.Instance.shopItemArmour.text = "+" + itemOnButton.SO.itemDefence.ToString();
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Potion)
        {
            ShopManager.Instance.shopItemPotionBox.SetActive(true);
            ShopManager.Instance.shopItemPotion.text = "+" + itemOnButton.SO.amountOfEffect.ToString();
            if (itemOnButton.SO.itemName == "Speed Potion")
            {
                ShopManager.Instance.shopItemPotion.text = "x" + itemOnButton.SO.amountOfEffect.ToString();
            }

            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Item)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.SO.itemType == ItemType.Food)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(true);
            ShopManager.Instance.shopItemFood.text = "+" + itemOnButton.SO.amountOfEffect.ToString();
        }

        GameManager.Instance.activeItem = itemOnButton;
        MenuManager.Instance.activeItem = itemOnButton;
        ShopManager.Instance.activeItem = itemOnButton;

        itemOnButton.SO.itemSelected = GameManager.Instance.activeItem;

        switch (itemOnButton.SO.isShopItem)
        {
            case true:
                itemOnButton.SO.itemSelected = ShopManager.Instance.activeItem;
                ShopManager.Instance.UpdateShopItemsInventory();
                break;
            case false:
                itemOnButton.SO.itemSelected = MenuManager.Instance.activeItem;
                MenuManager.Instance.UpdateItemsInventory();
                break;
        }
    }
}