using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject mainMenu;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] thulgranGold, ThulgranSpells, thulgranPotions, characterName, description, level, xp, mana, health, dexterity, defence, intelligence, perception,levelP;
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
                mainMenu.GetComponent<UIFader>().FadeOut(); // call a function from another script
                mainMenu.GetComponent<CanvasGroup>().interactable = false;
                mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                GameManager.instance.mKeyPressed = false;
                
            }
            else
            {
                UpdateStats();
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
                Debug.Log(playerStats[i].playerName + " (LEVEL " + playerStats[i].npcLevel + ") is now active");
                characterCards[i].SetActive(true);
                //characterParty[i].SetActive(true); // switched off until slots are ready
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
            }
        }

    }


    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }


}

 