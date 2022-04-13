using UnityEngine;
using Sirenix.OdinInspector;

public class ItemButton : MonoBehaviour
{
    public ItemsManager itemOnButton;

    [TabGroup("Buttons")]
    [Button]
    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;
        MenuManager.instance.itemImage.sprite = itemOnButton.itemsImage;
        MenuManager.instance.itemValue.text = itemOnButton.valueInCoins.ToString();
        MenuManager.instance.effectText.text = itemOnButton.amountOfEffect.ToString();

        ShopManager.Instance.shopItemName.text = itemOnButton.itemName;
        ShopManager.Instance.shopItemDescription.text = itemOnButton.itemDescription;
        ShopManager.Instance.shopItemImage.sprite = itemOnButton.itemsImage;
        ShopManager.Instance.shopItemValue.text = itemOnButton.valueInCoins.ToString();
        ShopManager.Instance.shopEffectText.text = itemOnButton.amountOfEffect.ToString();

        //Set up item stats in side panel. Reset values call values based on item type

        if (itemOnButton.itemType == ItemsManager.ItemType.Weapon)
        {
            MenuManager.instance.itemDamageBox.SetActive(true);
            MenuManager.instance.itemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            MenuManager.instance.itemArmourBox.SetActive(false);
            MenuManager.instance.itemPotionBox.SetActive(false);
            MenuManager.instance.itemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemsManager.ItemType.Armour ||
                 itemOnButton.itemType == ItemsManager.ItemType.Helmet ||
                 itemOnButton.itemType == ItemsManager.ItemType.Shield)
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
            if (itemOnButton.itemName == "Speed Potion")
            {
                MenuManager.instance.itemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            }

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
            ShopManager.Instance.shopItemDamageBox.SetActive(true);
            ShopManager.Instance.shopItemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemsManager.ItemType.Armour ||
                 itemOnButton.itemType == ItemsManager.ItemType.Helmet ||
                 itemOnButton.itemType == ItemsManager.ItemType.Shield)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(true);
            ShopManager.Instance.shopItemArmour.text = "+" + itemOnButton.itemDefence.ToString();
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Potion)
        {
            ShopManager.Instance.shopItemPotionBox.SetActive(true);
            ShopManager.Instance.shopItemPotion.text = "+" + itemOnButton.amountOfEffect.ToString();
            if (itemOnButton.itemName == "Speed Potion")
            {
                ShopManager.Instance.shopItemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            }

            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Item)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemsManager.ItemType.Food)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(true);
            ShopManager.Instance.shopItemFood.text = "+" + itemOnButton.amountOfEffect.ToString();
        }

        GameManager.Instance.activeItem = itemOnButton;
        MenuManager.instance.activeItem = itemOnButton;
        ShopManager.Instance.activeItem = itemOnButton;

        itemOnButton.itemSelected = GameManager.Instance.activeItem;

        switch (itemOnButton.isShopItem)
        {
            case true:
                itemOnButton.itemSelected = ShopManager.Instance.activeItem;
                ShopManager.Instance.UpdateShopItemsInventory();
                break;
            case false:
                itemOnButton.itemSelected = MenuManager.instance.activeItem;
                MenuManager.instance.UpdateItemsInventory();
                break;
        }
    }
}