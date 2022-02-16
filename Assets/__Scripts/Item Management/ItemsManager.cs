using System;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager instance;
    public enum ItemType { Item, Potion, Weapon, Armour, Skill, Spell, Food, Shield, Helmet }
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected = false;
    public bool isNewItem = true;
    public bool shopItem = false;

    public enum Shop { inventory, shop1, shop2, shop3 }
    public Shop shop; // inventory, shop1, shop2, shop3


    public enum AffectType { HP, Mana, Defence, Attack, Perception, Speed }
    public AffectType affectType;
    public int amountOfEffect = 0;

    public int itemAttack;
    public int itemDefence;


    public bool isStackable;

    public int amount;


    private void Start()
    {
        instance = this;

        // randomise item valueInCoins to � 20% of double the bonus advantage gained
        int totalBonus = valueInCoins + amountOfEffect + itemAttack + itemDefence;
        float totBonus = (float)totalBonus;
        float valueInCoinsF = 0;

        valueInCoinsF +=  (totBonus * 2) + (totBonus * UnityEngine.Random.Range(-0.2f, 0.2f));

        valueInCoins = (int)Math.Round(valueInCoinsF);

    }

    public void UseItem(int characterToUseOn)
    {

        PlayerStats selectedCharacter = GameManager.instance.GetPlayerStats()[characterToUseOn];


        Debug.Log("UseItem called from ItemsManager");
        if (affectType == AffectType.HP)
        {
            selectedCharacter.AddHP(amountOfEffect);
            if (characterToUseOn != 0) Debug.Log(amountOfEffect + " HP given to " + selectedCharacter.playerName);
        }

        else if (affectType == AffectType.Mana)
        {
            selectedCharacter.AddMana(amountOfEffect);
            Debug.Log(amountOfEffect + $"Mana given to{selectedCharacter.playerName}");

        }


        else if (itemType == ItemType.Armour)
        {

            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterArmour.itemDefence;

            if (selectedCharacter.characterArmourName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterArmour.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.characterArmour);

                MenuManager.instance.UpdateItemsInventory();
            }
            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipArmour(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Shield)
        {

            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterShield.itemDefence;

            if (selectedCharacter.characterShieldName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterShield.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.characterShield);

                MenuManager.instance.UpdateItemsInventory();
            }
            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipShield(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Helmet)
        {

            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterHelmet.itemDefence;

            if (selectedCharacter.characterHelmetName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterHelmet.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.characterHelmet);

                MenuManager.instance.UpdateItemsInventory();
            }
            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipHelmet(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }


        else if (itemType == ItemType.Weapon)
        {

            selectedCharacter.characterAttackTotal -= selectedCharacter.characterWeapon.itemAttack;

            if (selectedCharacter.characterWeaponName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterWeapon.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.characterWeapon);

                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(itemAttack);
            selectedCharacter.EquipWeapon(this);

            Debug.Log(selectedCharacter.playerName + " equipped with " + this.itemName);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("You picked up a " + itemName);
            SelfDestroy();
            Inventory.instance.AddItems(this);

        }
    }

    public void SelfDestroy()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }


}
