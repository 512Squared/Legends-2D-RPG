using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Sirenix.OdinInspector;



public class MenuManager : MonoBehaviour
{

    [SerializeField] PlayerStats[] playerStats;
    [SerializeField] GameObject[] statsButtons;

    [FoldoutGroup("Miscellaneous", expanded: false)]
    [SerializeField] GameObject mainMenu;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [SerializeField] Image imageToFade;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [SerializeField] TMP_Dropdown droppy; // dropbox for the dropdown object (hence, TMP_Dropdown)
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [SerializeField] private UltimateJoystick joystick;
    [FoldoutGroup("Miscellaneous", expanded: false)]
    [SerializeField] GameObject panelTesting;




    public static MenuManager instance;


    //adding serializeField gives possibility to add Simple Joystick object in inspector and thereby share its functions. Not possible if in prefab unless both are in a prefab



    public static int select;


    
    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI[] characterName, characterNameP, thulGold, thulMana, description, level, levelP, xp, mana, health,  dexterity, defence, intelligence, perception;
    [TabGroup("Char Stats")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject[] characterCards, characterParty;

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

    private int countEn = 0;
    private int countDis = 0;

    [ShowInInspector]

    [GUIColor(0.878f, 0.219f, 0.219f)]
    [Title("INVENTORY")]
    public ItemsManager activeItem; //what are we doing here? Creating a slot in inspector for an 'active item', which is an object that has an ItemsManager script attached?

        

    [BoxGroup("UI Bools")]
    [SerializeField] bool[] isTeamMember;

    

    private void Start()
    {

        instance = this;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mainMenu.GetComponent<CanvasGroup>().alpha == 0)
            {
                mainMenu.GetComponent<UIFader>().FadeIn(); // this is calling the fade-in
                mainMenu.GetComponent<CanvasGroup>().interactable = true;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                ButtonHandler.instance.IsinterfaceOn();
            }
            else
            {
                mainMenu.GetComponent<UIFader>().FadeOut(); // call a function from another script
                mainMenu.GetComponent<CanvasGroup>().interactable = false;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                ButtonHandler.instance.IsinterfaceOn();
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (panelTesting.GetComponent<CanvasGroup>().alpha == 0)
            {
                UpdateItemsInventory();
                UpdateStats();
                joystick.DisableJoystick();
                panelTesting.GetComponent<UIFader>().FadeIn(); // this is calling the fade-in
                panelTesting.GetComponent<CanvasGroup>().interactable = true;
                panelTesting.GetComponent<CanvasGroup>().blocksRaycasts = true;
                GameManager.instance.dialogueBoxOpened = true;


               
            }
            else if (panelTesting.GetComponent<CanvasGroup>().alpha == 1)
            {
                panelTesting.GetComponent<UIFader>().FadeOut(); // call a function from another script
                panelTesting.GetComponent<CanvasGroup>().interactable = false;
                panelTesting.GetComponent<CanvasGroup>().blocksRaycasts = false;
                GameManager.instance.dialogueBoxOpened = false;
                joystick.EnableJoystick();


            }
        }
    }


    public void UpdateStats()
    {

        playerStats = GameManager.instance.GetPlayerStats().OrderBy(m => m.transform.position.z).ToArray();

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
                thulMana[i].text = playerStats[0].npcMana.ToString();
                thulPotions.text = playerStats[0].thulPotions.ToString();
                thulSpells.text = playerStats[0].thulSpells.ToString();


            }
        }

    }


    public void UpdateItemsInventory()
    {
        foreach (Transform itemSlot in itemBoxParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetItemsList())
        {
            RectTransform itemSlot = Instantiate(itemBox, itemBoxParent).GetComponent<RectTransform>();

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
            
            if (item.isNewItem == true)
            {
                item.isNewItem = false;
                itemSlot.Find("New Item").GetComponent<Image>().enabled = true;
            }
            else if (item.isNewItem == false)
            {
                itemSlot.Find("New Item").GetComponent<Image>().enabled = false;
            }

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;

           if (item.itemSelected == false)
            {
                itemSlot.Find("Focus").GetComponent<Image>().enabled = false;
                countEn++;
                Debug.Log(item.itemName + " deselected: " + countEn);
            }

            if (item.itemSelected == true)
            {
                item.itemSelected = false;
                itemSlot.Find("Focus").GetComponent<Image>().enabled = true;
                countDis++;
                Debug.Log(item.itemName + " selected: " + countDis);
            }





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


    public void InventoryStats()
    {

        select = droppy.GetComponent<TMP_Dropdown>().value;  // getting a value from droppy (the object dropbox)
        //Debug.Log(playerStats[select].playerName + " is now active");
        //Debug.Log("SELECT NO: " + select);
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

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }

    public void QuitGame()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }

    public void DiscardItem()
    {
        Debug.Log("DiscardItem initiated");
        Inventory.instance.RemoveItem(activeItem);
        UpdateItemsInventory();

    }


}



//        //itemBox.SetActive(true);
//        //newItem.SetActive(true);
//for (int i = 0; i < itemBox.transform.childCount; i++)
//{

//    }
//    foreach (var x in itemBox.GetComponentsInChildren<Button>())
//    {
//        x.enabled = true;
//    }
//    foreach (var x in itemBox.GetComponentsInChildren<TextMeshProUGUI>())
//    {
//        x.enabled = true;
//    }
//}
//    }