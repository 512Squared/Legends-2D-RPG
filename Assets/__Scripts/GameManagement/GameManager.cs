using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour, ISaveable
{
    public static GameManager Instance;

    #region Serialized Fields

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public Item activeItem;

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public string activeScene = "Homestead";

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public int currentNewItems;

    [Space] [GUIColor(0.447f, 0.654f, 0.996f)]
    public int shopCurrentNewItems;

    // this is probably going to get called later. It's an array to hold the player stats
    [Space] public PlayerStats[] playerStats;
    public MagicManager[] magicManager;
    public GameObject[] sceneObjects;
    public int objectInt = 1;
    private SceneHandling _sceneHandler;


    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInterfaceOn, dialogueBoxOpened;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInventoryOn, isPlayerInShop, isShopUIOn;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isItemSelected;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool keyboardKeyI;

    [Title("Messaging")] [Space] public TextMeshProUGUI playerMessages;

    private string _firstScene = "Homestead";

    private List<ISaveable> _saveables;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        Actions.OnHomeButton += HomeButton;
        Actions.OnMainMenuButton += MainMenuButton;
        Actions.OnResumeButton += ResumeButton;
        Actions.OnGameExit += SaveGame;
        Actions.OnSceneChange += SceneChange;
    }

    private void OnDisable()
    {
        Actions.OnHomeButton -= HomeButton;
        Actions.OnMainMenuButton -= MainMenuButton;
        Actions.OnResumeButton -= ResumeButton;
        Actions.OnGameExit -= SaveGame;
        Actions.OnSceneChange -= SceneChange;
    }


    private void Update()
    {
        if (isInterfaceOn || dialogueBoxOpened)
        {
            PlayerGlobalData.Instance.deactivedMovement = true;
        }
        else
        {
            PlayerGlobalData.Instance.deactivedMovement = false;
        }
    }

    private void Start()
    {
        Instance = this;
        _sceneHandler = GetComponent<SceneHandling>();
        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();
        magicManager = FindObjectsOfType<MagicManager>().OrderBy(m => m.transform.position.z).ToArray();
        _saveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToList();

        StartCoroutine(Initialize());
    }


    private IEnumerator Initialize()
    {
        yield return null;
        SaveDataManager.LoadJsonData(_saveables);
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

    public void SaveGame()
    {
        SaveDataManager.SaveJsonData(_saveables);
    }

    public void QuitGame()
    {
        Actions.OnGameExit?.Invoke();
        Application.Quit();
    }

    public void LoadGame()
    {
        SaveDataManager.LoadJsonData(_saveables);
    }

    public void SceneChange(string scene, int indexFrom, int indexTo)
    {
        _firstScene = scene;
        sceneObjects[indexTo].SetActive(true);
        sceneObjects[indexFrom].SetActive(false);
        objectInt = indexTo;
        ActivateCharacters(scene);
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

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.sceneData.currentScene = _firstScene;
        a_SaveData.sceneData.sceneObjects = objectInt;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _firstScene = a_SaveData.sceneData.currentScene;
        SceneManager.LoadScene(_firstScene, LoadSceneMode.Additive);
        _sceneHandler.SetSceneObjects(a_SaveData.sceneData.currentScene);
        sceneObjects[SceneHandling.SceneObjectsInt(_sceneHandler.sceneObjectsLoad)].SetActive(true);
        Shop(_firstScene, _sceneHandler.sceneObjectsLoad);
        ActivateCharacters(_firstScene);
        Debug.Log($"Scene loaded from save: {_firstScene}");
    }

    private static void Shop(string scene, SceneObjectsLoad sceneObjectsLoad)
    {
        if (sceneObjectsLoad is SceneObjectsLoad.shop1 or SceneObjectsLoad.shop2 or SceneObjectsLoad.shop3)
        {
            ShopManager.Instance.isPlayerInsideShop = true;
            Debug.Log($"Scene Name: {scene}");
            Shop enumShopType = (Shop)Enum.Parse(typeof(Shop), scene);
            Debug.Log($"Enum shop type: {enumShopType}");
            ShopManager.Instance.ShopType(enumShopType);
            SecretShopSection.Instance.SetShopType(scene);
            ShopManager.Instance.UpdateShopItemsInventory();
        }

        else if (scene == "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size =
                new Vector2(1.12f, 1.8f);
        }

        else if (scene != "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size =
                new Vector2(1.12f, 1.31f);
        }
    }

    #endregion
}