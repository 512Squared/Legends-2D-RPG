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

    SceneHandling sceneStart;

    void Awake()
    {
        Debug.Log("First active scene: " + SceneManager.GetActiveScene().name);

        if (!gameStart)
        {
            anyManager = this;

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            SetActiveScene("Homestead", sceneStart);
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

    public void SetActiveScene(string scene, SceneHandling sceneHandle)
    {
        StartCoroutine(SetActive(scene, sceneHandle));
    }

    IEnumerator SetActive(string scene, SceneHandling sceneHandle)
    {
        yield return null; 
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));

        yield return null;
        GameManager.instance.sceneObjects[SceneManager.GetActiveScene().buildIndex].SetActive(true);

        yield return null;
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name + " | Build Index: " + SceneManager.GetActiveScene().buildIndex);

        yield return null;
        ShopMotherFucker(scene, sceneHandle);
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
