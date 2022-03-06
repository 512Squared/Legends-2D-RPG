using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    // TODO Q only when active in UI
    // TODO Q only active in first UI tab
    // TODO Q tab to claims
    // TODO Q subquest sliders



    public static MenuManager instance;

    #region FIELDS
    private int panelStuff;
    private string whichPanelIsOn = "";
    private int teamNofifyCount;
    private Tween fadeText;
    private int foodItems, weaponItems, potionItems, itemItems, armourItems;


    #endregion

    #region PROPERTIES

    //comment

    #endregion

    #region SERIALIZATION



    [SerializeField] PlayerStats[] playerStats;

    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject mainMenu, inventoryPanel, dayNightCycle;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] CanvasGroup[] menuPanels;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] RectTransform clockPanel, clockFrame;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [Range(0.5f, 2f)]
    [SerializeField] float minButtonSize = 0.9f;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [Range(0.5f, 2f)]
    [SerializeField] float maxButtonSize = 1f;


    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject equipment;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] Image imageToFade;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] TMP_Dropdown droppy; // dropbox for the dropdown object (hence, TMP_Dropdown)
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] private UltimateButton actionButton;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] private UltimateJoystick joystick;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] private UltimateMobileQuickbar quickBar;


    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject panelTesting;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject teamTabMenu;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] CanvasGroup teamNofify, questsNofify, fadeResume;
    [SerializeField] TextMeshProUGUI teamMemberCount;


    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI[] characterName, characterNameP, description, level, levelP, xp, mana, health, attack, defence, intelligence, perception;
    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject[] characterCards, characterParty, characterEquip, characterWeaponry, teamCharacterWeaponry;

    [TabGroup("Images")]
    [GUIColor(0.670f, 1, 0.560f)]
    [PreviewField, Required]
    [SerializeField] Image[] characterImage, characterMug, characterPlain;
    [TabGroup("Images")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] Image characterImageV;


    [TabGroup("Sliders")]
    [GUIColor(1f, 0.886f, 0.780f)]
    [SerializeField] Slider[] xpS, manaS, healthS, attackS, defenceS, intelligenceS, perceptionS;
    [TabGroup("Sliders")]
    [GUIColor(1f, 0.886f, 0.780f)]
    [SerializeField] Slider xpVS, manaVS, healthVS, attackVS, defenceVS, intelligenceVS, perceptionVS;


    [TabGroup("New Group", "Thulgren")]
    [GUIColor(1f, 0.780f, 0.984f)]
    [SerializeField] TextMeshProUGUI thulSpells, thulPotions, levelMain, xpMain, hpMain, manaMain;
    [TabGroup("New Group", "Thulgren")]
    [GUIColor(1f, 0.780f, 0.984f)]
    [SerializeField] Slider xpMainS;

    [TabGroup("Skills")]
    [GUIColor(1, 0.819f, 0.760f)]
    [SerializeField] TextMeshProUGUI characterNameV, descriptionV, levelV, xpV, manaV, healthV, attackV, defenceV, intelligenceV, perceptionV;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI itemName, goldMain, itemDescription, itemDamage, itemArmour, itemPotion, itemFood, itemValue;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image itemImage;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Sprite masking;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Transform itemBoxParent;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject itemBox, itemDamageBox, itemArmourBox, itemPotionBox, itemFoodBox;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI effectText;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject effectBox;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject cancelButton, useButton;


    [TabGroup("New Group", "Equip")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI[] manaEquipToString, hpEquipToString, defenceEquipToString;
    [TabGroup("New Group", "Equip")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Slider[] manaEquipSlider, hpEquipSlider, defenceEquipSlider;
    [TabGroup("New Group", "Equip")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image[] characterMugEquip;
    [TabGroup("New Group", "Equip")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI manaEquipTopBar, hpEquipTopBar, goldEquipTopBar; // doesn't look like I used these. Done in CoinsManager.
    [TabGroup("New Group", "Equip")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Button[] weaponPanelButtons, potionPanelButtons; // doesn't look like I used these. Done in CoinsManager.


    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] equippedWeaponName, equippedArmourName, equippedHelmetName, equippedShieldName;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] equippedWeaponImage, equippedArmourImage, equippedHelmetImage, equippedShieldImage;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] characterMugWeaponry;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] equippedWeaponBonus, equippedArmourBonus, equippedHelmetBonus, equippedShieldBonus;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.147f, 0.154f, 0.496f)]
    public TextMeshProUGUI itemPotionPower;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.147f, 0.154f, 0.496f)]
    public Sprite basicAxe, basicArmour, basicHelmet, basicShield;
    [Header("Team Panel UI")]

    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamCharacterName;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamEquippedWeaponImage, teamEquippedArmourImage, teamEquippedHelmetImage, teamEquippedShieldImage;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamCharacterMugWeaponry;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamInventoryAttackTotal, teamInventoryDefenceTotal; // attack power is actually Dexterity in PlayerStats (yeah, I had to same thought... wtf??
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamItemWeaponBonus, teamItemArmourBonus, teamItemHelmetBonus, teamItemShieldBonus;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Sprite teamBasicAxe, teamBasicArmour, teamBasicHelmet, TeamBasicShield;

    [TabGroup("Weapon Group", "Team Popup")]
    [GUIColor(0.207f, 0.121f, 0.027f)]
    public Image teamPopWeaponryImage;
    [TabGroup("Weapon Group", "Team Popup")]
    [GUIColor(0.207f, 0.121f, 0.027f)]
    public TextMeshProUGUI teamPopWeaponryName, teamPopWeaponryDescription, teamPopWeaponryBonusText;
    [TabGroup("Weapon Group", "Team Popup")]
    [GUIColor(0.207f, 0.121f, 0.027f)]
    public TextMeshProUGUI teamPopWeaponryBonus;

    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public Button inventTabsAllHolder, inventTabsWeaponsHolder, inventTabsArmourHolder, inventTabsItemsHolder, inventTabsPotionsHolder;
    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public TextMeshProUGUI inventTabsAllText;
    [TabGroup("Weapon Group", "Inventory Tabs")]
    [GUIColor(0.207f, 0.921f, 0.027f)]
    public GameObject inventTabsAllFocus, inventTabsWeaponsFocus, inventTabsArmourFocus, inventTabsItemsFocus, inventTabsPotionsFocus;
    [TabGroup("Weapon Group", "Add to Party")]
    [GUIColor(0.307f, 0.321f, 0.027f)]
    public Button[] addToPartyButton, retireFromPartyButton;
    [TabGroup("Weapon Group", "Add to Party")]
    [GUIColor(0.307f, 0.321f, 0.027f)]
    public GameObject[] isNewNotification;

    [Title("Quests")]
    [GUIColor(0.107f, 0.621f, 0.227f)]
    public GameObject pf_QuestDefault;
    [GUIColor(0.107f, 0.621f, 0.227f)]
    public GameObject pf_QuestComplete;
    [GUIColor(0.107f, 0.621f, 0.227f)]
    public Transform QuestParent;

    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] GameObject focusQuests, focusWeekly, focusAchieve, questTabMenu;

    [Header("Quest UI Sprites")]
    [Space]
    [FoldoutGroup("UI Sprites", expanded: false)]
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] Sprite questsSpriteOn, questsSpriteOff, weeklySpriteOn, weeklySpriteOff, achieveSpriteOn, achieveSpriteOff;
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] Image questSprite, weeklySprite, achieveSprite;
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] TextMeshProUGUI questFocusTitle, questText, weeklyText, achieveText;


    [ShowInInspector]
    [Title("Nofify Info")]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public int currentNewItems, claimQuestReward;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    [SerializeField] TextMeshProUGUI newItemsText, claimQuestText;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public ItemsManager activeItem; //what are we doing here? Creating a slot in inspector for an 'active item', which is an object that has an ItemsManager script attached?


    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [SerializeField] bool[] isTeamMember;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isInventoryOn = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool keyboardKeyI = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool controlSwitch;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool weaponBool, armourBool, itemBool, potionBool, spellBool;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isOverviewOn, isStatsOn, isWeaponryOn;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isInventorySlidePanelOn;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isClockPopOutVisible;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isQuestsOn, isWeeklyOn, isAchieveOn;



    [Header("UI Tweening")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private CanvasGroup chooseText;
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI textUseEquipTake;
    [GUIColor(1f, 1f, 0.215f)]
    public RectTransform mainEquipInfoPanel, characterChoicePanel, characterWeaponryPanel;





    [Header("Player Choice")]
    [GUIColor(1f, 0.2f, 0.515f)]
    [SerializeField] TextMeshProUGUI[] playerChoice;
    [FoldoutGroup("Button Images", expanded: false)]
    [GUIColor(1f, 0.2f, 0.515f)]
    [SerializeField] Sprite buttonGrey, buttonGreen;

    [Header("Team UI Sprites")]
    [Space]
    [FoldoutGroup("UI Sprites", expanded: false)]
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] Sprite overviewSpriteOn, overviewSpriteOff, statsSpriteOn, statsSpriteOff, weaponrySpriteOn, weaponrySpriteOff;
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] Image overviewSprite, statsSprite, weaponrySprite;
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] GameObject focusWeaponry, focusStats, focusOverview;
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField] TextMeshProUGUI focusTitle, overviewText, statsText, weaponryText;

    [SerializeField] GameObject questItem;


    #endregion

    #region CALLBACKS
    private void Start()
    {
        instance = this;
        mainEquipInfoPanel.DOAnchorPos(Vector2.zero, 0f);
        mainMenu.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.4f, 0, 1);
    }

    private void Awake()
    {
        mainMenu.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.4f, 0, 1);
    }

    private void Update()
    {
    }

    #endregion CALLBACKS

    #region SUBSCRIBERS


    private void OnEnable()
    {
        Actions.OnUseItem += UpdateStats_1;
        Actions.OnBuyItem += UpdateStats_2; //hook into Action with minimal Args
        Actions.OnSellItem += UpdateStats_2;
        Actions.OnBackButton += BackButton;
        Actions.OnHomeButton += HomeButton;
        Actions.OnMainMenuButton += MainMenuButton;
        Actions.OnResumeButton += ResumeButton;
        Actions.OnQuestLogCalled += UpdateQuestList;
    }


    private void OnDisable()
    {
        Actions.OnUseItem -= UpdateStats_1;
        Actions.OnBuyItem -= UpdateStats_2;
        Actions.OnSellItem -= UpdateStats_2;
        Actions.OnBackButton -= BackButton;
        Actions.OnHomeButton -= HomeButton;
        Actions.OnMainMenuButton -= MainMenuButton;
        Actions.OnResumeButton -= ResumeButton;
    }

    #endregion

    #region INVOCATIONS

    public void UpdateStats_1(ItemsManager item, int character, Vector2 position)
    {
        UpdateStats();
        UpdateItemsInventory();
    }

    public void UpdateStats_2(ItemsManager item)
    {
        UpdateStats(); //hook into Actions without all the Args
        UpdateItemsInventory();
    }

    private void ResumeButton()
    {
        #region Graphics

        StartCoroutine(FadeToAlpha(mainMenu.GetComponent<CanvasGroup>(), 0f, 0.3f));
        DoPunch(mainMenu, new Vector3(0.15f, 0.15f, 0), 0.4f);
        ControllersFadeIn(0.5f);
        StartCoroutine(EnableJoystickDelay(0.7f));
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;

        #endregion

        #region Data

        currentNewItems = 0;
        claimQuestReward = 0;
        ButtonHandler.instance.SetAllButtonsInteractable();
        ShopManager.instance.ShopItemInfoReset();
        ItemInfoReset();
        UpdateItemsInventory();
        UpdateStats();

        #endregion

        #region Bools

        GameManager.instance.isItemSelected = false;
        isInventoryOn = false;
        GameManager.instance.isInventoryOn = false;
        GameManager.instance.isShopUIOn = false;

        dayNightCycle.SetActive(true);

        #endregion
    }

    public void BackButton()
    {
        PanelController();
        currentNewItems = 0;
        claimQuestReward = 0;
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
        GameManager.instance.isItemSelected = false;
        UpdateItemsInventory();
        isInventoryOn = false;
        GameManager.instance.isInventoryOn = false;
        Debug.Log($"isInventoryOn: {isInventoryOn}");
    }

    private void HomeButton()
    {
        #region Graphics

        ControllersFadeIn(0.5f);
        StartCoroutine(EnableJoystickDelay(0.7f));
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
        MenuPanelsOff("home");

        #endregion

        #region Data

        currentNewItems = 0;
        claimQuestReward = 0;
        ButtonHandler.instance.SetAllButtonsInteractable();
        ShopManager.instance.ShopItemInfoReset();
        ItemInfoReset();

        UpdateItemsInventory();
        UpdateStats();

        #endregion

        #region Bools

        GameManager.instance.isItemSelected = false;
        GameManager.instance.isShopUIOn = false;

        dayNightCycle.SetActive(true);
        isInventoryOn = false;
        GameManager.instance.isInventoryOn = false;
        Debug.Log($"isInventoryOn: {isInventoryOn}");
        #endregion             
    }

    private void MainMenuButton()
    {
        MainMenuCGOn(); // no fade in, just DOPunch
        ControllersFadeOut(0.3f);
        DoPunch(mainMenu, new Vector3(0.15f, 0.15f, 0), 0.1f);
        UpdateStats();
        UpdateItemsInventory();
        UpdateQuestList();
    }

    private void MainMenuCGOn()
    {
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        mainMenu.GetComponent<CanvasGroup>().interactable = true;
        mainMenu.GetComponent<CanvasGroup>().alpha = 1;
        fadeResume.blocksRaycasts = true;
        fadeResume.alpha = 1;
        fadeResume.interactable = true;
    }

    private void ControllersFadeOut(float fadeTime)
    {
        StartCoroutine(DisableJoystickDelay());
        StartCoroutine(FadeToAlpha(joystick.GetComponent<CanvasGroup>(), 0f, fadeTime));
        StartCoroutine(FadeToAlpha(quickBar.GetComponent<CanvasGroup>(), 0f, fadeTime));
        StartCoroutine(FadeToAlpha(actionButton.GetComponent<CanvasGroup>(), 0f, fadeTime));
    }

    private void ControllersFadeIn(float fadeTime)
    {
        joystick.EnableJoystick();
        actionButton.EnableButton();
        StartCoroutine(FadeToAlpha(joystick.GetComponent<CanvasGroup>(), 1f, fadeTime));
        StartCoroutine(FadeToAlpha(quickBar.GetComponent<CanvasGroup>(), 1f, fadeTime));
        StartCoroutine(FadeToAlpha(actionButton.GetComponent<CanvasGroup>(), 1f, fadeTime));
    }

    private void ControllersOn()
    {
        joystick.EnableJoystick();
        actionButton.EnableButton();
        quickBar.EnableQuickbar();
        joystick.GetComponent<CanvasGroup>().alpha = 1;
        joystick.GetComponent<CanvasGroup>().interactable = true;
        joystick.GetComponent<CanvasGroup>().blocksRaycasts = true;
        actionButton.GetComponent<CanvasGroup>().alpha = 1;
        actionButton.GetComponent<CanvasGroup>().interactable = true;
        actionButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
        quickBar.GetComponent<CanvasGroup>().alpha = 1;
        quickBar.GetComponent<CanvasGroup>().interactable = true;
        quickBar.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void PanelController()
    {
        if (isInventoryOn == true)
        {
            Debug.Log($"Inventory is open and 'back' has been called");

            ButtonHandler.instance.SetAllButtonsInteractable();
            ShopManager.instance.ShopItemInfoReset();
            ItemInfoReset();

            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
            inventoryPanel.GetComponent<CanvasGroup>().interactable = false;
            inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

            isInventoryOn = false;
            GameManager.instance.isInventoryOn = false;
        }
        else if (GameManager.instance.isShopUIOn == true)
        {
            Debug.Log($"Shop is open and 'back' has been called");

            ButtonHandler.instance.SetAllButtonsInteractable();
            ShopManager.instance.ShopItemInfoReset();
            ItemInfoReset();

            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            ShopManager.instance.shopUIPanel.GetComponent<CanvasGroup>().interactable = false;
            ShopManager.instance.shopUIPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ShopManager.instance.shopUIPanel.GetComponent<CanvasGroup>().alpha = 0;

            GameManager.instance.isShopUIOn = false;
        }

        else if (isOverviewOn || isStatsOn || isWeaponryOn)
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log($"Team UI back triggered");

        }

        else if (isQuestsOn || isWeeklyOn || isAchieveOn)
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log($"Quest UI back triggered");
        }

        else if (menuPanels[2].alpha == 1) // keys
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            menuPanels[2].alpha = 0;
            menuPanels[2].interactable = false;
            menuPanels[2].blocksRaycasts = false;
        }

        else if (menuPanels[3].alpha == 1) // magic
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            menuPanels[3].alpha = 0;
            menuPanels[3].interactable = false;
            menuPanels[3].blocksRaycasts = false;
        }


    }

    #endregion

    #region CO-ROUTINES

    private IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(1.2f);
        clockFrame.GetComponent<Image>().raycastTarget = true;
        clockFrame.GetComponent<Button>().interactable = true;
    }
    private IEnumerator PanelCancelCoR()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
        characterWeaponryPanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);
    }
    private IEnumerator DisableJoystickDelay()
    {
        yield return new WaitForSeconds(0.7f);
        joystick.DisableJoystick();
        actionButton.DisableButton();
    }
    private IEnumerator EnableJoystickDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ControllersOn();
    }
    private void DoPunch(GameObject gameObject, Vector3 scale, float time)
    {
        gameObject.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.4f, 0, 1);
    }
    private static IEnumerator FadeToAlpha(CanvasGroup canvasGroup, float targetAlpha, float fadeTime)
    {
        float startingAlpha = canvasGroup.alpha;

        for (float i = 0; i < 1; i += Time.deltaTime / fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startingAlpha, targetAlpha, i);

            yield return null;
        }
        canvasGroup.alpha = targetAlpha;
    }
    private IEnumerator DelayPanelReturn() // also USE item tweens
    {

        Debug.Log("InventoryLeft panel animations engaged");

        if (activeItem.affectType == ItemsManager.AffectType.HP)
        {
            playerStats[0].characterHP = Thulgran.ThulgranHP;

            if (panelStuff != 0)
            {
                hpEquipToString[panelStuff].text = playerStats[panelStuff].characterHP.ToString();
            }
            else if (panelStuff == 0) // Thulgran is controlled by Thulgran.cs
            {
                hpEquipToString[panelStuff].text = Thulgran.ThulgranHP.ToString();
            }
            var sequence = DOTween.Sequence()
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(hpEquipSlider[panelStuff].DOValue(playerStats[panelStuff].characterHP + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);


            yield return new WaitForSecondsRealtime(1.8f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);

            Debug.Log("Slider HP fill scale enacted");
        }

        else if (activeItem.affectType == ItemsManager.AffectType.Mana)
        {
            playerStats[0].characterMana = Thulgran.ThulgranMana;

            if (panelStuff != 0)
            {
                manaEquipToString[panelStuff].text = playerStats[panelStuff].characterMana.ToString();
            }
            else if (panelStuff == 0)
            {
                manaEquipToString[panelStuff].text = Thulgran.ThulgranMana.ToString();
            }
            var sequence = DOTween.Sequence()
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(manaEquipSlider[panelStuff].DOValue(playerStats[panelStuff].characterMana + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);

            yield return new WaitForSecondsRealtime(1.8f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);

            Debug.Log("Slider Mana fill expand and slide");
        }
        else if (activeItem.itemType == ItemsManager.ItemType.Armour || activeItem.itemType == ItemsManager.ItemType.Weapon || activeItem.itemType == ItemsManager.ItemType.Helmet ||
                        activeItem.itemType == ItemsManager.ItemType.Shield)
        {

            if (activeItem.itemType == ItemsManager.ItemType.Armour)
            {
                InventoryStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }
            else if (activeItem.itemType == ItemsManager.ItemType.Weapon)
            {
                InventoryStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }

            else if (activeItem.itemType == ItemsManager.ItemType.Helmet)
            {
                InventoryStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedHelmetImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedHelmetImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }

            else if (activeItem.itemType == ItemsManager.ItemType.Shield)
            {
                InventoryStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedShieldImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedShieldImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }


            yield return new WaitForSecondsRealtime(1.3f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
            characterWeaponryPanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);

        }

        yield return new WaitForSecondsRealtime(0.3f);
        mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);
        SetAllButtonsInteractable();
        isInventorySlidePanelOn = false;

    }

    #endregion

    #region METHODS
    public void HomeScreenStats()
    {
        playerStats = GameManager.instance.GetPlayerStats().OrderBy(m => m.transform.position.z).ToArray();

        levelMain.text = playerStats[0].characterLevel.ToString();
        xpMain.text = playerStats[0].characterXP.ToString() + "/" + playerStats[0].xpLevelUp[playerStats[0].characterLevel];
        xpMainS.value = playerStats[0].characterXP;
        xpMainS.maxValue = playerStats[0].xpLevelUp[playerStats[0].characterLevel];

    }

    public void InventoryStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {


            if (playerStats[i].isTeamMember == true)
            {
                if (i != 0)
                {
                    hpEquipToString[i].text = playerStats[i].characterHP.ToString();
                    manaEquipToString[i].text = playerStats[i].characterMana.ToString();
                    hpEquipSlider[i].value = playerStats[i].characterHP;
                    manaEquipSlider[i].value = playerStats[i].characterMana;
                }

                else if (i == 0)
                {
                    hpEquipToString[i].text = Thulgran.ThulgranHP.ToString(); // characterChoice Panel
                    manaEquipToString[i].text = Thulgran.ThulgranMana.ToString();
                    hpEquipSlider[i].value = Thulgran.ThulgranHP;
                    manaEquipSlider[i].value = Thulgran.ThulgranMana;
                }


                // GIVE potions

                //stat text values
                characterEquip[i].SetActive(true);
                defenceEquipToString[i].text = playerStats[i].characterBaseDefence.ToString();
                //stat sliders
                defenceEquipSlider[i].value = playerStats[i].characterBaseDefence;
                characterMugEquip[i].sprite = playerStats[i].characterMug;

                // Inventory weaponry

                characterWeaponry[i].SetActive(true);
                characterMugWeaponry[i].sprite = playerStats[i].characterMug;

                equippedWeaponName[i].text = playerStats[i].characterWeaponName;
                equippedWeaponImage[i].sprite = playerStats[i].characterWeaponImage;
                equippedWeaponBonus[i].text = "+" + playerStats[i].characterWeapon.itemAttack.ToString();

                equippedArmourName[i].text = playerStats[i].characterArmourName;
                equippedArmourImage[i].sprite = playerStats[i].characterArmourImage;
                equippedArmourBonus[i].text = "+" + playerStats[i].characterArmour.itemDefence.ToString();

                equippedHelmetName[i].text = playerStats[i].characterHelmetName;
                equippedHelmetImage[i].sprite = playerStats[i].characterHelmetImage;
                equippedHelmetBonus[i].text = "+" + playerStats[i].characterHelmet.itemDefence.ToString();

                equippedShieldName[i].text = playerStats[i].characterShieldName;
                equippedShieldImage[i].sprite = playerStats[i].characterShieldImage;
                equippedShieldBonus[i].text = "+" + playerStats[i].characterShield.itemDefence.ToString();


                // this assigns a basic weapon and armour if none are set so that UI doesn't return blanks

                if (playerStats[i].characterWeaponName == "")
                {
                    equippedWeaponName[i].text = "Basic Axe";
                    equippedWeaponImage[i].sprite = basicAxe;
                    equippedWeaponBonus[i].text = "+5";
                }

                if (playerStats[i].characterArmourName == "")
                {
                    equippedArmourName[i].text = "Basic Armour";
                    equippedArmourImage[i].sprite = basicArmour;
                    equippedArmourBonus[i].text = "+5";
                }

                if (playerStats[i].characterHelmetName == "")
                {
                    equippedHelmetName[i].text = "Basic Helmet";
                    equippedHelmetImage[i].sprite = basicHelmet;
                    equippedHelmetBonus[i].text = "+5";
                }

                if (playerStats[i].characterShieldName == "")
                {
                    equippedShieldName[i].text = "Basic Shield";
                    equippedShieldImage[i].sprite = basicShield;
                    equippedShieldBonus[i].text = "+5";
                }

            }
        }
    }

    public void UpdateStats() // 
    {

        TeamMembersCount(); // nofify

        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].isAvailable == true) // on 'add to party screen'
            {
                characterParty[i].SetActive(true);

                if (playerStats[i].isTeamMember == true)
                {
                    // on screens where isTeamMember is necessary

                    characterCards[i].SetActive(true);

                    if (i != 0) // 0 is Thulgran
                    {
                        characterName[i].text = playerStats[i].playerName;
                        description[i].text = playerStats[i].playerDesc;
                        health[i].text = playerStats[i].characterHP.ToString();
                        characterImage[i].sprite = playerStats[i].characterImage;
                        level[i].text = playerStats[i].characterLevel.ToString();
                        xp[i].text = playerStats[i].characterXP.ToString();
                        mana[i].text = playerStats[i].characterMana.ToString();
                        attack[i].text = playerStats[i].characterBaseAttack.ToString();
                        defence[i].text = playerStats[i].characterBaseDefence.ToString();
                        intelligence[i].text = playerStats[i].characterIntelligence.ToString();
                        perception[i].text = playerStats[i].characterPerception.ToString();
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        xpS[i].value = playerStats[i].characterXP;
                        manaS[i].value = playerStats[i].characterMana;
                        healthS[i].value = playerStats[i].characterHP;
                        attackS[i].value = playerStats[i].characterBaseAttack;
                        defenceS[i].value = playerStats[i].characterBaseDefence;
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        perceptionS[i].value = playerStats[i].characterPerception;
                    }

                    if (i == 0) // Thulgran
                    {
                        health[i].text = Thulgran.ThulgranHP.ToString();
                        mana[i].text = Thulgran.ThulgranMana.ToString();
                        healthS[i].value = Thulgran.ThulgranHP;
                        manaS[i].value = Thulgran.ThulgranMana;
                        characterName[i].text = playerStats[i].playerName;
                        description[i].text = playerStats[i].playerDesc;
                        characterImage[i].sprite = playerStats[i].characterImage;
                        level[i].text = playerStats[i].characterLevel.ToString();
                        xp[i].text = playerStats[i].characterXP.ToString();
                        attack[i].text = playerStats[i].characterBaseAttack.ToString();
                        defence[i].text = playerStats[i].characterBaseDefence.ToString();
                        intelligence[i].text = playerStats[i].characterIntelligence.ToString();
                        perception[i].text = playerStats[i].characterPerception.ToString();
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        xpS[i].value = playerStats[i].characterXP;
                        attackS[i].value = playerStats[i].characterBaseAttack;
                        defenceS[i].value = playerStats[i].characterBaseDefence;
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        perceptionS[i].value = playerStats[i].characterPerception;
                    }


                    // Some team equipped stuff

                    teamCharacterWeaponry[i].SetActive(true);

                    teamCharacterMugWeaponry[i].sprite = playerStats[i].characterMug;

                    teamCharacterName[i].text = playerStats[i].playerName;

                    teamEquippedArmourImage[i].sprite = playerStats[i].characterArmourImage;
                    teamEquippedHelmetImage[i].sprite = playerStats[i].characterHelmetImage;
                    teamEquippedShieldImage[i].sprite = playerStats[i].characterShieldImage;
                    teamEquippedWeaponImage[i].sprite = playerStats[i].characterWeaponImage;

                    teamInventoryDefenceTotal[i].text = $"<color=#CFCFCF>{playerStats[i].characterBaseDefence}</color> +{(playerStats[i].characterDefenceTotal - playerStats[i].characterBaseDefence).ToString()}";
                    teamInventoryAttackTotal[i].text = $"<color=#CFCFCF>{playerStats[i].characterBaseAttack}</color> +{(playerStats[i].characterAttackTotal - playerStats[i].characterBaseAttack).ToString()}";

                    teamItemArmourBonus[i].text = "+" + playerStats[i].characterArmour.itemDefence.ToString();
                    teamItemHelmetBonus[i].text = "+" + playerStats[i].characterHelmet.itemDefence.ToString();
                    teamItemShieldBonus[i].text = "+" + playerStats[i].characterShield.itemDefence.ToString();
                    teamItemWeaponBonus[i].text = "+" + playerStats[i].characterWeapon.itemAttack.ToString();

                }

                // these are the references for the Team Overview (add to party)

                characterNameP[i].text = playerStats[i].playerName + "\n<size=26><color=#BEB5B6>" + playerStats[i].playerMoniker + "</color></size>";
                levelP[i].text = playerStats[i].characterLevel.ToString();
                characterMug[i].sprite = playerStats[i].characterMug;
            }
        }
    }

    public void AddCharacterToParty(int character)
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (i == character)
            {
                playerStats[character].isTeamMember = true;
                playerStats[character].isNew = false;
                teamNofifyCount--;
                addToPartyButton[character].gameObject.SetActive(false);
                isNewNotification[character].SetActive(false);
                retireFromPartyButton[character].gameObject.SetActive(true);
                InventoryStats();
                Debug.Log(playerStats[character].playerName + " added to party");
            }
        }
        UpdateStats();
    }

    public void AndroidControls()
    {
        controlSwitch = !controlSwitch;
    }

    public void CallToSellItem()
    {
        isInventorySlidePanelOn = true; // not sure why this is here
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
        textUseEquipTake.text = "Select";
    }

    public void CallToUseItem(int selectedCharacter)
    {
        Debug.Log("Use item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " + "Item: " + activeItem.itemName);

        panelStuff = selectedCharacter;

        if (activeItem.affectType == ItemsManager.AffectType.HP)
        {
            if (selectedCharacter != 0)
            {
                if (playerStats[selectedCharacter].characterHP == playerStats[selectedCharacter].maxHP)
                {
                    NotificationFader.instance.CallFadeInOut($"{playerStats[selectedCharacter].playerName}'s HP is at <color=#C60B0B>max!</color>\n Try someone else?", Sprites.instance.hpSprite, 1.5f, 1400,30);
                    Debug.Log($"Yo");
                }

                else
                {
                    cancelButton.SetActive(false);
                    useButton.GetComponent<Button>().interactable = false;
                    FadeOutText(1);
                    useButton.GetComponent<Image>().sprite = buttonGreen;
                    SetAllButtonsUninteractable();
                    activeItem.UseItem(selectedCharacter);
                    Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);
                    UpdateItemsInventory();
                    OnPlayerButton();
                    ItemInfoReset();

                    Debug.Log(activeItem.amountOfEffect + " HP given to " + playerStats[selectedCharacter].playerName);
                }
            }

            else if (selectedCharacter == 0)
            {
                if (Thulgran.ThulgranHP == Thulgran.maxThulgranHP)
                {
                    NotificationFader.instance.CallFadeInOut($"{playerStats[selectedCharacter].playerName}'s HP is at <color=#C60B0B>max!</color>\n Try someone else?", Sprites.instance.hpSprite, 1.5f, 1400, 30);
                    Debug.Log($"Yo");
                }

                else if (Thulgran.ThulgranHP < Thulgran.maxThulgranHP)
                {
                    cancelButton.SetActive(false);
                    useButton.GetComponent<Button>().interactable = false;
                    FadeOutText(1);
                    useButton.GetComponent<Image>().sprite = buttonGreen;
                    SetAllButtonsUninteractable();
                    activeItem.UseItem(selectedCharacter);
                    Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);
                    UpdateItemsInventory();
                    OnPlayerButton();
                    ItemInfoReset();
                    Debug.Log($"CallToUseItem completed | {activeItem.amountOfEffect} HP should have been given to " + playerStats[selectedCharacter].playerName);
                }
            }
        }

        else if (activeItem.affectType == ItemsManager.AffectType.Mana)
        {

            if (selectedCharacter != 0)
            {
                if (playerStats[selectedCharacter].characterMana == playerStats[selectedCharacter].maxMana)
                {
                    NotificationFader.instance.CallFadeInOut($"{playerStats[selectedCharacter].playerName}'s mana is at <color=#C60B0B>max!</color> \n Try someone else?", Sprites.instance.manaSprite, 1.5f, 1400, 30);
                }

                else if (playerStats[selectedCharacter].characterMana < playerStats[selectedCharacter].maxMana)
                {
                    cancelButton.SetActive(false);
                    useButton.GetComponent<Button>().interactable = false;
                    FadeOutText(1);
                    useButton.GetComponent<Image>().sprite = buttonGreen;
                    SetAllButtonsUninteractable();
                    activeItem.UseItem(selectedCharacter);
                    Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);
                    UpdateItemsInventory();
                    OnPlayerButton();
                    ItemInfoReset();
                    Debug.Log(activeItem.amountOfEffect + " mana given to " + playerStats[selectedCharacter].playerName);
                }

            }

            else if (selectedCharacter == 0)
            {
                if (Thulgran.ThulgranMana == Thulgran.maxThulgranMana)
                {
                    NotificationFader.instance.CallFadeInOut($"{playerStats[selectedCharacter].playerName}'s mana is at <color=#C60B0B>max!</color>\n Try someone else?", Sprites.instance.manaSprite, 1.5f, 1400, 30);
                }

                else if (Thulgran.ThulgranMana < Thulgran.maxThulgranMana)
                {
                    cancelButton.SetActive(false);
                    useButton.GetComponent<Button>().interactable = false;
                    FadeOutText(1);
                    useButton.GetComponent<Image>().sprite = buttonGreen;
                    SetAllButtonsUninteractable();
                    activeItem.UseItem(selectedCharacter);
                    Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);
                    UpdateItemsInventory();
                    OnPlayerButton();
                    ItemInfoReset();

                    Debug.Log(activeItem.amountOfEffect + " mana given to " + playerStats[selectedCharacter].playerName);
                }
            }
        }

        else if (activeItem.itemType == ItemsManager.ItemType.Armour || activeItem.itemType == ItemsManager.ItemType.Weapon || activeItem.itemType == ItemsManager.ItemType.Helmet || activeItem.itemType == ItemsManager.ItemType.Shield)
        {
            cancelButton.SetActive(false);
            useButton.GetComponent<Button>().interactable = false;
            FadeOutText(1);
            useButton.GetComponent<Image>().sprite = buttonGreen;
            SetAllButtonsUninteractable();
            activeItem.UseItem(selectedCharacter);
            Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);
            UpdateItemsInventory();
            OnPlayerButton();
            ItemInfoReset();
        }
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }

    public void FadeInText(float duration)
    {
        Fade(1f, duration, () =>
        {
            chooseText.interactable = true;
            chooseText.blocksRaycasts = true;
        });
    }

    public void FadeOutText(float duration)
    {
        Fade(0f, duration, () =>
        {
            chooseText.interactable = false;
            chooseText.blocksRaycasts = false;
        });
    }

    public void MainMenuPanel(int panel)  // switch a panel on
    {
        //    mainMenu 0
        //    shop 1
        //    keys 2
        //    magic 3
        //    overview 4
        //    stats 5
        //    weaponry 6
        //    team UI buttons 7
        //    team fadebackground 8
        //    quests 9
        //    weekly 10
        //    achieve 11
        //    quest UI Buttons 12
        //    quest fadebackground 13
        //    inventory 14


        menuPanels[panel].blocksRaycasts = true;
        menuPanels[panel].interactable = true;
        menuPanels[panel].alpha = 1;

        mainMenu.GetComponent<CanvasGroup>().interactable = false;
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void ItemInfoReset()
    {
        itemName.text = "Select an item";
        itemDescription.text = "";
        itemImage.sprite = masking;
        instance.itemValue.text = "";
        effectText.text = "0";
        itemDamage.text = "";
        itemDamageBox.SetActive(false);
        itemArmourBox.SetActive(false);
        itemPotionBox.SetActive(false);
        itemFoodBox.SetActive(false);
    }

    public void MenuPanelsOff(string call)
    {
        if (call == "home")
        {
            for (int i = 0; i < menuPanels.Length; i++)
            {
                menuPanels[i].alpha = 0;
                menuPanels[i].interactable = false;
                menuPanels[i].blocksRaycasts = false;
            }
        }

    }

    public void OnCancelButton()
    {
        StartCoroutine(PanelCancelCoR());
    }

    public void OnPlayerButton() // CALLS PANEL TWEEN
    {

        StartCoroutine(DelayPanelReturn());
    }

    public void OnUseButton()
    {
        mainEquipInfoPanel.DOAnchorPos(new Vector2(-750, 0), 1f);

        if (activeItem.itemType == ItemsManager.ItemType.Potion || activeItem.itemType == ItemsManager.ItemType.Food)
        {
            characterChoicePanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }

        else if (activeItem.itemType == ItemsManager.ItemType.Armour || activeItem.itemType == ItemsManager.ItemType.Weapon || activeItem.itemType == ItemsManager.ItemType.Helmet || activeItem.itemType == ItemsManager.ItemType.Shield)
        {
            characterWeaponryPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }
        isInventorySlidePanelOn = true;


    }

    public void QuitGame()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }

    public void RemoveCharacterFromParty(int character)
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (i == character)
            {
                playerStats[character].isTeamMember = false;

                characterCards[character].SetActive(false);
                teamCharacterWeaponry[character].SetActive(false);
                characterEquip[character].SetActive(false);
                characterWeaponry[character].SetActive(false);

                addToPartyButton[character].gameObject.SetActive(true);
                retireFromPartyButton[character].gameObject.SetActive(false);
                InventoryStats();

                Debug.Log(playerStats[character].playerName + " removed from party");
            }
        }
        UpdateStats();
    }

    public void SetAllButtonsInteractable()
    {
        foreach (Button button in potionPanelButtons)
        {
            button.interactable = true;
        }

        foreach (Button button in weaponPanelButtons)
        {
            button.interactable = true;
        }
    }

    public void SetAllButtonsUninteractable()
    {
        foreach (Button button in potionPanelButtons)
        {
            button.interactable = false;
        }

        foreach (Button button in weaponPanelButtons)
        {
            button.interactable = false;
        }
    }

    public void SetUpCharacterChoice()
    {
        if (activeItem)
        {
            for (int i = 0; i < playerStats.Length; i++)
            {
                PlayerStats activePlayer = GameManager.instance.GetPlayerStats()[i];
                playerChoice[i].text = activePlayer.playerName;

                bool activePlayerAvailable = activePlayer.gameObject.activeInHierarchy;
                playerChoice[i].transform.parent.gameObject.SetActive(activePlayerAvailable);
            }
        }
    }

    public void SortByItemType(string boolName)
    {

        if (isInventorySlidePanelOn == true)
        {
            OnCancelButton();
            isInventorySlidePanelOn = false;
            cancelButton.SetActive(false);
            textUseEquipTake.text = "Select";
            useButton.GetComponent<Button>().interactable = false;
            FadeOutText(1f);
        }

        else
        {

        }

        weaponBool = armourBool = itemBool = potionBool = spellBool = false;


        if (boolName == "weapon")
        {
            weaponBool = true;
            inventTabsAllFocus.SetActive(false);
            inventTabsWeaponsFocus.SetActive(true);
            inventTabsArmourFocus.SetActive(false);
            inventTabsItemsFocus.SetActive(false);
            inventTabsPotionsFocus.SetActive(false);

        }
        else if (boolName == "armour")
        {
            armourBool = true;
            inventTabsAllFocus.SetActive(false);
            inventTabsWeaponsFocus.SetActive(false);
            inventTabsArmourFocus.SetActive(true);
            inventTabsItemsFocus.SetActive(false);
            inventTabsPotionsFocus.SetActive(false);

        }
        else if (boolName == "item")
        {
            itemBool = true;
            inventTabsAllFocus.SetActive(false);
            inventTabsWeaponsFocus.SetActive(false);
            inventTabsArmourFocus.SetActive(false);
            inventTabsItemsFocus.SetActive(true);
            inventTabsPotionsFocus.SetActive(false);
        }
        else if (boolName == "potion")
        {
            potionBool = true;
            inventTabsAllFocus.SetActive(false);
            inventTabsWeaponsFocus.SetActive(false);
            inventTabsArmourFocus.SetActive(false);
            inventTabsItemsFocus.SetActive(false);
            inventTabsPotionsFocus.SetActive(true);
        }
        else if (boolName == "spell")
        {
            spellBool = true;

        }
        if (boolName != "all")
        {
            inventTabsAllText.GetComponent<TextMeshProUGUI>().color = new Color32(82, 77, 80, 255);
        }

        if (boolName == "all")
        {
            inventTabsAllText.GetComponent<TextMeshProUGUI>().color = new Color32(236, 216, 150, 255);
            inventTabsAllFocus.SetActive(true);
            inventTabsWeaponsFocus.SetActive(false);
            inventTabsArmourFocus.SetActive(false);
            inventTabsItemsFocus.SetActive(false);
            inventTabsPotionsFocus.SetActive(false);
        }
        UpdateItemsInventory();
        Debug.Log("Sort by item initiated: " + boolName);
    }

    public void TeamMembersCount()
    {
        teamNofifyCount = 0;

        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {


            if (playerStats[i].isAvailable == true && playerStats[i].isNew == true) teamNofifyCount++;

            if (teamNofifyCount > 0)
            {
                teamNofify.alpha = 1;
                teamMemberCount.text = teamNofifyCount.ToString();
            }
            else if (teamNofifyCount == 0)
            {
                teamNofify.alpha = 0;
            }

        }
    }

    public void TeamUISettings(string teamPanelTrigger)
    {
        if (teamPanelTrigger == "overview")
        {

            isOverviewOn = true;
            isStatsOn = false;
            isWeaponryOn = false;


            WhichPanelIsOn();

            focusTitle.text = "Character Party";

            // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindGameObjectWithTag("overviewTab").GetComponent<Button>().Select();
            overviewText.color = new Color(0.964f, 0.882f, 0.611f, 1);
            overviewSprite.sprite = overviewSpriteOn;


            focusOverview.SetActive(true);

            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().interactable = false;
            statsText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            statsSprite.sprite = statsSpriteOff;


            focusStats.SetActive(false);

            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().interactable = false;
            weaponrySprite.sprite = weaponrySpriteOff;
            weaponryText.color = new Color(0.745f, 0.709f, 0.713f, 1);

            focusWeaponry.SetActive(false);

        }
        else if (teamPanelTrigger == "stats")
        {
            isOverviewOn = false;
            isStatsOn = true;
            isWeaponryOn = false;

            focusTitle.text = "Stats & Skills";


            WhichPanelIsOn();
            teamTabMenu.SetActive(true);

            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().interactable = false;
            overviewText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            overviewSprite.sprite = overviewSpriteOff;

            focusOverview.SetActive(false);

            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().interactable = true;
            statsText.color = new Color(0.964f, 0.882f, 0.611f, 1);
            statsSprite.sprite = statsSpriteOn;

            focusStats.SetActive(true);

            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().interactable = false;
            weaponryText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            weaponrySprite.sprite = weaponrySpriteOff;

            focusWeaponry.SetActive(false);
        }
        else if (teamPanelTrigger == "weaponry")
        {

            isOverviewOn = false;
            isStatsOn = false;
            isWeaponryOn = true;

            focusTitle.text = "Weaponry";

            WhichPanelIsOn();

            teamTabMenu.SetActive(true);

            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().interactable = false;
            overviewText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            overviewSprite.sprite = overviewSpriteOff;

            focusOverview.SetActive(false);

            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().interactable = false;
            statsText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            statsSprite.sprite = statsSpriteOff;

            focusStats.SetActive(false);

            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().interactable = true;
            weaponrySprite.sprite = weaponrySpriteOn;
            weaponryText.color = new Color(0.964f, 0.882f, 0.611f, 1);

            focusWeaponry.SetActive(true);
        }
        else if (teamPanelTrigger == "exit")
        {
            isOverviewOn = false;
            isStatsOn = false;
            isWeaponryOn = false;


            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().interactable = false;


            focusOverview.SetActive(false);


            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().interactable = false;


            focusStats.SetActive(false);

            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().interactable = false;


            focusWeaponry.SetActive(false);

            teamTabMenu.GetComponent<CanvasGroup>().interactable = false;
            teamTabMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
            teamTabMenu.GetComponent<CanvasGroup>().alpha = 0;


            WhichPanelIsOn();

            Debug.Log($"Exiting. Panel status - Overview: { GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha} | Stats: { GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha} | Weaponry: {GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha} | Tabs: {teamTabMenu.GetComponent<CanvasGroup>().alpha}");
        }
        UpdateStats();
    }

    public void TeamWeaponryPopup(int selectedCharacter, string itemType)
    {
        if (itemType == "weapon")
        {
            teamPopWeaponryImage.sprite = playerStats[selectedCharacter].characterWeaponImage;
            teamPopWeaponryName.text = playerStats[selectedCharacter].characterWeaponName;
            teamPopWeaponryDescription.text = playerStats[selectedCharacter].characterWeaponDescription;
            teamPopWeaponryBonus.text = playerStats[selectedCharacter].characterWeapon.itemAttack.ToString();
            teamPopWeaponryBonusText.text = "Weapon Power:";
        }
        else if (itemType == "armour")
        {
            teamPopWeaponryImage.sprite = playerStats[selectedCharacter].characterArmourImage;
            teamPopWeaponryName.text = playerStats[selectedCharacter].characterArmourName;
            teamPopWeaponryDescription.text = playerStats[selectedCharacter].characterArmourDescription;
            teamPopWeaponryBonus.text = playerStats[selectedCharacter].characterArmour.itemDefence.ToString();
            teamPopWeaponryBonusText.text = "Armour Defence:";
        }


        else if (itemType == "helmet")
        {
            teamPopWeaponryImage.sprite = playerStats[selectedCharacter].characterHelmetImage;
            teamPopWeaponryName.text = playerStats[selectedCharacter].characterHelmetName;
            teamPopWeaponryDescription.text = playerStats[selectedCharacter].characterHelmetDescription;
            teamPopWeaponryBonus.text = playerStats[selectedCharacter].characterHelmet.itemDefence.ToString();
            teamPopWeaponryBonusText.text = "Helmet Defence:";
        }

        else if (itemType == "shield")
        {
            teamPopWeaponryImage.sprite = playerStats[selectedCharacter].characterShieldImage;
            teamPopWeaponryName.text = playerStats[selectedCharacter].characterShieldName;
            teamPopWeaponryDescription.text = playerStats[selectedCharacter].characterShieldDescription;
            teamPopWeaponryBonus.text = playerStats[selectedCharacter].characterShield.itemDefence.ToString();
            teamPopWeaponryBonusText.text = "Shield Defence:";
        }
    }

    public void turnInventoryOn()
    {
        isInventoryOn = !isInventoryOn;
        GameManager.instance.isInventoryOn = !GameManager.instance.isInventoryOn;
        Debug.Log("IsInventoryOn status: " + isInventoryOn);
    }

    public void UpdateItemsInventory()
    {
        currentNewItems = 0;

        foodItems = 0; // debug stuff
        potionItems = 0;
        weaponItems = 0;
        itemItems = 0;
        armourItems = 0;

        foreach (Transform _itemSlot in itemBoxParent)
        {
            Destroy(_itemSlot.gameObject);
        }


        foreach (ItemsManager item in Inventory.instance.GetItemsList())
        {

            if (item.shopItem == false)
            {
                RectTransform itemSlot = Instantiate(itemBox, itemBoxParent).GetComponent<RectTransform>();

                // show item image

                Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
                itemImage.sprite = item.itemsImage;

                TextMeshProUGUI itemsAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
                if (item.amount > 1)
                {
                    itemsAmountText.text = item.amount.ToString();
                }
                else
                {
                    itemsAmountText.text = "";
                }

                itemSlot.GetComponent<ItemButton>().itemOnButton = item; // this is a really important method

                switch (item.itemType)
                {
                    case ItemsManager.ItemType.Food:
                        foodItems++;
                        break;
                    case ItemsManager.ItemType.Potion:
                        potionItems++;
                        break;
                    case ItemsManager.ItemType.Item:
                        itemItems++;
                        break;
                    case ItemsManager.ItemType.Weapon:
                        weaponItems++;
                        break;
                    case ItemsManager.ItemType.Armour:
                        armourItems++;
                        break;
                }

                // new items - needs to run here to count how many new items

                if (item.isNewItem == true)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    currentNewItems++;
                }

                // Stuff to activate ONLY when inside inventory

                if (isInventoryOn == true)
                {

                    // Removing focus from previously selected items 

                    if (item.itemSelected == false)
                    {
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = false;
                        GameManager.instance.isItemSelected = false;

                        if (item.isNewItem == true)
                        {
                            itemSlot.Find("New Item").GetComponent<Image>().enabled = true;
                        }
                        // new items - set red marker; count item

                        if (item.isNewItem == false)
                        {
                            itemSlot.Find("New Item").GetComponent<Image>().enabled = false;
                        }
                    }

                    // ITEM SORTING FOR SELECTED ITEM

                    else if (item.itemSelected == true) // if item has been selected
                    {
                        item.itemSelected = false;
                        itemSlot.GetComponent<ButtonBounce>().AnimateItemSelection(); // button bounce
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = true;

                        // ITEM SELECTED animation

                        //itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

                        // NEW ITEM tagging

                        item.isNewItem = false; // switch off new item tag after selection
                        itemSlot.Find("New Item").GetComponent<Image>().enabled = false;

                        // SORTING BY ITEM TYPE

                        effectBox.GetComponent<CanvasGroup>().alpha = 0; // necessary reset


                        //  SORT BY POTIONS

                        if (item.affectType == ItemsManager.AffectType.HP)
                        {
                            Debug.Log($"Type: {item.itemType} | Name: {item.itemName} | Effect: {item.amountOfEffect}");

                            textUseEquipTake.text = "Give";


                            // EFFECT MODIFIER (on item info)

                            if (item.itemName == "Mana Potion")
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 1;
                                effectText.text = "+" + item.amountOfEffect.ToString();
                            }

                            else if (item.itemName == "Red Healing Potion" || item.itemName == "Green Healing Potion" || item.itemName == "Red Healing Potion Large")
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 1;
                                effectText.text = "+" + item.amountOfEffect.ToString();
                            }

                            else
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            }
                        }

                        if (item.affectType == ItemsManager.AffectType.Speed)
                        {
                            Debug.Log($"Type: {item.itemType} | Name: {item.itemName} | Effect: {item.amountOfEffect}");
                            effectBox.GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "x" + item.amountOfEffect.ToString();
                        }

                        // EFFECT - FOOD

                        if (item.itemType == ItemsManager.ItemType.Food)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "+" + item.amountOfEffect.ToString();
                            Debug.Log("Food: " + item.amountOfEffect + " | " + "Alpha status: " + GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha);

                        }

                        // SORT BY ARMOUR

                        if (item.itemType == ItemsManager.ItemType.Armour || item.itemType == ItemsManager.ItemType.Helmet || item.itemType == ItemsManager.ItemType.Shield)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log($"Type: {item.itemType} | Name: {item.itemName} | Effect: { item.amountOfEffect} | Power: { item.itemAttack} | Defence: { item.itemDefence}");
                            textUseEquipTake.text = "Equip";
                        }

                        // SORT BY WEAPON

                        if (item.itemType == ItemsManager.ItemType.Weapon)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log($"Type: {item.itemType} | Name: {item.itemName} | Effect: { item.amountOfEffect} | Weapon Power: { item.itemAttack} | Armour Defence: { item.itemDefence}");
                            textUseEquipTake.text = "Equip";
                        }

                        // SORT BY NORMAL ITEMS

                        if (item.itemType == ItemsManager.ItemType.Item)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log($"Type: {item.itemType} | Name: {item.itemName} | Effect: {item.amountOfEffect} | Weapon Power: {item.itemAttack} | Armour Defence: {item.itemDefence}");
                            textUseEquipTake.text = "Use";
                        }
                    }
                }
                // sorting strategy - destroy everything else but the chosen type

                if (weaponBool == true)

                {
                    if (item.itemType == ItemsManager.ItemType.Weapon) itemSlot.gameObject.SetActive(true);
                    else if ((item.itemType == ItemsManager.ItemType.Potion) ||
                        (item.itemType == ItemsManager.ItemType.Armour) ||
                        (item.itemType == ItemsManager.ItemType.Item) ||
                        (item.itemType == ItemsManager.ItemType.Skill) ||
                        (item.itemType == ItemsManager.ItemType.Food) ||
                        (item.itemType == ItemsManager.ItemType.Helmet) ||
                        (item.itemType == ItemsManager.ItemType.Shield))
                    {
                        itemSlot.gameObject.SetActive(false);
                    }

                }
                else if (armourBool == true)

                {
                    if (item.itemType == ItemsManager.ItemType.Armour) itemSlot.gameObject.SetActive(true);
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
                        (item.itemType == ItemsManager.ItemType.Weapon) ||
                        (item.itemType == ItemsManager.ItemType.Item) ||
                        (item.itemType == ItemsManager.ItemType.Spell) ||
                        (item.itemType == ItemsManager.ItemType.Food))
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (itemBool == true)

                {
                    if (item.itemType == ItemsManager.ItemType.Item) itemSlot.gameObject.SetActive(true);
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
                        (item.itemType == ItemsManager.ItemType.Armour) ||
                        (item.itemType == ItemsManager.ItemType.Weapon) ||
                        (item.itemType == ItemsManager.ItemType.Spell) ||
                        (item.itemType == ItemsManager.ItemType.Helmet) ||
                        (item.itemType == ItemsManager.ItemType.Shield))
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (spellBool == true)

                {
                    if (item.itemType == ItemsManager.ItemType.Spell) itemSlot.gameObject.SetActive(true);
                    if ((item.itemType == ItemsManager.ItemType.Potion) ||
                        (item.itemType == ItemsManager.ItemType.Armour) ||
                        (item.itemType == ItemsManager.ItemType.Item) ||
                        (item.itemType == ItemsManager.ItemType.Weapon) ||
                        (item.itemType == ItemsManager.ItemType.Helmet) ||
                        (item.itemType == ItemsManager.ItemType.Shield))
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (potionBool == true)

                {
                    if (item.itemType == ItemsManager.ItemType.Potion) itemSlot.gameObject.SetActive(true);
                    if ((item.itemType == ItemsManager.ItemType.Weapon) ||
                        (item.itemType == ItemsManager.ItemType.Armour) ||
                        (item.itemType == ItemsManager.ItemType.Item) ||
                        (item.itemType == ItemsManager.ItemType.Spell) ||
                        (item.itemType == ItemsManager.ItemType.Food) ||
                        (item.itemType == ItemsManager.ItemType.Helmet) ||
                        (item.itemType == ItemsManager.ItemType.Shield))
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }

                // new items - nofify on Main Menu. Items picked up are all set to 'new'. This code doesn't have to run until inventory has been built (above)

                if (currentNewItems == 0)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
                }

                else if (currentNewItems > 0)
                {
                    GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                    newItemsText.text = currentNewItems.ToString();
                }

                GameManager.instance.currentNewItems = currentNewItems;

            }
        }
    }

    public void WhichPanelIsOn()
    {

        if (isOverviewOn == true)
        {
            whichPanelIsOn = "Overview";
            Debug.Log("Which panel is on: " + whichPanelIsOn);
        }

        else if (isStatsOn == true)
        {
            whichPanelIsOn = "Stats";
            Debug.Log("Which panel is on: " + whichPanelIsOn);
        }

        else if (isWeaponryOn == true)
        {
            whichPanelIsOn = "Weaponry";
            Debug.Log("Which panel is on: " + whichPanelIsOn);
        }
        else if (isStatsOn == false && isWeaponryOn == false && isOverviewOn == false)
        {
            whichPanelIsOn = "None";
            Debug.Log("Which panel is on: " + whichPanelIsOn);
        }

    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeText != null)
        {
            fadeText.Kill(false);
        }

        fadeText = chooseText.DOFade(endValue, duration);
    }

    public void OpenClock()
    {
        isClockPopOutVisible = !isClockPopOutVisible;
        Debug.Log($"Clock popout now visible: {isClockPopOutVisible}");
        if (isClockPopOutVisible)
        {
            clockFrame.GetComponent<Image>().raycastTarget = false;
            clockFrame.GetComponent<Button>().interactable = false;
            clockPanel.DOKill();
            StartCoroutine(ButtonDelay());
            var sequence = DOTween.Sequence()
            .Append(clockPanel.DOScale(0.7f, 0.5f))
            .Join(clockPanel.DOAnchorPosY(-220f, 1f));
            sequence.SetLoops(1, LoopType.Yoyo);
        }

        else if (!isClockPopOutVisible)
        {
            clockFrame.GetComponent<Image>().raycastTarget = false;
            clockFrame.GetComponent<Button>().interactable = false;
            clockPanel.DOKill();
            StartCoroutine(ButtonDelay());
            var seq = DOTween.Sequence()
            .Append(clockPanel.DOAnchorPosY(-20, 1f))
            .Join(clockPanel.DOScale(0f, 2f));
            seq.SetLoops(1, LoopType.Yoyo);
        }
    }

    public void QuestUISettings(string questPanelTrigger)
    {
        if (questPanelTrigger == "quests")
        {

            isQuestsOn = true;
            isWeeklyOn = false;
            isAchieveOn = false;

            questFocusTitle.text = "Quest Log - Main Quests";

            // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindGameObjectWithTag("questsTab").GetComponent<Button>().Select();
            questText.color = new Color(0.964f, 0.882f, 0.611f, 1);
            questSprite.sprite = questsSpriteOn;


            focusQuests.SetActive(true);

            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().interactable = false;
            weeklyText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            weeklySprite.sprite = weeklySpriteOff;


            focusWeekly.SetActive(false);

            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().interactable = false;
            achieveSprite.sprite = achieveSpriteOff;
            achieveText.color = new Color(0.745f, 0.709f, 0.713f, 1);

            focusAchieve.SetActive(false);

        }
        else if (questPanelTrigger == "weekly")
        {
            isQuestsOn = false;
            isWeeklyOn = true;
            isAchieveOn = false;

            questFocusTitle.text = "Quest Log - Bonus Challenges";

            // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().interactable = false;
            questText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            questSprite.sprite = questsSpriteOff;


            focusQuests.SetActive(false);

            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().interactable = true;
            weeklyText.color = new Color(0.964f, 0.882f, 0.611f, 1);
            weeklySprite.sprite = weeklySpriteOn;


            focusWeekly.SetActive(true);

            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().interactable = false;
            achieveSprite.sprite = achieveSpriteOff;
            achieveText.color = new Color(0.745f, 0.709f, 0.713f, 1);

            focusAchieve.SetActive(false);
        }
        else if (questPanelTrigger == "achieve")
        {

            isQuestsOn = false;
            isWeeklyOn = false;
            isAchieveOn = true;

            questFocusTitle.text = "Quest Log - Achievements";

            // not necessary to change alpha on overview, FadeIn(onClick) takes care of it

            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().interactable = false;
            questText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            questSprite.sprite = questsSpriteOff;


            focusQuests.SetActive(false);

            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().interactable = false;
            weeklyText.color = new Color(0.745f, 0.709f, 0.713f, 1);
            weeklySprite.sprite = weeklySpriteOff;


            focusWeekly.SetActive(false);

            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().interactable = true;
            achieveSprite.sprite = achieveSpriteOn;
            achieveText.color = new Color(0.964f, 0.882f, 0.611f, 1);

            focusAchieve.SetActive(true);
        }
        else if (questPanelTrigger == "exit")
        {
            isQuestsOn = false;
            isWeeklyOn = false;
            isAchieveOn = false;


            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().interactable = false;


            focusQuests.SetActive(false);


            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().interactable = false;


            focusWeekly.SetActive(false);

            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().interactable = false;


            focusAchieve.SetActive(false);

            questTabMenu.GetComponent<CanvasGroup>().interactable = false;
            questTabMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
            questTabMenu.GetComponent<CanvasGroup>().alpha = 0;


            //WhichPanelIsOn();

            Debug.Log($"Exiting Quest Log. Panel status - Quests: { GameObject.FindGameObjectWithTag("questsPanel").GetComponent<CanvasGroup>().alpha} | Weekly: { GameObject.FindGameObjectWithTag("weeklyPanel").GetComponent<CanvasGroup>().alpha} | Achievements: {GameObject.FindGameObjectWithTag("achievePanel").GetComponent<CanvasGroup>().alpha} | Tabs: {questTabMenu.GetComponent<CanvasGroup>().alpha}");
        }
        UpdateStats();
    }

    public void UpdateQuestList()
    {
        claimQuestReward = 0;
        float subQuestIndent = 51;
        float defaultIndent = 1351;
        int m_IndexNumber = 0;

        foreach (Transform questPanel in QuestParent)
        {
            Destroy(questPanel.gameObject);
        }

        foreach (Quest quest in QuestManager.instance.GetQuestList())
        {

            if (quest.isDone) // Completed
            {
                RectTransform questPanel = Instantiate(pf_QuestComplete, QuestParent).GetComponent<RectTransform>();

                questPanel.SetSiblingIndex(m_IndexNumber);
                m_IndexNumber++;

                if (quest.isSubQuest) questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, defaultIndent-subQuestIndent);
                else if (!quest.isSubQuest) questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, defaultIndent);

                TextMeshProUGUI questNameQC = questPanel.Find("QC Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescriptionQC = questPanel.Find("QC Description").GetComponent<TextMeshProUGUI>();
                Image questImageQC = questPanel.Find("QC Image").GetComponent<Image>();
                Image questRewardImageQC = questPanel.Find("MissionReward/QC RewardImage").GetComponent<Image>();
                GameObject questNofify = questPanel.Find("QC Nofify").gameObject;

                questNameQC.text = quest.questName;
                questDescriptionQC.text = quest.questDescription;
                questImageQC.sprite = quest.questImage;
                questRewardImageQC.sprite = quest.questReward;

                if (!quest.questRewardClaimed) questNofify.SetActive(true);
                else if (quest.questRewardClaimed) questNofify.SetActive(false);

                if (quest.questName == "null") questPanel.gameObject.SetActive(false);

                if (!quest.questRewardClaimed) claimQuestReward++;
                claimQuestText.text = claimQuestReward.ToString();
                if (claimQuestReward > 0) questsNofify.alpha = 1;

                Debug.Log($"Quest completed: {quest.questName}");
            }

            if (quest.isActive && !quest.isDone)  // In Progress

            {
                RectTransform questPanel = Instantiate(pf_QuestDefault, QuestParent).GetComponent<RectTransform>();

                questPanel.SetSiblingIndex(quest.questID);

                if (quest.isSubQuest) questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1300f);
                else if (!quest.isSubQuest) questPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1351f);

                TextMeshProUGUI questNameQD = questPanel.Find("QD Name").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questDescriptionQD = questPanel.Find("QD Description").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI questStageQD = questPanel.Find("QD Slider/QD Stage").GetComponent<TextMeshProUGUI>();
                Image questImageQD = questPanel.Find("QD Image").GetComponent<Image>();
                Image questRewardImageQD = questPanel.Find("Button_Dim/QD RewardImage").GetComponent<Image>();
                Slider questSlider = questPanel.Find("QD Slider").GetComponent<Slider>();

                questNameQD.text = quest.questName;
                questDescriptionQD.text = quest.questDescription;
                questStageQD.text = quest.completedStages.ToString() + " / " + quest.totalStages.ToString();
                questImageQD.sprite = quest.questImage;
                questRewardImageQD.sprite = quest.questReward;

                if (quest.questName == "null") questPanel.gameObject.SetActive(false);

                if (quest.isSubQuest) questSlider.gameObject.SetActive(false);
                else if (quest.isMasterQuest)questSlider.gameObject.SetActive(true);

                Debug.Log($"Quest in progress: {quest.questName}");

            }

        }
    }


    #endregion
}

