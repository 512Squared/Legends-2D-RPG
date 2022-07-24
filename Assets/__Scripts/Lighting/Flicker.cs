using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Flicker : MonoBehaviour
{
    /************************************************************/

    #region Variables

    [Tooltip("Torch is the default setting.Area settings: 0.2, 0, 0.2, 0, 5;")]
    [SerializeField] [Min(0)] private float maxIntensity = 1f;

    [Tooltip("minimum possible intensity the light can flicker to")]
    [SerializeField] [Min(0)] private float minIntensity = 0.2f;

    [Tooltip("maximum frequency of often the light will flicker in seconds")]
    [SerializeField] [Min(0)] private float maxFlickerFrequency = 0.1f;

    [Tooltip("minimum frequency of often the light will flicker in seconds")]
    [SerializeField] [Min(0)]
    private float minFlickerFrequency;

    [Tooltip("how fast the light will flicker to it's next intensity (a very high value will)" +
             "look like a dying light bulb while a lower value will look more like an organic fire")]
    [SerializeField] [Min(0)]
    private float strength = 5f;

    private float baseIntensity;
    private float nextIntensity;

    private float flickerFrequency;
    private float timeOfLastFlicker;

    #endregion

    /************************************************************/

    #region Class Functions

    private Light2D lightSource;

    #endregion

    /************************************************************/

    #region Class Functions

    #region Unity Functions

    private void OnValidate()
    {
        if (maxIntensity < minIntensity) { minIntensity = maxIntensity; }

        if (maxFlickerFrequency < minFlickerFrequency) { minFlickerFrequency = maxFlickerFrequency; }
    }

    private void Awake()
    {
        lightSource = GetComponent<Light2D>();

        baseIntensity = lightSource.intensity;

        timeOfLastFlicker = Time.time;
    }

    private void Update()
    {
        if (timeOfLastFlicker + flickerFrequency < Time.time)
        {
            timeOfLastFlicker = Time.time;
            nextIntensity = Random.Range(minIntensity, maxIntensity);
            flickerFrequency = Random.Range(minFlickerFrequency, maxFlickerFrequency);
        }

        FlickerFlame();
    }

    #endregion

    #region Other Light Functions

    private void FlickerFlame()
    {
        lightSource.intensity = Mathf.Lerp(
            lightSource.intensity,
            nextIntensity,
            strength * Time.deltaTime
        );
    }

    public void Reset()
    {
        lightSource.intensity = baseIntensity;
    }

    #endregion

    #endregion
}