using System;
using System.Collections;
using System.Linq;
using Assets.HeroEditor4D.FantasyInventory.Scripts.Data;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(GenerateGUID))]
public class Item : MonoBehaviour, ISaveable
{
    #region SERIALIZATION

    [TitleGroup("SO details")]
    [Space] public int quantity = 1;

    [Space] [ItemCodeDescription] [SerializeField]
    private int itemCode = 1000;

    public SceneObjectsUnload itemHome;

    [ShowIf("isShopItem")]
    public Shop shop; // pickUpItem, shop1, shop2, shop3

    [TitleGroup("Item Configuration")]
    [Space] [ShowIf("isWearable")]
    public Wearables wearableItems;

    [Required]
    public SpriteRenderer spriteRenderer;

    [Required]
    public PolygonCollider2D polyCollider;


    [HideInInspector]
    public string itemGuid;

    [HideInInspector]
    public ItemType itemType;

    [HideInInspector]
    public AffectType affectType;


    [HideInInspector]
    public int itemCodeSo = 1000;

    [HideInInspector]
    public int valueInCoins;

    [HideInInspector]
    public int amountOfEffect;

    [HideInInspector]
    public int itemAttack;

    [HideInInspector]
    public int itemDefence;

    [HideInInspector]
    public string itemName;

    [HideInInspector]
    public string itemDescription;

    [HideInInspector]
    public bool itemSelected;

    [HideInInspector]
    public bool isNewItem = true;

    [Space]
    public bool isShopItem;

    public bool isQuestObject;

    public bool isWearable;

    public bool isPrefab;

    public bool pickUpNotice = true;

    [HideInInspector]
    public bool isRelic;

    [HideInInspector]
    public bool isStackable;

    [TitleGroup("Info Bools")]
    public bool isPickedUp;

    public bool isDeletedStack;

    public bool hasBeenDropped;

    public bool boughtFromShop;

    [HideInInspector]
    public AudioManager audio;

    [HideInInspector]
    [PreviewField(120, ObjectFieldAlignment.Center)]
    [GUIColor(0.2f, 0.286f, 0.680f)]
    public Sprite itemsImage;

    [HideInInspector]
    public int pickup; // not sure if this was implemented outside of save

    [TitleGroup("Modifiers")]
    [SerializeField] private int DefenceModifier;

    [SerializeField] private int AttackModifier;
    [SerializeField] private int EffectModifier;

    public ItemDetails So { get; set; }

    public int ItemCode { get => itemCode; set => itemCode = value; }

    [TitleGroup("Misc")]
    [HideInInspector]
    public int itemPickupPlace;

    public Vector3 itemPosition;

    #endregion

    private void Awake()
    {
        if (ItemCode != 0)
        {
            Init(ItemCode);
        }

        if (itemType is ItemType.Armour or ItemType.Shield or ItemType.Weapon or ItemType.Helmet) { isWearable = true; }

        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(0);
    }


    private void OnEnable()
    {
        Actions.OnDropItem += DropAnItem;
    }

    private void OnDisable()
    {
        Actions.OnDropItem -= DropAnItem;
    }


    private void Start()
    {
        itemGuid = GetComponent<GenerateGUID>().GUID;
        audio = FindObjectOfType<AudioManager>();
        wearableItems = GetComponent<Wearables>();
        StartCoroutine(InitializeSo());
    }

    private IEnumerator InitializeSo()
    {
        yield return null;
        GetItemDetailsFromScriptObject(this);
    }

    public Item GetItemDetailsFromScriptObject(Item item)
    {
        // Get itemDetails from SO list
        item.So = Inventory.Instance.GetItemDetails(ItemCode);

        // enums
        item.itemType = So.itemType;
        item.affectType = So.affectType;

        // variables
        item.itemDefence = So.itemDefence + DefenceModifier;
        item.itemAttack = So.itemAttack + AttackModifier;
        item.amountOfEffect = So.amountOfEffect + EffectModifier;
        item.valueInCoins = So.valueInCoins;
        item.itemCodeSo = So.itemCode;
        item.itemName = So.itemName;
        item.itemDescription = So.itemDescription;
        item.isRelic = So.isRelic;
        item.isStackable = So.isStackable;
        item.itemsImage = So.itemsImage;

        valueInCoins = CalculateValueInCoins(valueInCoins);
        return item;
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
        if (!collision.CompareTag("Player") || isQuestObject) { return; }

        SetItemParent(GameManager.Instance.pickedUpItems.transform, true);
        SelfDeactivate();
        audio.PlaySfxClip(1, false);

        if (pickUpNotice)
        {
            StartCoroutine(Notification());
        }

        IEnumerator Notification()
        {
            yield return null;
            NotificationFader.instance.CallFadeInOut($"You picked up a {itemName}",
                itemsImage,
                3f,
                1000f,
                30);
        }


        if (isPrefab)
        {
            NewObjects.Instance.RemoveItem(this);
        }

        isPickedUp = true;
        hasBeenDropped = false;
        Inventory.Instance.AddItems(this);
    }


    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.Instance.GetPlayerStats()[characterToUseOn];


        if (GameManager.Instance.inventory) { Debug.Log("UseItem called from Item"); }

        if (affectType == AffectType.Hp)
        {
            selectedCharacter.AddHp(amountOfEffect);
            if (characterToUseOn != 0)
            {
                if (GameManager.Instance.items)
                {
                    Debug.Log(amountOfEffect + " HP given to " + selectedCharacter.playerName);
                }
            }
        }

        else if (affectType == AffectType.Mana)
        {
            selectedCharacter.AddMana(amountOfEffect);
            if (GameManager.Instance.items)
            {
                Debug.Log(amountOfEffect + $"Mana given to{selectedCharacter.playerName}");
            }
        }


        else if (itemType == ItemType.Armour)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.itemArmour.itemDefence;

            if (selectedCharacter.characterArmourName != "")
            {
                selectedCharacter.itemArmour.GetItemDetailsFromScriptObject(selectedCharacter
                    .itemArmour);
                if (GameManager.Instance.items)
                {
                    Debug.Log(selectedCharacter.playerName + "'s equipped " +
                              selectedCharacter.itemArmour.itemName +
                              " has been added back into the Inventory");
                }

                Inventory.Instance.AddItems(selectedCharacter.itemArmour);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipArmour(this, GetComponent<Wearables>());
            if (GameManager.Instance.items) { Debug.Log(selectedCharacter.playerName + " equipped with " + this); }
        }

        else if (itemType == ItemType.Shield)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.itemShield.itemDefence;

            if (selectedCharacter.characterShieldName != "")
            {
                selectedCharacter.itemShield.GetItemDetailsFromScriptObject(selectedCharacter
                    .itemShield);
                if (GameManager.Instance.items)
                {
                    Debug.Log(selectedCharacter.playerName + "'s equipped " +
                              selectedCharacter.itemShield.itemName +
                              " has been added back into the Inventory");
                }

                Inventory.Instance.AddItems(selectedCharacter.itemShield);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipShield(this, GetComponent<Wearables>());
            if (GameManager.Instance.items) { Debug.Log(selectedCharacter.playerName + " equipped with " + this); }
        }

        else if (itemType == ItemType.Helmet)
        {
            selectedCharacter.characterDefenceTotal -= selectedCharacter.itemHelmet.itemDefence;

            if (selectedCharacter.characterHelmetName != "")
            {
                selectedCharacter.itemHelmet.GetItemDetailsFromScriptObject(selectedCharacter.itemHelmet);
                if (GameManager.Instance.items)
                {
                    Debug.Log(selectedCharacter.playerName + "'s equipped " +
                              selectedCharacter.itemHelmet.itemName +
                              " has been added back into the Inventory");
                }

                Inventory.Instance.AddItems(selectedCharacter.itemHelmet);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddArmourDefence(itemDefence);
            selectedCharacter.EquipHelmet(this, GetComponent<Wearables>());
            if (GameManager.Instance.items) { Debug.Log(selectedCharacter.playerName + " equipped with " + this); }
        }


        else if (itemType == ItemType.Weapon)
        {
            selectedCharacter.characterAttackTotal -= selectedCharacter.itemWeapon.itemAttack;

            if (selectedCharacter.characterWeaponName != "")
            {
                selectedCharacter.itemWeapon.GetItemDetailsFromScriptObject(selectedCharacter
                    .itemWeapon);
                if (GameManager.Instance.items)
                {
                    Debug.Log(selectedCharacter.playerName + "'s equipped " +
                              selectedCharacter.itemWeapon.itemName +
                              " has been added back into the Inventory");
                }

                Inventory.Instance.AddItems(selectedCharacter.itemWeapon);

                MenuManager.Instance.UpdateItemsInventory();
            }

            selectedCharacter.AddWeaponPower(itemAttack);
            selectedCharacter.EquipWeapon(this, GetComponent<Wearables>());

            if (GameManager.Instance.items)
            {
                Debug.Log(selectedCharacter.playerName + " equipped with " + itemName);
            }
        }
    }

    public void SelfDeactivate()
    {
        if (polyCollider)
        {
            polyCollider.enabled = false;
            if (GameManager.Instance.items) { Debug.Log($"polyCollider enabled: {polyCollider.enabled}"); }
        }

        if (spriteRenderer) { spriteRenderer.enabled = false; }
    }

    public void SelfDestruct()
    {
        SetItemParent(GameManager.Instance.deletedItems, true);
        isDeletedStack = true;
    }

    private void DropAnItem(Item droppedItem)
    {
        if (droppedItem.itemGuid != itemGuid) { return; }

        SelfActivate();
        isPickedUp = false;
        hasBeenDropped = true;
        isNewItem = true;
        quantity = 1;
        if (droppedItem.isQuestObject)
        {
            polyCollider.enabled = true;
            spriteRenderer.enabled = true;
            pickUpNotice = true;
            isQuestObject = false;
        }

        spriteRenderer.sortingLayerName = "Objects";
        spriteRenderer.sortingOrder = 3;

        DropItemPosition(this);
        AudioManager.Instance.PlaySfxClip(5);
        NotificationFader.instance.CallFadeInOut($"You dropped the {droppedItem.itemName}",
            droppedItem.itemsImage,
            3f,
            1400f,
            30);
    }

    private void DropItemPosition(Item itemToDrop)
    {
        itemPickupPlace = PlayerGlobalData.Instance.currentSceneIndex;
        if (GameManager.Instance.items) { Debug.Log($"itemPickupPlace after drop: {itemPickupPlace}"); }

        if (!itemToDrop.isQuestObject) { SetItemParent(GameManager.Instance.pickupParents[itemPickupPlace], true); }

        Transform playerTransform = PlayerGlobalData.Instance.gameObject.GetComponent<Transform>();
        transform.position = playerTransform.position;
        transform.position = new Vector3(transform.position.x,
            transform.position.y - 1.34f,
            transform
                .position.z);
        itemPosition = transform.position;
    }

    private void SelfActivate()
    {
        spriteRenderer.enabled = true;
        polyCollider.enabled = true;
        string guid = itemGuid[..8];
        if (GameManager.Instance.items)
        {
            Debug.Log(
                $"Dropped {itemName} | Visible: {spriteRenderer.enabled} | Position: {transform.position} | GUID: {guid}");
        }
    }

    public void SetItemParent(Transform newParent, bool worldSpace)
    {
        transform.SetParent(newParent, worldSpace);
    }

    private void OnValidate()
    {
        ResetSpritePolygonCollider();
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.482f, 0.486f, 0.156f)]
    public void ResetSpritePolygonCollider()
    {
        polyCollider.TryUpdateShapeToAttachedSprite();
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        itemPosition = transform.position;
        SaveData.ItemsData id = new(itemGuid,
            itemName,
            quantity,
            pickup,
            isPickedUp,
            isNewItem,
            isShopItem,
            spriteRenderer,
            polyCollider,
            itemPosition,
            itemPickupPlace,
            isDeletedStack,
            hasBeenDropped,
            isPrefab,
            isQuestObject,
            pickUpNotice,
            shop,
            boughtFromShop);

        a_SaveData.itemsData.Add(id);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        itemGuid = GetComponent<GenerateGUID>()?.GUID;

        polyCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        foreach (SaveData.ItemsData id in a_SaveData.itemsData.Where(id => id.itemGuid == itemGuid))
        {
            quantity = id.quantity;
            boughtFromShop = id.boughtFromShop;
            isPickedUp = id.isPickedUp;
            isNewItem = id.isNewItem;
            isShopItem = id.isShopItem;
            spriteRenderer = id.spriteRenderer;
            polyCollider = id.polyCollider;
            pickup = id.pickup;
            isDeletedStack = id.isDeletedStack;
            hasBeenDropped = id.hasBeenDropped;
            itemPosition = id.itemPosition;
            itemPickupPlace = id.itemPickupPlace;
            isPrefab = id.isPrefab;
            isQuestObject = id.isQuestObject;
            pickUpNotice = id.pickupNotice;
            transform.position = itemPosition;
            shop = id.shopPlace;


            if (id.isPickedUp)
            {
                polyCollider.enabled = false;
                spriteRenderer.enabled = false;
                SetItemParent(GameManager.Instance.pickedUpItems.transform, true);
                string shortGuid = itemGuid[..8];
                if (GameManager.Instance.items || GameManager.Instance.saveLoad)
                {
                    Debug.Log(
                        $"Poly: LoadFromSave {id.itemName} | poly status: {id.polyCollider.enabled} | GUID: {shortGuid}");
                }
            }

            string guid = id.itemGuid[..8];

            if (!id.isPickedUp && id.hasBeenDropped && !id.isQuestObject)
            {
                SetItemParent(GameManager.Instance.pickupParents[id.itemPickupPlace]
                        .transform,
                    true); // pickupParent is where dropped item is stored ready for pickup
                if (GameManager.Instance.items || GameManager.Instance.saveLoad)
                {
                    Debug.Log($"Dropped item put into correct box: {id.itemName} | GUID: {guid}");
                }
            }

            if (!id.isPickedUp && id.hasBeenDropped)
            {
                polyCollider.enabled = true;
                spriteRenderer.enabled = true;
                spriteRenderer.sortingOrder = 3;
                spriteRenderer.sortingLayerName = "Objects";
                if (GameManager.Instance.items || GameManager.Instance.saveLoad)
                {
                    Debug.Log($"Quantity calculation: {quantity}");
                }
            }

            if (id.isPickedUp && id.boughtFromShop)
            {
                SetItemParent(GameManager.Instance.pickedUpItems.transform, true);
                isShopItem = false;
                if (GameManager.Instance.items || GameManager.Instance.saveLoad)
                {
                    Debug.Log($"Bought Item put into Pickup box: {id.itemName}");
                }
            }

            if (isDeletedStack)
            {
                // Maybe Destroy

                SetItemParent(GameManager.Instance.deletedItems, true);

                if (polyCollider) { polyCollider.enabled = false; }

                if (spriteRenderer) { spriteRenderer.enabled = false; }

                if (GameManager.Instance.items || GameManager.Instance.saveLoad)
                {
                    Debug.Log($"Deleted item put into correct box: {id.itemName} | GUID: {guid}");
                }
            }

            break;
        }

        if (GetComponent<GenerateGUID>() == null) { Debug.Log($"GUID is Null: {itemName}"); }
    }

    #endregion
}