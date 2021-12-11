using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public static ButtonHandler instance;


    public bool interfaceOn;
    
    public void IsinterfaceOn()
    {
        GameManager.instance.isInterfaceOn = !GameManager.instance.isInterfaceOn;
        interfaceOn = !interfaceOn;

    }

    public void UseButtonOn()
    {
        GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable = true;
        GameObject.FindGameObjectWithTag("button_sell").GetComponent<Button>().interactable = true;

        Debug.Log("USE button re-activated. Status: " + GameObject.FindGameObjectWithTag("button_use").GetComponent<Button>().interactable);
    }

    [SerializeField]
    private Button[] buttons;

    public void SetAllButtonsInteractable()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void SetAllButtonsUninteractable()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
            return;

        SetAllButtonsInteractable();

        clickedButton.interactable = false;

    }

    public void OnButtonCalled(string calledTab)
    {

        SetAllButtonsInteractable();

        if (calledTab == "weapon") buttons[1].interactable = false;
        else if (calledTab == "armour") buttons[2].interactable = false;
    }



}
