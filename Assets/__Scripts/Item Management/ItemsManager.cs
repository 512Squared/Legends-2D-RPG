using System;
using UnityEngine;
using Sirenix.OdinInspector;


[ShowOdinSerializedPropertiesInInspector]
public class ItemsManager : SerializedMonoBehaviour
{
    /*#region Data

    [HorizontalGroup("Main")]
    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public ItemType itemType;

    [HorizontalGroup("Main")]
    [HorizontalGroup("Main/Data")]
    [BoxGroup("Main/Data/Data")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public AffectType affectType;

    [HorizontalGroup("Main/Data", Width = 160)] [BoxGroup("Main/Data/Data")] [HideLabel] [GUIColor(0.058f, 0.380f, 1f)]
    public Shop shop; // inventory, shop1, shop2, shop3

    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    [SerializeField]
    private int itemCode = 1000;

    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int valueInCoins;

    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int amountOfEffect;

    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemAttack;

    [HorizontalGroup("Main/Data", Width = 160)]
    [BoxGroup("Main/Data/Data")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemDefence;

    [HorizontalGroup("Main/Info", Width = 220)]
    [BoxGroup("Main/Info/Info")]
    [LabelWidth(90)]
    [TextArea(1, 7)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    public string itemName;

    [HorizontalGroup("Main/Info", Width = 220)]
    [BoxGroup("Main/Info/Info")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    [TextArea(7, 7)]
    public string itemDescription;

    [Space]
    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool itemSelected;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isNewItem = true;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopItem;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isQuestObject;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool pickUpNotice = true;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isRelic;


    [HorizontalGroup("Main/Bools", Width = 120)]
    [BoxGroup("Main/Bools/Bools")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isStackable;

    [HorizontalGroup("Main/Sprite", Width = 120)]
    [BoxGroup("Main/Sprite/Sprite")]
    [HideLabel]
    [Space]
    [Space]
    [Space]
    [PreviewField(120, ObjectFieldAlignment.Center)]
    [GUIColor(0.2f, 0.286f, 0.680f)]
    public Sprite itemsImage;

    #endregion Data

    [Space] [Space] public int amount;

    [Space] public SpriteRenderer spriteRenderer;

    public PolygonCollider2D polyCollider;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(0);
        polyCollider = GetComponent<PolygonCollider2D>();

        // randomise item valueInCoins to ± 20% of double the bonus advantage gained
        int totalBonus = valueInCoins + amountOfEffect + itemAttack + itemDefence;
        float totBonus = totalBonus;
        float valueInCoinsF = 0;

        valueInCoinsF += (totBonus * 2) + (totBonus * UnityEngine.Random.Range(-0.2f, 0.2f));

        valueInCoins = (int)Math.Round(valueInCoinsF);
    }

    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.Instance.GetPlayerStats()[characterToUseOn];


        Debug.Log("UseItem called from ItemsManager");
        if (affectType == AffectType.Hp)
        {
            selectedCharacter.AddHP(amountOfEffect);
            if (characterToUseOn != 0)
            {
                Debug.Log(amountOfEffect + " HP given to " + selectedCharacter.playerName);
            }
        }

        else if (affectType == AffectType.Mana)
        {
            selectedCharacter.AddMana(amountOfEffect);
            Debug.Log(amountOfEffect + $"Mana given to{selectedCharacter.playerName}");
        }


        else if (itemType == ItemType.Armour)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterArmour.SO.itemDefence;

            if (selectedCharacter.characterArmourName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterArmour.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterArmour);

                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipArmour(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Shield)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterShield.SO.itemDefence;

            if (selectedCharacter.characterShieldName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterShield.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterShield);

                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipShield(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Helmet)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterHelmet.SO.itemDefence;

            if (selectedCharacter.characterHelmetName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterHelmet.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterHelmet);

                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipHelmet(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }


        else if (itemType == ItemType.Weapon)
        {
            selectedCharacter.characterAttackTotal -= selectedCharacter.characterWeapon.SO.itemAttack;

            if (selectedCharacter.characterWeaponName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " + selectedCharacter.characterWeapon.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterWeapon);

                MenuManager.instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(itemAttack);
            selectedCharacter.EquipWeapon(this);

            Debug.Log(selectedCharacter.playerName + " equipped with " + itemName);
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

            //Inventory.Instance.AddItems(this);
        }
    }

    private void SelfDeactivate()
    {
        spriteRenderer.enabled = false;
        polyCollider.enabled = false;
    }*/
}