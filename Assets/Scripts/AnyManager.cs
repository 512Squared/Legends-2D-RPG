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
            Initialize();
        }
    }

    private void Start()
    {
        anyManager = this;
    }


    public void Initialize()
    {
        StartCoroutine(InitializeCo());
    }

    IEnumerator InitializeCo()
    {
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            if (asyncLoadLevel.progress >= 0.9f)
            {
                asyncLoadLevel.allowSceneActivation = true;
            }
            yield return new WaitUntil(() => asyncLoadLevel.allowSceneActivation == true);
            SetSceneActive(1, asyncLoadLevel);
        }
    }

    public void UnloadScene(string scene) // called from Exit script
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(string scene)
    {
        yield return null;

        SceneManager.UnloadSceneAsync(scene);

    }

    public void SetSceneActive(int buildIndex, AsyncOperation asyncLoadLevel)
    {
        StartCoroutine(SetActive(buildIndex,asyncLoadLevel));
    }

    IEnumerator SetActive(int buildIndex, AsyncOperation asyncLoadLevel)
    {
        yield return new WaitUntil(() => asyncLoadLevel.allowSceneActivation == true);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex));
    }
}
