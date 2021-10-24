using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    
    public enum ItemType { Item, Potion, Weapon, Armor, Skill}
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected = false;
    public bool isNewItem = true;


    public enum AffectType { HP, Mana, Defence, Dexterity, Perception}
    public AffectType affectType;
    public int amountOfEffect;

    public int WeaponDexterity;
    public int armourDefence;
    public int speedIncrease;

    public bool isStackable;

    public int amount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }


}
