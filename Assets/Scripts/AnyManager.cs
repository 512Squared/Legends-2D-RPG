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

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            SetActiveScene("Homestead");
            gameStart = true;

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

    public void SetActiveScene(string scene)
    {
        StartCoroutine(SetActive(scene));
    }

    IEnumerator SetActive(string scene)
    {
        yield return null; 
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));

        yield return null;
        GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(true);

        yield return null;
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name + " | Build Index: " + SceneManager.GetActiveScene().buildIndex);
        
    }

}
