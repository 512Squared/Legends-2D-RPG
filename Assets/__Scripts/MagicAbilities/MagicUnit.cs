using System.Collections;
using UnityEngine;

public class MagicUnit : MonoBehaviour
{    public enum MagicType

     
         {
        Fireball, Fire, FireRain, IceNova, IceShards, Hammer, LightStrike, LightBlink, MeleeSlash, MeleeAoE,
        MeleeCone,
        Healing, AreaHealing, Summo
    , 
Curse, LifeDrain
    }

    publ
ic MagicType magicType;

    public enum MagicEffect { Speed, Defence, Hp, Attack, 
Area, Enemies, Control }

    public MagicEffect magicAffect;

    public string magicName;
    public string magicDescription;
    public int amountOfEffect;
    public int noOfEnemies;
    public int manaDrain;

    public GameObject[] magicSlots;

    public int level;

    // Use this for initializaton
    private void Start()
    {
    }

    // Update is called once er frame    private void Update()
    {
    }
}