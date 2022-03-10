using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class Actions
{

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

    #region Quests

    public static Action <string, QuestRewards>OnQuestCompleted;
    public static Action<string> MarkQuestCompleted;
    public static Action<string> OnActivateQuest;
    public static Action OnQuestLogCalled;
    public static Action <string, string, string> OnDoQuestStuffAfterDialogue;

    #endregion

}
