using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;


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

    public AnimationCurve dayNightCurve;

    private void Awake()
    {
        startingRotation = ClockFace.localEulerAngles.z - 90;

    }

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(_DateTime dateTime, Continental continental)
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

        sunlight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, dayNightT);
        _time = dateTime;
    }

}



