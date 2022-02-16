using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class Actions
{
    /// <summary>
    /// Stat related actions standardised to a single form to facilitate one UpdateStats()
    /// </summary>


    #region Shop Functions

    public static Action<ItemsManager> OnSellItem;
    public static Action<ItemsManager> OnBuyItem;
    public static Action<ItemsManager, int, Vector2> OnUseItem;
    public static Action<int> OnCoinAdd;

    #endregion

    #region Stats

    public static Action<Thulgran, ItemsManager> OnThulgran; //

    #endregion

    #region UI buttons

    public static Action OnBackButton;
    public static Action OnHomeButton;
    public static Action OnMainMenuButton;
    public static Action OnResumeButton;

    #endregion

    #region Scene managament

    public static Action<string> OnSceneChange;

    #endregion

    #region Region Name



    #endregion





}
