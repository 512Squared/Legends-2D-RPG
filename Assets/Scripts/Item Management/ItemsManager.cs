using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager instance;
    public enum ItemType { Item, Potion, Weapon, Armour, Skill}
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected = false;
    public bool isNewItem = true;
    public bool itemSold = false;


    public enum AffectType { HP, Mana, Defence, Dexterity, Perception}
    public AffectType affectType;
    public int amountOfEffect;

    public int weaponPower;
    public int armourDefence;


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
                Debug.Log("HP given to " + selectedCharacter.playerName);
            }

            else if (affectType == AffectType.Mana)
            {
                selectedCharacter.AddMana(amountOfEffect);
                Debug.Log("Mana given to " + selectedCharacter.playerName);
            }
        }

        if (itemType == ItemType.Armour)
        {
            selectedCharacter.AddDefence(amountOfEffect);             
                Debug.Log("Defence given to " + selectedCharacter.playerName);
        }

        if (itemType == ItemType.Weapon)
        {
            Debug.Log("Weapon given to " + selectedCharacter.playerName);
        }

        // Maybe here for giving weapon and armour to characters?


    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
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
