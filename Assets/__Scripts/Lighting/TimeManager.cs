using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;

    public float dayDurationSecs = 60f;

    float totalTime = 0;
    float currentTime = 0;

    public float nightDuration = .4f;
    public float sunriseHour = 6;


    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDurationSecs;
    }

    void Start()
    {
        StartCoroutine(CurrentTime());
    }

    IEnumerator CurrentTime()
    {
        for (;;)
        {
            Debug.Log("Current time: " + currentTime);
            yield return new WaitForSeconds(1f);
        }
    }


    public float GetHour()
    {
        return currentTime * hoursInDay / dayDurationSecs;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDurationSecs)%minutesInHour;
    }

    public string Clock24Hour()
    {
        //00:00
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0) hour = 12;

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }
    public float GetSunsetHour()
    {
        return (sunriseHour + (1 - nightDuration) * hoursInDay) % hoursInDay;
    }
}
