﻿using System.Collections;
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

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenFadedBackground()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return null;

        fadeImage.LeanAlpha(0.6f, 0.2f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;
    }

    public void CloseFadedBackground()
    {
        MenuManager.instance.OnMainMenuBtnPress();
        StartCoroutine(DelayedStuff());
        fadeImage.LeanAlpha(0, 0.6f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }

    public IEnumerator DelayedStuff()
    {
        yield return new WaitForSeconds(0.6f);
        MenuManager.instance.InventoryBackOrHome("home");
        ButtonHandler.IsInterfaceOn(); //both the above have IsInterfaceOn, so needs an extra switch here

    }
    public void ShopCloseFadedBackground()
    {
        MenuManager.instance.OnMainMenuBtnPress();
        ShopManager.instance.ShopBackOrHome("home");
        ButtonHandler.IsInterfaceOn(); //both the above have IsInterfaceOn, so needs an extra switch here
        fadeImage.LeanAlpha(0, 0.3f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }







}
