using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;


public class ClockManager : SingletonMonobehaviour<ClockManager>
{
    [Header("Day-Night Clock")]
    public RectTransform ClockFace;

    [Space]
    public TextMeshProUGUI Date, Time, Seasons, Year;

    [Space]
    public Image seasonSprite;

    private _DateTime _time;

    private float startingRotation;

    [Space]
    public Light2D sunlight;

    public float nightIntensity;
    public float dayIntensity;
    public float lightScaler;

    [Space]
    public AnimationCurve dayNightCurve;

    [Space]
    public bool isDaylightOn;

    public string scene;

    [Space]
    public Sprite[] seasonSprites = new Sprite[3];

    private void Awake()
    {
        startingRotation = ClockFace.localEulerAngles.z - 90;
        isDaylightOn = true;
        lightScaler = 0;
    }

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
        Actions.OnSceneChange += SceneChange;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
        Actions.OnSceneChange -= SceneChange;
    }

    public void SceneChange(string scene, string arrivingFrom, int empty, int empty2) // change daylight by scene type
    {
        this.scene = scene;

        lightScaler = scene is "shop1" or "shop2" or "shop3" ? 1.2f : 0f;
    }


    private void UpdateDateTime(_DateTime dateTime, Continental continental) // UI update
    {
        _time = dateTime;

        Date.text = dateTime.DateToString();
        if (continental.RailwayTime) { Time.text = dateTime.TimeToString24(); }
        else if (!continental.RailwayTime) { Time.text = dateTime.TimeToString12(); }

        seasonSprite.sprite = seasonSprites[(int)dateTime.Season];

        Seasons.text = dateTime.Season.ToString();
        Year.text = dateTime.YearToString();

        float t = (float)dateTime.Hour / 24f;

        float newRotation = Mathf.Lerp(360, 0, t);
        ClockFace.localEulerAngles = new Vector3(0, 0, newRotation + startingRotation);

        float dayNightT = dayNightCurve.Evaluate(t);

        if (_time.Hour > _time.StreetLightsOnAt || _time.Hour < _time.StreetLightsOffAt) { sunlight.intensity = 0.2f; }

        else { sunlight.intensity = Mathf.Lerp(dayIntensity - lightScaler, nightIntensity, dayNightT); }

        if (scene == "Dungeon")
        {
            lightScaler = 0;
            sunlight.intensity = 0.2f;
        }
    }
}