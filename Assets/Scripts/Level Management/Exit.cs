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

    bool isLoaded;
    bool unloaded;
    private string sceneName;

    private Sprite progress;


    void OnTriggerEnter2D(Collider2D collision)
    {
        sceneName = sceneToLoad;

        if (isLoaded) return;
        Debug.Log("Is Loaded status: " + isLoaded);
        isLoaded = true;

        if (collision.CompareTag("Player"))
        {

            GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

            PlayerGlobalData.instance.arrivedAt = goingTo;

            StartCoroutine(LoadSceneCoroutine());

            GameManager.instance.ActivateCharacters(sceneToLoad);

            Debug.Log("Scene load called: " + sceneToLoad + " | Arriving from: " + arrivingFrom);
        }
    }



    IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        asyncLoadLevel.allowSceneActivation = false;

        while (!asyncLoadLevel.isDone)
        {
            if (asyncLoadLevel.progress >= 0.9f)
            {
                asyncLoadLevel.allowSceneActivation = true;
            }

            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);

            }
            yield return StartCoroutine(SetActiveScene(sceneToLoad));
        }
        StartCoroutine(LoadShop());
    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    IEnumerator SetActiveScene(string scene)
    {
        yield return new WaitUntil(() => unloaded == true);
        AnyManager.anyManager.SetActiveScene(scene);
        yield return new WaitForEndOfFrame();
        isLoaded = false;
    }

    public void LoadingShop()
    {
        StartCoroutine(LoadShop());
    }

    IEnumerator LoadShop()
    {
        yield return null;

        while (true)
        {
            if (gameObject.GetComponent<SceneHandling>().sceneLoad == SceneHandling.SceneLoad.shop)
            {
                ShopManager.instance.isPlayerInsideShop = true;
                ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), sceneName);
                ShopManager.instance.ShopType(_enum_shopType);
                Debug.Log("Scenehandling. Loading... " + gameObject.GetComponent<SceneHandling>().sceneLoad + " | Enum used: " + _enum_shopType);
                SecretShopSection.instance.shop = _enum_shopType;
                ShopManager.instance.UpdateShopItemsInventory();
            }

            else if (gameObject.GetComponent<SceneHandling>().sceneUnload == SceneHandling.SceneUnload.shop)
            {
                Debug.Log("Scenehandling called - unload: " + gameObject.GetComponent<SceneHandling>().sceneUnload);
                ShopManager.instance.isShopArmouryOpen = false;
                ShopManager.instance.isPlayerInsideShop = false;
                ShopManager.instance.UpdateShopItemsInventory();
            }
        }
    }
}
