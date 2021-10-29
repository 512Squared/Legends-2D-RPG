using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

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




    // this is probably going to get called later. It's an array to hold the player stats
    [Space]
    public PlayerStats[] playerStats;


    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isInterfaceOn, dialogueBoxOpened;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isEquipOn;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool isItemSelected;
    [BoxGroup("UI Bools")]
    [GUIColor(1f, 1f, 0.215f)]
    public bool keyboardKeyI = false;




    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);


        playerStats = FindObjectsOfType<PlayerStats>();



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