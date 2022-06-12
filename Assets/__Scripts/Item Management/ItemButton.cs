using UnityEngine;
using Sirenix.OdinInspector;

public class ItemButton : MonoBehaviour
{
    public Item itemOnButton;

    [TabGroup("Buttons")]
    [Button]
    public void Press()
    {
        AudioManager.Instance.PlaySfxClip(8);
        itemOnButton.GetItemDetailsFromScriptObject(itemOnButton);

        MenuManager.Instance.itemName.text = itemOnButton.itemName;
        MenuManager.Instance.itemDescription.text = itemOnButton.itemDescription;
        MenuManager.Instance.itemImage.sprite = itemOnButton.itemsImage;
        MenuManager.Instance.itemValue.text = itemOnButton.valueInCoins.ToString();
        MenuManager.Instance.effectText.text = itemOnButton.amountOfEffect.ToString();

        ShopManager.Instance.shopItemName.text = itemOnButton.itemName;
        ShopManager.Instance.shopItemDescription.text = itemOnButton.itemDescription;
        ShopManager.Instance.shopItemImage.sprite = itemOnButton.itemsImage;
        ShopManager.Instance.shopItemValue.text = itemOnButton.valueInCoins.ToString();
        ShopManager.Instance.shopEffectText.text = itemOnButton.amountOfEffect.ToString();

        //Set up item stats in side panel. Reset values call values based on item type

        if (itemOnButton.itemType == ItemType.Weapon)
        {
            MenuManager.Instance.itemDamageBox.SetActive(true);
            MenuManager.Instance.itemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemType.Armour ||
                 itemOnButton.itemType == ItemType.Helmet ||
                 itemOnButton.itemType == ItemType.Shield)
        {
            MenuManager.Instance.itemArmourBox.SetActive(true);
            MenuManager.Instance.itemArmour.text = "+" + itemOnButton.itemDefence.ToString();
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemType.Potion)
        {
            MenuManager.Instance.itemPotionBox.SetActive(true);
            MenuManager.Instance.itemPotion.text = "+" + itemOnButton.amountOfEffect.ToString();
            if (itemOnButton.itemName == "Speed Potion")
            {
                MenuManager.Instance.itemPotion.text = "x" + itemOnButton.amountOfEffect.ToString();
            }

            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemType.Item)
        {
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemType.Food)
        {
            MenuManager.Instance.itemArmourBox.SetActive(false);
            MenuManager.Instance.itemDamageBox.SetActive(false);
            MenuManager.Instance.itemPotionBox.SetActive(false);
            MenuManager.Instance.itemFoodBox.SetActive(true);
            MenuManager.Instance.itemFood.text = "+" + itemOnButton.amountOfEffect.ToString();
        }

        if (itemOnButton.itemType == ItemType.Weapon)
        {
            ShopManager.Instance.shopItemDamageBox.SetActive(true);
            ShopManager.Instance.shopItemDamage.text = "+" + itemOnButton.itemAttack.ToString();
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }
        else if (itemOnButton.itemType == ItemType.Armour ||
                 itemOnButton.itemType == ItemType.Helmet ||
                 itemOnButton.itemType == ItemType.Shield)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(true);
            ShopManager.Instance.shopItemArmour.text = "+" + itemOnButton.itemDefence.ToString();
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemType.Potion)
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

        else if (itemOnButton.itemType == ItemType.Item)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(false);
        }

        else if (itemOnButton.itemType == ItemType.Food)
        {
            ShopManager.Instance.shopItemArmourBox.SetActive(false);
            ShopManager.Instance.shopItemDamageBox.SetActive(false);
            ShopManager.Instance.shopItemPotionBox.SetActive(false);
            ShopManager.Instance.shopItemFoodBox.SetActive(true);
            ShopManager.Instance.shopItemFood.text = "+" + itemOnButton.amountOfEffect.ToString();
        }

        GameManager.Instance.activeItem = itemOnButton;
        MenuManager.Instance.activeItem = itemOnButton;
        ShopManager.Instance.activeItem = itemOnButton;

        itemOnButton.itemSelected = GameManager.Instance.activeItem;

        switch (itemOnButton.isShopItem)
        {
            case true:
                itemOnButton.itemSelected = ShopManager.Instance.activeItem;
                ShopManager.Instance.UpdateShopItemsInventory();
                break;
            case false:
                itemOnButton.itemSelected = MenuManager.Instance.activeItem;
                MenuManager.Instance.UpdateItemsInventory();
                break;
        }
    }
}