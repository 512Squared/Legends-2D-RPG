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

                PlayerGlobalData.instance.arrivedAt = goingTo;

                StartCoroutine(LoadSceneCoroutine());

                GameManager.instance.ActivateCharacters(sceneToLoad);

                Debug.Log("Scene load called: " + sceneToLoad + " | Arriving from: " + arrivingFrom);
                loaded = true;

            }
        }
    }



    IEnumerator LoadSceneCoroutine()
    {

        Debug.Log("Load scene started");

        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (true)
        {
            SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();

            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
            }
            yield return new WaitUntil(() => asyncLoadLevel.isDone);
            AnyManager.anyManager.SetActiveScene(sceneToLoad, sceneHandle);
        }

    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }



}

