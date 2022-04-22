using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    
    public static void SaveJsonData(IEnumerable<ISaveable> a_Saveables) // ATM called in GameManager in OnDestroy
    {
        SaveData sd = new SaveData();
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

        SaveData sd = new SaveData();
        sd.LoadFromJson(json);

        foreach (ISaveable saveable in a_Saveables)
        {
            saveable.LoadFromSaveData(sd);
        }
            
        Debug.Log("Load complete");
    }
}