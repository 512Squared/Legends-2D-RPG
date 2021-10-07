using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;

    public Sprite characterImage;

    [SerializeField] int thulGold;
    [SerializeField] int thulSpells;
    [SerializeField] int thulPotions;
    public int[] xpLevelUp;
    [SerializeField] int maxLevel;
    public int baseLevelXP;
    public int maxMana;
    public int maxHP;

    public bool isTeamMember;
    public string playerName;
    public string playerDesc;
    
    public int npcLevel;
    public int npcXP;
    public int npcMana;
    public int npcHP;
    public int npcDexterity;
    public int npcDefence;
    public int npcIntelligence;
    public int npcPerception;


// Start is called before the first frame update
    void Start()
    {
        instance = this;

        // assigning XP and leveling up from XP
        
        xpLevelUp = new int[maxLevel];
        xpLevelUp[1] = baseLevelXP;

        for (int i = 1; i < xpLevelUp.Length; i++)
        {
            Debug.Log("PlayerStats: The current level is: " + i);
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

}

