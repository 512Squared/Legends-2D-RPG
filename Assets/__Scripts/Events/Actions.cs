using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions
{
    /// <summary>
    /// Stat related actions standardised to a single form to facilitate one UpdateStats()
    /// </summary>
    
    
    // requires ItemsManager for item info
    public static Action<ItemsManager> OnSellItem; 
    public static Action<ItemsManager> OnBuyItem;

    // int = selectedCharacter | Vector2 = mugshot target for UI animation
    public static Action<ItemsManager, int, Vector2> OnUseItem;

    public static Action<Thulgran, ItemsManager> OnThulgran; //

    public static Action<ItemsManager> _cUpdate;

}
