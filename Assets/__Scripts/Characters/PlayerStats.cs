using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Assets.HeroEditor4D.FantasyInventory.Scripts.Data;
using Assets.HeroEditor4D.FantasyInventory.Scripts.Enums;
using Sirenix.OdinInspector;


public class PlayerStats : Rewardable<QuestRewards>, ISaveable, IDamageable
{
    [DetailedInfoBox("Click for INFO about PlayerStats...",
        "Player Stats handles many different data related aspects of the characters. First thing to say is that the UI is a bit hard-engineered, because I wasn't yet able to use prefabs when I first started working on using multiple characters in the UI, that is the character party, so I added UI character slots and applied a numbering system. When that character was active or added to the party, then that character slot would be active. I don't remember an easy way to do the sorting and getting the order to work consistently, so I used an extension that sorts by hierarchy order and used the z-axis, which isn't used in 2D games to store the order.\n\n")]
    public static PlayerStats Instance;

    #region Serialized Fields

    public Character4D character;

    public SceneObjectsLoad homeScene;

    public string playerName;
    public string playerDesc;
    public string playerMoniker;

    [SerializeField] public TeamMemberBase teamMemberBase;

    [TabGroup("Images")] [GUIColor(0.670f, 1, 0.560f)] [PreviewField] [Required]
    public Sprite imageFront, imageRight;

    [TabGroup("Stats")] [GUIColor(0.970f, 1, 0.260f)]
    public int maxLevel, baseLevelXp, characterXp, maxMana, maxHp;

    [TabGroup("Range")] [GUIColor(0.970f, 1, 0.260f)] [Range(1, 10)]
    public int characterLevel;

    [TabGroup("Range")] [GUIColor(0.970f, 1, 0.260f)] [Range(1, 300)]
    public int characterMana, characterHp;

    [TabGroup("Range")] [GUIColor(0.970f, 1, 0.260f)] [Range(1, 100)]
    public int characterIntelligence, characterPerception;

    [TabGroup("Range")] [GUIColor(0.970f, 1, 0.260f)] [Range(1, 20)]
    public int characterBaseAttack, characterBaseDefence, characterSpeed, characterJumpAbility;


    [TabGroup("Bools")] [GUIColor(0.670f, 1, 0.560f)]
    public bool isTeamMember, isAvailable, isNew = true;


    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Item itemWeapon, itemArmour, itemHelmet, itemShield;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public string characterWeaponName, characterArmourName, characterHelmetName, characterShieldName;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public string characterWeaponDescription,
        characterArmourDescription,
        characterHelmetDescription,
        characterShieldDescription;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public int characterAttackTotal, characterDefenceTotal;


    [TabGroup("New Group", "Weaponry Images")] [GUIColor(0.447f, 0.654f, 0.996f)] [PreviewField] [Required]
    public Sprite weaponSprite, armourSprite, helmetSprite, shieldSprite;


    public Sprite[] skills;
    public int[] xpLevelUp;
    public int[] skillBonus;
    public MagicManager[] magicSlots;

    private string _npcGuid;
    private Vector3 position;
    public float uiDamageOffset;
    public bool isAttacking;
    [SerializeField] private bool debugOn;
    private string savedPath;
    private string tempPath;

    #endregion

    private void Awake()
    {
        position = transform.position;
        savedPath = Application.persistentDataPath + "/Resources/PNGs/" + playerName;
        tempPath = Application.persistentDataPath + "/Resources/PNGs/" + "_unsaved_" + playerName;
    }

    // Start is called before the first frame update
    private void Start()
    {
        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXp;
        _npcGuid = GetComponent<GenerateGUID>().GUID;
        character = GetComponent<Character4D>();

        for (int i = 1; i < xpLevelUp.Length; i++)
        {
            xpLevelUp[i] = (int)((0.02f * Math.Pow(i, 3)) + (3.06f * Math.Pow(i, 2)) + (105.6f * i));
        }

        StartCoroutine(Initialize());
    }


    public override void Reward(QuestRewards rewards)
    {
        switch (rewards.playerClass)
        {
            case QuestRewards.PlayerClasses.NPC:
            case QuestRewards.PlayerClasses.all:
                {
                    if (rewards.rewardType == QuestRewards.RewardTypes.hp) { characterHp += rewards.rewardAmount; }

                    break;
                }
        }
    }

    public void AddXp(int amountOfXp)
    {
        characterXp += amountOfXp;
        if (characterXp <= xpLevelUp[characterLevel]) { return; }

        characterXp -= xpLevelUp[characterLevel];
        characterLevel++;

        maxHp = (int)(maxHp * 1.06f);
        maxMana = (int)(maxMana * 1.06f);
        characterHp = maxHp;
        characterMana = maxMana;

        if (characterLevel % 2 == 0) { characterBaseAttack++; }
        else { characterBaseDefence++; }

        if (characterLevel % 3 == 0) { characterIntelligence++; }

        if (characterLevel % 5 == 0) { characterPerception++; }
    }

    public void AddHp(int amountOfHpToAdd)
    {
        if (playerName != "Thulgran")
        {
            characterHp += amountOfHpToAdd;

            if (characterHp > maxHp)
            {
                characterHp = maxHp;
                NotificationFader.instance.CallFadeInOut(
                    $"{playerName}'s HP is <color=#E0A515>full</color> - well done!",
                    Sprites.instance.hpSprite,
                    3f,
                    1400,
                    30);
                Debug.Log($"Yo");
            }

            Debug.Log($"Not thulgran: {playerName}");
        }

        Debug.Log($"AddHP called");
    }

    public void AddMana(int amountOfManaToAdd)
    {
        if (playerName != "Thulgran")
        {
            characterMana += amountOfManaToAdd;
            if (characterMana > maxMana)
            {
                characterMana = maxMana;
                NotificationFader.instance.CallFadeInOut(
                    $"{playerName}'s Mana is <color=#E0A515>full</color> - well done!",
                    Sprites.instance.manaSprite,
                    3f,
                    1400,
                    30);
                Debug.Log($"Yo");
            }
        }
    }

    public void AddArmourDefence(int amountOfArmourDefenceToAdd)
    {
        characterDefenceTotal += amountOfArmourDefenceToAdd;
    }

    public void AddWeaponPower(int amountOfWeaponPowerToAdd)
    {
        characterAttackTotal += amountOfWeaponPowerToAdd;
    }

    public void EquipWeapon(Item weaponToEquip, Wearables heroWeapon)
    {
        itemWeapon = weaponToEquip;
        character.EquipMeleeWeapon1H(heroWeapon);
        SendPlayerToPhotobooth();
        characterWeaponName = itemWeapon.itemName;
        weaponSprite = itemWeapon.itemsImage;
        characterWeaponDescription = itemWeapon.itemDescription;
    }

    public void EquipArmour(Item armourToEquip, Wearables heroArmor)
    {
        itemArmour = armourToEquip;
        character.EquipArmor(heroArmor);
        SendPlayerToPhotobooth();
        characterArmourName = itemArmour.itemName;
        armourSprite = itemArmour.itemsImage;
        characterArmourDescription = itemArmour.itemDescription;
    }

    public void EquipHelmet(Item helmetToEquip, Wearables heroHelmet)
    {
        itemHelmet = helmetToEquip;
        characterHelmetName = itemHelmet.itemName;
        character.EquipHelmet(heroHelmet);
        SendPlayerToPhotobooth();
        helmetSprite = itemHelmet.itemsImage;
        characterHelmetDescription = itemHelmet.itemDescription;
    }

    public void EquipShield(Item shieldToEquip, Wearables heroShield)
    {
        itemShield = shieldToEquip;
        character.EquipShield(heroShield);
        SendPlayerToPhotobooth();
        characterShieldName = itemShield.itemName;
        shieldSprite = itemShield.itemsImage;
        characterShieldDescription = itemShield.itemDescription;
    }

    public void HitEnemy(Collider2D col, string colGuid, Character apex)
    {
        string guid = apex.AnchorSword.GetComponent<GenerateGUID>().GUID;

        if (guid == colGuid && isAttacking)
        {
            col.GetComponent<IDamageable>().Damage(characterAttackTotal);

            if (debugOn)
            {
                Debug.Log(
                    $"Enemy found: {col.name}  | Hit by: {playerName} | Damage: {characterAttackTotal} | Enemy HP: {col.GetComponent<EnemyStats>().HitPoints}");
            }

            isAttacking = false;
        }
    }

    private IEnumerator Initialize()
    {
        yield return new WaitForSeconds(0.5f);

        int armour = 0; // simple fix for nulls if armour or weapon slots are empty
        int helmet = 0;
        int shield = 0;
        int weapon = 0;
        if (itemArmour != null) { armour = itemArmour.itemDefence; }

        if (itemHelmet != null) { helmet = itemHelmet.itemDefence; }

        if (itemShield != null) { shield = itemShield.itemDefence; }

        if (itemWeapon != null) { weapon = itemWeapon.itemAttack; }

        characterDefenceTotal = characterBaseDefence + armour + shield + helmet;
        characterAttackTotal = characterBaseAttack + weapon;
        if (playerName == "Thulgran")
        {
            transform.position = PlayerGlobalData.Instance.playerTrans;
            position = transform.position;
        }
    }

    private void SendPlayerToPhotobooth()
    {
        CreatePlayerPNGs.Instance.Photobooth(this, tempPath); // creates PNGs
        LoadTempUISprites(); // converts to temp sprites
    }

    public void SayCheese() // this is just for game initialization
    {
        CreatePlayerPNGs.Instance.Photobooth(this, savedPath);
        imageFront = CreateSpriteFromPNG(savedPath + "_front" + ".png"); // creates PNGs
        imageRight = CreateSpriteFromPNG(savedPath + "_right" + ".png");
    }

    private void LoadTempUISprites()
    {
        imageFront = CreateSpriteFromPNG(tempPath + "_front" + ".png");
        imageRight = CreateSpriteFromPNG(tempPath + "_right" + ".png");
    }

    private static Sprite CreateSpriteFromPNG(string path)
    {
        // this fetches the png texture and builds a sprite

        if (string.IsNullOrEmpty(path)) { return null; }

        if (System.IO.File.Exists(path))
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new(512, 512);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
            return sprite;
        }

        return null;
    }

    private void SaveUISprites()
    {
        CreatePlayerPNGs.Instance.Photobooth(this, savedPath); // creates saved PNGs
    }

    private void LoadSavedUISprites()
    {
        imageRight = CreateSpriteFromPNG(savedPath + "_right" + ".png"); // re-creates sprites from saved PNGs
        imageFront = CreateSpriteFromPNG(savedPath + "_front" + ".png");
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        position = transform.position;
        SaveUISprites();

        SaveData.CharacterData cd = new(playerName,
            _npcGuid,
            characterLevel,
            characterMana,
            characterHp,
            characterIntelligence,
            characterPerception,
            characterBaseAttack,
            characterBaseDefence,
            isTeamMember,
            isAvailable,
            isNew,
            characterAttackTotal,
            characterDefenceTotal,
            skills,
            position,
            itemWeapon,
            itemArmour,
            itemHelmet,
            itemShield,
            weaponSprite,
            armourSprite,
            helmetSprite,
            shieldSprite);

        a_SaveData.characterDataList.Add(cd);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.CharacterData cd in a_SaveData.characterDataList.Where(cd => cd.npcGuid == _npcGuid))
        {
            isTeamMember = cd.isTeamMember;
            playerName = cd.playerName;

            if (isTeamMember)
            {
                switch (playerName)
                {
                    case "Briarfoot":
                        MenuManager.Instance.CharacterActivationButtons(1);
                        break;
                    case "Grumpy Greta":
                        MenuManager.Instance.CharacterActivationButtons(2);
                        break;
                    case "Winrussel":
                        MenuManager.Instance.CharacterActivationButtons(3);
                        break;
                    case "Haefra Do'hea":
                        MenuManager.Instance.CharacterActivationButtons(4);
                        break;
                }
            }

            characterLevel = cd.characterLevel;
            characterMana = cd.characterMana;
            characterHp = cd.characterHp;
            characterIntelligence = cd.characterIntelligence;
            characterPerception = cd.characterPerception;
            characterBaseAttack = cd.characterBaseAttack;
            characterBaseDefence = cd.characterBaseDefence;
            isAvailable = cd.isAvailable;
            isNew = cd.isNew;

            weaponSprite = cd.weaponSprite;
            itemWeapon = cd.itemWeapon;

            armourSprite = cd.armourSprite;
            itemArmour = cd.itemArmour;

            helmetSprite = cd.helmetSprite;
            itemHelmet = cd.itemHelmet;

            shieldSprite = cd.shieldSprite;
            itemShield = cd.itemShield;

            StartCoroutine(ReequipPlayer());

            characterAttackTotal = cd.characterAttackTotal;
            characterDefenceTotal = cd.characterDefenceTotal;

            skills = cd.skills;
            if (playerName != "Thulgran")
            {
                position = cd.position;
                transform.position = position;
            }
            else if (playerName == "Thulgran")
            {
                position = PlayerGlobalData.Instance.playerTrans;
                transform.position = position;
            }
        }

        if (gameObject.activeInHierarchy)
        {
            LoadSavedUISprites();
            if (GameManager.Instance.saveLoad) { Debug.Log($"Player Images updated: {playerName}"); }
        }
    }

    private IEnumerator ReequipPlayer()
    {
        yield return null;
        Wearables helmet = itemHelmet.GetComponent<Wearables>();
        Debug.Log($"Helmet id: {helmet.Id}");
        character.EquipHelmet(helmet);

        Wearables weapon = itemWeapon.GetComponent<Wearables>();
        Debug.Log($"Weapon id: {weapon.Id}");
        character.EquipMeleeWeapon1H(weapon);

        Wearables armour = itemArmour.GetComponent<Wearables>();
        Debug.Log($"Armour id: {armour.Id}");
        character.EquipArmor(armour);

        Wearables shield = itemShield.GetComponent<Wearables>();
        Debug.Log($"Shield id: {shield.Id}");
        character.EquipShield(shield);
    }

    #endregion

    #region Implementation of IDamageable

    public void Damage(int damage) // receive a hit
    {
        damage = SpecialAbilities(damage);

        if (playerName != "Thulgran")
        {
            characterHp -= damage; // defence bonuses and total damage calculated in 'attack' method on enemies
        }
        else { GetComponent<Thulgran>().Damage(damage); }

        character.AnimationManager.Hit();
        if (characterHp <= 1)
        {
            IsAlive = false;
            GetComponent<PlayerGlobalData>().isAlive = false;
            GetComponent<NPCMovement>().Death();
        }
    }

    private int SpecialAbilities(int firstDamage)
    {
        Wearables wearable = itemArmour.GetComponent<Wearables>();

        switch (wearable.Modifier.Id)
        {
            case ItemModifier.Onslaught:
                firstDamage += 10;
                return firstDamage;
            case ItemModifier.Fire:
                firstDamage += 10;
                return firstDamage;
            case ItemModifier.None:
                firstDamage += 1;
                break;
            case ItemModifier.Reinforced: break;
            case ItemModifier.Refined: break;
            case ItemModifier.Sharpened: break;
            case ItemModifier.Lightweight: break;
            case ItemModifier.Poison: break;
            case ItemModifier.Bleeding: break;
            case ItemModifier.Spread: break;
            case ItemModifier.Shieldbreaker: break;
            case ItemModifier.Ice: break;
            case ItemModifier.Lightning: break;
            case ItemModifier.Light: break;
            case ItemModifier.Darkness: break;
            case ItemModifier.Vampiric: break;
            case ItemModifier.LevelDown: break;
            case ItemModifier.LevelUp: break;
            case ItemModifier.HealthUp: break;
            case ItemModifier.HealthRecovery: break;
            case ItemModifier.StaminaUp: break;
            case ItemModifier.StaminaRecovery: break;
            case ItemModifier.Speed: break;
            case ItemModifier.Accuracy: break;
            case ItemModifier.Reloading: break;
            default: return firstDamage;
        }

        return firstDamage;
    }

    public Vector3 GetPositionOfHead()
    {
        Vector3 headPosition = new(transform.position.x, transform.position.y + uiDamageOffset, 0);
        return headPosition;
    }

    public string Combatant => playerName;

    public bool IsAlive
    {
        get => false;
        set { }
    }

    #endregion
}