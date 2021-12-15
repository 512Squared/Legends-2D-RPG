using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System.Linq;
using TMPro;

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




    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

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


}