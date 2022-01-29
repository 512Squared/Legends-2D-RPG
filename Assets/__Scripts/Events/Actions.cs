using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions
{
    // requires ItemsManager for item info
    public static Action<ItemsManager> OnSellItem; 

    // int = selectedCharacter | Vector2 = mugshot target for UI animation
    public static Action<ItemsManager, int, Vector2> OnUseItem; 
}
