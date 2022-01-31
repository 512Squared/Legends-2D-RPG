using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// cant
public class Exit : MonoBehaviour
{

    [SerializeField] string sceneToLoad;
    [SerializeField] string goingTo;
    [SerializeField] string arrivingFrom;
    [Space]
    [SerializeField] int indexTo;
    [SerializeField] int indexFrom;

    bool isLoaded;
    bool unloaded;



    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (isLoaded) return;
            isLoaded = true;

            SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();

            StartCoroutine(LoadSceneCoroutine());

            PlayerGlobalData.instance.arrivingAt = goingTo;

            GameManager.instance.sceneObjects[indexTo].SetActive(true);
            GameManager.instance.sceneObjects[indexFrom].SetActive(false);

            GameManager.instance.ActivateCharacters(sceneToLoad);

            ShopMotherFucker(sceneToLoad, sceneHandle.sceneObjectsLoad, sceneHandle.sceneObjectsUnload);

        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoadLevel.isDone)
        {
            yield return new WaitForEndOfFrame();

            if (!unloaded)
            {
                unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
            }

        }

    }


    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    public void ShopMotherFucker(string scene, SceneObjectsLoad sceneObjectsLoad, SceneObjectsUnload sceneObjectsUnload)
    {
        if (sceneObjectsLoad == SceneObjectsLoad.shop1 || sceneObjectsLoad == SceneObjectsLoad.shop2 || sceneObjectsLoad == SceneObjectsLoad.shop3)
        {
            ShopManager.instance.isPlayerInsideShop = true;
            ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), scene);
            ShopManager.instance.ShopType(_enum_shopType);
            SecretShopSection.instance.shop = _enum_shopType;
            ShopManager.instance.UpdateShopItemsInventory();
        }

        else if (sceneObjectsUnload == SceneObjectsUnload.shop1 || sceneObjectsUnload == SceneObjectsUnload.shop2 || sceneObjectsUnload == SceneObjectsUnload.shop3)
        {
            ShopManager.instance.isShopArmouryOpen = false;
            ShopManager.instance.isPlayerInsideShop = false;
            ShopManager.instance.UpdateShopItemsInventory();
        }

        else if (scene == "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size = new Vector2(1.12f, 1.57f);
            Debug.Log($"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
        }

        else if (scene != "Dungeon")
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size = new Vector2(1.12f, 1.31f);
            Debug.Log($"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
    }

}

