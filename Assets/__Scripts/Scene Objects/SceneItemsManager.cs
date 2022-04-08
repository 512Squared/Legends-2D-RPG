using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GenerateGUID))]
public class SceneItemsManager : SingletonMonobehaviour<SceneItemsManager>, ISaveable
{
    private Transform _parentItem;
    [SerializeField] private GameObject itemPrefab = null;

    private string _iSaveableUniqueID;

    public string SaveableUniqueID
    {
        get => _iSaveableUniqueID;
        set => _iSaveableUniqueID = value;
    }

    private GameItemsSave _gameItemsSave;

    public GameItemsSave GameItemsSave
    {
        get => _gameItemsSave;
        set => _gameItemsSave = value;
    }

    private void AfterSceneLoad()
    {
        _parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }

    protected override void Awake()
    {
        base.Awake();

        SaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameItemsSave = new GameItemsSave();
    }

    /// <summary>
    /// Destroy items currently in the scene
    /// </summary>
    private void DestroySceneItems()
    {
        // Get all items in the scene
        ItemsManager[] itemsInScene = FindObjectsOfType<ItemsManager>();

        // Loop through all scene items and destroy them
        for (int i = itemsInScene.Length - 1; i > -1; i--)
        {
            Destroy(itemsInScene[i].gameObject);
        }
    }

    public void InstantiateSceneItem(int itemCode, Vector3 itemPosition)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity, _parentItem);
        Item item = itemGameObject.GetComponent<Item>();
        item.Init(itemCode);
    }

    private void InstantiateSceneItems(List<SceneItem> sceneItemList)
    {
        GameObject itemGameObject;

        foreach (SceneItem sceneItem in sceneItemList)
        {
            itemGameObject = Instantiate(itemPrefab,
                new Vector3(sceneItem.position.x, sceneItem.position.y, sceneItem.position.z), Quaternion.identity,
                _parentItem);

            Item item = itemGameObject.GetComponent<Item>();
            item.ItemCode = sceneItem.itemCode;
            item.name = sceneItem.itemName;
        }
    }

    private void OnEnable()
    {
        SaveableRegister();
        //EventHandler.AfterSceneLoadEvent += AfterSceneLoad;
    }

    private void OnDisable()
    {
        SaveableDeregister();
        //EventHandler.AfterSceneLoadEvent -= AfterSceneLoad;
    }


    public void SaveableDeregister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    }

    public void SaveableLoad(GameSave gameSave)
    {
        if (gameSave.GameItemsData.TryGetValue(SaveableUniqueID, out GameItemsSave gameItemsSave))
        {
            GameItemsSave = gameItemsSave;

            // Restore data for current scene
            SaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }


    public void SaveableRestoreScene(string sceneName)
    {
        // if (GameItemsSave.InventoryLists.TryGetValue(ItemLists.Inventory, out SceneSave sceneSave))
        // {
        //     if (sceneSave.listSceneItem != null)
        //     {
        //         // scene list items found - destroy existing items in scene
        //         DestroySceneItems();
        //
        //         // now instantiate the list of scene items
        //         InstantiateSceneItems(sceneSave.listSceneItem);
        //     }
        // }
    }

    public void SaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public GameItemsSave SaveableSave()
    {
        // Store current scene data
        SaveableStoreScene(SceneManager.GetActiveScene().name);

        return GameItemsSave;
    }


    public void SaveableStoreScene(string sceneName)
    {
        // Add scene save to gameobject
        //GameItemsSave.InventoryLists.Add(sceneName, sceneSave);
    }
}