using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xyz;

public class GameManager : MonoBehaviour
{

    
    // game manager is holding the player stats and preserving them. It's public, which allows it to be called. 
    
    public static GameManager instance;



    // this is probably going to get called later. It's an array to hold the player stats

    [SerializeField] PlayerStats[] playerStats;

    
    public bool mKeyPressed, dialogueBoxOpened, settingsOpen;

    [SerializeField] bool[] isTeamMember;

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


        playerStats = Object.FindObjectsOfType<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        if(mKeyPressed || dialogueBoxOpened || settingsOpen)
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
