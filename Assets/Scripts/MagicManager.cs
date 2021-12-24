using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    public static MagicManager instance;

    public enum MagicType { Fireball, Fire, FireRain, IceNova, IceShards, Hammer, LightStrike, LightBlink, MeleeSlash, MeleeAoE, MeleeCone, Healing, AreaHealing, Summon, Curse, LifeDrain }
    public MagicType magicType;
    public  enum MagicEffect { Speed, Defence, HP, Attack, Area, Enemies, Control }
    public MagicEffect magicAffect;

    public string magicName;
    public string magicDescription;
    public int amountOfEffect;
    public int noOfEnemies;
    public int manaDrain;

    public GameObject[] magicSlots;




    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        magicSlots = new GameObject[7]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseMagic(int characterToUseOn)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("You picked up a " + magicName);
            SelfDestroy();
            Inventory.instance.AddMagic(this);

        }
    }

    public void SelfDestroy()
    {
        gameObject.SetActive(false);
    }
}
