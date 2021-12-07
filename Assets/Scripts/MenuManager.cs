using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;



public class MenuManager : MonoBehaviour
{

    [SerializeField] PlayerStats[] playerStats;
    [SerializeField] GameObject[] statsButtons;

    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject mainMenu;
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
    [SerializeField] private UltimateJoystick joystick;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject panelTesting;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [GUIColor(1f, 0.8f, 0.315f)]
    [SerializeField] GameObject teamTabMenu;

    public static MenuManager instance;



    private int panelStuff;
    private string whichPanelIsOn = "";
    private UIFader uiFader;

    //adding serializeField gives possibility to add Simple Joystick object in inspector and thereby share its functions. Not possible if in prefab unless both are in a prefab

    public static int select;

    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI[] characterName, characterNameP, thulGold, thulMana, description, level, levelP, xp, mana, health, dexterity, defence, intelligence, perception;
    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject[] characterCards, characterParty, characterEquip, characterWeaponry;

    [TabGroup("Images")]
    [GUIColor(0.670f, 1, 0.560f)]
    [PreviewField, Required]
    [SerializeField] Image[] characterImage, characterMug;
    [TabGroup("Images")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] Image characterImageV;

    [TabGroup("Sliders")]
    [GUIColor(1f, 0.886f, 0.780f)]
    [SerializeField] Slider[] xpS, manaS, healthS, dexterityS, defenceS, intelligenceS, perceptionS;
    [TabGroup("Sliders")]
    [GUIColor(1f, 0.886f, 0.780f)]
    [SerializeField] Slider xpVS, manaVS, healthVS, dexterityVS, defenceVS, intelligenceVS, perceptionVS;

    [Space]
    [TabGroup("New Group", "Thulgren")]
    [GUIColor(1f, 0.780f, 0.984f)]
    [SerializeField] TextMeshProUGUI thulSpells, thulPotions, levelMain, xpMain, hpMain, manaMain, goldMain;
    [TabGroup("New Group", "Thulgren")]
    [GUIColor(1f, 0.780f, 0.984f)]
    [SerializeField] Slider xpMainS;

    [TabGroup("Skills")]
    [GUIColor(1, 0.819f, 0.760f)]
    [SerializeField] TextMeshProUGUI characterNameV, descriptionV, levelV, xpV, manaV, healthV, dexterityV, defenceV, intelligenceV, perceptionV;

    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI itemName, itemDescription, itemDamage, itemArmour, itemValue;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public Image itemImage;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Transform itemBoxParent;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public GameObject itemBox, itemDamageBox, itemArmourBox;
    [TabGroup("New Group", "Items")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public TextMeshProUGUI effectText;


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


    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] equippedWeaponName, equippedArmourName;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] equippedWeaponImage, equippedArmourImage;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public Image[] characterMugWeaponry;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.447f, 0.454f, 0.496f)]
    public TextMeshProUGUI[] inventoryWeaponPower, inventoryArmourDefence;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.147f, 0.154f, 0.496f)]
    public TextMeshProUGUI itemWeaponPower, itemArmourDefence;
    [TabGroup("New Group", "Weaponry")]
    [GUIColor(0.147f, 0.154f, 0.496f)]
    public Sprite basicAxe, basicArmour;


    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamEquippedWeaponName, teamEquippedArmourName;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamEquippedWeaponImage, teamEquippedArmourImage;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Image[] teamCharacterMugWeaponry;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI[] teamInventoryWeaponPower, teamInventoryArmourDefence;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public TextMeshProUGUI teamItemWeaponPower, teamItemArmourDefence;
    [TabGroup("Weapon Group", "Team Weaponry")]
    [GUIColor(0.047f, 0.254f, 0.296f)]
    public Sprite teamBasicAxe, teamBasicArmour;






    [ShowInInspector]
    [Title("INVENTORY")]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public int currentNewItems;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    [SerializeField] TextMeshProUGUI newItemsText;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public ItemsManager activeItem; //what are we doing here? Creating a slot in inspector for an 'active item', which is an object that has an ItemsManager script attached?


    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [SerializeField] bool[] isTeamMember;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isEquipOn = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool keyboardKeyI = false;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool controlSwitch;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool weaponBool, armourBool, itemBool, potionBool, skillBool;
    [FoldoutGroup("UI Bools", expanded: false)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isOverviewOn, isStatsOn, isWeaponryOn;


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
    [GUIColor(1f, 0.2f, 0.515f)]
    [SerializeField] Sprite buttonGrey;

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



    private Tween fadeText;


    private void Start()
    {

        instance = this;

        mainEquipInfoPanel.DOAnchorPos(Vector2.zero, 0f);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            GameManager.instance.isInterfaceOn = !GameManager.instance.isInterfaceOn;

            if (mainMenu.GetComponent<CanvasGroup>().alpha == 0)
            {
                mainMenu.GetComponent<UIFader>().FadeIn(); // this is calling the fade-in
                mainMenu.GetComponent<CanvasGroup>().interactable = true;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                joystick.DisableJoystick();
            }
            else
            {
                mainMenu.GetComponent<UIFader>().FadeOut(); // call a function from another script
                mainMenu.GetComponent<CanvasGroup>().interactable = false;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                joystick.EnableJoystick();
            }
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            PanelTestingKeyboardControl();
        }
    }

    public void UpdateStats()
    {

        playerStats = GameManager.instance.GetPlayerStats();



        for (int i = 0; i < playerStats.Length; i++)
        {


            isTeamMember[i] = playerStats[i].isTeamMember;


            // set to false first, to account for changes in character party updating

            if (isTeamMember[i] == true)
            {
                //Debug.Log(playerStats[i].playerName + " (LEVEL " + playerStats[i].npcLevel + ") is now active");
                characterCards[i].SetActive(true);
                characterParty[i].SetActive(true);
                //characterWeaponry[i].SetActive(true);


                characterName[i].text = playerStats[i].playerName;
                description[i].text = playerStats[i].playerDesc;
                health[i].text = playerStats[i].npcHP.ToString();
                characterImage[i].sprite = playerStats[i].characterImage;
                level[i].text = playerStats[i].npcLevel.ToString();
                xp[i].text = playerStats[i].npcXP.ToString();
                mana[i].text = playerStats[i].npcMana.ToString();
                dexterity[i].text = playerStats[i].npcDexterity.ToString();
                defence[i].text = playerStats[i].npcDefence.ToString();
                intelligence[i].text = playerStats[i].npcIntelligence.ToString();
                perception[i].text = playerStats[i].npcPerception.ToString();
                intelligenceS[i].value = playerStats[i].npcIntelligence;
                xpS[i].value = playerStats[i].npcXP;
                manaS[i].value = playerStats[i].npcMana;
                healthS[i].value = playerStats[i].npcHP;
                dexterityS[i].value = playerStats[i].npcDexterity;
                defenceS[i].value = playerStats[i].npcDefence;
                intelligenceS[i].value = playerStats[i].npcIntelligence;
                perceptionS[i].value = playerStats[i].npcPerception;
                characterNameP[i].text = playerStats[i].playerName + "\n<size=26><color=#BEB5B6>" + playerStats[i].playerMoniker + "</color></size>";
                levelP[i].text = playerStats[i].npcLevel.ToString();
                characterMug[i].sprite = playerStats[i].characterMug;
                thulGold[i].text = playerStats[0].thulGold.ToString();
                thulPotions.text = playerStats[0].thulPotions.ToString();
                thulSpells.text = playerStats[0].thulSpells.ToString();

            }
        }


    }

    public void AndroidControls()
    {
        controlSwitch = !controlSwitch;
    }

    public void UpdateItemsInventory()     // create  UI Equip table and side panel. Item sorting at the bottom
    {

        currentNewItems = 0;


        foreach (Transform itemSlot in itemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }


        foreach (ItemsManager item in Inventory.instance.GetItemsList())
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


            // new items - needs to run here to count how many new items

            if (item.isNewItem == true)
            {
                GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 1;
                currentNewItems++;
            }


            // Stuff to activate ONLY when inside inventory

            if (isEquipOn == true)
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
                    itemSlot.Find("Focus").GetComponent<Image>().enabled = true;

                    // ITEM SELECTED animation

                    itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

                    // NEW ITEM tagging

                    item.isNewItem = false; // switch off new item tag after selection
                    itemSlot.Find("New Item").GetComponent<Image>().enabled = false;

                    // SORTING BY ITEM TYPE

                    GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha = 0; // necessary reset


                    //  SORT BY POTIONS

                    if (item.itemType == ItemsManager.ItemType.Potion)
                    {
                        Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);

                        textUseEquipTake.text = "Give";

                        // EFFECT MODIFIER (on item info)

                        if (item.itemName == "Speed Potion")
                        {
                            GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "x" + item.amountOfEffect.ToString();
                        }

                        else if (item.itemName == "Mana Potion")
                        {
                            GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "+" + item.amountOfEffect.ToString();
                        }

                        else if (item.itemName == "Red Healing Potion" || item.itemName == "Green Healing Potion")
                        {
                            GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha = 1;
                            effectText.text = "+" + item.amountOfEffect.ToString();
                        }

                        else
                        {
                            GameObject.FindGameObjectWithTag("Effect").GetComponent<CanvasGroup>().alpha = 0;
                        }

                    }

                    // SORT BY ARMOUR

                    if (item.itemType == ItemsManager.ItemType.Armour)
                    {
                        Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        textUseEquipTake.text = "Equip";
                    }

                    // SORT BY WEAPON

                    if (item.itemType == ItemsManager.ItemType.Weapon)
                    {
                        Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        textUseEquipTake.text = "Equip";
                    }

                    // SORT BY NORMAL ITEMS

                    if (item.itemType == ItemsManager.ItemType.Item)
                    {
                        Debug.Log("Type: " + item.itemType + " | " + "Name: " + item.itemName);
                        textUseEquipTake.text = "Use";
                    }
                }
            }

            // sorting strategy - destroy everything else but the chosen type

            if (weaponBool == true)

            {
                if ((item.itemType == ItemsManager.ItemType.Potion) ||
       (item.itemType == ItemsManager.ItemType.Armour) ||
       (item.itemType == ItemsManager.ItemType.Item) ||
       (item.itemType == ItemsManager.ItemType.Skill))
                {
                    Destroy(itemSlot.gameObject);
                }

            }
            else if (armourBool == true)

            {
                if ((item.itemType == ItemsManager.ItemType.Potion) ||
       (item.itemType == ItemsManager.ItemType.Weapon) ||
       (item.itemType == ItemsManager.ItemType.Item) ||
       (item.itemType == ItemsManager.ItemType.Skill))
                {
                    Destroy(itemSlot.gameObject);
                }
            }
            else if (itemBool == true)

            {
                if ((item.itemType == ItemsManager.ItemType.Potion) ||
       (item.itemType == ItemsManager.ItemType.Armour) ||
       (item.itemType == ItemsManager.ItemType.Weapon) ||
       (item.itemType == ItemsManager.ItemType.Skill))
                {
                    Destroy(itemSlot.gameObject);
                }
            }
            else if (skillBool == true)

            {
                if ((item.itemType == ItemsManager.ItemType.Potion) ||
       (item.itemType == ItemsManager.ItemType.Armour) ||
       (item.itemType == ItemsManager.ItemType.Item) ||
       (item.itemType == ItemsManager.ItemType.Weapon))
                {
                    Destroy(itemSlot.gameObject);
                }
            }
            else if (potionBool == true)

            {
                if ((item.itemType == ItemsManager.ItemType.Weapon) ||
       (item.itemType == ItemsManager.ItemType.Armour) ||
       (item.itemType == ItemsManager.ItemType.Item) ||
       (item.itemType == ItemsManager.ItemType.Skill))
                {
                    Destroy(itemSlot.gameObject);
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
            //Debug.Log("No. of new Items: " + currentNewItems);


        }
    }

    public void StatsMenu()
    {
        for (int i = 0; i < playerStats.Length; i++)
        {
            statsButtons[i].SetActive(true);
        }
    }

    public void HomeScreenStats()
    {
        playerStats = GameManager.instance.GetPlayerStats().OrderBy(m => m.transform.position.z).ToArray();

        levelMain.text = playerStats[0].npcLevel.ToString();
        xpMain.text = playerStats[0].npcXP.ToString() + "/" + playerStats[0].xpLevelUp[playerStats[0].npcLevel];
        xpMainS.value = playerStats[0].npcXP;
        xpMainS.maxValue = playerStats[0].xpLevelUp[playerStats[0].npcLevel];
        manaMain.text = playerStats[0].npcMana.ToString() + "/" + playerStats[0].maxMana;
        hpMain.text = playerStats[0].npcHP.ToString() + "/" + playerStats[0].maxHP;
        goldMain.text = playerStats[0].thulGold.ToString();


    }

    public void InventoryStats() // this is rather the skills panel
    {

        // select is the choice of character in the dropdown menu, i.e. the character array slot. 

        select = droppy.GetComponent<TMP_Dropdown>().value;  // getting a value from droppy (the object dropbox)
        characterNameV.text = playerStats[select].playerName;
        descriptionV.text = playerStats[select].playerDesc;
        healthV.text = playerStats[select].npcHP.ToString();
        characterImageV.sprite = playerStats[select].characterImage;
        levelV.text = playerStats[select].npcLevel.ToString();
        xpV.text = playerStats[select].npcXP.ToString();
        manaV.text = playerStats[select].npcMana.ToString();
        dexterityV.text = playerStats[select].npcDexterity.ToString();
        defenceV.text = playerStats[select].npcDefence.ToString();
        intelligenceV.text = playerStats[select].npcIntelligence.ToString();
        perceptionV.text = playerStats[select].npcPerception.ToString();
        intelligenceVS.value = playerStats[select].npcIntelligence;
        xpVS.value = playerStats[select].npcXP;
        manaVS.value = playerStats[select].npcMana;
        healthVS.value = playerStats[select].npcHP;
        dexterityVS.value = playerStats[select].npcDexterity;
        defenceVS.value = playerStats[select].npcDefence;
        intelligenceVS.value = playerStats[select].npcIntelligence;
        perceptionVS.value = playerStats[select].npcPerception;
        characterImageV.sprite = playerStats[select].characterImage;


    }

    public void equipCharStats()
    {


        playerStats = GameManager.instance.GetPlayerStats();


        // populates a character array and assigns stats, weapons, and armour

        for (int i = 0; i < playerStats.Length; i++)
        {

            isTeamMember[i] = playerStats[i].isTeamMember;
            if (isTeamMember[i] == true)
            {
                //stat text values
                characterEquip[i].SetActive(true);
                hpEquipToString[i].text = playerStats[i].npcHP.ToString();
                manaEquipToString[i].text = playerStats[i].npcMana.ToString();
                defenceEquipToString[i].text = playerStats[i].npcDefence.ToString();
                //stat sliders
                hpEquipSlider[i].value = playerStats[i].npcHP;
                manaEquipSlider[i].value = playerStats[i].npcMana;
                defenceEquipSlider[i].value = playerStats[i].npcDefence;
                characterMugEquip[i].sprite = playerStats[i].characterMug;

                //weaponry

                characterWeaponry[i].SetActive(true);
                characterMugWeaponry[i].sprite = playerStats[i].characterMug;

                equippedWeaponName[i].text = playerStats[i].equippedWeaponName;
                equippedWeaponImage[i].sprite = playerStats[i].equippedWeaponImage;
                inventoryWeaponPower[i].text = "+" + playerStats[i].characterWeaponPower.ToString();

                equippedArmourName[i].text = playerStats[i].equippedArmourName;
                equippedArmourImage[i].sprite = playerStats[i].equippedArmourImage;
                inventoryArmourDefence[i].text = "+" + playerStats[i].characterArmourDefence.ToString();

                // this assigns a basic weapon and armour if none are set so that UI doesn't return blanks

                if (playerStats[i].equippedWeaponName == "")
                {
                    equippedWeaponName[i].text = "Basic Axe";
                    equippedWeaponImage[i].sprite = basicAxe;
                    inventoryWeaponPower[i].text = "+5";
                }

                if (playerStats[i].equippedArmourName == "")
                {
                    equippedArmourName[i].text = "Basic Armour";
                    equippedArmourImage[i].sprite = basicArmour;
                    inventoryArmourDefence[i].text = "+5";
                }

            }
        }
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }

    public void QuitGame()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }

    public void CallToSellItem(int selectedCharacter)
    {
        Debug.Log("Sell item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " + "Item: " + activeItem.itemName);
        Inventory.instance.SellItem(activeItem, selectedCharacter);
        UpdateItemsInventory();
        GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable = false;
        Debug.Log("CallToSellItem calling UpdateItemsInventory");
        textUseEquipTake.text = "Select";
    }

    public void CallToUseItem(int selectedCharacter)
    {
        // debug info

        Debug.Log("Use item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " + "Item: " + activeItem.itemName);
        activeItem.UseItem(selectedCharacter);

        // pass player image position for CoinsManager animations
        Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter, characterMugEquip[selectedCharacter].transform.position);

        // give a new color to button. Can add to this later with color coding for selecting equip, use, give 
        //GameObject.FindGameObjectWithTag("text_UseEquipTake").GetComponent<TextMeshProUGUI>().color = new Color(0.015f, 0.352f, 0.223f, 1);

        // panelStuff is used in the tween animations on OnPlayerButton() (i.e. give stuff to character)
        panelStuff = selectedCharacter;
        UpdateItemsInventory();

        //GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable = false;
        textUseEquipTake.text = "Select";
    }

    public void turnEquipOn()
    {
        isEquipOn = !isEquipOn;
        GameManager.instance.isEquipOn = !GameManager.instance.isEquipOn;
        Debug.Log("IsEquip status: " + isEquipOn);
    }

    public void equipBackAndHome() // tidying for back and home buttons
    {
        turnEquipOn();
        currentNewItems = 0;
        if (keyboardKeyI == true)
        {
            PanelTestingKeyboardControl();
            mainMenu.GetComponent<UIFader>().FadeIn(); // this is calling the fade-in
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        GameObject.FindGameObjectWithTag("NewItemsNofify").GetComponent<CanvasGroup>().alpha = 0;
        GameManager.instance.isItemSelected = false;
        UpdateItemsInventory();

    }

    public void PanelTestingKeyboardControl()
    {
        GameManager.instance.isInterfaceOn = !GameManager.instance.isInterfaceOn;

        if (panelTesting.GetComponent<CanvasGroup>().alpha == 0)
        {
            isEquipOn = true;
            GameManager.instance.isEquipOn = true;
            keyboardKeyI = true;
            GameManager.instance.keyboardKeyI = true;
            UpdateItemsInventory();
            UpdateStats();
            joystick.DisableJoystick();
            panelTesting.GetComponent<UIFader>().FadeIn(); // this is calling the fade-in
            panelTesting.GetComponent<CanvasGroup>().interactable = true;
            panelTesting.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log("E Key on");

        }
        else if (panelTesting.GetComponent<CanvasGroup>().alpha == 1)
        {
            isEquipOn = false;
            GameManager.instance.isEquipOn = false;
            UpdateItemsInventory();
            keyboardKeyI = false;
            GameManager.instance.keyboardKeyI = false;
            Debug.Log("E Key off");
            panelTesting.GetComponent<UIFader>().FadeOut(); // call a function from another script
            panelTesting.GetComponent<CanvasGroup>().interactable = false;
            panelTesting.GetComponent<CanvasGroup>().blocksRaycasts = false;
            joystick.EnableJoystick();

        }
    }



    // UI Tweeing on Equipment left panel, animations

    public void OnUseButton()
    {
        mainEquipInfoPanel.DOAnchorPos(new Vector2(-750, 0), 1f);

        if (activeItem.itemType == ItemsManager.ItemType.Potion)
        {
            characterChoicePanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }

        else if (activeItem.itemType == ItemsManager.ItemType.Armour || activeItem.itemType == ItemsManager.ItemType.Weapon)
        {
            characterWeaponryPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        }


    }

    public void OnPlayerButton() // CALLS PANEL TWEEN
    {

        StartCoroutine(DelayPanelReturn());

    }

    IEnumerator DelayPanelReturn()
    {

        Debug.Log("InventoryLeft panel animations engaged");

        if (activeItem.itemName == "Red Healing Potion" || activeItem.itemName == "Green Healing Potion")
        {
            hpEquipToString[panelStuff].text = playerStats[panelStuff].npcHP.ToString();
            var sequence = DOTween.Sequence()
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(hpEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(hpEquipSlider[panelStuff].DOValue(playerStats[panelStuff].npcHP + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);


            yield return new WaitForSecondsRealtime(2f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);

            Debug.Log("Slider HP fill scale enacted");
        }

        else if (activeItem.itemName == "Mana Potion")
        {
            manaEquipToString[panelStuff].text = playerStats[panelStuff].npcMana.ToString();
            var sequence = DOTween.Sequence()
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(2.2f, 0.2f))
                .Append(manaEquipSlider[panelStuff].GetComponentInChildren<Transform>().DOScaleY(1f, 0.6f))
                .Join(manaEquipSlider[panelStuff].DOValue(playerStats[panelStuff].npcMana + activeItem.amountOfEffect, 1.8f));
            sequence.SetLoops(1, LoopType.Yoyo);

            Debug.Log("Slider Mana fill expand and slide");


            yield return new WaitForSecondsRealtime(2f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);

        }
        else if (activeItem.itemType == ItemsManager.ItemType.Armour || activeItem.itemType == ItemsManager.ItemType.Weapon)
        {

            if (activeItem.itemType == ItemsManager.ItemType.Armour)
            {
                equipCharStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(2f, 0.4f))
                    .Append(equippedArmourImage[panelStuff].GetComponent<Transform>().DOScale(0.8f, 0.4f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }
            if (activeItem.itemType == ItemsManager.ItemType.Weapon)
            {
                equipCharStats();
                var sequence = DOTween.Sequence()
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(2f, 0.4f))
                    .Append(equippedWeaponImage[panelStuff].GetComponent<Transform>().DOScale(1f, 0.4f));
                sequence.SetLoops(1, LoopType.Yoyo);
            }

            yield return new WaitForSecondsRealtime(1f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
            characterWeaponryPanel.DOAnchorPos(new Vector2(0, 1200), 1f);

        }

        yield return new WaitForSecondsRealtime(0.3f);
        mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);

    }

    public void onCancelButton()
    {
        StartCoroutine(PanelCancel());
    }

    IEnumerator PanelCancel()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        characterWeaponryPanel.DOAnchorPos(new Vector2(0, 1200), 1f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);
    }

    public void FadeOutText(float duration)
    {
        Fade(0f, duration, () =>
        {
            chooseText.interactable = false;
            chooseText.blocksRaycasts = false;
        });
    }

    public void FadeInText(float duration)
    {
        Fade(1f, duration, () =>
        {
            chooseText.interactable = true;
            chooseText.blocksRaycasts = true;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeText != null)
        {
            fadeText.Kill(false);
        }

        fadeText = chooseText.DOFade(endValue, duration);
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
        weaponBool = armourBool = itemBool = potionBool = skillBool = false;

        if (boolName == "weapon") weaponBool = true;
        else if (boolName == "armour") armourBool = true;
        else if (boolName == "item") itemBool = true;
        else if (boolName == "potion") potionBool = true;
        else if (boolName == "skill") skillBool = true;
        if (boolName != "all")
        {
            TextMeshProUGUI allText = GameObject.FindGameObjectWithTag("allTab").GetComponent<TextMeshProUGUI>();
            allText.color = new Color32(82, 77, 80, 255);
        }

        if (boolName == "all")
        {
            TextMeshProUGUI allText = GameObject.FindGameObjectWithTag("allTab").GetComponent<TextMeshProUGUI>();
            allText.color = new Color32(236, 216, 150, 255);
        }
        UpdateItemsInventory();
        Debug.Log("Sort by item initiated: " + boolName);
    }

    public void TeamUISettings(string teamPanelTrigger)
    {


        if (teamPanelTrigger == "overview")
        {

            isOverviewOn = true;
            isStatsOn = false;
            isWeaponryOn = false;

            
            WhichPanelIsOn();

            focusTitle.text = "Overview";

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

            //GameObject.FindGameObjectWithTag("fade_back_party").GetComponent<CanvasGroup>().alpha = 0;

            teamTabMenu.GetComponent<CanvasGroup>().interactable = false;
            teamTabMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

            WhichPanelIsOn();

            Debug.Log("Panel status - Overview: " + GameObject.FindGameObjectWithTag("overviewPanel").GetComponent<CanvasGroup>().alpha + " | Stats: " + GameObject.FindGameObjectWithTag("statsPanel").GetComponent<CanvasGroup>().alpha + " | Weaponry: " + GameObject.FindGameObjectWithTag("weaponryPanel").GetComponent<CanvasGroup>().alpha);

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


}




//public IEnumerator FadeInCall()
//{
//    yield return new WaitForSeconds(1f);
//    FadeIn(1f);
//}

//public IEnumerator FadeOutCall()
//{
//    yield return new WaitForSeconds(1f);
//    FadeOut(1f);
//}
