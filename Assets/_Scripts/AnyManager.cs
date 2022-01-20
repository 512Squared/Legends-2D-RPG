using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnyManager : MonoBehaviour
{

    public static AnyManager anyManager;
    [SerializeField] private SceneHandling.SceneObjectsLoad startScene;
    private int startSceneNumber;

    bool gameStart;

    void Awake()
    {
        Debug.Log("First active scene: " + SceneManager.GetActiveScene().name);


        if (!gameStart)
        {
            SceneStartSelection(startScene);
            anyManager = this;
            gameStart = true;
            SceneManager.LoadSceneAsync(startSceneNumber, LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        anyManager = this;
    }

    public void UnloadScene(string scene)
    {
        StartCoroutine(Unload(scene));

    }

    IEnumerator Unload(string scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);

    }

    public void SceneStartSelection(SceneHandling.SceneObjectsLoad startScene)
    {

        switch (startScene)
        {
            case SceneHandling.SceneObjectsLoad.homestead: startSceneNumber = 1; break;
            case SceneHandling.SceneObjectsLoad.mountain: startSceneNumber = 2; break;
            case SceneHandling.SceneObjectsLoad.dungeon: startSceneNumber = 3; break;
            case SceneHandling.SceneObjectsLoad.shop1: startSceneNumber = 4; break;
            case SceneHandling.SceneObjectsLoad.shop2: startSceneNumber = 5; break;
            case SceneHandling.SceneObjectsLoad.shop3: startSceneNumber = 6; break;
            case SceneHandling.SceneObjectsLoad.house_h_north: startSceneNumber = 7; break;
            case SceneHandling.SceneObjectsLoad.house_h_south: startSceneNumber = 8; break;
            case SceneHandling.SceneObjectsLoad.house_h_west: startSceneNumber = 9; break;
            case SceneHandling.SceneObjectsLoad.house_m_north: startSceneNumber = 10; break;
            case SceneHandling.SceneObjectsLoad.house_m_south: startSceneNumber = 11; break;
            case SceneHandling.SceneObjectsLoad.house_m_west: startSceneNumber = 12; break;
            case SceneHandling.SceneObjectsLoad.town: startSceneNumber = 13; break;
            default: startSceneNumber = 1; break;
        }
    }


}
