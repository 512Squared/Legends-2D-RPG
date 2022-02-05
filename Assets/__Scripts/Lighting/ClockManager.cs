using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;


public class ClockManager : MonoBehaviour
{
    public RectTransform ClockFace;
    public TextMeshProUGUI Date, Time, Season, Year;

    public Image weatherSprite;
    public Sprite[] weatherSprites;

    private float startingRotation = 180;

    public Light2D sunlight;
    public float nightIntensity;
    public float dayIntensity;

    public AnimationCurve dayNightCurve;

    private void Awake()
    {
        startingRotation = ClockFace.localEulerAngles.z;
    }

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(_DateTime dateTime)
    {
        Date.text = dateTime.DateToString();
        if (dateTime.railwayTime) Time.text = dateTime.TimeToString24();
        else if (!dateTime.railwayTime) Time.text = dateTime.TimeToString12();
        Season.text = dateTime.Season.ToString();
        Year.text = dateTime.YearToString();

        float t = (float)dateTime.Hour / 24f;

        float newRotation = Mathf.Lerp(0, 360, t);
        ClockFace.localEulerAngles = new Vector3(0, 0, newRotation + startingRotation);

        float dayNightT = dayNightCurve.Evaluate(t);

        sunlight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, dayNightT);
    }
}
