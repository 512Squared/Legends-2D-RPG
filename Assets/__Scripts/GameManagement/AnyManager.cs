using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour, ISaveable
{
    public static AnyManager Instance;
    //[SerializeField] private SceneObjectsLoad startScene;

    private int _startSceneNumber;

    private void Start()
    {
        Instance = this;
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        //a_SaveData.sceneData.objectsLoad = startScene;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        //SceneStartSelection(a_SaveData.sceneData.objectsLoad);
    }

    #endregion
}