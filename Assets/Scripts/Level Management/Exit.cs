using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Exit : MonoBehaviour
{

    [SerializeField] string sceneToLoad;
    [SerializeField] string goingTo;
    [SerializeField] string arrivingFrom;

    bool loaded;
    bool unloaded;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (!loaded)
            {

                GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

                SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();

                PlayerGlobalData.instance.arrivedAt = goingTo;

                LoadSceneCall();

                DoShit(sceneToLoad, sceneHandle);

                Debug.Log($"Load scene called from: {SceneManager.GetActiveScene().name}");

                loaded = true;
            }

            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
            }
        }
    }

    public void LoadSceneCall()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (true)
        {
            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
            }
            yield return new WaitUntil(() => asyncLoadLevel.isDone);
            AnyManager.anyManager.SetActiveScene(sceneToLoad);
        }

    }

    public void DoShit(string scene, SceneHandling sceneHandle)
    {
        
        Debug.Log($"Do shit called: {scene} + {sceneHandle.sceneLoad}");
        StartCoroutine(DoRestOfShit(scene, sceneHandle));
    }

    IEnumerator DoRestOfShit(string scene, SceneHandling sceneHandle)
    {
        yield return null;
        Debug.Log("Set up shop");
        AnyManager.anyManager.ShopMotherFucker(scene, sceneHandle);
        yield return null; 
        Debug.Log("Activate characters"); 
        GameManager.instance.ActivateCharacters(scene);

    }


    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }



}

