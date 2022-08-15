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
        ShopObjects(sceneToLoad, sceneHandle.sceneObjectsLoad, sceneHandle.sceneObjectsUnload);
    }

    private IEnumerator LoadSceneCoroutine()
    {
        yield return null;

        PlayerGlobalData.Instance.isLoaded = false;
        Actions.OnSceneLoad?.Invoke(sceneToLoad, arrivingFrom);


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
            Actions.OnSceneChange?.Invoke(sceneToLoad, arrivingFrom, indexFrom, indexTo);
            PlayerGlobalData.Instance.currentSceneIndex = indexTo;
            GameManager.Instance.ActivateCharacters(sceneToLoad);
            Debug.Log($"currentSceneIndex: {PlayerGlobalData.Instance.currentSceneIndex}");
        }
    }


    public void ActiveScene()
    {
        arrivingFrom = SceneManager.GetActiveScene().name;
    }

    private static void ShopObjects(string scene, SceneObjectsLoad sceneObjectsLoad,
        SceneObjectsUnload sceneObjectsUnload)
    {
        if (sceneObjectsLoad is SceneObjectsLoad.Shop1 or SceneObjectsLoad.Shop2 or SceneObjectsLoad.Shop3)
        {
            ShopManager.Instance.isPlayerInsideShop = true;
            ShopManager.Instance.ShopType(scene);
            ShopManager.Instance.UpdateShopItemsInventory();
        }

        else if (sceneObjectsUnload is SceneObjectsUnload.Shop1 or SceneObjectsUnload.Shop2 or SceneObjectsUnload.Shop3)
        {
            ShopManager.Instance.isShopArmouryOpen = false;
            ShopManager.Instance.isPlayerInsideShop = false;
            ShopManager.Instance.UpdateShopItemsInventory();
        }
    }
}