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

        GameManager.instance.isInterfaceOn = !GameManager.instance.isInterfaceOn;


    }

}
