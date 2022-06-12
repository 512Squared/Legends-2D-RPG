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
        if (time.IsNight())
        {
            LightsOn();
            lightsOn = true;
            if (lightsOn && tripSwitch)
            {
                StartCoroutine(PlayerAudio());
                tripSwitch = false;
            }
        }
        else
        {
            LightsOff();
            tripSwitch = true;
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
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = true;
        }
    }

    private void LightsOff()
    {
        for (int i = 0; i < sceneLighting.Length; i++)
        {
            sceneLighting[i].GetComponent<Light2D>().enabled = false;
        }
    }
}