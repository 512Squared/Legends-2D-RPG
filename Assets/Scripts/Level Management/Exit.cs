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
            StartCoroutine(SetActiveScene(sceneToLoad));
            LoadShop(sceneToLoad);

        }

    }

    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    IEnumerator SetActiveScene(string scene)
    {
        yield return new WaitForEndOfFrame();
        AnyManager.anyManager.SetActiveScene(scene);
    }

    public void LoadShop(string sceneToLoad)
    {


        if (gameObject.GetComponent<SceneHandling>().sceneLoad == SceneHandling.SceneLoad.shop1 || gameObject.GetComponent<SceneHandling>().sceneLoad == SceneHandling.SceneLoad.shop2 || gameObject.GetComponent<SceneHandling>().sceneLoad == SceneHandling.SceneLoad.shop3)
        {

            ShopManager.instance.isPlayerInsideShop = true;
            ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), sceneToLoad);
            ShopManager.instance.ShopType(_enum_shopType);
            SecretShopSection.instance.shop = _enum_shopType;
            ShopManager.instance.UpdateShopItemsInventory();
        }

        else if (gameObject.GetComponent<SceneHandling>().sceneUnload == SceneHandling.SceneUnload.shop1 || gameObject.GetComponent<SceneHandling>().sceneUnload == SceneHandling.SceneUnload.shop2 || gameObject.GetComponent<SceneHandling>().sceneUnload == SceneHandling.SceneUnload.shop3)
        {
            ShopManager.instance.isShopArmouryOpen = false;
            ShopManager.instance.isPlayerInsideShop = false;
            ShopManager.instance.UpdateShopItemsInventory();
        }

    }
}

