using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{

    public CanvasGroup fadeImage;


    private void Awake()
    {
        if(fadeImage != null) fadeImage.alpha = 0f;   
    }

    private void OnEnable()
    {
        Actions.OnMainMenuButton += FadeIn;
        Actions.OnResumeButton += ClosePopBackground;
        Actions.OnHomeButton += ClosePopBackground;
    }

    private void OnDisable()
    {
        Actions.OnMainMenuButton -= FadeIn;
        Actions.OnResumeButton -= ClosePopBackground;
        Actions.OnHomeButton -= ClosePopBackground;
    }


    private void FadeIn() // for UI dark mask on background
    {
        fadeImage.LeanAlpha(1f, 0.1f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;
    }


    public void ClosePopBackground()
    {
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
    }







}
