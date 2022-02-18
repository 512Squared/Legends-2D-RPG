using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using System;

public class LightingManager : MonoBehaviour
{

    #region Serialized Fields

    [Space]
    public GameObject[] sceneLighting;



    #endregion

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += TimeFetch;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= TimeFetch;
    }

    private void TimeFetch(_DateTime time, Continental empty)
    {
        if (time.IsNight()) LightsOn();
        else LightsOff();
        
    }

    private void LightsOn()
    {
        StartCoroutine(FlickTheSwitchBoy());       
    }

    private IEnumerator FlickTheSwitchBoy()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = true;
        }

    }

    private void LightsOff()
    {
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = false;
        }
    }

}
