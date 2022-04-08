using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    public GameSave gameSave;
    public List<ISaveable> iSaveableObjectList;

    private string dataPath;

    protected override void Awake()
    {
        base.Awake();

        iSaveableObjectList = new List<ISaveable>();
        dataPath = Path.Combine(Application.persistentDataPath + "Legends.dat");
    }

    public void SaveDataToFile()
    {
        gameSave = new GameSave();

        // loop through all ISaveable objects and generate save data
        foreach (ISaveable iSaveableObject in iSaveableObjectList)
        {
            gameSave.GameItemsData.Add(iSaveableObject.SaveableUniqueID, iSaveableObject.SaveableSave());
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(dataPath, FileMode.Create);

        bf.Serialize(file, gameSave);

        file.Close();

        //IManager.Instance.DisablePauseMenu();
    }

    public void LoadDataFromFile()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(dataPath))
        {
            gameSave = new GameSave();

            FileStream file = File.Open(dataPath, FileMode.Open);

            gameSave = (GameSave)bf.Deserialize(file);

            // loop through all ISaveable objects and apply save data
            for (int i = iSaveableObjectList.Count - 1; i > -1; i--)
            {
                if (gameSave.GameItemsData.ContainsKey(iSaveableObjectList[i].SaveableUniqueID))
                {
                    iSaveableObjectList[i].SaveableLoad(gameSave);
                }
                // else if iSaveableObject unique ID is not in the game object data then destroy object
                else
                {
                    Component component = (Component)iSaveableObjectList[i];
                    Destroy(component.gameObject);
                }
            }

            file.Close();
        }

        //UIManager.Instance.DisablePauseMenu();
    }


    public void StoreCurrentSceneData()
    {
        // loop through all ISaveable objects and trigger store scene data for each
        foreach (ISaveable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.SaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSceneData()
    {
        // loop through all ISaveable objects and trigger restore scene data for each
        foreach (ISaveable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.SaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}