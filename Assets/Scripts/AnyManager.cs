using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            gameStart = true;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
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


}
