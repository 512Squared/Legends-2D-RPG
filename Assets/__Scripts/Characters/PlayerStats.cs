using UnityEngine;
using System;
using Sirenix.OdinInspector;


public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    #region Serialized Fields

    public string homeScene;

    public string playerName;
    public string playerDesc;
    public string playerMoniker;
    [Space]
    public int thulGold, thulSpells, thulPotions;

    [TabGroup("Images")]
    [GUIColor(0.670f, 1, 0.560f)]
    [PreviewField, Required]
    public Sprite characterImage, characterMug, characterPlain;

    [TabGroup("Stats")]
    [GUIColor(0.970f, 1, 0.260f)]
    public int maxLevel, baseLevelXP, characterXP, maxMana, maxHP;

    [TabGroup("Range")]
    [GUIColor(0.970f, 1, 0.260f)]
    [Range(1, 10)]
    public int characterLevel;
    [TabGroup("Range")]
    [GUIColor(0.970f, 1, 0.260f)]
    [Range(1, 300)]
    public int characterMana, characterHP;
    [TabGroup("Range")]
    [GUIColor(0.970f, 1, 0.260f)]
    [Range(1, 100)]
    public int characterIntelligence, characterPerception;
    [TabGroup("Range")]
    [GUIColor(0.970f, 1, 0.260f)]
    [Range(1, 20)]
    public int characterBaseAttack, characterBaseDefence, characterSpeed, characterJumpAbility;



    [TabGroup("Bools")]
    [GUIColor(0.670f, 1, 0.560f)]
    public bool isTeamMember, isAvailable = false, isNew = true;


    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public ItemsManager characterWeapon, characterArmour, characterHelmet, characterShield;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public string characterWeaponName, characterArmourName,characterHelmetName, characterShieldName;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public string characterWeaponDescription, characterArmourDescription, characterHelmetDescription, characterShieldDescription;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public int characterAttackTotal, characterDefenceTotal;


    [TabGroup("New Group", "Weaponry Images")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [PreviewField, Required]
    public Sprite characterWeaponImage, characterArmourImage, characterHelmetImage, characterShieldImage;

    

    public Sprite[] skills;
    public int[] xpLevelUp;
    public int[] skillBonus;
    public MagicManager[] magicSlots;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXP;

        for (int i = 1; i < xpLevelUp.Length; i++)
        {
            xpLevelUp[i] = (int)(0.02f * Math.Pow(i, 3) + 3.06f * Math.Pow(i, 2) + 105.6f * i);
        }

        characterDefenceTotal = characterBaseDefence + characterArmour.itemDefence + characterShield.itemDefence + characterHelmet.itemDefence;
        characterAttackTotal = characterBaseAttack + characterWeapon.itemAttack;
    }




    public void AddXP(int amountOfXp)
    {
        characterXP += amountOfXp;
        if (characterXP > xpLevelUp[characterLevel])
        {
            characterXP -= xpLevelUp[characterLevel];
            characterLevel++;

            maxHP = (int)(maxHP * 1.06f);
            maxMana = (int)(maxMana * 1.06f);
            characterHP = maxHP;
            characterMana = maxMana;

            if (characterLevel % 2 == 0)
            {
                characterBaseAttack++;
            }
            else
            {
                characterBaseDefence++;
            }

            if (characterLevel % 3 == 0)
            {
                characterIntelligence++;
            }

            if (characterLevel % 5 == 0)
            {
                characterPerception++;
            }


        }
    }

    public void AddHP(int amountOfHPToAdd)
    {
        if (playerName != "Thulgran")
        {
            characterHP += amountOfHPToAdd;

            if (characterHP > maxHP)
            {
                characterHP = maxHP;
                NotificationFader.instance.CallFadeInOut($"{playerName}'s HP is <color=#E0A515>full</color> - well done!", Sprites.instance.hpSprite,
                3f,
                1400, 30);
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
                NotificationFader.instance.CallFadeInOut($"{playerName}'s Mana is <color=#E0A515>full</color> - well done!", Sprites.instance.manaSprite, 3f, 1400, 30);
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

    public void EquipWeapon(ItemsManager weaponToEquip)
    {
        characterWeapon = weaponToEquip;
        characterWeaponName = characterWeapon.itemName;
        characterWeaponImage = characterWeapon.itemsImage;
        characterWeaponDescription = characterWeapon.itemDescription;


    }

    public void EquipArmour(ItemsManager armourToEquip)
    {
        characterArmour = armourToEquip;
        characterArmourName = characterArmour.itemName;
        characterArmourImage = characterArmour.itemsImage;
        characterArmourDescription = characterArmour.itemDescription;
    }

    public void EquipHelmet(ItemsManager helmetToEquip)
    {
        characterHelmet = helmetToEquip;
        characterHelmetName = characterHelmet.itemName;
        characterHelmetImage = characterHelmet.itemsImage;
        characterHelmetDescription = characterHelmet.itemDescription;
    }

    public void EquipShield(ItemsManager shieldToEquip)
    {
        characterShield = shieldToEquip;
        characterShieldName = characterShield.itemName;
        characterShieldImage = characterShield.itemsImage;
        characterShieldDescription = characterShield.itemDescription;
    }


}

