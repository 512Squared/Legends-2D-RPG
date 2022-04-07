using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


// cant
public class Exit : MonoBehaviour
{

    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private string goingTo;
    [SerializeField]
    private string arrivingFrom;
    [Space]
    [SerializeField]
    private int indexTo;
    [SerializeField]
    private int indexFrom;

    private bool _isLoaded;
    private bool _unloaded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (_isLoaded) return;
        _isLoaded = true;
             
        SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();

        StartCoroutine(LoadSceneCoroutine(sceneHandle));

        PlayerGlobalData.instance.arrivingAt = goingTo;

        GameManager.Instance.sceneObjects[indexTo].SetActive(true);
        GameManager.Instance.sceneObjects[indexFrom].SetActive(false);

        ShopMotherFucker(sceneToLoad, sceneHandle.sceneObjectsLoad, sceneHandle.sceneObjectsUnload);
    }

    IEnumerator LoadSceneCoroutine(SceneHandling scene)
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (asyncLoadLevel != null && !asyncLoadLevel.isDone)
        {
            yield return new WaitForEndOfFrame();

            if (!_unloaded)
            {
                _unloaded = true;
                AnyManager.anyManager.UnloadScene(arrivingFrom);
                GameManager.Instance.ActivateCharacters(sceneToLoad);
                Actions.OnSceneChange?.Invoke(sceneToLoad);
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size = new Vector2(1.12f, 1.8f);
            Debug.Log($"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
        }

        else if (scene != "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size = new Vector2(1.12f, 1.31f);
            Debug.Log($"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
        }
    }

}

