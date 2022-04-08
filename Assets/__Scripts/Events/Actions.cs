using UnityEngine;
using System;

public static class Actions
{

    #region Shop Functions

    public static Action<ItemsManager> OnSellItem;
    public static Action<ItemsManager> OnBuyItem;
    public static Action<ItemsManager, int, Vector2> OnUseItem;
    
    #endregion

    #region Stats

    public static Action<Thulgran, ItemsManager> OnThulgran; //

    #endregion

    #region UI buttons

    public static Action OnBackButton;
    public static Action OnHomeButton;
    public static Action OnMainMenuButton;
    public static Action OnResumeButton;
    public static Action OnQuestCompletedResume;

    #endregion

    #region Scene managament

    public static Action<string> OnSceneChange;

    #endregion

    #region Region Name



    #endregion

    #region Quests

    public static Action <string>OnQuestCompleted;
    public static Action<string> MarkQuestCompleted;
    public static Action<string> OnActivateQuest;
    public static Action <string> OnQuestLogCalled;
    public static Action <Quest>OnClaimQuestRewards;
    public static Action <string, string, string> OnDoQuestStuffAfterDialogue;

    #endregion

}
