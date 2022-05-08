using System;
using Sirenix.OdinInspector;
using UnityEngine;

[zable]
public class QuestRewards
{
    public enum RewardTypes
    {
        None,
        Hp,
        Gold,
        Skills,
        ImmuneToDragonBreath
    }

    [HideInInlineEditors]
    public enum PlayerClasses
    {
        Thulgran,
        Npc,
        All,
        Enemy
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
    Npc = 1 << 2, // 2
    Enemy = 1 << 3, // 4
    All = Thulgran | Npc | Enemy
}