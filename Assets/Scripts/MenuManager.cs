using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    private void Start()
    {
        instance = this;
    }    


    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menu.GetComponent<CanvasGroup>().alpha == 1)
            {
                menu.GetComponent<UIFader>().FadeOut(); // this is how you call a function from another script
                menu.GetComponent<CanvasGroup>().interactable = false;
                menu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                /*if (menu.activeInHierarchy)
                {
                    menu.SetActive(false);
                }*/
            }
            else 
            {
                menu.SetActive(true);
                menu.GetComponent<UIFader>().FadeIn(); // this is calling the fade in
                menu.GetComponent<CanvasGroup>().interactable = true;
                menu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }


    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }


}
