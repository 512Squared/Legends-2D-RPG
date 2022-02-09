using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{

    public CanvasGroup fadeImage;
    private ButtonHandler bh;



    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        fadeImage.alpha = 0;
        fadeImage.LeanAlpha(1, 0.3f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;
        transform.LeanScale(Vector3.one, 0.6f).setEaseOutBack();
    }

    public void Close()
    {
        MenuManager.instance.InventoryBackOrHome("home");
        ButtonHandler.IsInterfaceOn();
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }    
    
    public void CloseBackground()
    {
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
        Debug.Log($"UIPopup Close called. | Interface on: {ButtonHandler.interfaceOn}");
    }



}
