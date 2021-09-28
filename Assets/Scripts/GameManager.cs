using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    // game manager is holding the player stats and preserving them. It's public, which allows it to be called. 
    
    public static GameManager instance;

    
    // this is probably going to get called later. It's an array to hold the player stats
    
    [SerializeField] PlayerStats[] playerStats;




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
        
    }
}
