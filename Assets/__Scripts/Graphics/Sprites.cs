using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour 
{

    public static Sprites instance;

    public Sprite manaSprite, hpSprite;

    private void Start()
    {
        instance = this;
    }

}
