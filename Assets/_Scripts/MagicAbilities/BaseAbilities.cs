using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MagicType
{
    Fireball,
    Fire,
    FireRain,
    IceNova,
    IceShards,
    Hammer,
    LightStrike,
    LightBlink,
    MeleeSlash,
    MeleeAoE,
    MeleeCone,
    Healing,
    AreaHealing,
    Summon,
    Curse,
    LifeDrain,
}

public enum MagicStates
{
    Null,
    Speed, // blue potion (x2 to movement speed when activated)
    Nimble, // yellow lightning, x2 to jump ability
    Swift, // purple lightning, x3 to jump ability
    Locks, // padlock (5% chance of picking a lock)
    Heal, // self-heal: green potion (+20 heal per round up to 3/4 max)
    Calm, // hourglass (slow enemy attacks)
    Rage, // fist (+30 to damage)
    Berserker, // ruby wings (double attacks per round)
    Parry, // helmet (10% chance of parry enemy attack)
    MortalWounding, // sword (10% change of mortal wound)
    Proximity, // Dungeon basic: glows when enemies are near
    Undead, // double damage against undead enemies

}

public enum Modify
{
    Null,
    IncreaseFlat,
    DecreaseFlat,
    IncreasePercentage,
    DecreasePercentage, 
    Area,
    Enemies, 
    Control,
    Summon,
}

public enum Stats
{
    CurrentHP,
    MaxHP,
    CurrentMana,
    MaxMana,
    Defence, 
    Dexterity,
    Speed,
    Jump
}


[System.Serializable]
public class BaseAbilities
{

    public string name;

    [TextArea]
    [Space]
    public string description;

    [Space]
    public int manaCost;

    [Space]
    public int lvlAvailable;

    [Space]
    public float cooldown;

    public bool onCooldown;

    [Space]
    public int power;

    [Space]
    public bool ticking;
    public float tickTime;

    [Space]
    public float projectileLifeTime;

    [Space]
    public float spellActiveTime;

    [Space]
    public float chargeDistance;

    [Space]
    public Sprite buttonSprite;

    [Space]
    public GameObject magicPrefab;

    [System.Serializable]
    public struct SpellControlList { public MagicType castType; public Modify modify; public Stats stats; public MagicStates states; }

    [Space]
    public SpellControlList spellControl = new SpellControlList();

}
