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

    public static MenuManager instance;

    private int panelStuff;

    //adding serializeField gives possibility to add Simple Joystick object in inspector and thereby share its functions. Not possible if in prefab unless both are in a prefab

    public static int select;

    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI[] characterName, characterNameP, thulGold, thulMana, description, level, levelP, xp, mana, health, dexterity, defence, intelligence, perception;
    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject[] characterCards, characterParty, characterEquip;

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
    [SerializeField] GameObject itemBox;
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
    public TextMeshProUGUI manaEquipTopBar, hpEquipTopBar, goldEquipTopBar;


    [ShowInInspector]
    [Title("INVENTORY")]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public int currentNewItems;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    [SerializeField] TextMeshProUGUI newItemsText;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    public ItemsManager activeItem; //what are we doing here? Creating a slot in inspector for an 'active item', which is an object that has an ItemsManager script attached?


    [BoxGroup("UI Bools")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    [SerializeField] bool[] isTeamMember;
    [BoxGroup("UI Bools")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isEquipOn = false;
    [BoxGroup("UI Bools")]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool keyboardKeyI = false;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)



    [Header("UI Tweening")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private CanvasGroup chooseText;
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI textUseEquipTake;
    [GUIColor(1f, 1f, 0.215f)]
    public RectTransform mainEquipInfoPanel, characterChoicePanel;


    [Header("Player Choice")]
    [GUIColor(1f, 0.2f, 0.515f)]
    [SerializeField] TextMeshProUGUI[] playerChoice;
    [GUIColor(1f, 0.2f, 0.515f)]
    [SerializeField] Sprite buttonGrey;


<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public bool controlSwitch = false;

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
    public bool controlSwitch = false;

>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
    private Tween fadeText;


    private void Start()
    {

        instance = this;
        mainEquipInfoPanel.DOAnchorPos(Vector2.zero, 0f);
        
        DontDestroyOnLoad(gameObject);

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
            if (isTeamMember[i] == true)
            {
                //Debug.Log(playerStats[i].playerName + " (LEVEL " + playerStats[i].npcLevel + ") is now active");
                characterCards[i].SetActive(true);
                characterParty[i].SetActive(true);
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

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;


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

                // ITEM SORTING

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

                        else if (item.itemName == "Healing Potion")
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
        //manaEquipTopBar.text = playerStats[0].npcMana.ToString();
        //hpEquipTopBar.text = playerStats[0].npcHP.ToString();
        //goldEquipTopBar.text = playerStats[0].thulGold.ToString();
    }

    public void InventoryStats()
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


        // grey out the button

        GameObject.FindGameObjectWithTag("button_use").GetComponent<Image>().sprite = buttonGrey;
        GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable = false;
        GameObject.FindGameObjectWithTag("text_UseEquipTake").GetComponent<TextMeshProUGUI>().color = new Color(0.270f, 0.270f, 0.270f, 1);

        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {

            isTeamMember[i] = playerStats[i].isTeamMember;
            if (isTeamMember[i] == true)
            {
                //text
                characterEquip[i].SetActive(true);
                hpEquipToString[i].text = playerStats[i].npcHP.ToString();
                manaEquipToString[i].text = playerStats[i].npcMana.ToString();
                defenceEquipToString[i].text = playerStats[i].npcDefence.ToString();
                //sliders
                hpEquipSlider[i].value = playerStats[i].npcHP;
                manaEquipSlider[i].value = playerStats[i].npcMana;
                defenceEquipSlider[i].value = playerStats[i].npcDefence;
                characterMugEquip[i].sprite = playerStats[i].characterMug;

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

    public void CallToSellItem()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        Debug.Log("Sell item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " + "Item: " + activeItem.itemName);
        Inventory.instance.SellItem(activeItem, selectedCharacter);

        UpdateItemsInventory();


=======
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Inventory.instance.SellItem(activeItem);
        UpdateItemsInventory();
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
    }

    public void CallToUseItem(int selectedCharacter)
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        Debug.Log("Use item initiated | Selected character: " + playerStats[selectedCharacter].playerName + " | " + "Item: " + activeItem.itemName);
        activeItem.UseItem(selectedCharacter);
        panelStuff = selectedCharacter;
=======
        Debug.Log("UseItem initiated");
        activeItem.UseItem(selectedCharacter);
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Debug.Log("UseItem initiated");
        activeItem.UseItem(selectedCharacter);
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Debug.Log("UseItem initiated");
        activeItem.UseItem(selectedCharacter);
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Debug.Log("UseItem initiated");
        activeItem.UseItem(selectedCharacter);
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
=======
        Debug.Log("UseItem initiated");
        activeItem.UseItem(selectedCharacter);
>>>>>>> parent of c72fc792 (added selectedCharacter (slider related) + bug fixes + nightly build)
        Inventory.instance.UseAndRemoveItem(activeItem, selectedCharacter);
        GameObject.FindGameObjectWithTag("text_UseEquipTake").GetComponent<TextMeshProUGUI>().color = new Color(0.015f, 0.352f, 0.223f, 1);

        UpdateItemsInventory();
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
        characterChoicePanel.DOAnchorPos(new Vector2(0, 0), 1f);
    }

    public void OnPlayerButton()
    {

        StartCoroutine(DelayPanelReturn());
        UpdateStats();
    }


    IEnumerator DelayPanelReturn()
    {
        if (panelStuff != 0)
        {

            Debug.Log("Giving stuff to other characters");
            //playerStats[panelStuff].npcHP += activeItem.amountOfEffect;
            if (activeItem.itemName == "Healing Potion")
            {
                hpEquipToString[panelStuff].text = playerStats[panelStuff].npcHP.ToString();
                hpEquipSlider[panelStuff].value = playerStats[panelStuff].npcHP;
            }

            else if (activeItem.itemName == "Mana Potion")
            {
                manaEquipToString[panelStuff].text = playerStats[panelStuff].npcMana.ToString();
                manaEquipSlider[panelStuff].value = playerStats[panelStuff].npcMana;
            }

            yield return new WaitForSecondsRealtime(1.2f);
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);

        }
        
        else
        {
            mainEquipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
            characterChoicePanel.DOAnchorPos(new Vector2(0, 1200), 1f);
        }
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
