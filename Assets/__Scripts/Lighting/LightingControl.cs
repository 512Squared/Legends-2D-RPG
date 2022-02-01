using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;


public class LightingControl : MonoBehaviour
{
    [SerializeField] private LightingSchedule lightingSchedule;
    [SerializeField] private bool isLightFlickering = false;
    [SerializeField] [Range(0f, 1f)] private float lightFlickerIntensity;
    [SerializeField] [Range(0f, 0.2f)] private float lightFlickerTimeMin;
    [SerializeField] [Range(0f, 0.2f)] private float lightFlickerTimeMax;

    private Light2D light2D;
    private Dictionary<string, float> lightBrightnessDictionary = new Dictionary<string, float>();
    private float currentLightIntensity;
    private float lightFlickerTimer = 0f;
    private Coroutine fadeInLightRoutine;

    private void Awake()
    {
        // Get 2D light
        light2D = GetComponentInChildren<Light2D>();

        // disable if no light2D

        if (light2D == null)
            enabled = false;

        // populate lighting brightness dictionary
        //foreach (LightingBrightness lightingBrightness in lightingSchedule?.lightingBrightnessArray)
        //{
        //    string key = lightingBrightness.season.ToString() + lightingBrightness.hour.ToString();

        //    if (!lightBrightnessDictionary.ContainsKey(key))
        //    {
        //        lightBrightnessDictionary.Add(key, lightingBrightness.lightIntensity);
        //        Debug.Log($"Lighting Schedule Dictionary has had the {key} key added");
        //    }
        //}

    }

    private void OnEnable()
    {
        // subscribe to events
        //EventHandler.AdvanceGameHourEvent += EventHandler_AdvanceGameHourEvent;
        //EventHandler.AfterSceneLoadEvent += EventHandler_AfterSceneLoadEvent;

    }

    private void OnDisable()
    {
        // unsubscribe to events
        //EventHandler.AdvanceGameHourEvent -= EventHandler_AdvanceGameHourEvent;
        //EventHandler.AfterSceneLoadEvent -= EventHandler_AfterSceneLoadEvent;
    }

    private void EventHandler_AdvanceGameHourEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)

    {
        SetLightingIntensity(gameSeason, gameHour, true);
    }

    private void SetLightingIntensity(Season gameSeason, int gameHour, bool v)
    {
        
    }

    private void EventHandler_AfterSceneLoadEvent()
    {
        SetLightingAfterSceneLoad();
    }

    private void SetLightingAfterSceneLoad()
    {
        
    }

    private void Update()
    {
        if (isLightFlickering)
            lightFlickerTimer -= Time.deltaTime;
    }

}
    