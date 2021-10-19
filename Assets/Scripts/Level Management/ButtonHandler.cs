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

    public void IsinterfaceOn()
    {

        if (GameManager.instance.isInterfaceOpen == false)
        {
            GameManager.instance.isInterfaceOpen = true;

        }

        else if (GameManager.instance.isInterfaceOpen == true)
        {
            
            GameManager.instance.isInterfaceOpen = false;

        }

    }

}
