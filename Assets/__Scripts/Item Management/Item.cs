using UnityEngine;


public class Item : MonoBehaviour
{
    [Space] public int quantity = 1;

    [Space] [ItemCodeDescription] [SerializeField]
    private int itemCode = 1000;

    [Space] public SpriteRenderer spriteRenderer;

    public PolygonCollider2D polyCollider;

    [SerializeField] private ItemDetails _so;

    public ItemDetails SO
    {
        get => _so;
        set => _so = value;
    }

    public int ItemCode { get => itemCode; set => itemCode = value; }

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(0);
    }

    private void Start()
    {
        if (ItemCode != 0)
        {
            Init(ItemCode);
        }
    }

    public void Init(int itemCodeParam)
    {
        if (itemCodeParam == 0)
        {
            return;
        }

        ItemCode = itemCodeParam;
        SO = Inventory.Instance.GetItemDetails(ItemCode);
        Debug.Log($"Details: {SO.itemName}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SO.isQuestObject)
        {
            SO = Inventory.Instance.GetItemDetails(ItemCode);
            SelfDeactivate();
            if (SO.pickUpNotice)
            {
                NotificationFader.instance.CallFadeInOut($"You picked up a {SO.itemName}", SO.itemsImage,
                    3f, 1000f,
                    30);
            }

            Inventory.Instance.AddItems(this);
            Debug.Log($"Item added: {SO.itemName}");
        }
    }

    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.Instance.GetPlayerStats()[characterToUseOn];


        Debug.Log("UseItem called from Item");
        if (SO.affectType == AffectType.Hp)
        {
            selectedCharacter.AddHP(SO.amountOfEffect);
            if (characterToUseOn != 0)
            {
                Debug.Log(SO.amountOfEffect + " HP given to " + selectedCharacter.playerName);
            }
        }

        else if (SO.affectType == AffectType.Mana)
        {
            selectedCharacter.AddMana(SO.amountOfEffect);
            Debug.Log(SO.amountOfEffect + $"Mana given to{selectedCharacter.playerName}");
        }


        else if (SO.itemType == ItemType.Armour)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterArmour.SO.itemDefence;

            if (selectedCharacter.characterArmourName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterArmour.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterArmour);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(SO.itemDefence);
            selectedCharacter.EquipArmour(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (SO.itemType == ItemType.Shield)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterShield.SO.itemDefence;

            if (selectedCharacter.characterShieldName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterShield.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterShield);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(SO.itemDefence);
            selectedCharacter.EquipShield(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }

        else if (SO.itemType == ItemType.Helmet)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.characterHelmet.SO.itemDefence;

            if (selectedCharacter.characterHelmetName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterHelmet.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterHelmet);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(SO.itemDefence);
            selectedCharacter.EquipHelmet(this);
            Debug.Log(selectedCharacter.playerName + " equipped with " + this);
        }


        else if (SO.itemType == ItemType.Weapon)
        {
            selectedCharacter.characterAttackTotal -= selectedCharacter.characterWeapon.SO.itemAttack;

            if (selectedCharacter.characterWeaponName != "")
            {
                Debug.Log(selectedCharacter.playerName + "'s equipped " +
                          selectedCharacter.characterWeapon.SO.itemName +
                          " has been added back into the Inventory");
                Inventory.Instance.AddItems(selectedCharacter.characterWeapon);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(SO.itemAttack);
            selectedCharacter.EquipWeapon(this);

            Debug.Log(selectedCharacter.playerName + " equipped with " + SO.itemName);
        }
    }

    private void SelfDeactivate()
    {
        spriteRenderer.enabled = false;
        polyCollider.enabled = false;
    }
}