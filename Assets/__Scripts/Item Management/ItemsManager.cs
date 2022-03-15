using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager instance;
    public enum ItemType { Item, Potion, Weapon, Armour, Skill, Spell, Food, Shield, Helmet, Relic }
    public ItemType itemType;

    public string itemName;
    [TextArea(5,5)]
    public string itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected = false;
    public bool isNewItem = true;
    public bool shopItem = false;
    public bool isQuestObject;
    public bool isInstantiated;
    public bool pickUpNotice = true;
    [Space]
    [InfoBox("ALL RELICS ARE QUEST ITEMS. IF YOU TICK THIS BOX, MAKE SURE THE ITEM HAS A QUEST COMPONENT ATTACHED AND THAT 'ITEM IS RELIC' IS TICKED THERE TOO. A RELIC BOX FROM THE RELICS UI PANEL IN THE HIERARCHY MUST ALSO BE ATTACHED TO THE QUEST COMPONENT IF IT IS TO WORK CORRECTLY.", InfoMessageType.Warning, "isRelic")]
    public bool isRelic;
    [Space]
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D polyCollider;  
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

        spriteRenderer = GetComponent<SpriteRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();

        // randomise item valueInCoins to ± 20% of double the bonus advantage gained
        int totalBonus = valueInCoins + amountOfEffect + itemAttack + itemDefence;
        float totBonus = (float)totalBonus;
        float valueInCoinsF = 0;

        valueInCoinsF += (totBonus * 2) + (totBonus * UnityEngine.Random.Range(-0.2f, 0.2f));

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
        if (collision.CompareTag("Player") && !isQuestObject)
        {
            SelfDeactivate();
            if (pickUpNotice)
            {
                NotificationFader.instance.CallFadeInOut($"You picked up a {itemName}", itemsImage, 3f, 1000f, 30);
            }
            Inventory.instance.AddItems(this);
        }
    }

    public void SelfDeactivate()
    {
        spriteRenderer.enabled = false;
        polyCollider.enabled = false;
    }

}
