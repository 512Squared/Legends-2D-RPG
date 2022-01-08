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
    private string sceneName;



    void OnTriggerEnter2D(Collider2D collision)
    {
        sceneName = sceneToLoad;

        if (isLoaded) return;
        Debug.Log("Is Loaded status: " + isLoaded);
        isLoaded = true;

        if (collision.CompareTag("Player"))
        {
            GameManager.instance.ActivateCharacters(sceneToLoad);
            GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

            PlayerGlobalData.instance.arrivedAt = goingTo;

            StartCoroutine(LoadSceneCoroutine());

            Debug.Log("Scene load called: " + sceneToLoad + " | Arriving from: " + arrivingFrom);


            if (gameObject.GetComponent<SceneHandling>().sceneLoad == SceneHandling.SceneLoad.shop)
            {
 
                ShopManager.instance.isPlayerInsideShop = true;
                ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), sceneName);
                ShopManager.instance.ShopType(_enum_shopType);
                SecretShopSection.instance.SetShopType(sceneName);
                ShopManager.instance.UpdateShopItemsInventory();
                Debug.Log("Scenehandling called - load: " + gameObject.GetComponent<SceneHandling>().sceneLoad + " | Enum used: " + _enum_shopType);

            }

            else if (gameObject.GetComponent<SceneHandling>().sceneUnload == SceneHandling.SceneUnload.shop)
            {
                Debug.Log("Scenehandling called - unload: " + gameObject.GetComponent<SceneHandling>().sceneUnload);
                ShopManager.instance.isShopArmouryOpen = false;
                ShopManager.instance.isPlayerInsideShop = false;
            }
        }
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
        

}
