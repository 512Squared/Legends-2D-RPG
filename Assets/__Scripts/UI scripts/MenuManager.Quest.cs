using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;


public partial class MenuManager
{
    public void QuestUISettings(string questPanelTrigger)
    {
        switch (questPanelTrigger)
        {
            case "quests":
                isQuestsOn = true;
                isClaimsOn = false;
                isRelicsOn = false;

                // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

                questsUIPanel.blocksRaycasts = true;
                questsUIPanel.interactable = true;
                questsTabButton.Select();
                questText.color = new Color(0.964f, 0.882f, 0.611f, 1);
                questSprite.sprite = questsSpriteOn;

                focusQuests.SetActive(true);

                claimsUIPanel.alpha = 0;
                claimsUIPanel.blocksRaycasts = false;
                claimsUIPanel.interactable = false;
                claimsText.color = new Color(0.745f, 0.709f, 0.713f, 1);
                claimsSprite.sprite = claimsSpriteOff;

                focusClaims.SetActive(false);

                relicsUIPanel.alpha = 0;
                relicsUIPanel.blocksRaycasts = false;
                relicsUIPanel.interactable = false;
                relicsSprite.sprite = relicsSpriteOff;
                relicsText.color = new Color(0.745f, 0.709f, 0.713f, 1);

                focusRelics.SetActive(false);
                break;
            case "claims":
                isQuestsOn = false;
                isClaimsOn = true;
                isRelicsOn = false;

                // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

                focusQuests.SetActive(false);
                questsUIPanel.alpha = 0;
                questsUIPanel.blocksRaycasts = false;
                questsUIPanel.interactable = false;
                questText.color = new Color(0.745f, 0.709f, 0.713f, 1);
                questSprite.sprite = questsSpriteOff;

                focusClaims.SetActive(true);

                claimsUIPanel.blocksRaycasts = true;
                claimsUIPanel.interactable = true;
                claimsText.color = new Color(0.964f, 0.882f, 0.611f, 1);
                claimsSprite.sprite = claimsSpriteOn;

                relicsUIPanel.alpha = 0;
                relicsUIPanel.blocksRaycasts = false;
                relicsUIPanel.interactable = false;
                relicsSprite.sprite = relicsSpriteOff;
                relicsText.color = new Color(0.745f, 0.709f, 0.713f, 1);

                focusRelics.SetActive(false);
                break;
            case "relics":
                {
                    isQuestsOn = false;
                    isClaimsOn = false;
                    isRelicsOn = true;

                    questFocusTitle.text = "Quest Log - Relics";

                    if (notifyRelicActive > 0)
                    {
                        notifyRelicActive = 0;
                    }

                    // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

                    questsUIPanel.alpha = 0;
                    questsUIPanel.blocksRaycasts = false;
                    questsUIPanel.interactable = false;
                    questText.color = new Color(0.745f, 0.709f, 0.713f, 1);
                    questSprite.sprite = questsSpriteOff;

                    focusQuests.SetActive(false);

                    claimsUIPanel.alpha = 0;
                    claimsUIPanel.blocksRaycasts = false;
                    claimsUIPanel.interactable = false;
                    claimsText.color = new Color(0.745f, 0.709f, 0.713f, 1);
                    claimsSprite.sprite = claimsSpriteOff;

                    focusClaims.SetActive(false);

                    relicsUIPanel.blocksRaycasts = true;
                    relicsUIPanel.interactable = true;
                    relicsSprite.sprite = relicsSpriteOn;
                    relicsText.color = new Color(0.964f, 0.882f, 0.611f, 1);

                    focusRelics.SetActive(true);
                    break;
                }
            case "exit":
                isQuestsOn = false;
                isClaimsOn = false;
                isRelicsOn = false;

                questsUIPanel.alpha = 0;
                questsUIPanel.blocksRaycasts = false;
                questsUIPanel.interactable = false;

                focusQuests.SetActive(false);

                claimsUIPanel.alpha = 0;
                claimsUIPanel.blocksRaycasts = false;
                claimsUIPanel.interactable = false;

                focusClaims.SetActive(false);

                relicsUIPanel.alpha = 0;
                relicsUIPanel.blocksRaycasts = false;
                relicsUIPanel.interactable = false;

                focusRelics.SetActive(false);

                questTabMenu.GetComponent<CanvasGroup>().interactable = false;
                questTabMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                questTabMenu.GetComponent<CanvasGroup>().alpha = 0;

                fadeBackground.GetComponent<CanvasGroup>().interactable = false;
                fadeBackground.GetComponent<CanvasGroup>().blocksRaycasts = false;
                fadeBackground.GetComponent<CanvasGroup>().alpha = 0;
                break;
        }

        UpdateQuestList("");
    }

    public void UpdateQuestList(string toggle)
    {
        foreach (Transform questPanel in QuestParent)
        {
            Destroy(questPanel.gameObject);
        }

        foreach (Transform claimsPanel in ClaimsParent)
        {
            Destroy(claimsPanel.gameObject);
        }

        foreach (Quest quest in QuestManager.Instance.GetQuestList())
        {
            #region QUESTS PANEL

            // Master Quests 

            if (isQuestsOn && quest.isActive && (quest.isMasterQuest || quest.isSubQuest))
            {
                // Master Quests - in progress

                if (quest.isMasterQuest && !quest.isDone)
                {
                    // in progress Master
                    RectTransform questPanel =
                        Instantiate(pf_QuestDefault, QuestParent).GetComponent<RectTransform>(); // Default

                    questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                    #region Find UI Elements

                    TextMeshProUGUI questName = questPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questDescription = questPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questStage = questPanel.Find("Slider/Stage").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questTrophies = questPanel.Find("MissionReward/Trophies/Amount")
                        .GetComponent<TextMeshProUGUI>();
                    RectTransform upButton = questPanel.Find("upDownIcon").GetComponent<RectTransform>();
                    Image questImage = questPanel.Find("Image").GetComponent<Image>();
                    Image questRewardImage = questPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                    RectTransform mask = questPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                    Slider questSlider = questPanel.Find("Slider").GetComponent<Slider>();
                    Button upDownButton = questPanel.Find("upDownIcon/Button").GetComponent<Button>();

                    #endregion

                    #region Toggle Icon

                    upButton.localScale = quest.toggleMasterSub switch
                    {
                        // toggleMasterSub now true, so icon stays UP
                        false => new Vector3(upButton.localScale.x, 1f, upButton.localScale.z),

                        // toggleMasterSub now false, so icon stays DOWN 
                        true => new Vector3(upButton.localScale.x, -1f, upButton.localScale.z)
                    };

                    if (toggle == quest.questName)
                    {
                        Debug.Log($"Toggle working: {toggle}");

                        upButton.localScale = quest.toggleMasterSub switch
                        {
                            // start position, subQuests will now collapse, change to DOWN icon
                            false when animate => new Vector3(upButton.localScale.x, -1f, upButton.localScale.z),

                            // after toggle, subQuests will now expand, change to UP icon
                            true when animate => new Vector3(upButton.localScale.x, 1f, upButton.localScale.z),
                            _ => upButton.localScale
                        };
                    }

                    #endregion Toggle Icon

                    #region UI Stuff

                    mask.sizeDelta = quest.trophiesAwarded switch
                    {
                        < 9 => new Vector2(25, mask.sizeDelta.y),
                        > 9 => new Vector2(50, mask.sizeDelta.y),
                        _ => mask.sizeDelta
                    };

                    questName.text = quest.questName;
                    questDescription.text = quest.questDescription;
                    questStage.text = quest.completedStages.ToString() + " / " + quest.totalMasterStages.ToString();
                    questImage.sprite = quest.questImage;
                    questRewardImage.sprite = quest.questReward;
                    questSlider.maxValue = quest.totalMasterStages;
                    questSlider.value = quest.completedStages;
                    questTrophies.text = quest.trophiesAwarded.ToString();
                    questSlider.gameObject.SetActive(true);
                    upDownButton.onClick.AddListener(() => SubQuestsShowing(quest));

                    #endregion UI Stuff
                }

                // Master's Subquests - in progress

                if (quest.isSubQuest && !quest.isDone)
                {
                    // in progress subs

                    RectTransform questPanel =
                        Instantiate(pf_QuestDefault, QuestParent).GetComponent<RectTransform>(); // Default

                    questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1155f);


                    #region Find UI Elements

                    RectTransform upButton = questPanel.Find("upDownIcon").GetComponent<RectTransform>();
                    RectTransform buttonBox = questPanel.Find("MissionReward").GetComponent<RectTransform>();
                    RectTransform TextBox = questPanel.Find("Name").GetComponent<RectTransform>();
                    RectTransform DescriptionBox = questPanel.Find("Description").GetComponent<RectTransform>();
                    RectTransform mask = questPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                    TextMeshProUGUI questName = questPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questDescription = questPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questStage = questPanel.Find("Slider/Stage").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI questTrophies = questPanel.Find("MissionReward/Trophies/Amount")
                        .GetComponent<TextMeshProUGUI>();
                    Image questImage = questPanel.Find("Image").GetComponent<Image>();
                    Image questRewardImage = questPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                    Image questContainer = questPanel.GetComponent<Image>();
                    Image questButtonContainer = questPanel.Find("MissionReward").GetComponent<Image>();
                    Slider questSlider = questPanel.Find("Slider").GetComponent<Slider>();

                    #endregion

                    #region Animate Toggle

                    if (!quest.isExpanded)
                    {
                        questPanel.sizeDelta = new Vector2(0, -9);
                        questPanel.localScale = new Vector3(0, 0, 1);
                    }

                    if (toggle == quest.masterQuest.questName)
                    {
                        if (animate && quest.isExpanded) // toggle expansion, animate collapse
                        {
                            questPanel.DOScale(new Vector3(0f, 0f, 1f), 0.6f).SetEase(Ease.InCirc);
                            questPanel.DOSizeDelta(new Vector3(0f, -9f, 0.8f), 0.8f).SetEase(Ease.InCirc);
                            quest.isExpanded = false;
                        }

                        else if (animate && !quest.isExpanded) // toggle collapse, animate expansion
                        {
                            questPanel.DOSizeDelta(new Vector3(1155, 131, 1), 0.3f).SetEase(Ease.InCirc);
                            questPanel.DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.InCirc);
                            quest.isExpanded = true;
                        }
                    }

                    #endregion

                    #region UI Stuff

                    upButton.gameObject.SetActive(false); // not needed on subquests
                    if (quest.trophiesAwarded < 9)
                    {
                        mask.sizeDelta = new Vector2(25, mask.sizeDelta.y); // graphic tidying
                    }
                    else if (quest.trophiesAwarded > 9)
                    {
                        mask.sizeDelta = new Vector2(50, mask.sizeDelta.y); // graphic tidying
                    }

                    questName.text = quest.questName;
                    questDescription.text = quest.questDescription;
                    questStage.text = quest.completedStages.ToString() + " / " + quest.totalMasterStages.ToString();
                    questImage.sprite = quest.questImage;
                    questRewardImage.sprite = quest.questReward;
                    questTrophies.text = quest.trophiesAwarded.ToString();
                    questSlider.gameObject.SetActive(false);
                    questContainer.color = new Color32(174, 163, 79, 255);
                    questButtonContainer.color = new Color32(20, 13, 8, 255);

                    #endregion UI Stuff
                }
            }

            // Other Quests - in Progress

            if (isQuestsOn && quest.isActive && !quest.isDone && !quest.isSubQuest && !quest.isMasterQuest)
            {
                // in progress

                RectTransform
                    questPanel = Instantiate(pf_QuestDefault, QuestParent).GetComponent<RectTransform>(); // Default

                questPanel.SetSiblingIndex(quest.questID);

                questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                #region Find UI Elements

                TextMeshProUGUI questName = questPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescription = questPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questStage = questPanel.Find("Slider/Stage").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies =
                    questPanel.Find("MissionReward/Trophies/Amount").GetComponent<TextMeshProUGUI>();
                Image questImage = questPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = questPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                RectTransform mask = questPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                RectTransform upButton = questPanel.Find("upDownIcon").GetComponent<RectTransform>();
                Slider questSlider = questPanel.Find("Slider").GetComponent<Slider>();

                #endregion

                if (quest.trophiesAwarded < 9)
                {
                    mask.sizeDelta = new Vector2(25, mask.sizeDelta.y);
                }
                else if (quest.trophiesAwarded > 9)
                {
                    mask.sizeDelta = new Vector2(50, mask.sizeDelta.y);
                }

                questName.text = quest.questName;
                questDescription.text = quest.questDescription;
                questImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();

                if (quest.questName == "null")
                {
                    questPanel.gameObject.SetActive(false);
                }

                questSlider.gameObject.SetActive(false);
                upButton.gameObject.SetActive(false);
            }

            #endregion

            #region CLAIMS PANEL

            // Master - incomplete

            if (isClaimsOn && quest.isActive && !quest.isDone && quest.isMasterQuest && quest.completedStages > 0 &&
                quest.MasterHasUnclaimedSubs())
            {
                // in progress Master
                RectTransform claimsPanel =
                    Instantiate(pf_QuestDefault, ClaimsParent).GetComponent<RectTransform>(); // Default

                claimsPanel.SetSiblingIndex(quest.questID);
                Debug.Log($"Quest Name: {quest.questName} | QuestID {claimsPanel.GetSiblingIndex()}");

                claimsPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                TextMeshProUGUI claimsName = claimsPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI claimsDescription = claimsPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI claimsStage = claimsPanel.Find("Slider/Stage").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies =
                    claimsPanel.Find("MissionReward/Trophies/Amount").GetComponent<TextMeshProUGUI>();
                RectTransform upButton = claimsPanel.Find("upDownIcon").GetComponent<RectTransform>();
                RectTransform mask = claimsPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                Image claimsImage = claimsPanel.Find("Image").GetComponent<Image>();
                Image claimsRewardImage = claimsPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                Slider claimsSlider = claimsPanel.Find("Slider").GetComponent<Slider>();

                if (quest.trophiesAwarded < 9)
                {
                    mask.sizeDelta = new Vector2(25, mask.sizeDelta.y);
                }
                else if (quest.trophiesAwarded > 9)
                {
                    mask.sizeDelta = new Vector2(50, mask.sizeDelta.y);
                }

                #region UI Stuff

                claimsSlider.gameObject.SetActive(true);
                claimsName.text = quest.questName;
                claimsDescription.text = quest.questDescription;
                claimsStage.text = quest.completedStages.ToString() + " / " + quest.totalMasterStages.ToString();
                claimsImage.sprite = quest.questImage;
                claimsRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();
                claimsSlider.maxValue = quest.totalMasterStages;
                claimsSlider.value = quest.completedStages;
                upButton.gameObject.SetActive(false);

                #endregion UI Stuff
            }

            // Master - completed but not claimed

            if (isClaimsOn && quest.isMasterQuest && quest.isDone && !quest.questRewardClaimed)
            {
                RectTransform claimsPanel =
                    Instantiate(pf_QuestComplete, ClaimsParent).GetComponent<RectTransform>(); // Completed

                claimsPanel.SetSiblingIndex(quest.questID);
                Debug.Log(
                    $"Quest: {quest.questName} | Sibling Index: {claimsPanel.GetSiblingIndex()} | QuestID: {quest.questID}");

                claimsPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                TextMeshProUGUI claimsName = claimsPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI claimsDescription = claimsPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies =
                    claimsPanel.Find("MissionReward/Trophies/Amount").GetComponent<TextMeshProUGUI>();
                Image claimsImage = claimsPanel.Find("Image").GetComponent<Image>();
                Image claimsRewardImage = claimsPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                RectTransform mask = claimsPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                Button claimsButton = claimsPanel.Find("Button_Claim").GetComponent<Button>();

                if (quest.trophiesAwarded < 9)
                {
                    mask.sizeDelta = new Vector2(25, mask.sizeDelta.y);
                }
                else if (quest.trophiesAwarded > 9)
                {
                    mask.sizeDelta = new Vector2(50, mask.sizeDelta.y);
                }

                claimsName.text = quest.questName;
                claimsDescription.text = quest.questDescription;
                claimsImage.sprite = quest.questImage;
                claimsRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();
                claimsButton.onClick.AddListener(() => ClaimQuestRewards(claimsPanel, quest));
            }

            // Subquests - completed but not claimed

            if (isClaimsOn && quest.isSubQuest && quest.isDone && !quest.questRewardClaimed)
            {
                // completed subs
                RectTransform claimsPanel =
                    Instantiate(pf_QuestComplete, ClaimsParent).GetComponent<RectTransform>(); // Completed

                claimsPanel.SetSiblingIndex(quest.questID);

                claimsPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1300f);

                TextMeshProUGUI claimsName = claimsPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI claimsDescription = claimsPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies =
                    claimsPanel.Find("MissionReward/Trophies/Amount").GetComponent<TextMeshProUGUI>();
                Image claimsImage = claimsPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = claimsPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                RectTransform mask = claimsPanel.Find("MissionReward/Trophies/Image").GetComponent<RectTransform>();
                Button claimsButton = claimsPanel.Find("Button_Claim").GetComponent<Button>();
                Image claimsContainer = claimsPanel.GetComponent<Image>();
                RectTransform upButton = claimsPanel.Find("upDownIcon").GetComponent<RectTransform>();

                if (quest.trophiesAwarded < 9)
                {
                    mask.sizeDelta = new Vector2(25, mask.sizeDelta.y);
                }
                else if (quest.trophiesAwarded > 9)
                {
                    mask.sizeDelta = new Vector2(50, mask.sizeDelta.y);
                }

                upButton.gameObject.SetActive(false); // not needed on subquests
                claimsName.text = quest.questName;
                claimsDescription.text = quest.questDescription;
                claimsImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();
                claimsContainer.color = new Color32(174, 163, 79, 255);
                claimsButton.onClick.AddListener(() => ClaimQuestRewards(claimsPanel, quest));
            }

            // Other quests - completed but not claimed

            if (isClaimsOn && !quest.isSubQuest && !quest.isMasterQuest && quest.isDone && !quest.questRewardClaimed)
            {
                RectTransform claimsPanel =
                    Instantiate(pf_QuestComplete, ClaimsParent).GetComponent<RectTransform>(); // Completed

                claimsPanel.SetSiblingIndex(quest.questID);

                claimsPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                TextMeshProUGUI claimsName = claimsPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI claimsDescription = claimsPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies =
                    claimsPanel.Find("MissionReward/Trophies/Amount").GetComponent<TextMeshProUGUI>();
                Image claimsImage = claimsPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = claimsPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                Button claimsButton = claimsPanel.Find("Button_Claim").GetComponent<Button>();
                RectTransform upButton = claimsPanel.Find("upDownIcon").GetComponent<RectTransform>();

                upButton.gameObject.SetActive(false); // not needed on subquests
                claimsName.text = quest.questName;
                claimsDescription.text = quest.questDescription;
                claimsImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();
                claimsButton.onClick.AddListener(() => ClaimQuestRewards(claimsPanel, quest));
            }

            #endregion
        }

        // COMPLETED QUESTS

        foreach (Quest quest in QuestManager.Instance.GetQuestList()
                     .Where(quest => isQuestsOn && quest.questRewardClaimed))
        {
            // Master Quests

            if (quest.isMasterQuest)
            {
                // Completed Master

                if (quest.isMasterQuest && !quest.resetChildren && quest.questRewardClaimed)
                {
                    ResetChildren(quest);
                }

                RectTransform claimedPanel =
                    Instantiate(pf_QuestClaimed, QuestParent).GetComponent<RectTransform>(); // Default

                claimedPanel.SetSiblingIndex(quest.questID); // quest limit

                Debug.Log($"Quest: {quest.questName} | Sibling Index: {claimedPanel.GetSiblingIndex()}");

                claimedPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                #region Find UI Elements

                TextMeshProUGUI questName = claimedPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescription = claimedPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies = claimedPanel.Find("MissionReward/Trophies/Amount")
                    .GetComponent<TextMeshProUGUI>();
                RectTransform upButton = claimedPanel.Find("upDownIcon").GetComponent<RectTransform>();

                Image questImage = claimedPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = claimedPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                RectTransform mask = claimedPanel.Find("MissionReward/Trophies/Mask").GetComponent<RectTransform>();
                Button upDownButton = claimedPanel.Find("upDownIcon/Button").GetComponent<Button>();
                upDownButton.onClick.AddListener(() => SubQuestsShowing(quest));

                #endregion Find UI Elements

                #region Toggle Icon

                upButton.localScale = quest.toggleMasterSub switch
                {
                    // toggleMasterSub now true, so icon stays UP
                    false => new Vector3(upButton.localScale.x, 1f, upButton.localScale.z),

                    // toggleMasterSub now false, so icon stays DOWN 
                    true => new Vector3(upButton.localScale.x, -1f, upButton.localScale.z)
                };

                if (toggle == quest.questName)
                {
                    Debug.Log($"Toggle working: {toggle}");

                    upButton.localScale = quest.toggleMasterSub switch
                    {
                        // start position, subQuests will now collapse, change to DOWN icon
                        false when animate => new Vector3(upButton.localScale.x, -1f, upButton.localScale.z),

                        // after toggle, subQuests will now expand, change to UP icon
                        true when animate => new Vector3(upButton.localScale.x, 1f, upButton.localScale.z)
                    };
                }

                #endregion Toggle Icon

                #region UI Stuff

                mask.sizeDelta = quest.trophiesAwarded switch
                {
                    < 9 => new Vector2(25, mask.sizeDelta.y),
                    > 9 => new Vector2(50, mask.sizeDelta.y),
                    _ => mask.sizeDelta
                };

                questName.text = quest.questName;
                questDescription.text = quest.questDescription;
                questImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();

                #endregion UI Stuff
            }

            // Completed Master Subquests

            if (quest.isSubQuest && quest.masterQuest.questRewardClaimed)
            {
                RectTransform claimedPanel =
                    Instantiate(pf_QuestClaimed, QuestParent).GetComponent<RectTransform>(); // Default

                claimedPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1155f);

                claimedPanel.SetSiblingIndex(quest.questID);

                #region Find UI Elements

                RectTransform upButton = claimedPanel.Find("upDownIcon").GetComponent<RectTransform>();
                RectTransform buttonBox = claimedPanel.Find("MissionReward").GetComponent<RectTransform>();
                RectTransform textBox = claimedPanel.Find("Name").GetComponent<RectTransform>();
                RectTransform descriptionBox = claimedPanel.Find("Description").GetComponent<RectTransform>();
                RectTransform mask = claimedPanel.Find("MissionReward/Trophies/Mask").GetComponent<RectTransform>();
                TextMeshProUGUI questName = claimedPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescription = claimedPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies = claimedPanel.Find("MissionReward/Trophies/Amount")
                    .GetComponent<TextMeshProUGUI>();
                Image questImage = claimedPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = claimedPanel.Find("MissionReward/RewardImage").GetComponent<Image>();

                #endregion

                #region Animate Toggle

                if (!quest.isExpanded)
                {
                    claimedPanel.sizeDelta = new Vector2(0, -9);
                    claimedPanel.localScale = new Vector3(0, 0, 1);
                }

                if (toggle == quest.masterQuest.questName)
                {
                    switch (animate)
                    {
                        // toggle expansion, animate collapse
                        case true when quest.isExpanded:
                            claimedPanel.DOScale(new Vector3(0f, 0f, 1f), 0.6f).SetEase(Ease.InCirc);
                            claimedPanel.DOSizeDelta(new Vector3(0f, -9f, 0.8f), 0.8f).SetEase(Ease.InCirc);
                            quest.isExpanded = false;
                            break;
                        // toggle collapse, animate expansion
                        case true when !quest.isExpanded:
                            claimedPanel.DOSizeDelta(new Vector3(1155, 131, 1), 0.3f).SetEase(Ease.InCirc);
                            claimedPanel.DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.InCirc);
                            quest.isExpanded = true;
                            break;
                    }
                }

                #endregion

                #region UI Stuff

                upButton.gameObject.SetActive(false); // not needed on subquests
                mask.sizeDelta = quest.trophiesAwarded switch
                {
                    < 9 => new Vector2(25, mask.sizeDelta.y),
                    > 9 => new Vector2(50, mask.sizeDelta.y),
                    _ => mask.sizeDelta
                };

                questName.text = quest.questName;
                questDescription.text = quest.questDescription;
                questImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();

                #endregion UI Stuff
            }

            // Other Quests - Completed & Claimed

            if (!quest.isMasterQuest && !quest.isSubQuest)
            {
                RectTransform claimedPanel =
                    Instantiate(pf_QuestClaimed, QuestParent).GetComponent<RectTransform>(); // Default

                claimedPanel.SetSiblingIndex(quest.questID);

                claimedPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                #region Find UI Elements

                TextMeshProUGUI questName = claimedPanel.Find("Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescription = claimedPanel.Find("Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questTrophies = claimedPanel.Find("MissionReward/Trophies/Amount")
                    .GetComponent<TextMeshProUGUI>();
                Image questImage = claimedPanel.Find("Image").GetComponent<Image>();
                Image questRewardImage = claimedPanel.Find("MissionReward/RewardImage").GetComponent<Image>();
                RectTransform mask = claimedPanel.Find("MissionReward/Trophies/Mask").GetComponent<RectTransform>();
                RectTransform upButton = claimedPanel.Find("upDownIcon").GetComponent<RectTransform>();

                #endregion

                #region UI Stuff

                if (quest.trophiesAwarded < 9)
                {
                    mask.sizeDelta = new Vector2(25, mask.sizeDelta.y);
                }
                else if (quest.trophiesAwarded > 9)
                {
                    mask.sizeDelta = new Vector2(50, mask.sizeDelta.y);
                }

                upButton.gameObject.SetActive(false);
                questName.text = quest.questName;
                questDescription.text = quest.questDescription;
                questImage.sprite = quest.questImage;
                questRewardImage.sprite = quest.questReward;
                questTrophies.text = quest.trophiesAwarded.ToString();

                #endregion UI Stuff
            }
        }


        UpdateQuestNotifications();
    }

    public void UpdateQuestNotifications()
    {
        // nofify
        totalQuestNotifications = notifyActiveQuest + notifyQuestReward + notifyRelicActive;

        questsTabNofify.alpha = notifyActiveQuest > 0 ? 1 : 0;
        claimsTabNofify.alpha = notifyQuestReward > 0 ? 1 : 0;
        relicsTabNofify.alpha = notifyRelicActive > 0 ? 1 : 0;
        totalQuestNofify.alpha = totalQuestNotifications > 0 ? 1 : 0;

        newQuestActiveText.text = notifyActiveQuest.ToString();
        newClaimQuestRewardText.text = notifyQuestReward.ToString();
        newQuestRelicActiveText.text = notifyRelicActive.ToString();
        totalQuestNofifyText.text = totalQuestNotifications.ToString();
    }

    public void SubQuestsShowing(Quest quest)
    {
        animate = true;
        Debug.Log($"Quest name: {quest.questName}");
        UpdateQuestList(quest.questName);
        quest.isExpanded = !quest.isExpanded;
        quest.toggleMasterSub = !quest.toggleMasterSub;
        animate = false;
    }

    public void QuestCompletePanel(Quest quest, Quest[] childQuests)
    {
        MainMenuPanel(15);
        DoPunch(menuPanels[15].gameObject, new Vector3(0.15f, 0.15f, 0), 0.1f);
        questCompleted.text = quest.onDoneMessage;
        questCompletedName.text = quest.questName;
        questCompletedPanelSprite.sprite = quest.questImage;
        questRewardSprite.sprite = quest.questReward;
        questRewardText[0].text = quest.trophiesAwarded.ToString();
        questRewardText[1].text = (quest.trophiesAwarded + 10).ToString();


        for (int i = 4; i < questRewardSlots.Length; i++)
        {
            questRewardSlots[i].SetActive(false);
        } // slot reset

        questRewardSlots[2].SetActive(false); // bonus reset

        if (quest.bonusRewardItem)
        {
            questRewardSlots[2].SetActive(true);
        }

        if (quest.isMasterQuest && childQuests != null) // child quest stuff + trophies etc
        {
            Debug.Log($"Master slots test 1 | Child quests: {childQuests.Length - 1}");

            if (!quest.isDone) { return; }

            Debug.Log($"Master slots test 2");

            for (int i = 1; i < childQuests.Length; i++) // child quest stuff
            {
                Debug.Log($"Master slots test 3 | {i}");
                questRewardSlots[i + 3].SetActive(true);
                questSlotImage[i + 3].sprite = childQuests[i].questImage;
                questRewardText[i + 3].enabled = false;
            }
        }
    }

    public void QuestPanelClose()
    {
        StartCoroutine(FadeToAlpha(menuPanels[15].GetComponent<CanvasGroup>(), 0f, 0.3f));
        menuPanels[15].GetComponent<CanvasGroup>().interactable = false;
        menuPanels[15].GetComponent<CanvasGroup>().blocksRaycasts = false;
        DoPunch(menuPanels[15].gameObject, new Vector3(0.15f, 0.15f, 0), 0.4f);
    }

    public void OpenRelicInfo(int itemCode)
    {
        if (QuestManager.Instance.GetRelicList().All(relic => relic.ItemCode != itemCode)) { return; }

        ItemDetails item = Inventory.Instance.GetItemDetails(itemCode);
        questRelicName.text = item.itemName;
        questRelicDescription.text = item.itemDescription;
        questRelicImage.sprite = item.itemsImage;
    }

    public static void ClaimQuestRewards(RectTransform questPanel, Quest quest)
    {
        // invoked via a listener added via updateQuestList

        Actions.OnClaimQuestRewards?.Invoke(quest);
        CanvasGroup canvas = questPanel.GetComponent<CanvasGroup>();
        canvas.DOFade(0, 2f);
        canvas.blocksRaycasts = false;
        canvas.interactable = false;
        questPanel.DOScale(new Vector3(0f, 0f, 1f), 0.4f).SetEase(Ease.InCirc);
        questPanel.DOSizeDelta(new Vector3(0f, 0f, 0.4f), 0.5f).SetEase(Ease.InCirc);

        Thulgran.AddGold(quest.trophiesAwarded + 10);
        Thulgran.AddTrophies(quest.trophiesAwarded);
    }

    public void ResetChildren(Quest quest)
    {
        if (!quest.resetChildren)
        {
            Debug.Log($"Genius in action: {quest.isExpanded}");
            Quest[] quests = quest.GetChildQuests();
            foreach (Quest q in quests)
            {
                q.isExpanded = quest.isExpanded;
            }
        }

        quest.resetChildren = true;
    }
}