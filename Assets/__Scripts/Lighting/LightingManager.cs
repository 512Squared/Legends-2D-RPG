using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class LightingManager : MonoBehaviour
{

    #region Serialized Fields


    public GameObject[] sceneLighting;


    #endregion


    private void OnEnable()
    {
        Actions.OnDusk += LightsOn;
        Actions.OnDawn += LightsOff;
    }

    private void OnDisable()
    {
        Actions.OnDusk -= LightsOn;
        Actions.OnDawn -= LightsOff;
    }

    private void LightsOn()
    {
        Debug.Log($"Lights switched on");
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = true; 
        }
        

    }
    private void LightsOff()
    {

        Debug.Log($"Lights switched off");
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = false;
        }
    }

}
