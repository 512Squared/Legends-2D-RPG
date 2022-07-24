using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveDataManager
{
    private static SaveData _initialData;

    public static string InitialData;
    //public static SaveData.InventoryData ShopList;


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
        _initialData = new SaveData {sceneData = default, thulgranData = default, inventoryDatas = default};
        _initialData.thulgranData.trophies = 0;
        _initialData.thulgranData.hitPoints = 10;
        _initialData.thulgranData.gold = 10;
        _initialData.thulgranData.moveSpeed = 5;
        _initialData.thulgranData.maxHp = 300;
        _initialData.thulgranData.maxMana = 200;
        _initialData.sceneData.currentScene = "Homestead";
        _initialData.sceneData.sceneObjects = 1;
        _initialData.timeData.hour = GameManager.Instance.startTime;
        _initialData.audioData.musicVolume = 0.2f;
        _initialData.audioData.sfxVolume = 0.5f;
        _initialData.characterDataList.Clear();
        _initialData.questDataList.Clear();
        _initialData.questElementsList.Clear();
        _initialData.dialoguesList.Clear();
        _initialData.itemsData.Clear();
        _initialData.inventoryDataList.Clear();
        _initialData.inventoryDatas.shopsItemsList = Inventory.Instance.GetInitialShopList();
        _initialData.thulgranData.position = new Vector3(-8.25f, -3.25f, 0.75f);
        PlayerGlobalData.Instance.playerTrans = _initialData.thulgranData.position;
        PlayerGlobalData.Instance.transform.position = PlayerGlobalData.Instance.playerTrans;
        InitialData = _initialData.ToJson();
        Debug.Log($"Shoplist check: {_initialData.inventoryDatas.shopsItemsList.Count}");
        return InitialData;
    }

    public static void DeleteJsonData(IEnumerable<ISaveable> saveables)
    {
        FileManager.DeleteFile("SaveData.dat");
        LoadJsonData(saveables);

        Debug.Log("Delete complete");
    }
}