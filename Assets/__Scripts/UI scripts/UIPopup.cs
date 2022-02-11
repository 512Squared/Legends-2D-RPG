using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{

    public CanvasGroup fadeImage;


    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.one;
        fadeImage.alpha = 0;
    }

    private void OnEnable()
    {
        Actions.OnMainMenuButton += OpenFadedBackground;
        Actions.OnBackButton += CloseFadedBackground;
        Actions.OnResumeButton += ClosePopBackground;
        Actions.OnHomeButton += ClosePopBackground;
    }

    private void OnDisable()
    {
        Actions.OnMainMenuButton -= OpenFadedBackground;
        Actions.OnBackButton -= CloseFadedBackground;
        Actions.OnResumeButton -= ClosePopBackground;
        Actions.OnHomeButton -= ClosePopBackground;
    }

    public void OpenFadedBackground()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() // for UI dark mask on background
    {
        yield return null;
        fadeImage.LeanAlpha(0.6f, 0.2f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;
    }

    public void CloseFadedBackground()
    {
        fadeImage.LeanAlpha(0, 0.6f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }

    public void ShopCloseFadedBackground()
    {
        fadeImage.LeanAlpha(0, 0.3f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }

    public void ClosePopBackground()
    {
        fadeImage.LeanAlpha(0, 0.6f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }







}
