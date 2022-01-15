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
    [SerializeField] int GoingToBuildIndex;

    bool loaded;
    bool unloaded;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (!loaded)
            {
                Debug.Log($"Active scene: {SceneManager.GetActiveScene().name} | Scene called: {sceneToLoad} ");

                GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(false);

                SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();

                PlayerGlobalData.instance.arrivedAt = goingTo;

                LoadSceneCall();

                GameManager.instance.sceneObjects[GoingToBuildIndex].SetActive(true);

                GameManager.instance.ActivateCharacters(sceneToLoad);

                ShopMotherFucker(sceneToLoad, sceneHandle);

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
    } // coroutine call

    IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

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

            yield return new WaitUntil(() => asyncLoadLevel.allowSceneActivation == true);
            AnyManager.anyManager.SetSceneActive(GoingToBuildIndex, asyncLoadLevel);
        }
    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    public void ShopMotherFucker(string scene, SceneHandling sceneHandle)
    {

        Debug.Log("Shop motherfucker started");

        if (sceneHandle.sceneLoad == SceneHandling.SceneLoad.shop1 || sceneHandle.sceneLoad == SceneHandling.SceneLoad.shop2 || sceneHandle.sceneLoad == SceneHandling.SceneLoad.shop3)
        {
            ShopManager.instance.isPlayerInsideShop = true;
            ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), scene);
            ShopManager.instance.ShopType(_enum_shopType);
            SecretShopSection.instance.shop = _enum_shopType;
            ShopManager.instance.UpdateShopItemsInventory();
        }

        else if (sceneHandle.sceneUnload == SceneHandling.SceneUnload.shop1 || sceneHandle.sceneUnload == SceneHandling.SceneUnload.shop2 || sceneHandle.sceneUnload == SceneHandling.SceneUnload.shop3)
        {
            ShopManager.instance.isShopArmouryOpen = false;
            ShopManager.instance.isPlayerInsideShop = false;
            ShopManager.instance.UpdateShopItemsInventory();
        }
    }

}

