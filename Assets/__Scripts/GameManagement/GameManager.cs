using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Rendering.UI;


public class GameManager : MonoBehaviour, ISaveable
{
    public static GameManager Instance;


    #region Serialized Fields

    [DetailedInfoBox("Game elements that exist but are not fully implemented...",
        "THERE ARE FIVE GAME ELEMENTS THAT EXIST BUT AREN'T FULLY IMPLEMENTED \n \n 1. ATTACKS: Additional character attacks (two handed, bow,gun, dodge, etc) \n \n 2. SPELL SYSTEM: 16 types of spells and also VFX animations \n \n 3. ABILITIES - this includes the spell system, but also stuff like cooldown \n \n 4. MODIFIERS: for the wearable items. E.g. Reinforced, Refined, Sharpened, Lightweight, Bleeding \n \n 5. ITEM PARAMETERS: some elements are currently hidden, e.g item type, class, rarity, weight, properties \n ",
        VisibleIf = "showInfo")]
    [Space] public bool showInfo;

    [Title("Debug Options")]
    [FoldoutGroup("Debugging")]
    public bool initialization;

    [FoldoutGroup("Debugging")]
    public bool items;

    [FoldoutGroup("Debugging")]
    public bool inventory;

    [FoldoutGroup("Debugging")]
    public bool saveLoad;

    [FoldoutGroup("Debugging")]
    public bool artificialIntelligence;

    [FoldoutGroup("Debugging")]
    public bool gameAudio;

    [FoldoutGroup("Debugging")]
    public bool collections;

    [FoldoutGroup("Debugging")]
    public bool quests;

    [FoldoutGroup("Debugging")]
    public bool battle;


    [Title("Game Settings")]
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

    public Transform[] itemsForPickup;
    public Transform pickedUpItems;
    public Transform deletedItems;
    public int sceneIndex = 1;
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

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool pathfindingObstacleDebug;

    [BoxGroup("UI Bools")] [GUIColor(1f, 1f, 0.215f)]
    public bool gridDebug;


    [Title("Messaging")] [Space] public TextMeshProUGUI playerMessages;


    public Transform gridParent;
    [SerializeField] public bool isPaused;
    [SerializeField] public bool crosshairsOn;

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
            isPaused = true;
        }
        else
        {
            PlayerGlobalData.Instance.deactivedMovement = false;
            isPaused = false;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        sceneHandler = GetComponent<SceneHandling>();
        sceneIndex = 0;
        playerStats = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();
        StartCoroutine(DelayedInitialisation());
    }

    private static IEnumerator DelayedInitialisation()
    {
        yield return new WaitForEndOfFrame();
        MenuManager.Instance.HomeScreenStats();
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

    public void ToggleCrosshairs()
    {
        crosshairsOn = !crosshairsOn;
        Actions.OnCrosshairsChanged?.Invoke();
    }


    public void SceneChange(string scene, string previousScene, int indexFrom, int indexTo)
    {
        sceneObjects[indexTo].SetActive(true);
        sceneObjects[indexFrom].SetActive(false);
        sceneIndex = indexTo;
        ActivateCharacters(scene);
        firstScene = scene;
        Debug.Log($"OnSceneLoad Invoke: {scene}");
        Actions.OnSceneLoad?.Invoke(scene, previousScene);
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }


    public void SendPlayersToPhotobooth()
    {
        foreach (PlayerStats player in GetPlayerStats())
        {
            if (player.gameObject.activeInHierarchy)
            {
                player.SayCheese();
            }
        }
    }

    public void ActivateCharacters(string sceneToLoad)
    {
        int playersActivated = 0;
        foreach (PlayerStats t in playerStats)
        {
            if (t.playerName != "Thulgran")
            {
                if (sceneToLoad == t.homeScene.ToString())
                {
                    t.gameObject.SetActive(true);
                    playersActivated++;
                }
                else if (sceneToLoad != t.homeScene.ToString())
                {
                    t.gameObject.SetActive(false);
                }
            }
        }

        if (initialization) { Debug.Log($"Players activated in {sceneToLoad}: {playersActivated}"); }
    }

    private void IsInterfaceOn()
    {
        isInterfaceOn = !isInterfaceOn;
    }


    private void Shop(string scene, SceneObjectsLoad sceneObjectsLoad)
    {
        if (sceneObjectsLoad is SceneObjectsLoad.Shop1 or SceneObjectsLoad.Shop2 or SceneObjectsLoad.Shop3)
        {
            ShopManager.Instance.isPlayerInsideShop = true;
            ShopManager.Instance.ShopType(scene);
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


    private IEnumerator ActivateFirstScene()
    {
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Additive);

        while (asyncLoadLevel is {isDone: false})
        {
            yield return new WaitForEndOfFrame();
            AstarPath.active.data.LoadFromCache();
        }
    }

    #endregion

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.sceneData.currentScene = firstScene;
        a_SaveData.sceneData.sceneObjects = sceneIndex;
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
        if (firstScene is "Shop1" or "Shop2" or "Shop3")
        {
            Shop(firstScene, sceneHandler.sceneObjectsLoad);
            clockManager.SceneChange(firstScene, "", 0, 0);
        }

        StartCoroutine(ActivateFirstScene());

        // Initialise NPCs
        ActivateCharacters(firstScene);

        // Initialise Scene Audio
        AudioManager.Instance.SetSceneDynamicAudio(firstScene, "");
    }

    #endregion
}