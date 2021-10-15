using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{


    //myObject.GetComponent<MyScript>().MyFunction();


    // game manager is holding the player stats and preserving them. It's public, which allows it to be called. 

    public static GameManager instance;



    // this is probably going to get called later. It's an array to hold the player stats

    private PlayerStats[] playerStats;


    public bool mKeyPressed, dialogueBoxOpened;

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
        if (mKeyPressed || dialogueBoxOpened)
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