using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    
    public bool interfaceOn;
    
    public void IsinterfaceOn()
    {
        GameManager.instance.isInterfaceOn = !GameManager.instance.isInterfaceOn;
        interfaceOn = !interfaceOn;

    }

}
