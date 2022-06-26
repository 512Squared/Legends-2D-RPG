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
    public Transform deletedItems;
    public int objectInt = 1;
    public SceneHandling sceneHandler;
    public ClockManager clockManager;

    public string firstScene = "Homestead";
    public float startTime;


    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInterfaceOn, dialogueBoxOpened;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isInventoryOn, isPlayerInShop, isShopUIOn;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool isItemSelected;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool keyboardKeyI;

    [Title("Messaging")] [Space] public TextMeshProUGUI playerMessages;


    public Transform gridParent;

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
        sceneHandler = GetComponent<SceneHandling>();
        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();
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

    public void SceneChange(string scene, int indexFrom, int indexTo)
    {
        sceneObjects[indexTo].SetActive(true);
        sceneObjects[indexFrom].SetActive(false);
        objectInt = indexTo;
        ActivateCharacters(scene);
        firstScene = scene;
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }

    public void ActivateCharacters(string sceneToLoad)
    {
        int playersActivated = 0;
        foreach (PlayerStats t in playerStats)
        {
            if (sceneToLoad == t.homeScene)
            {
                t.gameObject.SetActive(true);
                playersActivated++;
            }
            else if (sceneToLoad != t.homeScene)
            {
                t.gameObject.SetActive(false);
            }
        }

        Debug.Log($"Players activated in Scene: {playersActivated}");
        playerStats[0].gameObject.SetActive(true); // Thulgran
    }

    private void IsInterfaceOn()
    {
        isInterfaceOn = !isInterfaceOn;
    }


    private void Shop(string scene, SceneObjectsLoad sceneObjectsLoad)
    {
        if (sceneObjectsLoad is SceneObjectsLoad.shop1 or SceneObjectsLoad.shop2 or SceneObjectsLoad.shop3)
        {
            ShopManager.Instance.isPlayerInsideShop = true;
            Debug.Log($"Scene Name: {scene}");
            Shop enumShopType = (Shop)Enum.Parse(typeof(Shop), scene);
            Debug.Log($"Enum shop type: {enumShopType}");
            ShopManager.Instance.ShopType(enumShopType);
            ShopManager.Instance.UpdateShopItemsInventory();
            StartCoroutine(SecretShopSetup(scene));
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

    private static IEnumerator SecretShopSetup(string scene)
    {
        yield return null;
        SecretShopSection.Instance.SetShopType(scene);
    }

    #endregion

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.sceneData.currentScene = firstScene;
        a_SaveData.sceneData.sceneObjects = objectInt;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void LoadFromSaveData(SaveData a_SaveData)
    {
        firstScene = a_SaveData.sceneData.currentScene;

        // Assign saved object data
        sceneHandler.SetSceneObjects(a_SaveData.sceneData.currentScene);

        // Load scene objects
        sceneObjects[SceneHandling.SceneObjectsInt(sceneHandler.sceneObjectsLoad)].SetActive(true);

        // Initialise shop
        if (firstScene is "shop1" or "shop2" or "shop3")
        {
            Shop(firstScene, sceneHandler.sceneObjectsLoad);
            clockManager.SceneChange(firstScene, 0, 0);
        }

        // Load saved Scene
        SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);

        // Initialise NPCs
        ActivateCharacters(firstScene);

        Debug.Log($"Scene loaded from save: {firstScene}");
    }

    #endregion
}