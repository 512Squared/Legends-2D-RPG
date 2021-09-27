using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;

    public static MenuManager instance;

    public void QuitGame ()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }

    private void Start()
    {
        instance = this;
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }


}
