using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

public class ItemsManager : MonoBehaviour, ISaveable
{
    //[ItemCodeDescription]
    [FormerlySerializedAs("_itemCode")] [SerializeField]
    private int itemCode;

    public int ItemCode { get => itemCode; set => itemCode = value; }

    public enum ItemType { Item, Potion, Weapon, Armour, Skill, Spell, Food, Shield, Helmet, Relic }

    public ItemType itemType;

    public string itemName;
    [TextArea(5, 5)]
    public string itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;
    public bool itemSelected;
    public bool isNewItem = true;
    public bool shopItem;
    public bool isQuestObject;
    public bool pickUpNotice = true;
    [Space]
    [InfoBox("ALL RELICS ARE QUEST ITEMS. IF YOU TICK THIS BOX, MAKE SURE THE ITEM HAS A QUEST COMPONENT ATTACHED AND THAT 'ITEM IS RELIC' IS TICKED THERE TOO. A RELIC BOX FROM THE RELICS UI PANEL IN THE HIERARCHY MUST ALSO BE ATTACHED TO THE QUEST COMPONENT IF IT IS TO WORK CORRECTLY. ALSO, THE BUTTON ON THE UI PANEL NEEDS THE EXACT SAME ITEM NAME.", InfoMessageType.Warning, "isRelic")]
    public bool isRelic;
    [Space]
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D polyCollider;
    public enum Shop { Inventory, Shop1, Shop2, Shop3 }
    public Shop shop; // inventory, shop1, shop2, shop3


    public enum AffectType { Hp, Mana, Defence, Attack, Perception, Speed }
    public AffectType affectType;
    public int amountOfEffect;

    public int itemAttack;
    public int itemDefence;


    public bool isStackable;

    public int amount;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();

        // randomise item valueInCoins to ± 20% of double the bonus advantage gained
        int totalBonus = valueInCoins + amountOfEffect + itemAttack + itemDefence;
        float totBonus = totalBonus;
        float valueInCoinsF = 0;

        valueInCoinsF += (totBonus * 2) + (totBonus * UnityEngine.Random.Range(-0.2f, 0.2f));

        valueInCoins = (int)Math.Round(valueInCoinsF);

        if (ItemCode != 0)
        {
            Init(ItemCode);
        }

    }

    public void UseItem(int characterToUseOn)
    {

        PlayerStats selectedCharacter = GameManager.Instance.GetPlayerStats()[characterToUseOn];


        Debug.Log("UseItem called from ItemsManager");
        if (affectType == AffectType.Hp)
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

    private void SelfDeactivate()
    {
        spriteRenderer.enabled = false;
        polyCollider.enabled = false;
    }

    public void Init(int itemCodeParam)
    {
        if (itemCodeParam != 0)
        {
            ItemCode = itemCodeParam;

            //ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(ItemCode);
        }

    }

    public string ISaveableUniqueID { get; set; }
    
    public GameObjectSave GameObjectSave { get; set; }
    public void ISaveableRegister()
    {
        throw new NotImplementedException();
    }

    public void ISaveableDeregister()
    {
        throw new NotImplementedException();
    }

    public GameObjectSave ISaveableSave()
    {
        throw new NotImplementedException();
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        throw new NotImplementedException();
    }

    public void ISaveableStoreScene(string sceneName)
    {
        throw new NotImplementedException();
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        throw new NotImplementedException();
    }
}
