using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour 
{
    #region TODO List
    

    #endregion

    #region SINGLETON

    public static Sprites instance;

    #endregion

    # region SpriteStuff
    public Sprite manaSprite, hpSprite;

    void Start()
    {
        instance = this;
    }
    #endregion

}
