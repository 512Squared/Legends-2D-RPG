using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public static ButtonHandler instance;
    public bool settingsOpen;
    public Button settingsButton;


    private void Start()
    {
        settingsButton.onClick.AddListener(buttonBool);
        instance = this;
    


    }

    public void buttonBool()
    {
        if (settingsOpen == true)
        {
            settingsOpen = false;
            GameManager.instance.settingsOpen = false;
            
        }
        else if (settingsOpen == false)
        {
            settingsOpen = true;
            GameManager.instance.settingsOpen = true;

        }

        if (GameManager.instance.mKeyPressed == true)
        {
            GameManager.instance.mKeyPressed = false;
        }

        else if (GameManager.instance.mKeyPressed == false)
        {
            GameManager.instance.mKeyPressed = true;
        }

    }

}
