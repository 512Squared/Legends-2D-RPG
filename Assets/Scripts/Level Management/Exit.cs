using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{

    [SerializeField] string sceneToLoad;
    [SerializeField] string goingTo;
    [SerializeField] string arrivingFrom;


    bool loaded;
    bool unloaded;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Player"))
        {
            if (!loaded)
            {
                PlayerGlobalData.instance.arrivedAt = goingTo;

                //MenuManager.instance.FadeImage();

                StartCoroutine(LoadSceneCoroutine());

                Debug.Log("Scene load called: " + sceneToLoad);

                loaded = true;
            }

        }

    }

    public void teleport()
    {
        if (gameObject.CompareTag("teleport"))
        {
            PlayerGlobalData.instance.arrivedAt = goingTo;

            //MenuManager.instance.FadeImage();

            StartCoroutine(LoadSceneCoroutine());

            loaded = true;
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        if (!unloaded)
        {
            unloaded = true;
            AnyManager.anyManager.UnloadScene(arrivingFrom);
            Debug.Log("Scene unload called: " + arrivingFrom);
        }


    }


}
