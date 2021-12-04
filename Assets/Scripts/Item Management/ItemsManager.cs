using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager instance;
    public enum ItemType { Item, Potion, Weapon, Armour, Skill, Spell }
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected = false;
    public bool isNewItem = true;
    public bool itemSold = false;


    public enum AffectType { HP, Mana, Defence, Attack, Perception }
    public AffectType affectType;
    public int amountOfEffect;

    public int itemWeaponPower;
    public int itemArmourDefence;


    public bool isStackable;

    public int amount;

    private void Start()
    {
        instance = this;
    }


    public void UseItem(int characterToUseOn)
    {

        PlayerStats selectedCharacter = GameManager.instance.GetPlayerStats()[characterToUseOn];



        Debug.Log("UseItem called from ItemsManager");
        if (itemType == ItemType.Potion)
        {
            if (affectType == AffectType.HP)
            {
                selectedCharacter.AddHP(amountOfEffect);
                Debug.Log(amountOfEffect + " HP given to " + selectedCharacter.playerName);

            }

            else if (affectType == AffectType.Mana)
            {
                selectedCharacter.AddMana(amountOfEffect);
                Debug.Log(amountOfEffect + " Mana given to " + selectedCharacter.playerName);
            }
        }

        else if (itemType == ItemType.Armour)
        {
            if (selectedCharacter.equippedArmourName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.equippedArmour.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.equippedArmour);

                MenuManager.instance.UpdateItemsInventory();
            }
            selectedCharacter.AddArmourDefence(itemArmourDefence);
            selectedCharacter.EquipArmour(this);
            MenuManager.instance.UpdateStats();
            
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Weapon)
        {
            if (selectedCharacter.equippedWeaponName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.equippedWeapon.itemName + " has been added back into the Inventory");
                Inventory.instance.AddItems(selectedCharacter.equippedWeapon);
                
                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(itemWeaponPower);
            selectedCharacter.EquipWeapon(this);
            MenuManager.instance.UpdateStats();

            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
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
