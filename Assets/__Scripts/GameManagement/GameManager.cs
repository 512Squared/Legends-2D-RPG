using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using DG.Tweening.Core;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    #region Serialized Fields

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Item activeItem;

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public int currentNewItems;

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public int shopCurrentNewItems;


    // this is probably going to get called later. It's an array to hold the player stats
    [Space] public PlayerStats[] playerStats;
    public MagicManager[] magicManager;
    public GameObject[] sceneObjects;


    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInterfaceOn, dialogueBoxOpened;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInventoryOn, isPlayerInShop, isShopUIOn;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isItemSelected;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool keyboardKeyI;

    [Title("Messaging")] [Space] public TextMeshProUGUI playerMessages;
    private string _firstScene;

    private List<ISaveable> _saveables;

    #endregion

    #region Callbacks

    // Start is called before the first frame update


    private void OnEnable()
    {
        Actions.OnHomeButton += HomeButton;
        Actions.OnMainMenuButton += MainMenuButton;
        Actions.OnResumeButton += ResumeButton;
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        yield return new WaitForFixedUpdate();
        SaveDataManager.LoadJsonData(_saveables);
    }


    private void OnDisable()
    {
        Actions.OnHomeButton -= HomeButton;
        Actions.OnMainMenuButton -= MainMenuButton;
        Actions.OnResumeButton -= ResumeButton;
    }

    private void OnDestroy()
    {
        SaveDataManager.SaveJsonData(_saveables);
    }

    private void Start()
    {
        Instance = this;

        _firstScene = "Homestead";

        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

        magicManager = FindObjectsOfType<MagicManager>().OrderBy(m => m.transform.position.z).ToArray();

        ActivateCharacters(_firstScene);
        sceneObjects[1].SetActive(true);

        _saveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToList();

        Debug.Log($"ISaveable List Count: {_saveables.Count}");
    }

// Update is called once per frame
    private void Update()
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

    #endregion

    #region Callback functions

    private void ResumeButton()
    {
        IsInterfaceOn();
    }

    private void HomeButton()
    {
        IsInterfaceOn();
    }

    private void MainMenuButton()
    {
        IsInterfaceOn();
    }

    #endregion

    #region Methods

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
        foreach (PlayerStats t in playerStats)
        {
            if (sceneToLoad == t.homeScene)
            {
                t.gameObject.SetActive(true);
                Debug.Log(t.playerName + " is active in " + sceneToLoad);
            }
            else if (sceneToLoad != t.homeScene)
            {
                t.gameObject.SetActive(false);
            }
        }

        playerStats[0].gameObject.SetActive(true); // Thulgran
    }

    private void IsInterfaceOn()
    {
        isInterfaceOn = !isInterfaceOn;
    }

    #endregion
}