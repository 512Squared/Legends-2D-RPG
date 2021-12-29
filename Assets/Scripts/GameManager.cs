using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    //myObject.GetComponent<MyScript>().MyFunction();rob


    // game manager is holding the player stats and preserving them. It's public, which allows it to be called. 

    public static GameManager instance;


    [Title("Management")]
    [GUIColor(0.878f, 0.219f, 0.219f)]
    [SerializeField] MenuManager menuManager;
    [GUIColor(0.878f, 0.219f, 0.219f)]
    [SerializeField] CoinsManager coinsManager;

    [Space]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public ItemsManager activeItem;
    [Space]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public int currentNewItems;
    [Space]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    public int shopCurrentNewItems;




    // this is probably going to get called later. It's an array to hold the player stats
    [Space]
    public PlayerStats[] playerStats;
    public MagicManager[] magicManager;
    public GameObject[] sceneObjects;


    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isInterfaceOn, dialogueBoxOpened;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isEquipOn, isShopOn;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isItemSelected;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool keyboardKeyI = false;

    
    public TextMeshProUGUI playerMessages;
    private string firstScene;




    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        firstScene = "Homestead";

        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

        magicManager = FindObjectsOfType<MagicManager>().OrderBy(m => m.transform.position.z).ToArray();

        ActivateCharacters(firstScene);

    }

    // Update is called once per frame
    void Update()
    {
        if (isInterfaceOn || dialogueBoxOpened)
        {
            PlayerGlobalData.instance.deactivedMovement = true;
        }
        else
        {
            PlayerGlobalData.instance.deactivedMovement = false;
        }


    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }

    public MagicManager[] GetMagicManager()
    {
        return magicManager;
    }

    public void ActivateCharacters(string sceneToLoad)
    {

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (sceneToLoad == playerStats[i].homeScene)
            {
                playerStats[i].gameObject.SetActive(true);
                Debug.Log(playerStats[i].playerName + " is active in " + sceneToLoad);
            }
            else if (sceneToLoad != playerStats[i].homeScene)
            {
                playerStats[i].gameObject.SetActive(false);
            }
        }

        playerStats[0].gameObject.SetActive(true);
        
        Debug.Log("Thulgran's Status: " + playerStats[0].enabled);
    }


}