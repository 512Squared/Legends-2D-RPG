using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;

    [SerializeField] Sprite characterImage;

    [SerializeField] int thulGold;
    [SerializeField] int thulSpells;
    [SerializeField] int thulPotions;
    [SerializeField] int[] xpLevelUp;
    [SerializeField] int maxLevel = 5;
    [SerializeField] int baseLevelXP;
    [SerializeField] int maxMana;
    [SerializeField] int maxHP;

    public bool isTeamMember;
    public string characterName;
    public string characterDesc;
    public int characterNo;


    
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP = 0;
    [SerializeField] int currentMana;
    [SerializeField] int currentHP;
    [SerializeField] int dexterity;
    [SerializeField] int defence;
    [SerializeField] int intelligence;
    [SerializeField] int perception;


// Start is called before the first frame update
    void Start()
    {
        instance = this;

        // assigning XP and leveling up from XP
        
        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXP;

        for (int i = 1; i < xpLevelUp.Length; i++)
        {
            Debug.Log("The current level is: " + i);
            xpLevelUp[i] = (int)(0.02f * Math.Pow(i, 3) + 3.06f * Math.Pow(i, 2) + 105.6f * i);
        }

    }

    // Update is called once per frame
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
        currentXP += amountOfXp;
        if(currentXP > xpLevelUp[playerLevel])
        {
            currentXP -= xpLevelUp[playerLevel];
            playerLevel++;

            maxHP = (int)(maxHP * 1.06f);
            maxMana = (int)(maxMana * 1.06f);
            currentHP = maxHP;
            currentMana = maxMana;

            if(playerLevel % 2 == 0)
            {
               dexterity++;
            }
            else
            {
               defence++;
            }

            if(playerLevel % 3 == 0)
            {
                intelligence++;
            }

            if (playerLevel % 5 == 0)
            {
                perception++;
            }


        }
    }

}

