using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flicker : MonoBehaviour
{
    /************************************************************/

 
   #region Variables

    [Tooltip("Torch is the default setting.Area settings: 0.2, 0, 0.2, 0, 5;")]
    [SerializeField] [Min(0)]
    private float maxIntensity = 1f;

    [Tooltip("minimum possible intensity the light can flicker to")]
    [SerializeField] [Min(0)]
    private float minIntensity = 0.2f;

    [Tooltip("maximum frequency of often the light will flicker in seconds")]
    [SerializeField] [Min(0)]
    private float maxFlickerFrequency = 0.1f;

    [Tooltip("minimum frequency of often the light will flicker in seconds")]
    [SerializeField] [Min(0)]
    private float minFlickerFrequency = 0f;

    [Tooltip("how fast the light will flicker              next intensity (a very high value will)" +
             "look like a dying lightbulb while a lower value will look more like an organic fire")]
    [SerializeField] [Min(0)]
    private float strength = 5f;

    private float _baseIntensity;
    private float _nextIn
tensity;

    private float _flickerFrequency;
    private float _t
imeOfLastFlicker;

    #endregion

    /*******************************************************
        ****/

    #region Class Functions

    private UnityEngine.Rendering.Uni
versal.Light2D LightSource =>
        GetComponent<UnityEngine.Rend
ering.Universal.Light2D>();

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
        _baseIntensity = LightSource.intensity;

        _timeOfLastFlicker = Time.time;
    }

    private void Update()
    {
        if (_timeOfLastFlicker + _flickerFrequency < Time.time)
        {
            _timeOfLastFlicker = Time.time;
            _nextIntensity = Random.Range(minIntensity, maxIntensity);
            _flickerFrequency = Random.Range(minFlickerFrequency, maxFlickerFrequency);
        }

        FlickerFlame();
    }

    #endregion

    #region Other Light Functions

    private void FlickerFlame()
    {
        LightSource.intensity = Mathf.Lerp(
            LightSource.intensity,
            _nextIntensity,
            strength * Time.deltaTime
        );
    }

    public void Reset()
    {
        LightSource.intensity = _baseIntensity;
    }

    #endregion

    #endregion
}