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

    bool isLoaded;
    bool unloaded;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isLoaded) return;
        Debug.Log("Is Loaded status: " + isLoaded);
        isLoaded = true;

        if (collision.CompareTag("Player"))
        {
            GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

            PlayerGlobalData.instance.arrivedAt = goingTo;

            StartCoroutine(LoadSceneCoroutine());

            Debug.Log("Scene load called: " + sceneToLoad + " | Arriving from: " + arrivingFrom);
            ShopInstantiation(sceneToLoad);
            Debug.Log("Shop Identification called: " + sceneToLoad);
        }

        GameManager.instance.ActivateCharacters(sceneToLoad);
        

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
        yield return new WaitForEndOfFrame();
        isLoaded = false;
    }

    public void ShopInstantiation(string scene) // called at first scene change
    {
        if (sceneToLoad == "Shop_counter") // shop1
        {
            Debug.Log("Scene: " + scene);
            ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), "shop1");
            ShopManager.instance.shopType = _enum_shopType;
            Debug.Log("Shoptype: " + ShopManager.instance.shopType);    
            ShopManager.instance.ShopArmoury();
        }

    }

}
