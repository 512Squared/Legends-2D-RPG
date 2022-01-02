using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{

    public static AnyManager anyManager;

    bool gameStart;

    void Awake()
    {
        Debug.Log("First active scene: " + SceneManager.GetActiveScene().name);

        if (!gameStart)
        {
            anyManager = this;

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            SetActiveScene("Homestead");

            gameStart = true;

        }
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

    public void SetActiveScene(string scene)
    {
        StartCoroutine(SetActive(scene));
    }
     
    IEnumerator SetActive(string scene)
    {
        yield return null;
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        
        GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(true);
        
        Debug.Log("Additive scene: " + SceneManager.GetActiveScene().name);
    }

}
