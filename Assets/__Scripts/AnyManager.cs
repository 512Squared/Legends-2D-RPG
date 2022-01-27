using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{

    public static AnyManager anyManager;
    [SerializeField] private SceneObjectsLoad startScene;
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

    public void SceneStartSelection(SceneObjectsLoad startScene)
    {

        switch (startScene)
        {
            case SceneObjectsLoad.homestead: startSceneNumber = 1; break;
            case SceneObjectsLoad.mountain: startSceneNumber = 2; break;
            case SceneObjectsLoad.dungeon: startSceneNumber = 3; break;
            case SceneObjectsLoad.shop1: startSceneNumber = 4; break;
            case SceneObjectsLoad.shop2: startSceneNumber = 5; break;
            case SceneObjectsLoad.shop3: startSceneNumber = 6; break;
            case SceneObjectsLoad.house_h_north: startSceneNumber = 7; break;
            case SceneObjectsLoad.house_h_south: startSceneNumber = 8; break;
            case SceneObjectsLoad.house_h_west: startSceneNumber = 9; break;
            case SceneObjectsLoad.house_m_north: startSceneNumber = 10; break;
            case SceneObjectsLoad.house_m_south: startSceneNumber = 11; break;
            case SceneObjectsLoad.house_m_west: startSceneNumber = 12; break;
            case SceneObjectsLoad.town: startSceneNumber = 13; break;
            default: startSceneNumber = 1; break;
        }
    }


}
