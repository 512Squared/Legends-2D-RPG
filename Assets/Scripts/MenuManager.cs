using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject mainMenu;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] thulgranGold, ThulgranSpells, thulgranPotions, characterName, characterNumber, description, level, xp, mana, health, dexterity, defence, intelligence, perception,levelP;
    [SerializeField] Slider[] xpS, manaS, healthS, dexterityS, defenceS, intelligenceS, perceptionS;
    [SerializeField] Image[] characterImage,characterImageP;
    [SerializeField] GameObject[] characterCards;
    [SerializeField] GameObject[] characterParty;


    [SerializeField] bool[] isTeamMember;



    private void Start()
    {

        instance = this;
    
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            ButtonHandler.instance.buttonBool();

            if (mainMenu.GetComponent<CanvasGroup>().alpha == 1)
            {
                UpdateStats();

                mainMenu.GetComponent<UIFader>().FadeOut(); // call a function from another script
                mainMenu.GetComponent<CanvasGroup>().interactable = false;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                GameManager.instance.mKeyPressed = false;
                
            }
            else
            {
                mainMenu.GetComponent<UIFader>().FadeIn(); // this is calling the fade in
                mainMenu.GetComponent<CanvasGroup>().interactable = true;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                GameManager.instance.mKeyPressed = true;
            }
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
                Debug.Log(playerStats[i].characterName + " is active");
                characterCards[i].SetActive(true);
                characterParty[i].SetActive(true);
                characterName[i].text = playerStats[i].characterName;
                description[i].text = playerStats[i].characterDesc;
            }
        }

    }


    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }


}
