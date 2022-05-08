using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;


public class ClockManager : MonoBehaviour
{
    [Header("Day-Night Clock")]
    public RectTransform clockFace;

    [Space]
    public TextMeshProUGUI date, time, seasons, year;

    [Space]
    public Image seasonSprite;

    private TimeDate _time;

    private float _startingRotation;

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
        _startingRotation = clockFace.localEulerAngles.z - 90;
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

    private void SceneChange(string scene, int empty, int empty2) // change daylight by scene type
    {
        this.scene = scene;

        if (scene == "shop1" || scene == "shop2" || scene == "shop3") { lightScaler = 1.2f; }
        else { lightScaler = 0f; }
    }


    private void UpdateDateTime(TimeDate timeDate, Continental continental) // UI update
    {
        _time = timeDate;

        date.text = timeDate.DateToString();
        if (continental.RailwayTime) { time.text = timeDate.TimeToString24(); }
        else if (!continental.RailwayTime) { time.text = timeDate.TimeToString12(); }

        seasonSprite.sprite = seasonSprites[(int)timeDate.Season];

        seasons.text = timeDate.Season.ToString();
        year.text = timeDate.YearToString();

        float t = (float)timeDate.Hour / 24f;

        float newRotation = Mathf.Lerp(360, 0, t);
        clockFace.localEulerAngles = new Vector3(0, 0, newRotation + _startingRotation);

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