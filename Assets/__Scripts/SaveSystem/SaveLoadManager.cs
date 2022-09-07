using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    private string currentScene;


    public List<ISaveable> Saveables;

    private void Start()
    {
        // currentScene = GameManager.Instance.firstScene;
        StartCoroutine(Initialize());
        Saveables = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveable>().ToList();
        if (GameManager.Instance.initialization) { Debug.Log($"Save items count: {Saveables.Count}"); }
    }


    private IEnumerator Initialize()
    {
        yield return null;
        SaveDataManager.LoadJsonData(Saveables);
    }


    public void ResetGame()
    {
        SaveDataManager.DeleteJsonData(Saveables);
        SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {
        SaveDataManager.SaveJsonData(Saveables);
    }

    public void QuitGame()
    {
        SaveDataManager.SaveJsonData(Saveables);
        Application.Quit();
        Debug.Log($"Quit Application");
    }
}