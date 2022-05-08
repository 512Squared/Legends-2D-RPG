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
    public Item activeItem; // this is just for tracking activeItems in UI

    [GUIColor(0.447f, 0.654f, 0.996f)]
    public string activeScene = "Homestead";

    [GUIColor(0.447f, 0.654f, 0.996f)]
    public int currentNewItems;

    [GUIColor(0.447f, 0.654f, 0.996f)]
    public int shopCurrentNewItems;

    [Space] public PlayerStats[] playerStats;

    public Transform[] pickupParents;

    public GameObject[] sceneObjects;

    public Transform pickedUpItems;
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
        Actions.OnSceneChange += SceneChange;
    }

    private void OnDisable()
    {
        Actions.OnHomeButton -= HomeButton;
        Actions.OnMainMenuButton -= MainMenuButton;
        Actions.OnResumeButton -= ResumeButton;
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
        _saveables = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveable>().ToList();
        Debug.Log($"Save items count: {_saveables.Count}");

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

    public void ResetGame()
    {
        SceneManager.UnloadSceneAsync(_firstScene);
        SaveDataManager.DeleteJsonData(_saveables);
    }

    public void SaveGame()
    {
        SaveDataManager.SaveJsonData(_saveables);
    }

    public void QuitGame()
    {
        SaveDataManager.SaveJsonData(_saveables);
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

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.sceneData.currentScene = _firstScene;
        a_SaveData.sceneData.sceneObjects = objectInt;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _firstScene = a_SaveData.sceneData.currentScene;
        // Load saved Scene
        SceneManager.LoadScene(_firstScene, LoadSceneMode.Additive);

        // Assign saved object data
        _sceneHandler.SetSceneObjects(a_SaveData.sceneData.currentScene);

        // Load scene objects
        sceneObjects[SceneHandling.SceneObjectsInt(_sceneHandler.sceneObjectsLoad)].SetActive(true);

        // Initialise shop
        Shop(_firstScene, _sceneHandler.sceneObjectsLoad);

        // Initialise NPCs
        ActivateCharacters(_firstScene);

        Debug.Log($"Scene loaded from save: {_firstScene}");
    }

    #endregion
}