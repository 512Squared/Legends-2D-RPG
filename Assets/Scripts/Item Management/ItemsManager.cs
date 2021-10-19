using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    
    public enum ItemType { Item, Potion, Spell, Weapon, Armor, Skill}
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemImage;


    public enum AffectType { HP, Mana, Defence, Dexterity, Perception}
    public AffectType affectType;
    public int amountOfEffect;

    public int WeaponDexterity;
    public int armourDefence;

    public int speedIncrease;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
