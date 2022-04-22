using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    private static SaveData _initialData;
    public static string InitialData;

    public static void SaveJsonData(IEnumerable<ISaveable> a_Saveables) // ATM called in GameManager in OnDestroy
    {
        SaveData sd = new();
        foreach (ISaveable saveable in a_Saveables)
        {
            saveable.PopulateSaveData(sd);
        }

        if (FileManager.WriteToFile("SaveData.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public static void LoadJsonData(IEnumerable<ISaveable> a_Saveables) // ATM called in GameManager in OnEnable
    {
        if (!FileManager.LoadFromFile("SaveData.dat", out string json)) { return; }

        SaveData sd = new();
        sd.LoadFromJson(json);

        foreach (ISaveable saveable in a_Saveables)
        {
            saveable.LoadFromSaveData(sd);
        }

        Debug.Log("Load complete");
    }

    public static string GetInitialData()
    {
        _initialData = new SaveData
        {
            sceneData = default,
            questData = default,
            itemsData = default,
            characterData = default,
            thulgranData = default
        };
        _initialData.sceneData.currentScene = "Homestead";
        _initialData.thulgranData.position = new Vector3(-8.25f, -3.25f, 0.75f);
        _initialData.thulgranData.hitPoints = 10;
        _initialData.sceneData.sceneObjects = 1;
        InitialData = _initialData.ToJson();
        return InitialData;
    }
}