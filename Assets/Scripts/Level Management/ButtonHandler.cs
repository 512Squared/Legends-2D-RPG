using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public static ButtonHandler instance;

  
        public void Start()
    {
        instance = this;
    }

    public void buttonBool()
    {

        if (GameManager.instance.mKeyPressed == false)
        {
            GameManager.instance.mKeyPressed = true;

        }

        else if (GameManager.instance.mKeyPressed == true)
        {
            
            GameManager.instance.mKeyPressed = false;

        }

/*
        if (GameManager.instance.mKeyPressed == true)
        {
            GameManager.instance.mKeyPressed = false;
        }

        else if (GameManager.instance.mKeyPressed == false)
        {
            GameManager.instance.mKeyPressed = true;
        }*/

    }

}
