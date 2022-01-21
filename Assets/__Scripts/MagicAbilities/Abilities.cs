using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    [SerializeField]
    public List<BaseAbilities> ability = new List<BaseAbilities>();


    //To cast a spell you would use Abilities.Cast[SpellIDNumber]
    //It's very easy to access all the information from BaseAbility
    //Using Switch Statements.

    //Here is an example from how I would set up a HoT on my player.
    // I have also added a Cooldown Example.

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Cast(0);
        }
    }


    public void Cast(int a)
    {
        if (ability[a].onCooldown)
        {
            return;
        }

        switch (ability[a].spellControl.castType)
        {

            case MagicType.Fireball:
                Fireball(a);
                break;


        }



    }


    public void Fireball(int a)
    {
        if (ability[a].ticking == true)
        {
            switch (ability[a].spellControl.modify)
            {
                case Modify.IncreaseFlat:
                    ability[a].onCooldown = true;
                    StartCoroutine(Cooldown(a));
                    StartCoroutine(Ticking(a));
                    break;
            }
        }
        else { }
    }




    IEnumerator Cooldown(int a)
    {
        yield return new WaitForSeconds(ability[a].cooldown);
        ability[a].onCooldown = false;
    }

    //In this Coroutine you would increase the chosen stat by said amount, you'll have to add your own stat script and modify it through here.
    //For now this will just give you a console log in increments of tickTime for the duration of the spell. So tickTime = how often it ticks


    IEnumerator Ticking(int a)
    {
        float timer = 0;

        while (timer < ability[a].spellActiveTime)
        {
            yield return new WaitForSeconds(ability[a].tickTime);
            timer += ability[a].tickTime;
            Debug.Log(timer);

        }


    }
}

