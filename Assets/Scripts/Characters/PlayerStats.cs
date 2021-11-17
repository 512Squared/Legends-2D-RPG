using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;
    public PlayerStats thulgran;

    public Sprite characterImage;
    public Sprite characterMug;
    public Sprite[] skills;


    public int[] skillBonus;

    public int thulGold;
    public int thulSpells;
    public int thulPotions;
    public int[] xpLevelUp;
    public int maxLevel;
    public int baseLevelXP;
    public int maxMana;
    public int maxHP;

    public bool isTeamMember;
    public string playerName;
    public string playerDesc;
    public string playerMoniker;
    

    public int npcLevel;
    public int npcXP;
    public int npcMana;
    public int npcHP;
    public int npcDexterity;
    public int npcDefence;
    public int npcIntelligence;
    public int npcPerception;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)

// Start is called before the first frame update
    void Start()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        // assigning XP and leveling up from XP

        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXP;

        for (int i = 1; i < xpLevelUp.Length; i++)
        {
            xpLevelUp[i] = (int)(0.02f * Math.Pow(i, 3) + 3.06f * Math.Pow(i, 2) + 105.6f * i);
        }
    }


    // Update is called once per frame YnPCmrtgUB0uhClQKlSTeTjVJ82fkbzf
    void Update()
    {

        // assign XP is currently assigned to a key L

        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
            Debug.Log("XP was added");


        }
    }

    public void AddXP(int amountOfXp)
    {
        npcXP += amountOfXp;
        if(npcXP > xpLevelUp[npcLevel])
        {
            npcXP -= xpLevelUp[npcLevel];
            npcLevel++;

            maxHP = (int)(maxHP * 1.06f);
            maxMana = (int)(maxMana * 1.06f);
            npcHP = maxHP;
            npcMana = maxMana;

            if(npcLevel % 2 == 0)
            {
               npcDexterity++;
            }
            else
            {
               npcDefence++;
            }

            if(npcLevel % 3 == 0)
            {
                npcIntelligence++;
            }

            if (npcLevel % 5 == 0)
            {
                npcPerception++;
            }


        }
    }

    public void AddHP(int amountOfHPToAdd)
    {
        npcHP += amountOfHPToAdd;
        
        if (npcHP > maxHP)
        {
            npcHP = maxHP;
        }

    }

    public void AddMana(int amountOfManaToAdd)
    {
        npcMana += amountOfManaToAdd;
        if (npcMana > maxMana)
        {
            npcMana = maxMana;
        }
    }

    public void AddDefence(int amountofDefenceToAdd)
    {

    }


}

