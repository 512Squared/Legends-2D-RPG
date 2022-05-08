using System;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class QuestRewards
{

    public enum RewardTypes
    {
        none,
        hp,
        gold,
        skills,
        immuneToDragonBreath
    }
    [HideInInlineEditors]
    public enum PlayerClasses
    {
        Thulgran,
        NPC,
        all,
        enemy
    }

    public RewardTypes rewardType;
    [HideInInspector]
    public PlayerClasses playerClass;

    [EnumToggleButtons]
    public Recipients recipients;
    
    public int rewardAmount;
}

[Flags]
public enum Recipients
{
    Thulgran = 1 << 1, // 1
    NPC = 1 << 2, // 2
    enemy = 1 << 3, // 4
    all = Thulgran | NPC | enemy
}

