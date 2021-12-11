using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{

    [SerializeField] string sceneToLoad;
    [SerializeField] string goingTo;
    [SerializeField] string arrivingFrom;


    bool loaded;
    bool unloaded;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (!loaded)
            {
                PlayerGlobalData.instance.arrivedAt = goingTo;

                StartCoroutine(LoadSceneCoroutine());

                Debug.Log("Scene load called: " + sceneToLoad);

                loaded = true;
            }

        }

    }

    public void teleport()
    {


        Debug.Log("Active scene name: " + arrivingFrom);

        if (!loaded)
                {
                    PlayerGlobalData.instance.arrivedAt = "WishingWell";

                    StartCoroutine(LoadTeleportCoroutine());

                    Debug.Log("Scene load called: " + sceneToLoad);

                    loaded = true;
                }
            
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        if (!unloaded)
        {
            unloaded = true;
            AnyManager.anyManager.UnloadScene(arrivingFrom);
            Debug.Log("Scene unload called: " + arrivingFrom);
        }

    }


    IEnumerator LoadTeleportCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        if (!unloaded)
        {
            unloaded = true;
            AnyManager.anyManager.UnloadScene(arrivingFrom);
            Debug.Log("Scene unload called: " + arrivingFrom);
        }


    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(0.5f);

        if (!unloaded)
        {
            unloaded = true;
            AnyManager.anyManager.UnloadScene(arrivingFrom);
            Debug.Log("Scene unload called: " + arrivingFrom);
        }
    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }


}
