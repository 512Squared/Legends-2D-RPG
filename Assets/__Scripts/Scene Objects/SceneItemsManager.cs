﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GenerateGUID))]
public class SceneItemsManager : SingletonMonobehaviour<SceneItemsManager>, ISaveable
{
    private Transform _parentItem;
    [SerializeField] private GameObject itemPrefab = null;

    private string _iSaveableUniqueID;
    public string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; } }

    private GameObjectSave _gameObjectSave;
    public GameObjectSave GameObjectSave { get { return _gameObjectSave; } set { _gameObjectSave = value; } }

    private void AfterSceneLoad()
    {
        _parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }

    protected override void Awake()
    {
        base.Awake();

        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    /// <summary>
    /// Destroy items currently in the scene
    /// </summary>
    private void DestroySceneItems()
    {
        // Get all items in the scene
        ItemsManager[] itemsInScene = GameObject.FindObjectsOfType<ItemsManager>();

        // Loop through all scene items and destroy them
        for (int i = itemsInScene.Length - 1; i > -1; i--)
        {
            Destroy(itemsInScene[i].gameObject);
        }
    }

    public void InstantiateSceneItem(int itemCode, Vector3 itemPosition)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity, _parentItem);
        ItemsManager item = itemGameObject.GetComponent<ItemsManager>();
        item.Init(itemCode);
    }

    private void InstantiateSceneItems(List<SceneItem> sceneItemList)
    {
        GameObject itemGameObject;

        foreach (SceneItem sceneItem in sceneItemList)
        {
            itemGameObject = Instantiate(itemPrefab, new Vector3(sceneItem.position.x, sceneItem.position.y, sceneItem.position.z), Quaternion.identity, _parentItem);

            ItemsManager item = itemGameObject.GetComponent<ItemsManager>();
            item.ItemCode = sceneItem.itemCode;
            item.name = sceneItem.itemName;
        }
    }
    private void OnEnable()
    {
        ISaveableRegister();
        //EventHandler.AfterSceneLoadEvent += AfterSceneLoad;
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        //EventHandler.AfterSceneLoadEvent -= AfterSceneLoad;
    }


    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            GameObjectSave = gameObjectSave;

            // Restore data for current scene
            ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }



    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.listSceneItem != null)
            {
                // scene list items found - destroy existing items in scene
                DestroySceneItems();

                // now instantiate the list of scene items
                InstantiateSceneItems(sceneSave.listSceneItem);
            }
        }
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public GameObjectSave ISaveableSave()
    {
        // Store current scene data
        ISaveableStoreScene(SceneManager.GetActiveScene().name);

        return GameObjectSave;
    }



    public void ISaveableStoreScene(string sceneName)
    {
        // Remove old scene save for gameObject if exists
        GameObjectSave.sceneData.Remove(sceneName);

        // Get all items in the scene
        List<SceneItem> sceneItemList = new List<SceneItem>();
        ItemsManager[] itemsInScene = FindObjectsOfType<ItemsManager>();

        // Loop through all scene items
        foreach (ItemsManager item in itemsInScene)
        {
            SceneItem sceneItem = new SceneItem();
            sceneItem.itemCode = item.ItemCode;
            sceneItem.position = new Vector3Serializable(item.transform.position.x, item.transform.position.y, item.transform.position.z);
            sceneItem.itemName = item.name;

            // Add scene item to list
            sceneItemList.Add(sceneItem);
        }

        // Create list scene items in scene save and set to scene item list
        SceneSave sceneSave = new SceneSave();
        sceneSave.listSceneItem = sceneItemList;

        // Add scene save to gameobject
        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }
}
