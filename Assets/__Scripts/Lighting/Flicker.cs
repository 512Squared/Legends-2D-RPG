using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


[RequireComponent(typeof(Light2D))]
public class Flicker : MonoBehaviour
{
    /************************************************************/
    #region Variables

    [Tooltip("maximum possible intensity the light can flicker to")]
    [SerializeField, Min(0)] float maxIntensity = 1f;

    [Tooltip("minimum possible intensity the light can flicker to")]
    [SerializeField, Min(0)] float minIntensity = 0.5f;

    [Tooltip("maximum frequency of often the light will flicker in seconds")]
    [SerializeField, Min(0)] float maxFlickerFrequency = 1f;

    [Tooltip("minimum frequency of often the light will flicker in seconds")]
    [SerializeField, Min(0)] float minFlickerFrequency = 0.1f;

    [Tooltip("how fast the light will flicker to it's next intensity (a very high value will)" +
        "look like a dying lightbulb while a lower value will look more like an organic fire")]
    [SerializeField, Min(0)] float strength = 5f;

    float baseIntensity;
    float nextIntensity;

    float flickerFrequency;
    float timeOfLastFlicker;

    #endregion
    /************************************************************/
    #region Class Functions

    private Light2D LightSource => GetComponent<Light2D>();

    #endregion
    /************************************************************/
    #region Class Functions

    #region Unity Functions

    private void OnValidate()
    {
        if (maxIntensity < minIntensity) minIntensity = maxIntensity;
        if (maxFlickerFrequency < minFlickerFrequency) minFlickerFrequency = maxFlickerFrequency;
    }

    private void Awake()
    {
        baseIntensity = LightSource.intensity;

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
        LightSource.intensity = Mathf.Lerp(
            LightSource.intensity,
            nextIntensity,
            strength * Time.deltaTime
        );
    }

    public void Reset()
    {
        LightSource.intensity = baseIntensity;
    }

    #endregion

    #endregion
}