using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;


public class ClockManager : MonoBehaviour
{
    public RectTransform ClockFace;
    public TextMeshProUGUI Date, Time, Seasons, Year;

    public Image seasonSprite;
    public Sprite[] seasonSprites = new Sprite[3];
    private _DateTime _time;

    private float startingRotation;

    public Light2D sunlight;
    public float nightIntensity;
    public float dayIntensity;
    public float lightScaler;

    public AnimationCurve dayNightCurve;

    public bool isDaylightOn;

    private void Awake()
    {
        startingRotation = ClockFace.localEulerAngles.z - 90;
        isDaylightOn = true;
    }

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
        Actions.OnUnderground += GlobalLightSwitch;
        Actions.OnOverground += GlobalLightSwitch;
        Actions.OnSceneChange += SceneChange;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
        Actions.OnUnderground -= GlobalLightSwitch;
        Actions.OnOverground -= GlobalLightSwitch;
    }

    private void SceneChange(SceneObjectsLoad scene)  // change daylight by scene type
    {

        if (scene == SceneObjectsLoad.shop1 || scene == SceneObjectsLoad.shop2 || scene == SceneObjectsLoad.shop3) lightScaler = 1.2f;
        else lightScaler = 0f;  
        
        StartCoroutine(FrameDelay());
        
        Debug.Log($"Is globalLight on: {isDaylightOn}");
    }

    public IEnumerator FrameDelay() // subscriber = LightingManager streetlamps
    {
        yield return null;
        if (_time.IsAfternoon())
        {
            Actions.OnSceneChangeTimeCheck?.Invoke(true, _time);
            isDaylightOn = true;
        }

        else if (_time.IsMorning())
        {
            Actions.OnSceneChangeTimeCheck?.Invoke(true, _time);
            isDaylightOn = true;
        }

        else if (_time.IsNight())
        {
            Actions.OnSceneChangeTimeCheck?.Invoke(false, _time);
            isDaylightOn = false;
        }
    }

    private void GlobalLightSwitch() // global ligth
    {
        if (_time.IsAfternoon()) isDaylightOn = false;
        else if (_time.IsMorning()) isDaylightOn = false;
        else if (_time.IsNight()) isDaylightOn = true;
    }

    private void UpdateDateTime(_DateTime dateTime, Continental continental) // UI update
    {
        Date.text = dateTime.DateToString();
        if (continental.RailwayTime) Time.text = dateTime.TimeToString24();
        else if (!continental.RailwayTime) Time.text = dateTime.TimeToString12();

        seasonSprite.sprite = seasonSprites[(int)dateTime.Season];

        Seasons.text = dateTime.Season.ToString();
        Year.text = dateTime.YearToString();

        float t = (float)dateTime.Hour / 24f;

        float newRotation = Mathf.Lerp(360, 0, t);
        ClockFace.localEulerAngles = new Vector3(0, 0, newRotation + startingRotation);

        float dayNightT = dayNightCurve.Evaluate(t);

        if (isDaylightOn == true)
            sunlight.intensity = Mathf.Lerp((dayIntensity-lightScaler), nightIntensity, dayNightT);

        else if(isDaylightOn == false)
            sunlight.intensity = 0.1f;

        _time = dateTime;


    }

}



