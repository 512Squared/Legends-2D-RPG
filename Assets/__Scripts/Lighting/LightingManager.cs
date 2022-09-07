using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightingManager : MonoBehaviour
{
    #region Serialized Fields

    [Space] public GameObject[] sceneLighting;

    private bool lightsOn;
    private bool tripSwitch;
    [SerializeField] private GameObject[] candleLighting;

    public Sprite candleOff;
    public Sprite candleOn;

    #endregion

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += TimeFetch;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= TimeFetch;
    }

    private void TimeFetch(_DateTime time, Continental empty)
    {
        if (time.IsNight() && lightsOn)
        {
            LightsOn();
            StartCoroutine(PlayerAudio());
            lightsOn = false;
        }
        else if (!time.IsNight() && !lightsOn)
        {
            LightsOff();
            lightsOn = true;
        }
    }

    private static IEnumerator PlayerAudio()
    {
        yield return new WaitForSeconds(1.5f);
        AudioManager.Instance.PlaySfxClip(7);
    }

    private void LightsOn()
    {
        StartCoroutine(FlickTheSwitchBoy());
    }

    private IEnumerator FlickTheSwitchBoy()
    {
        yield return new WaitForSeconds(2f);

        foreach (GameObject t in sceneLighting) { t.GetComponent<Light2D>().enabled = true; }

        foreach (GameObject s in candleLighting)
        {
            s.GetComponent<SpriteRenderer>().sprite = candleOn;
            s.GetComponent<Animator>().enabled = true;
            s.GetComponentInChildren<Flicker>().enabled = true;
            s.GetComponentInChildren<Light2D>().enabled = true;
        }
    }

    private void LightsOff()
    {
        foreach (GameObject g in sceneLighting) { g.GetComponent<Light2D>().enabled = false; }

        foreach (GameObject s in candleLighting)
        {
            s.GetComponent<SpriteRenderer>().sprite = candleOff;
            s.GetComponent<Animator>().enabled = false;
            s.GetComponentInChildren<Flicker>().enabled = false;
            s.GetComponentInChildren<Light2D>().enabled = false;
        }
    }
}