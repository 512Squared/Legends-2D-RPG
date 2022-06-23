using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// cant
public class Exit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string goingTo;
    [SerializeField] private string arrivingFrom;
    [Space] [SerializeField] private int indexTo;
    [SerializeField] private int indexFrom;

    private bool _isLoaded;
    private bool _unloaded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (_isLoaded)
        {
            return;
        }

        _isLoaded = true;

        SceneHandling sceneHandle = gameObject.GetComponent<SceneHandling>();
        StartCoroutine(LoadSceneCoroutine());
        PlayerGlobalData.Instance.arrivingAt = goingTo;
        ShopMotherFucker(sceneToLoad, sceneHandle.sceneObjectsLoad, sceneHandle.sceneObjectsUnload);
    }

    private IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (asyncLoadLevel is {isDone: false})
        {
            yield return new WaitForEndOfFrame();

            if (_unloaded)
            {
                continue;
            }

            _unloaded = true;
            SceneManager.UnloadSceneAsync(arrivingFrom);
            Actions.OnSceneChange?.Invoke(sceneToLoad, indexFrom, indexTo);
            PlayerGlobalData.Instance.currentSceneIndex = indexTo;

            Debug.Log($"currentSceneIndex: {PlayerGlobalData.Instance.currentSceneIndex}");
        }
    }


    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    private void ShopMotherFucker(string scene, SceneObjectsLoad sceneObjectsLoad,
        SceneObjectsUnload sceneObjectsUnload)
    {
        if (sceneObjectsLoad is SceneObjectsLoad.shop1 or SceneObjectsLoad.shop2 or SceneObjectsLoad.shop3)
        {
            ShopManager.Instance.isPlayerInsideShop = true;
            Debug.Log($"Scene Name: {scene}");
            Shop enumShopType = (Shop)System.Enum.Parse(typeof(Shop), scene);
            Debug.Log($"Enum shop type: {enumShopType}");
            ShopManager.Instance.ShopType(enumShopType);
            ShopManager.Instance.UpdateShopItemsInventory();
        }

        else if (sceneObjectsUnload is SceneObjectsUnload.shop1 or SceneObjectsUnload.shop2 or SceneObjectsUnload.shop3)
        {
            ShopManager.Instance.isShopArmouryOpen = false;
            ShopManager.Instance.isPlayerInsideShop = false;
            ShopManager.Instance.UpdateShopItemsInventory();
        }

        else if (scene == "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size =
                new Vector2(1.12f, 1.8f);
            Debug.Log(
                $"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
        }

        else if (scene != "Dungeon")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size =
                new Vector2(1.12f, 1.31f);
            Debug.Log(
                $"SceneName: {scene} | CapsuleSize: {GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>().size}");
        }
    }
}