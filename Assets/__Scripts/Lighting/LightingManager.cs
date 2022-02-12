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
        Actions.OnSceneChangeTimeCheck += SceneChangeTimeCheck;
        Actions.OnDusk += LightsOn;
        Actions.OnDawn += LightsOff;
    }

    private void OnDisable()
    {
        Actions.OnSceneChangeTimeCheck -= SceneChangeTimeCheck;
        Actions.OnDusk -= LightsOn;
        Actions.OnDawn -= LightsOff;

    }

    private void SceneChangeTimeCheck(bool isDayTime, _DateTime _time)
    {
        if (isDayTime) LightsOff();
        else if (!isDayTime) LightsOn();
        Debug.Log($"Time: {_time.Hour}:{_time.Minutes} | Afternoon: {_time.IsAfternoon()} | Night: {_time.IsNight()} | Morning: {_time.IsMorning()}");
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


    private void Start()
    {
        
    }
}
