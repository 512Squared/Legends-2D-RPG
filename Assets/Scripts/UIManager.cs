using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject[] UIWindows;


    public static UIManager instance;


    private void Start()
    {
            instance = this;
    }


    private void Update()
    {

    }


    public void JoystickVisible()
    {
        joystick.GetComponent<CanvasGroup>().alpha = 1;
        joystick.GetComponent<CanvasGroup>().interactable = true;
        joystick.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void JoystickInvisible()
    {
        joystick.GetComponent<CanvasGroup>().alpha = 0;
        joystick.GetComponent<CanvasGroup>().interactable = false;
        joystick.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void CloseUI()
    {
        for (int i = 0; i < UIWindows.Length; i++)
        {
            if (i == 4)
            {
                UIWindows[4].GetComponent<CanvasGroup>().interactable = false;
                UIWindows[4].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            UIWindows[i].GetComponent<CanvasGroup>().alpha = 0;
            UIWindows[i].GetComponent<CanvasGroup>().interactable = false;
            UIWindows[i].GetComponent<CanvasGroup>().blocksRaycasts = false;



        }

        joystick.GetComponent<CanvasGroup>().alpha = 1;
        joystick.GetComponent<CanvasGroup>().interactable = true;
        joystick.GetComponent<CanvasGroup>().blocksRaycasts = true;

    }


    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }

    public void QuitGame()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }
}


