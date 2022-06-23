using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>, ISaveable
{
    private string firstScene;


    public List<ISaveable> Saveables;

    private void Start()
    {
        firstScene = GameManager.Instance.firstScene;
        StartCoroutine(Initialize());
        Saveables = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveable>().ToList();
        Debug.Log($"Save items count: {Saveables.Count}");
    }

    private void OnEnable()
    {
        Actions.OnSceneChange += SceneChange;
    }

    private void SceneChange(string scene, int arg2, int arg3)
    {
        firstScene = scene;
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= SceneChange;
    }


    private IEnumerator Initialize()
    {
        yield return null;
        SaveDataManager.LoadJsonData(Saveables);
    }


    public void ResetGame()
    {
        SceneManager.UnloadSceneAsync(firstScene);
        SaveDataManager.DeleteJsonData(Saveables);
    }

    public void SaveGame()
    {
        SaveDataManager.SaveJsonData(Saveables);
    }

    public void QuitGame()
    {
        SaveDataManager.SaveJsonData(Saveables);
        Application.Quit();
    }

    public void LoadGame()
    {
        SaveDataManager.LoadJsonData(Saveables);
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        firstScene = GameManager.Instance.firstScene;
        a_SaveData.sceneData.currentScene = firstScene;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void LoadFromSaveData(SaveData a_SaveData)
    {
        firstScene = a_SaveData.sceneData.currentScene;
    }

    #endregion
}