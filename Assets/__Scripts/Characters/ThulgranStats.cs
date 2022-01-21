using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThulgranStats : MonoBehaviour
{

    public static int thulgranHP = 150;
    public static int thulgranMana = 45;
    public static int thulgranGold = 0;

    public static int thulgranSpells = 0;
    public static int thulgranPotions = 0;

    public static Sprite thulgranImage;
    public static Sprite thulgranMug;
    public static Sprite thulgranSkills;


    public static int[] thulgranSkillBonus;


    public static int[] thulgranXpLevelUp;
    public static int thulgranMaxLevel = 5;
    public static int thulgranBaseLevelXP = 0;
    public static int thulgranMaxHP = 300;
    public static int thulgranMaxMana = 200;


    public static bool isTeamMember = true;
    public static bool isVisible = true;
    public static string thulgranDesc = "Thulgran is dwarf royalty but he can't say not to an adventure. His life's ambition is to defeat a dragon.";
    public static string thulgranMoniker = "Dwarf Lord - PARTY LEADER";

    public static int thulgranLevel = 1;
    public static int thulgranXP = 75;

    public static int thulgranDexterity = 67;
    public static int thulgranDefence = 81;
    public static int thulgranIntelligence = 80;
    public static int thulgranPerception = 70;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
