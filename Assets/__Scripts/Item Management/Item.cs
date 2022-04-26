using System;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(GenerateGUID))]
public class Item : MonoBehaviour, ISaveable
{
    [Space] public int quantity = 1;

    [Space] [ItemCodeDescription] [SerializeField]
    private int itemCode = 1000;

    [Space] public SpriteRenderer spriteRenderer;

    public PolygonCollider2D polyCollider;


    private string _itemGuid;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public ItemType itemType;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public AffectType affectType;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public Shop shop; // pickUpItem, shop1, shop2, shop3

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemCodeSo = 1000;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int valueInCoins;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int amountOfEffect;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemAttack;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [BoxGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemDefence;

    [HorizontalGroup("Info")]
    [TableColumnWidth(220)]
    [BoxGroup("Info/a")]
    [LabelWidth(90)]
    [TextArea(1, 5)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    public string itemName;

    [Space]
    [HorizontalGroup("Info")]
    [TableColumnWidth(220)]
    [BoxGroup("Info/a")]
    [LabelWidth(90)]
    [TextArea(7, 7)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    public string itemDescription;

    [Space]
    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool itemSelected;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isNewItem = true;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isShopItem;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isQuestObject;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool pickUpNotice = true;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isRelic;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isStackable;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [BoxGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isPickedUp;

    [HorizontalGroup("Sprite")]
    [TableColumnWidth(120)]
    [BoxGroup("Sprite/a")]
    [HideLabel]
    [Space]
    [Space]
    [Space]
    [PreviewField(120, ObjectFieldAlignment.Center)]
    [GUIColor(0.2f, 0.286f, 0.680f)]
    public Sprite itemsImage;


    [SerializeField] private int itemDefenceModifier;
    [SerializeField] private int itemAttackModifier;
    [SerializeField] private int amountOfEffectModifier;

    public ItemDetails So { get; set; }

    public int ItemCode { get => itemCode; set => itemCode = value; }

    private void Awake()
    {
        if (ItemCode != 0)
        {
            Init(ItemCode);
        }

        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(0);

        GetItemDetailsFromScriptObject(this);
    }

    public Item GetItemDetailsFromScriptObject(Item item)
    {
        // Get itemDetails from SO list
        item.So = Inventory.Instance.GetItemDetails(ItemCode);


        // enums
        item.itemType = So.itemType;
        item.affectType = So.affectType;
        item.shop = So.shop;

        // variables
        item.isNewItem = So.isNewItem;
        item.isShopItem = So.isShopItem;
        item.itemDefence = So.itemDefence + itemDefenceModifier;
        item.itemAttack = So.itemAttack + itemAttackModifier;
        item.amountOfEffect = So.amountOfEffect + amountOfEffectModifier;
        item.valueInCoins = So.valueInCoins;
        item.itemCodeSo = So.itemCode;
        item.itemName = So.itemName;
        item.itemDescription = So.itemDescription;
        item.itemSelected = So.itemSelected;
        item.isQuestObject = So.isQuestObject;
        item.pickUpNotice = So.pickUpNotice;
        item.isRelic = So.isRelic;
        item.isStackable = So.isStackable;
        item.itemsImage = So.itemsImage;

        valueInCoins = CalculateValueInCoins(valueInCoins);
        return item;
    }

    private void Start()
    {
        _itemGuid = GetComponent<GenerateGUID>().GUID;
        GetItemDetailsFromScriptObject(this);
    }

    private int CalculateValueInCoins(int initialValue)
    {
        // randomise item valueInCoins to ± 20% of double the bonus advantage gained
        int totalBonus = initialValue + amountOfEffect + itemAttack + itemDefence;
        float totBonus = totalBonus;
        float valueInCoinsF = 0;

        valueInCoinsF += (totBonus * 2) + (totBonus * UnityEngine.Random.Range(-0.2f, 0.2f));

        valueInCoins = (int)Math.Round(valueInCoinsF);
        return valueInCoins;
    }

    public void Init(int itemCodeParam)
    {
        if (itemCodeParam == 0)
        {
            return;
        }

        ItemCode = itemCodeParam;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || So.isQuestObject) { return; }

        SelfDeactivate();
        if (pickUpNotice)
        {
            NotificationFader.instance.CallFadeInOut($"You picked up a {So.itemName}", So.itemsImage,
                3f, 1000f,
                30);
        }

        isPickedUp = true;
        Inventory.Instance.AddItems(this);
    }

    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.Instance.GetPlayerStats()[characterToUseOn];


        Debug.Log("UseItem called from Item");
        if (affectType == AffectType.Hp)
        {
            selectedCharacter.AddHp(So.amountOfEffect);
            if (characterToUseOn != 0)
            {
                Debug.Log(So.amountOfEffect + " HP given to " + selectedCharacter.playerName);
            }
        }

        else if (affectType == AffectType.Mana)
        {
            selectedCharacter.AddMana(So.amountOfEffect);
            Debug.Log(So.amountOfEffect + $"Mana given to{selectedCharacter.playerName}");
        }


        else if (itemType == ItemType.Armour)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterArmour.So.itemDefence;

            if (selectedCharacter.characterArmourName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterArmour.So.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterArmour);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(So.itemDefence);
            selectedCharacter.EquipArmour(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Shield)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterShield.So.itemDefence;

            if (selectedCharacter.characterShieldName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterShield.So.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterShield);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(So.itemDefence);
            selectedCharacter.EquipShield(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (itemType == ItemType.Helmet)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterHelmet.So.itemDefence;

            if (selectedCharacter.characterHelmetName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterHelmet.So.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterHelmet);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(So.itemDefence);
            selectedCharacter.EquipHelmet(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }


        else if (itemType == ItemType.Weapon)
        {
            selectedCharacter.characterAttackTotal -= selectedCharacter.characterWeapon.So.itemAttack;

            if (selectedCharacter.characterWeaponName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterWeapon.So.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterWeapon);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(So.itemAttack);
            selectedCharacter.EquipWeapon(this);

            Debug.Log(selectedCharacter.playerName + " equipped with " + So.itemName);
        }
    }

    private void SelfDeactivate()
    {
        spriteRenderer.enabled = false;
        polyCollider.enabled = false;
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.ItemsData id = new(_itemGuid, quantity, isPickedUp, isNewItem, isShopItem, spriteRenderer,
            polyCollider);

        a_SaveData.itemsData.Add(id);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _itemGuid = GetComponent<GenerateGUID>()?.GUID;
        if (GetComponent<GenerateGUID>() == null) { Debug.Log($"GUID is Null: {itemName}"); }

        foreach (SaveData.ItemsData id in a_SaveData.itemsData.Where(id => id.itemGuid == _itemGuid))
        {
            quantity = id.quantity;
            isPickedUp = id.isPickedUp;
            isNewItem = id.isNewItem;
            isShopItem = id.isShopItem;
            spriteRenderer = id.spriteRenderer;
            polyCollider = id.polyCollider;
            if (id.isPickedUp)
            {
                polyCollider.enabled = false;
                spriteRenderer.enabled = false;
            }

            break;
        }
    }

    #endregion
}