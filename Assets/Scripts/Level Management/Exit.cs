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
                // disable old scene objects
                GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

                PlayerGlobalData.instance.arrivedAt = goingTo;

                StartCoroutine(LoadSceneCoroutine());

                Debug.Log("Scene load called: " + sceneToLoad + " | Arriving from: " + arrivingFrom);

                loaded = true;
            }
        }

        GameManager.instance.ActivateCharacters(sceneToLoad);
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);

    }


    IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoadLevel.isDone)
        {
            yield return null;
            // Wait a frame so every Awake and Start method is called
            yield return new WaitForEndOfFrame();

            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
            }

            yield return StartCoroutine(SetActiveScene(sceneToLoad));
        }

    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    IEnumerator SetActiveScene(string scene)
    {
        yield return null;
        AnyManager.anyManager.SetActiveScene(scene);
        yield return new WaitForSeconds(0.1f);
        ShopIdentification(sceneToLoad);
        Debug.Log("Shop Identification called: " + sceneToLoad);
    }

    public void ShopIdentification(string scene)
    {
        if (sceneToLoad == "Shop_counter")
        {
                ShopManager.instance.GetChildObjects("shop1");
                Debug.Log("Is shoptype identified correctly? " + scene);
        }

    }

}
