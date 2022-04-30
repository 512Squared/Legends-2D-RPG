using UnityEngine;
using System;

public static class Actions
{
    #region Shop Functions

    public static Action<Item> OnSellItem;
    public static Action<Item> OnBuyItem;
    public static Action<Item, int, Vector2> OnUseItem;

    #endregion

    #region Stats

    public static Action<Thulgran, Item> OnThulgran; //

    #endregion

    #region UI buttons

    public static Action OnBackButton;
    public static Action OnHomeButton;
    public static Action OnMainMenuButton;
    public static Action OnResumeButton;
    public static Action OnQuestCompletedResume;

    #endregion

    #region Scene managament

    public static Action<string, int, int> OnSceneChange;

    #endregion

    #region Region Name

    #endregion

    #region Quests

    public static Action<string> OnQuestCompleted;
    public static Action<string> MarkQuestCompleted;
    public static Action<string> OnActivateQuest;
    public static Action<string> OnQuestLogCalled;
    public static Action<Quest> OnClaimQuestRewards;
    public static Action<string, Quest, Quest> OnDoQuestStuffAfterDialogue;

    #endregion
}