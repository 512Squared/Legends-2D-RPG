using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;


public partial class MenuManager : MonoBehaviour, INotifyPropertyChanged
{
    public static MenuManager Instance;

    #region FIELDS

    private int panelStuff;
    private string whichPanelIsOn = "";
    private int teamNofifyCount;
    private Tween fadeText;
    private int foodItems, weaponItems, potionItems, itemItems, armourItems;

    #endregion

    #region PROPERTIES

    //comment
    public event PropertyChangedEventHandler PropertyChanged;
    private bool _isExpanded = true;

    [FoldoutGroup("UI Bools", false)]
    [ShowInInspector]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isExpanded
    {
        get => _isExpanded;

        set
        {
            _isExpanded = value;
            NotifyPropertyChanged();
        }
    }

    private bool _animate = false;

    [FoldoutGroup("UI Bools", false)]
    [ShowInInspector]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool animate
    {
        get => _animate;

        set
        {
            _animate = value;
            NotifyPropertyChanged();
        }
    }

    private bool _toggleMasterSub = false;

    [FoldoutGroup("UI Bools", false)]
    [ShowInInspector]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool toggleMasterSub
    {
        get => _toggleMasterSub;

        set
        {
            _toggleMasterSub = value;
            NotifyPropertyChanged();
        }
    }

    #endregion

    #region SERIALIZATION

    [SerializeField] private PlayerStats[] playerStats;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private GameObject mainMenu, inventoryPanel, dayNightCycle;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private CanvasGroup[] menuPanels;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private RectTransform clockPanel, clockFrame;

    [FoldoutGroup("Miscellaneous", false)] [Range(0.5f, 2f)] [SerializeField]
    private float minButtonSize = 0.9f;

    [FoldoutGroup("Miscellaneous", false)] [Range(0.5f, 2f)] [SerializeField]
    private float maxButtonSize = 1f;


    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private GameObject equipment;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private Image imageToFade;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private TMP_Dropdown droppy; // dropbox for the dropdown object (hence, TMP_Dropdown)

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private UltimateButton actionButton;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private UltimateJoystick joystick;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private UltimateMobileQuickbar quickBar;


    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private GameObject panelTesting;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private GameObject teamTabMenu;

    [FoldoutGroup("Miscellaneous", false)] [GUIColor(1f, 0.8f, 0.315f)] [SerializeField]
    private CanvasGroup teamNofify, fadeResume;

    [SerializeField] private TextMeshProUGUI teamMemberCount;


    [TabGroup("Char Stats")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private TextMeshProUGUI[] characterName,
        characterNameP,
        description,
        level,
        levelP,
        xp,
        mana,
        health,
        attack,
        defence,
        intelligence,
        perception;

    [TabGroup("Char Stats")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private GameObject[] characterCards, characterParty, characterEquip, characterWeaponry, teamCharacterWeaponry;

    [TabGroup("Images")] [GUIColor(0.670f, 1, 0.560f)] [PreviewField] [Required] [SerializeField]
    private Image[] characterImage, characterMug, characterPlain;

    [TabGroup("Images")] [GUIColor(0.670f, 1, 0.560f)] [SerializeField]
    private Image characterImageV;


    [TabGroup("Sliders")] [GUIColor(1f, 0.886f, 0.780f)] [SerializeField]
    private Slider[] xpS, manaS, healthS, attackS, defenceS, intelligenceS, perceptionS;

    [TabGroup("Sliders")] [GUIColor(1f, 0.886f, 0.780f)] [SerializeField]
    private Slider xpVS, manaVS, healthVS, attackVS, defenceVS, intelligenceVS, perceptionVS;


    [TabGroup("New Group", "Thulgren")] [GUIColor(1f, 0.780f, 0.984f)] [SerializeField]
    private TextMeshProUGUI thulSpells, thulPotions, levelMain, xpMain, hpMain, manaMain;

    [TabGroup("New Group", "Thulgren")] [GUIColor(1f, 0.780f, 0.984f)] [SerializeField]
    private Slider xpMainS;

    [TabGroup("Skills")] [GUIColor(1, 0.819f, 0.760f)] [SerializeField]
    private TextMeshProUGUI characterNameV,
        descriptionV,
        levelV,
        xpV,
        manaV,
        healthV,
        attackV,
        defenceV,
        intelligenceV,
        perceptionV;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI itemName, goldMain, itemDescription, itemDamage, itemArmour, itemPotion, itemFood, itemValue;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image itemImage, sellGold;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Sprite masking;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField]
    private Transform itemBoxParent;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject itemBox, itemDamageBox, itemArmourBox, itemPotionBox, itemFoodBox;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI effectText;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject effectBox;

    [TabGroup("New Group", "Items")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject cancelButton, useButton, dropButton, sellButton;


    [TabGroup("New Group", "Equip")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI[] manaEquipToString, hpEquipToString, defenceEquipToString;

    [TabGroup("New Group", "Equip")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Slider[] manaEquipSlider, hpEquipSlider, defenceEquipSlider;

    [TabGroup("New Group", "Equip")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image[] characterMugEquip;

    [TabGroup("New Group", "Equip")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI
        manaEquipTopBar, hpEquipTopBar, goldEquipTopBar; // doesn't look like I used these. Done in CoinsManager.

    [TabGroup("New Group", "Equip")] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Button[] weaponPanelButtons, potionPanelButtons; // doesn't look like I used these. Done in CoinsManager.


    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] equippedWeaponName, equippedArmourName, equippedHelmetName, equippedShieldName;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] equippedWeaponImage, equippedArmourImage, equippedHelmetImage, equippedShieldImage;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] characterMugWeaponry;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] equippedWeaponBonus, equippedArmourBonus, equippedHelmetBonus, equippedShieldBonus;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.147f, 0.154f, 0.496f)]
    public TextMeshProUGUI itemPotionPower;

    [TabGroup("New Group", "Weaponry")] [GUIColor(0.147f, 0.154f, 0.496f)]
    public Sprite basicAxe, basicArmour, basicHelmet, basicShield;

    [Header("Team Panel UI")] [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamCharacterName;

    [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamEquippedWeaponImage, teamEquippedArmourImage, teamEquippedHelmetImage, teamEquippedShieldImage;

    [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamCharacterMugWeaponry;

    [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[]
        teamInventoryAttackTotal,
        teamInventoryDefenceTotal; // attack power is actually Dexterity in PlayerStats (yeah, I had to same thought... wtf??

    [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamItemWeaponBonus, teamItemArmourBonus, teamItemHelmetBonus, teamItemShieldBonus;

    [TabGroup("Weapon Group", "Team Weaponry")] [GUIColor(0.047f, 0.254f, 0.296f)]
    public Sprite teamBasicAxe, teamBasicArmour, teamBasicHelmet, TeamBasicShield;

    [TabGroup("Weapon Group", "Team Popup")] [GUIColor(0.207f, 0.121f, 0.027f)]
    public Image teamPopWeaponryImage;

    [TabGroup("Weapon Group", "Team Popup")] [GUIColor(0.207f, 0.121f, 0.027f)]
    public TextMeshProUGUI teamPopWeaponryName, teamPopWeaponryDescription, teamPopWeaponryBonusText;

    [TabGroup("Weapon Group", "Team Popup")] [GUIColor(0.207f, 0.121f, 0.027f)]
    public TextMeshProUGUI teamPopWeaponryBonus;

    [TabGroup("Weapon Group", "Inventory Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public Button inventTabsAllHolder,
        inventTabsWeaponsHolder,
        inventTabsArmourHolder,
        inventTabsItemsHolder,
        inventTabsPotionsHolder;

    [TabGroup("Weapon Group", "Inventory Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public TextMeshProUGUI inventTabsAllText;

    [TabGroup("Weapon Group", "Inventory Tabs")] [GUIColor(0.207f, 0.921f, 0.027f)]
    public GameObject inventTabsAllFocus,
        inventTabsWeaponsFocus,
        inventTabsArmourFocus,
        inventTabsItemsFocus,
        inventTabsPotionsFocus;

    [TabGroup("Weapon Group", "Add to Party")] [GUIColor(0.307f, 0.321f, 0.027f)]
    public Button[] addToPartyButton, retireFromPartyButton;

    [TabGroup("Weapon Group", "Add to Party")] [GUIColor(0.307f, 0.321f, 0.027f)]
    public GameObject[] isNewNotification;

    [TabGroup("Weapon Group", "Add to Party")] [GUIColor(0.307f, 0.321f, 0.027f)]
    public Image[] partyAdd;

    [TabGroup("Weapon Group", "Add to Party")] [GUIColor(0.307f, 0.321f, 0.027f)]
    public Sprite partyMember;

    [Title("Quests")] [TabGroup("Quests Group", "Quest Prefab")] [GUIColor(0.5f, 1f, 0.515f)]
    public GameObject pf_QuestDefault;

    [TabGroup("Quests Group", "Quest Prefab")] [GUIColor(0.5f, 1f, 0.515f)]
    public GameObject pf_QuestComplete, pf_QuestClaimed;

    [TabGroup("Quests Group", "Quest Prefab")] [GUIColor(0.5f, 1f, 0.515f)]
    public Transform QuestParent, ClaimsParent, relicsParent;

    [TabGroup("Quests Group", "Quest Prefab")] [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private CanvasGroup questsUIPanel, claimsUIPanel, relicsUIPanel, fadeBackground;

    [TabGroup("Quests Group", "Quest UI")] [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private Button questsTabButton;

    [TabGroup("Quests Group", "Quest UI")] [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private Image questSprite, claimsSprite, relicsSprite;

    [TabGroup("Quests Group", "Quest UI")] [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private TextMeshProUGUI questFocusTitle, questText, claimsText, relicsText;

    [TabGroup("Quests Group", "Quest UI")] [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private GameObject focusQuests, focusClaims, focusRelics, questTabMenu;

    [TabGroup("Quests Group", "Quest Relics")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private TextMeshProUGUI questRelicName, questRelicDescription, questCompleted, questCompletedName;

    [TabGroup("Quests Group", "Quest Relics")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private Image questRelicImage,
        questCompletedPanelSprite,
        questRewardTrophies,
        questRewardGold,
        questRewardBonus,
        questRewardSprite;

    [TabGroup("Quests Group", "Quest Complete")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private GameObject[] questRewardSlots;

    [TabGroup("Quests Group", "Quest Complete")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private Image[] questSlotImage;

    [TabGroup("Quests Group", "Quest Complete")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private TextMeshProUGUI[] questRewardText;

    [TabGroup("Quests Group", "Quest Complete")] [GUIColor(0.5f, 1f, 0f)] [SerializeField]
    private Sprite questRewardTest;


    [Header("Quest UI Sprites")]
    [Space]
    [FoldoutGroup("UI Sprites", false)]
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField]
    private Sprite questsSpriteOn, questsSpriteOff, claimsSpriteOn, claimsSpriteOff, relicsSpriteOn, relicsSpriteOff;


    [ShowInInspector] [Title("Nofify Info")]
    [TabGroup("Nofify Group", "Nofify")] [SerializeField] [GUIColor(0.878f, 0.219f, 0.219f)]
    public int currentNewItems;

    [TabGroup("Nofify Group", "Nofify")] [SerializeField] [GUIColor(0.878f, 0.219f, 0.219f)]
    public int notifyActiveQuest, notifyQuestReward, notifyRelicActive, totalQuestNotifications;

    [TabGroup("Nofify Group", "Nofify")] [SerializeField] [GUIColor(0.878f, 0.219f, 0.219f)]
    private TextMeshProUGUI newItemsText,
        newQuestActiveText,
        newClaimQuestRewardText,
        newQuestRelicActiveText,
        totalQuestNofifyText;

    [TabGroup("Nofify Group", "Nofify")] [GUIColor(0.878f, 0.219f, 0.219f)]
    public Item activeItem;

    [TabGroup("Nofify Group", "Nofify")]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public CanvasGroup questsTabNofify, claimsTabNofify, relicsTabNofify, totalQuestNofify;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)] [SerializeField]
    private bool[] isTeamMember;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isInventoryOn = false;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool weaponBool, armourBool, itemBool, potionBool, spellBool;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isOverviewOn, isStatsOn, isWeaponryOn;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isInventorySlidePanelOn;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isClockPopOutVisible;

    [FoldoutGroup("UI Bools", false)] [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isQuestsOn, isClaimsOn, isRelicsOn;


    [Header("UI Tweening")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private CanvasGroup chooseText;

    [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private TextMeshProUGUI textUseEquipTake;

    [GUIColor(1f, 1f, 0.215f)] public RectTransform mainEquipInfoPanel, characterChoicePanel, characterWeaponryPanel;

    [Header("Player Choice")] [GUIColor(1f, 0.2f, 0.515f)] [SerializeField]
    private TextMeshProUGUI[] playerChoice;

    [FoldoutGroup("Button Images", false)] [GUIColor(1f, 0.2f, 0.515f)] [SerializeField]
    private Sprite buttonGrey, buttonGreen;

    [Header("Team UI Sprites")]
    [Space]
    [FoldoutGroup("UI Sprites", false)]
    [GUIColor(0.5f, 1f, 0.515f)]
    [SerializeField]
    private Sprite overviewSpriteOn,
        overviewSpriteOff,
        statsSpriteOn,
        statsSpriteOff,
        weaponrySpriteOn,
        weaponrySpriteOff;

    [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private Image overviewSprite, statsSprite, weaponrySprite;

    [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private GameObject focusWeaponry, focusStats, focusOverview;

    [GUIColor(0.5f, 1f, 0.515f)] [SerializeField]
    private TextMeshProUGUI focusTitle, overviewText, statsText, weaponryText;

    #endregion

    #region CALLBACKS

    private void Start()
    {
        Instance = this;
        mainEquipInfoPanel.DOAnchorPos(Vector2.zero, 0f);
        mainMenu.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.4f, 0, 1);
    }

    private void Awake()
    {
        mainMenu.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.4f, 0, 1);
        sellGold = GameObject.FindGameObjectWithTag("sellGold").GetComponent<Image>();
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
        Actions.OnQuestCompletedResume += QuestPanelClose;
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
        Actions.OnQuestCompletedResume += QuestPanelClose;
    }

    #endregion

    #region INVOCATIONS

    public void UpdateStats_1(Item item, int character, Vector2 position)
    {
        UpdateStats();
        UpdateItemsInventory();
    }

    public void UpdateStats_2(Item item)
    {
        UpdateStats(); //hook into Actions without all the Args
        UpdateItemsInventory();
    }

    private void ResumeButton()
    {
        #region Graphics

        StartCoroutine(FadeToAlpha(mainMenu.GetComponent<CanvasGroup>(), 0f, 0.3f));
        mainMenu.GetComponent<CanvasGroup>().interactable = false;
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        DoPunch(mainMenu, new Vector3(0.15f, 0.15f, 0), 0.4f);
        ControllersFadeIn(0.5f);
        StartCoroutine(EnableJoystickDelay(0.7f));
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;

        #endregion

        #region Data

        currentNewItems = 0;
        ButtonHandler.Instance.SetAllButtonsInteractable();
        ShopManager.Instance.ShopItemInfoReset();
        ItemInfoReset();
        UpdateItemsInventory();
        UpdateStats();

        #endregion

        #region Bools

        GameManager.Instance.isItemSelected = false;
        isInventoryOn = false;
        GameManager.Instance.isInventoryOn = false;
        GameManager.Instance.isShopUIOn = false;

        dayNightCycle.SetActive(true);

        #endregion
    }

    public void BackButton()
    {
        PanelController();
        currentNewItems = 0;
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
        GameManager.Instance.isItemSelected = false;
        UpdateItemsInventory();
        UpdateQuestList("");
        isInventoryOn = false;
        GameManager.Instance.isInventoryOn = false;
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
        ButtonHandler.Instance.SetAllButtonsInteractable();
        ButtonHandler.Instance.InventoryButtonsDisabled();
        ShopManager.Instance.ShopItemInfoReset();
        ItemInfoReset();
        UpdateQuestList("");
        UpdateItemsInventory();
        UpdateStats();

        #endregion

        #region Bools

        GameManager.Instance.isItemSelected = false;
        GameManager.Instance.isShopUIOn = false;

        dayNightCycle.SetActive(true);
        isInventoryOn = false;
        GameManager.Instance.isInventoryOn = false;

        isQuestsOn = false;
        isClaimsOn = false;
        isRelicsOn = false;

        #endregion
    }

    private void MainMenuButton()
    {
        MainMenuCGOn(); // no fade in, just DOPunch
        ControllersFadeOut(0.3f);
        DoPunch(mainMenu, new Vector3(0.15f, 0.15f, 0), 0.1f);
        UpdateStats();
        UpdateItemsInventory();
        UpdateQuestList("");
    }

    private void MainMenuCGOn()
    {
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        mainMenu.GetComponent<CanvasGroup>().interactable = true;
        mainMenu.GetComponent<CanvasGroup>().alpha = 1;
        fadeResume.blocksRaycasts = true;
        fadeResume.interactable = true;
        fadeResume.alpha = 1;
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
        if (isInventoryOn)
        {
            Debug.Log($"Inventory is open and 'back' has been called");

            ButtonHandler.Instance.SetAllButtonsInteractable();
            ButtonHandler.Instance.InventoryButtonsDisabled();
            ShopManager.Instance.ShopItemInfoReset();
            ItemInfoReset();

            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
            inventoryPanel.GetComponent<CanvasGroup>().interactable = false;
            inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

            isInventoryOn = false;
            GameManager.Instance.isInventoryOn = false;
        }
        else if (GameManager.Instance.isShopUIOn)
        {
            Debug.Log($"Shop is open and 'back' has been called");

            ButtonHandler.Instance.SetAllButtonsInteractable();
            ShopManager.Instance.ShopItemInfoReset();
            ItemInfoReset();

            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            ShopManager.Instance.shopUIPanel.GetComponent<CanvasGroup>().interactable = false;
            ShopManager.Instance.shopUIPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            ShopManager.Instance.shopUIPanel.GetComponent<CanvasGroup>().alpha = 0;

            GameManager.Instance.isShopUIOn = false;
        }

        else if (isOverviewOn || isStatsOn || isWeaponryOn)
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log($"Team UI back triggered");
        }

        else if (isQuestsOn || isClaimsOn || isRelicsOn)
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

        if (activeItem.affectType == AffectType.Hp)
        {
            playerStats[0].characterHp = Thulgran.ThulgranHp;

            if (panelStuff != 0)
            {
                hpEquipToString[panelStuff].text = playerStats[panelStuff].characterHp.ToString();
            }
            else if (panelStuff == 0) // Thulgran is controlled by Thulgran.cs
            {
                hpEquipToString[panelStuff].text = Thulgran.ThulgranHp.ToString();
            }

            Sequence sequence = DOTween.Sequence()
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(hpEquipSlider[panelStuff]
                    .DOValue(playerStats[panelStuff].characterHp + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);


            yield return new WaitForSecondsRealtime(1.8f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);

            Debug.Log("Slider HP fill scale enacted");
        }

        else if (activeItem.affectType == AffectType.Mana)
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

            Sequence sequence = DOTween.Sequence()
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(manaEquipSlider[panelStuff]
                    .DOValue(playerStats[panelStuff].characterMana + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);

            yield return new WaitForSecondsRealtime(1.8f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 0.8f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 0.8f);

            Debug.Log("Slider Mana fill expand and slide");
        }
        else if (activeItem.itemType == ItemType.Armour ||
                 activeItem.itemType == ItemType.Weapon ||
                 activeItem.itemType == ItemType.Helmet ||
                 activeItem.itemType == ItemType.Shield)
        {
            if (activeItem.itemType == ItemType.Armour)
            {
                InventoryStats();
                Sequence sequence = DOTween.Sequence()
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }
            else if (activeItem.itemType == ItemType.Weapon)
            {
                InventoryStats();
                Sequence sequence = DOTween.Sequence()
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }

            else if (activeItem.itemType == ItemType.Helmet)
            {
                InventoryStats();
                Sequence sequence = DOTween.Sequence()
                    .Append(equippedHelmetImage[panelStuff].GetComponent<Transform>().DOScale(1.2f, 0.6f))
                    .Append(equippedHelmetImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.7f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }

            else if (activeItem.itemType == ItemType.Shield)
            {
                InventoryStats();
                Sequence sequence = DOTween.Sequence()
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

    private void NotifyPropertyChanged([CallerMemberName] string subExpanded = "<color=#C60B0B>has changed</color>")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs($"<color =#C60B0B>{subExpanded}</color>"));
    }

    public void HomeScreenStats()
    {
        playerStats = GameManager.Instance.GetPlayerStats().OrderBy(m => m.transform.position.z).ToArray();

        levelMain.text = playerStats[0].characterLevel.ToString();
        xpMain.text = playerStats[0].characterXp.ToString() + "/" +
                      playerStats[0].xpLevelUp[playerStats[0].characterLevel];
        xpMainS.value = playerStats[0].characterXp;
        xpMainS.maxValue = playerStats[0].xpLevelUp[playerStats[0].characterLevel];
    }

    public void InventoryStats()
    {
        playerStats = GameManager.Instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].isTeamMember == true)
            {
                if (i != 0)
                {
                    hpEquipToString[i].text = playerStats[i].characterHp.ToString();
                    manaEquipToString[i].text = playerStats[i].characterMana.ToString();
                    hpEquipSlider[i].value = playerStats[i].characterHp;
                    manaEquipSlider[i].value = playerStats[i].characterMana;
                }

                else if (i == 0)
                {
                    hpEquipToString[i].text = Thulgran.ThulgranHp.ToString(); // characterChoice Panel
                    manaEquipToString[i].text = Thulgran.ThulgranMana.ToString();
                    hpEquipSlider[i].value = Thulgran.ThulgranHp;
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

        playerStats = GameManager.Instance.GetPlayerStats();

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
                        health[i].text = playerStats[i].characterHp.ToString();
                        characterImage[i].sprite = playerStats[i].characterImage;
                        level[i].text = playerStats[i].characterLevel.ToString();
                        xp[i].text = playerStats[i].characterXp.ToString();
                        mana[i].text = playerStats[i].characterMana.ToString();
                        attack[i].text = playerStats[i].characterBaseAttack.ToString();
                        defence[i].text = playerStats[i].characterBaseDefence.ToString();
                        intelligence[i].text = playerStats[i].characterIntelligence.ToString();
                        perception[i].text = playerStats[i].characterPerception.ToString();
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        xpS[i].value = playerStats[i].characterXp;
                        manaS[i].value = playerStats[i].characterMana;
                        healthS[i].value = playerStats[i].characterHp;
                        attackS[i].value = playerStats[i].characterBaseAttack;
                        defenceS[i].value = playerStats[i].characterBaseDefence;
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        perceptionS[i].value = playerStats[i].characterPerception;
                    }

                    if (i == 0) // Thulgran
                    {
                        health[i].text = Thulgran.ThulgranHp.ToString();
                        mana[i].text = Thulgran.ThulgranMana.ToString();
                        healthS[i].value = Thulgran.ThulgranHp;
                        manaS[i].value = Thulgran.ThulgranMana;
                        characterName[i].text = playerStats[i].playerName;
                        description[i].text = playerStats[i].playerDesc;
                        characterImage[i].sprite = playerStats[i].characterImage;
                        level[i].text = playerStats[i].characterLevel.ToString();
                        xp[i].text = playerStats[i].characterXp.ToString();
                        attack[i].text = playerStats[i].characterBaseAttack.ToString();
                        defence[i].text = playerStats[i].characterBaseDefence.ToString();
                        intelligence[i].text = playerStats[i].characterIntelligence.ToString();
                        perception[i].text = playerStats[i].characterPerception.ToString();
                        intelligenceS[i].value = playerStats[i].characterIntelligence;
                        xpS[i].value = playerStats[i].characterXp;
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

                    teamInventoryDefenceTotal[i].text =
                        $"<color=#CFCFCF>{playerStats[i].characterBaseDefence}</color> +{(playerStats[i].characterDefenceTotal - playerStats[i].characterBaseDefence).ToString()}";
                    teamInventoryAttackTotal[i].text =
                        $"<color=#CFCFCF>{playerStats[i].characterBaseAttack}</color> +{(playerStats[i].characterAttackTotal - playerStats[i].characterBaseAttack).ToString()}";

                    teamItemArmourBonus[i].text = "+" + playerStats[i].characterArmour.itemDefence.ToString();
                    teamItemHelmetBonus[i].text = "+" + playerStats[i].characterHelmet.itemDefence.ToString();
                    teamItemShieldBonus[i].text = "+" + playerStats[i].characterShield.itemDefence.ToString();
                    teamItemWeaponBonus[i].text = "+" + playerStats[i].characterWeapon.itemAttack.ToString();
                }

                // these are the references for the Team Overview (add to party)

                characterNameP[i].text = playerStats[i].playerName + "\n<size=26><color=#BEB5B6>" +
                                         playerStats[i].playerMoniker + "</color></size>";
                levelP[i].text = playerStats[i].characterLevel.ToString();
                characterMug[i].sprite = playerStats[i].characterMug;
            }
        }
    }

    public void AddCharacterToParty(int character)
    {
        playerStats = GameManager.Instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (i == character)
            {
                playerStats[character].isTeamMember = true;
                playerStats[character].isNew = false;
                playerStats[character].npc.IsTeamMember(true);
                teamNofifyCount--;
                CharacterActivationButtons(character);
                InventoryStats();
                Debug.Log(playerStats[character].playerName + " added to party");
            }
        }

        UpdateStats();
    }

    public void CharacterActivationButtons(int character)
    {
        addToPartyButton[character].gameObject.SetActive(false);
        partyAdd[character].sprite = partyMember;
        isNewNotification[character].SetActive(false);
        retireFromPartyButton[character].gameObject.SetActive(true);
    }

    public void AndroidControls()
    {
        PlayerGlobalData.Instance.controllerSwitch = !PlayerGlobalData.Instance.controllerSwitch;
    }

    public void CallToSellItem()
    {
        isInventorySlidePanelOn = true; // not sure why this is here
        Inventory.Instance.SellItem(activeItem);
        UpdateItemsInventory();
        textUseEquipTake.text = "Select";
    }

    public void CallToDropItem()
    {
        Inventory.Instance.DropItem(activeItem);
        UpdateItemsInventory();
    }

    public void CallToUseItem(int selectedCharacter)
    {
        Debug.Log("Use item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " +
                  "Item: " + activeItem.itemName);

        panelStuff = selectedCharacter;


        switch (activeItem.affectType)
        {
            case AffectType.Hp when selectedCharacter != 0:
                {
                    if (playerStats[selectedCharacter].characterHp == playerStats[selectedCharacter].maxHp)
                    {
                        NotificationFader.instance.CallFadeInOut(
                            $"{playerStats[selectedCharacter].playerName}'s HP is at <color=#C60B0B>max!</color>\n Try someone else?",
                            Sprites.instance.hpSprite, 1.5f, 1400, 30);
                        Debug.Log($"Yo");
                    }

                    else
                    {
                        cancelButton.SetActive(false);
                        dropButton.SetActive(true);
                        dropButton.GetComponent<Button>().interactable = false;
                        useButton.GetComponent<Button>().interactable = false;
                        sellGold.color = new Color32((byte)sellGold.color.r, (byte)sellGold.color.b,
                            (byte)sellGold.color.g, 100);
                        //useButton.GetComponent<Image>().sprite = buttonGreen;

                        FadeOutText(1);
                        SetAllButtonsUninteractable();
                        activeItem.UseItem(selectedCharacter);
                        Inventory.Instance.UseAndRemoveItem(activeItem, selectedCharacter,
                            characterMugEquip[selectedCharacter].transform.position);
                        UpdateItemsInventory();
                        OnPlayerButton();
                        ItemInfoReset();

                        Debug.Log(activeItem.amountOfEffect + " HP given to " + playerStats[selectedCharacter]
                            .playerName);
                    }

                    break;
                }
            case AffectType.Hp:
                {
                    if (selectedCharacter == 0)
                    {
                        if (Thulgran.ThulgranHp < Thulgran.MaxThulgranHp)
                        {
                            cancelButton.SetActive(false);
                            dropButton.SetActive(true);
                            dropButton.GetComponent<Button>().interactable = false;
                            useButton.GetComponent<Button>().interactable = false;
                            sellGold.color = new Color32((byte)sellGold.color.r, (byte)sellGold.color.b,
                                (byte)sellGold.color.g, 100);
                            //useButton.GetComponent<Image>().sprite = buttonGreen;

                            FadeOutText(1);
                            SetAllButtonsUninteractable();
                            activeItem.UseItem(selectedCharacter);
                            Inventory.Instance.UseAndRemoveItem(activeItem, selectedCharacter,
                                characterMugEquip[selectedCharacter].transform.position);
                            UpdateItemsInventory();
                            OnPlayerButton();
                            ItemInfoReset();
                            Debug.Log(
                                $"CallToUseItem completed | {activeItem.amountOfEffect} HP should have been given to " +
                                playerStats[selectedCharacter].playerName);
                        }
                        else if (Thulgran.ThulgranHp == Thulgran.MaxThulgranHp)
                        {
                            NotificationFader.instance.CallFadeInOut(
                                $"{playerStats[selectedCharacter].playerName}'s HP is at <color=#C60B0B>max!</color>\n Try someone else?",
                                Sprites.instance.hpSprite, 1.5f, 1400, 30);
                            Debug.Log($"Yo");
                        }
                    }

                    break;
                }
            case AffectType.Mana when selectedCharacter != 0:
                {
                    if (playerStats[selectedCharacter].characterMana == playerStats[selectedCharacter].maxMana)
                    {
                        NotificationFader.instance.CallFadeInOut(
                            $"{playerStats[selectedCharacter].playerName}'s mana is at <color=#C60B0B>max!</color> \n Try someone else?",
                            Sprites.instance.manaSprite, 1.5f, 1400, 30);
                    }

                    else if (playerStats[selectedCharacter].characterMana < playerStats[selectedCharacter].maxMana)
                    {
                        cancelButton.SetActive(false);
                        dropButton.SetActive(true);
                        dropButton.GetComponent<Button>().interactable = false;
                        useButton.GetComponent<Button>().interactable = false;
                        sellGold.color = new Color32((byte)sellGold.color.r, (byte)sellGold.color.b,
                            (byte)sellGold.color.g, 100);
                        //useButton.GetComponent<Image>().sprite = buttonGreen;

                        FadeOutText(1);
                        SetAllButtonsUninteractable();
                        activeItem.UseItem(selectedCharacter);
                        Inventory.Instance.UseAndRemoveItem(activeItem, selectedCharacter,
                            characterMugEquip[selectedCharacter].transform.position);
                        UpdateItemsInventory();
                        OnPlayerButton();
                        ItemInfoReset();
                        Debug.Log(activeItem.amountOfEffect + " mana given to " +
                                  playerStats[selectedCharacter].playerName);
                    }

                    break;
                }
            case AffectType.Mana:
                {
                    if (selectedCharacter == 0)
                    {
                        if (Thulgran.ThulgranMana == Thulgran.MaxThulgranMana)
                        {
                            NotificationFader.instance.CallFadeInOut(
                                $"{playerStats[selectedCharacter].playerName}'s mana is at <color=#C60B0B>max!</color>\n Try someone else?",
                                Sprites.instance.manaSprite, 1.5f, 1400, 30);
                        }

                        else if (Thulgran.ThulgranMana < Thulgran.MaxThulgranMana)
                        {
                            cancelButton.SetActive(false);
                            dropButton.SetActive(true);
                            dropButton.GetComponent<Button>().interactable = false;
                            useButton.GetComponent<Button>().interactable = false;
                            sellGold.color = new Color32((byte)sellGold.color.r, (byte)sellGold.color.b,
                                (byte)sellGold.color.g, 100);
                            //useButton.GetComponent<Image>().sprite = buttonGreen;

                            FadeOutText(1);
                            SetAllButtonsUninteractable();
                            activeItem.UseItem(selectedCharacter);
                            Inventory.Instance.UseAndRemoveItem(activeItem, selectedCharacter,
                                characterMugEquip[selectedCharacter].transform.position);
                            UpdateItemsInventory();
                            OnPlayerButton();
                            ItemInfoReset();

                            Debug.Log(activeItem.amountOfEffect + " mana given to " +
                                      playerStats[selectedCharacter].playerName);
                        }
                    }

                    break;
                }
            default:
                {
                    if (activeItem.itemType is ItemType.Armour or ItemType.Weapon or ItemType.Helmet or ItemType.Shield)
                    {
                        cancelButton.SetActive(false);
                        dropButton.SetActive(true);
                        dropButton.GetComponent<Button>().interactable = false;
                        useButton.GetComponent<Button>().interactable = false;
                        sellGold.color = new Color32((byte)sellGold.color.r, (byte)sellGold.color.b,
                            (byte)sellGold.color.g, 100);
                        //useButton.GetComponent<Image>().sprite = buttonGreen;

                        FadeOutText(1);
                        SetAllButtonsUninteractable();
                        activeItem.UseItem(selectedCharacter);
                        Inventory.Instance.UseAndRemoveItem(activeItem, selectedCharacter,
                            characterMugEquip[selectedCharacter].transform.position);
                        UpdateItemsInventory();
                        OnPlayerButton();
                        ItemInfoReset();
                    }

                    break;
                }
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

    public void MainMenuPanel(int panel) // switch a panel on
    {
        //    mainMenu 0
        //    shop 1
        //    path 2
        //    magic 3
        //    overview 4
        //    stats 5
        //    weaponry 6
        //    team UI buttons 7
        //    team fadebackground 8
        //    quests 9
        //    claims 10
        //    relics 11
        //    quest UI Buttons 12
        //    quest fadebackground 13
        //    inventory 14
        //    completed Quest 15  


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
        Instance.itemValue.text = "";
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

        if (activeItem.itemType is ItemType.Potion or ItemType.Food)
        {
            characterChoicePanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }

        else if (activeItem.itemType is ItemType.Armour or ItemType.Weapon or ItemType.Helmet or ItemType.Shield)
        {
            characterWeaponryPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }

        isInventorySlidePanelOn = true;
    }

    public void RemoveCharacterFromParty(int character)
    {
        playerStats = GameManager.Instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (i == character)
            {
                playerStats[character].isTeamMember = false;
                playerStats[character].npc.IsTeamMember(false);
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

    public void SetAllButtonsUninteractable() // this disables buttons for character selection on equip item etc
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
                PlayerStats activePlayer = GameManager.Instance.GetPlayerStats()[i];
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

        playerStats = GameManager.Instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].isAvailable == true && playerStats[i].isNew == true)
            {
                teamNofifyCount++;
            }

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

            Debug.Log(
                $"Exiting. Panel status - Overview: {GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha} | Stats: {GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha} | Weaponry: {GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha} | Tabs: {teamTabMenu.GetComponent<CanvasGroup>().alpha}");
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
        GameManager.Instance.isInventoryOn = !GameManager.Instance.isInventoryOn;
    }

    public void UpdateItemsInventory()
    {
        currentNewItems = 0;
        foodItems = 0; // debug stuff
        potionItems = 0;
        weaponItems = 0;
        itemItems = 0;
        armourItems = 0;

        foreach (Transform itemSlot in itemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }


        foreach (Item item in Inventory.Instance.GetItemsList())
        {
            //item.GetItemDetailsFromScriptObject(item);

            if (item.isShopItem == false)
            {
                RectTransform itemSlot = Instantiate(itemBox, itemBoxParent).GetComponent<RectTransform>();

                // show item image
                Image itemsImage = itemSlot.Find("Items Image").GetComponent<Image>();
                itemsImage.sprite = item.itemsImage;

                TextMeshProUGUI itemsAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
                itemsAmountText.text = item.quantity > 1 ? item.quantity.ToString() : "";

                // this finds the ItemButton on the item prefab and assigns the item to it. When the button is pressed, that data can be used for the item info, use ietem etc. 
                itemSlot.GetComponent<ItemButton>().itemOnButton = item;

                int i = -1;
                i = item.itemType switch
                {
                    ItemType.Food => foodItems++,
                    ItemType.Potion => potionItems++,
                    ItemType.Item => itemItems++,
                    ItemType.Weapon => weaponItems++,
                    ItemType.Armour => armourItems++,
                    ItemType.Helmet => armourItems++,
                    ItemType.Shield => armourItems++,
                    _ => i
                };

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

                    if (!item.itemSelected)
                    {
                        itemSlot.Find("Focus").GetComponent<Image>().enabled = false;
                        GameManager.Instance.isItemSelected = false;

                        if (item.isNewItem)
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

                    else if (item.itemSelected) // if item has been selected
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

                        if (item.affectType == AffectType.Hp)
                        {
                            textUseEquipTake.text = "Give";


                            // EFFECT MODIFIER (on item info)

                            if (item.itemName == "Mana Potion")
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 1;
                                effectText.text = "+" + item.amountOfEffect.ToString();
                            }

                            else if (item.itemName is "Red Healing Potion" or "Green Healing Potion"
                                     or "Red Healing Potion Large")
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 1;
                                effectText.text = "+" + item.amountOfEffect.ToString();
                            }

                            else
                            {
                                effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            }
                        }

                        if (item.affectType == AffectType.Speed)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "x" + item.amountOfEffect.ToString();
                        }

                        // EFFECT - FOOD

                        if (item.itemType is ItemType.Food)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "+" + item.amountOfEffect;
                            textUseEquipTake.text = "Give";
                        }

                        // SORT BY ARMOUR

                        if (item.itemType is ItemType.Armour or ItemType.Helmet or ItemType.Shield)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            textUseEquipTake.text = "Equip";
                        }

                        // SORT BY WEAPON

                        if (item.itemType is ItemType.Weapon)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            textUseEquipTake.text = "Equip";
                        }

                        // SORT BY NORMAL ITEMS

                        if (item.itemType == ItemType.Item)
                        {
                            effectBox.GetComponent<CanvasGroup>().alpha = 0;
                            Debug.Log(
                                $"Type: {item.itemType} | Name: {item.itemName} | Effect: {item.amountOfEffect} | Weapon Power: {item.itemAttack} | Armour Defence: {item.itemDefence}");
                            textUseEquipTake.text = "Use";
                        }
                    }
                }
                // sorting strategy - destroy everything else but the chosen type

                if (weaponBool)

                {
                    if (item.itemType == ItemType.Weapon)
                    {
                        itemSlot.gameObject.SetActive(true);
                    }
                    else if (item.itemType is ItemType.Potion or ItemType.Armour or ItemType.Item or ItemType.Skill
                             or ItemType.Food or ItemType.Helmet or ItemType.Shield or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (armourBool)

                {
                    if (item.itemType is ItemType.Armour or ItemType.Helmet or ItemType.Shield)
                    {
                        itemSlot.gameObject.SetActive(true);
                    }

                    if (item.itemType is ItemType.Potion or ItemType.Weapon or ItemType.Item or ItemType.Skill
                        or ItemType.Food or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (itemBool)

                {
                    if (item.itemType == ItemType.Item ||
                        item.itemType == ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(true);
                    }

                    if (item.itemType is ItemType.Potion or ItemType.Armour or ItemType.Weapon or ItemType.Spell
                        or ItemType.Helmet or ItemType.Shield)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (spellBool)

                {
                    if (item.itemType == ItemType.Spell)
                    {
                        itemSlot.gameObject.SetActive(true);
                    }

                    if (item.itemType is ItemType.Potion or ItemType.Armour or ItemType.Item or ItemType.Weapon
                        or ItemType.Helmet or ItemType.Shield or ItemType.Relic)
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else if (potionBool)

                {
                    if (item.itemType == ItemType.Potion)
                    {
                        itemSlot.gameObject.SetActive(true);
                    }

                    if (item.itemType is ItemType.Weapon or ItemType.Armour or ItemType.Item or ItemType.Spell
                        or ItemType.Food or ItemType.Helmet or ItemType.Shield or ItemType.Relic)
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

                GameManager.Instance.currentNewItems = currentNewItems;
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
            Sequence sequence = DOTween.Sequence()
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
            Sequence seq = DOTween.Sequence()
                .Append(clockPanel.DOAnchorPosY(-20, 1f))
                .Join(clockPanel.DOScale(0f, 2f));
            seq.SetLoops(1, LoopType.Yoyo);
        }
    }

    #endregion
}