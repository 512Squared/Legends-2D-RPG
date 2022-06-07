using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using Sirenix.OdinInspector;


public class PlayerStats : Rewardable<QuestRewards>, ISaveable
{
    public static PlayerStats Instance;

    #region Serialized Fields

    public string homeScene;

    public string playerName;
    public string playerDesc;
    public string playerMoniker;


    [TabGroup("Images")] [GUIColor(0.670f, 1, 0.560f)] [PreviewField] [Required]
    public Sprite characterImage, characterMug, characterPlain;

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
    public Item characterWeapon, characterArmour, characterHelmet, characterShield;

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
    public Sprite characterWeaponImage, characterArmourImage, characterHelmetImage, characterShieldImage;


    public Sprite[] skills;
    public int[] xpLevelUp;
    public int[] skillBonus;
    public MagicManager[] magicSlots;

    private string _npcGuid;
    private Vector3 position;

    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXp;

        _npcGuid = GetComponent<GenerateGUID>().GUID;

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
                    $"{playerName}'s HP is <color=#E0A515>full</color> - well done!", Sprites.instance.hpSprite,
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
                NotificationFader.instance.CallFadeInOut(
                    $"{playerName}'s Mana is <color=#E0A515>full</color> - well done!", Sprites.instance.manaSprite, 3f,
                    1400, 30);
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

    public void EquipWeapon(Item weaponToEquip)
    {
        characterWeapon = weaponToEquip;
        characterWeaponName = characterWeapon.itemName;
        characterWeaponImage = characterWeapon.itemsImage;
        characterWeaponDescription = characterWeapon.itemDescription;
    }

    public void EquipArmour(Item armourToEquip)
    {
        characterArmour = armourToEquip;
        characterArmourName = characterArmour.itemName;
        characterArmourImage = characterArmour.itemsImage;
        characterArmourDescription = characterArmour.itemDescription;
    }

    public void EquipHelmet(Item helmetToEquip)
    {
        characterHelmet = helmetToEquip;
        characterHelmetName = characterHelmet.itemName;
        characterHelmetImage = characterHelmet.itemsImage;
        characterHelmetDescription = characterHelmet.itemDescription;
    }

    public void EquipShield(Item shieldToEquip)
    {
        characterShield = shieldToEquip;
        characterShieldName = characterShield.itemName;
        characterShieldImage = characterShield.itemsImage;
        characterShieldDescription = characterShield.itemDescription;
    }

    private IEnumerator Initialize()
    {
        yield return new WaitForSeconds(1f);
        characterDefenceTotal = characterBaseDefence + characterArmour.itemDefence + characterShield.itemDefence +
                                characterHelmet.itemDefence;
        characterAttackTotal = characterBaseAttack + characterWeapon.itemAttack;
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        position = transform.position;

        SaveData.CharacterData cd = new(_npcGuid, characterLevel, characterMana, characterHp, characterIntelligence,
            characterPerception, characterBaseAttack, characterBaseDefence, isTeamMember, isAvailable, isNew,
            characterWeapon, characterArmour, characterHelmet, characterShield, characterAttackTotal,
            characterDefenceTotal, characterWeaponImage, characterArmourImage, characterHelmetImage,
            characterShieldImage, skills, position);

        a_SaveData.characterDataList.Add(cd);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.CharacterData cd in a_SaveData.characterDataList.Where(cd => cd.npcGuid == _npcGuid))
        {
            characterLevel = cd.characterLevel;
            characterMana = cd.characterMana;
            characterHp = cd.characterHp;
            characterIntelligence = cd.characterIntelligence;
            characterPerception = cd.characterPerception;
            characterBaseAttack = cd.characterBaseAttack;
            characterBaseDefence = cd.characterBaseDefence;
            isTeamMember = cd.isTeamMember;
            isAvailable = cd.isAvailable;
            isNew = cd.isNew;
            characterWeapon = cd.characterWeapon;
            characterArmour = cd.characterArmour;
            characterHelmet = cd.characterHelmet;
            characterShield = cd.characterShield;
            characterAttackTotal = cd.characterAttackTotal;
            characterDefenceTotal = cd.characterDefenceTotal;
            characterWeaponImage = cd.characterWeaponImage;
            characterArmourImage = cd.characterArmourImage;
            characterHelmetImage = cd.characterHelmetImage;
            characterShieldImage = cd.characterShieldImage;
            skills = cd.skills;
            position = cd.position;
            transform.position = position;

            Debug.Log($"npcPosition: {position}");

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

            break;
        }
    }

    #endregion
}