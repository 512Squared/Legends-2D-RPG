using System.Collections;
using UnityEngine;

public class MagicUnit : MonoBehaviour
{

    public enum MagicType { Fireball, Fire, FireRain, IceNova, IceShards, Hammer, LightStrike, LightBlink, MeleeSlash, MeleeAoE, MeleeCone, Healing, AreaHealing, Summon, Curse, LifeDrain }
    public MagicType magicType;
    public enum MagicEffect { Speed, Defence, HP, Attack, Area, Enemies, Control }
    public MagicEffect magicAffect;

    public string magicName;
    public string magicDescription;
    public int amountOfEffect;
    public int noOfEnemies;
    public int manaDrain;

    public GameObject[] magicSlots;

    public int Level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
