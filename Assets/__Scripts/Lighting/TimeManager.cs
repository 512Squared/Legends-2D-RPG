using UnityEngine;
using UnityEngine.Events;
using System;
using Sirenix.OdinInspector;

public class TimeManager : MonoBehaviour
{
    [Header("Date & Time Settings")]

    public int streetLightsOnAt;
    public int streetLightsOffAt;

    [Space]
    [Range(1, 28)]
    public int dateInMonth;
    [Range(0, 3)]
    public int season;
    [Range(1, 99)]
    public int year;
    [Range(0, 24)]
    public int hour;
    [Range(0, 6)]
    public float minutes;
    [Space]
    public bool railwayTime;




    private _DateTime dateTime;
    private Continental continental;

    [Header("Tick Settings")]
    public float MinsAddedPerTick = 10;
    public float TickInSecs = 1;
    private float currentTimeBetweenTicks = 0;

    [Space]
    [Header("Lighting Controls")]


    public static UnityAction<_DateTime, Continental> OnDateTimeChanged;

    private void Awake()
    {
        dateTime = new _DateTime(dateInMonth, season, year, hour, minutes * 10, streetLightsOnAt, streetLightsOffAt);
        continental = new Continental(railwayTime);
    }

    private void Start()
    {
        OnDateTimeChanged?.Invoke(dateTime, continental);
    }

    private void Update()
    {
        currentTimeBetweenTicks += Time.deltaTime;

        if (currentTimeBetweenTicks >= TickInSecs)
        {
            currentTimeBetweenTicks = 0;
            Tick();
        }


    }

    void Tick()
    {
        AdvanceTime();
    }

    void AdvanceTime()
    {
        dateTime.AdvanceMinutes(MinsAddedPerTick);

        OnDateTimeChanged?.Invoke(dateTime, continental);
    }
}

[System.Serializable]
public struct _DateTime
{
    #region Fields
    private Days day;
    private int date;
    private int year;

    private int hour;
    private float minutes;

    private Season season;

    private int totalNumDays;
    private int totalNumWeeks;
    private int streetLightsOffAt;
    private int streetLightsOnAt;

    #endregion

    #region Properties
    public Days Day => day;
    public int Date => date;
    public float Hour => hour;
    public float Minutes => minutes;
    public Season Season => season;
    public int Year => year;
    public int TotalNumDays => totalNumDays;
    public int TotalNumWeeks => totalNumWeeks;
    public int CurrentWeek => totalNumWeeks % 16 == 0 ? 16 : totalNumWeeks % 16;

    public int StreetLightsOnAt => streetLightsOnAt;
    public int StreetLightsOffAt => streetLightsOffAt;

    #endregion

    #region Constructors

    public _DateTime(int date, int season, int year, int hour, float minutes, int streetLightsOnAt, int streetLightsOffAt)
    {
        this.day = (Days)(date % 7);
        if (day == 0) day = (Days)7;
        this.date = date;
        this.season = (Season)season;
        this.year = year;

        this.hour = hour;
        this.minutes = minutes;
        this.streetLightsOffAt = streetLightsOffAt;
        this.streetLightsOnAt = streetLightsOnAt;

        totalNumDays = date + (28 * (int)this.season) + (112 * (year - 1));

        totalNumWeeks = 1 + totalNumDays / 7;
    }

    #endregion

    #region Time Advancement

    public void AdvanceMinutes(float SecondsToAdvanceBy)
    {
        if (minutes + SecondsToAdvanceBy >= 60) // changed this from >=
        {
            minutes = (minutes + SecondsToAdvanceBy) % 60;
            AdvanceHour();
        }
        else
        {
            minutes += SecondsToAdvanceBy;
        }
    }

    private void AdvanceHour()
    {
        if ((hour + 1) == 24)
        {
            hour = 0;
            AdvanceDay();
        }
        else
        {
            hour++;
        }
    }

    private void AdvanceDay()
    {
        day++;

        if (day > (Days)7)
        {
            day = (Days)1;
            totalNumWeeks++;
        }

        date++;

        if (date % 29 == 0)
        {
            AdvanceSeason();
            date = 1;
        }

        totalNumDays++;

    }

    private void AdvanceSeason()
    {
        if (Season == Season.Winter)
        {
            season = Season.Spring;
            AdvanceYear();
        }
        else season++;
    }

    private void AdvanceYear()
    {
        date = 1;
        year++;
    }

    public void AdvanceHourKey()
    {
        hour++;
    }

    public void AdvanceDayKey()
    {
        day++;
    }

    #endregion

    #region Bool Checks
    public bool IsNight()
    {
        return hour > streetLightsOnAt || hour < streetLightsOffAt;
    }

    public bool IsMorning()
    {
        return hour >= streetLightsOffAt && hour <= 12;
    }

    public bool IsAfternoon()
    {
        return hour > 12 && hour < streetLightsOnAt;
    }

    public bool IsWeekend()
    {
        return day > Days.Fri ? true : false;
    }

    public bool IsParticularDay(Days _day)
    {
        return day == _day;
    }
    #endregion

    #region Key Dates

    public _DateTime NewYearsDay(int year)
    {
        if (year == 0) year = 1;
        return new _DateTime(1, 0, year, 6, 0, StreetLightsOnAt, StreetLightsOffAt);
    }

    public _DateTime SummerSolstice(int year)
    {
        if (year == 0) year = 1;
        return new _DateTime(28, 1, year, 6, 0, StreetLightsOnAt, StreetLightsOffAt);
    }
    public _DateTime PumpkinHarvest(int year)
    {
        if (year == 0) year = 1;
        return new _DateTime(28, 2, year, 6, 0, StreetLightsOnAt, StreetLightsOffAt);
    }

    #endregion

    #region Start Of Season

    public _DateTime StartOfSeason(int season, int year)
    {
        season = Mathf.Clamp(season, 0, 3);
        if (year == 0) year = 1;

        return new _DateTime(1, season, year, 6, 0, StreetLightsOnAt, StreetLightsOffAt);
    }

    public _DateTime StartOfSpring(int year)
    {
        return StartOfSeason(0, year);
    }

    public _DateTime StartOfSummer(int year)
    {
        return StartOfSeason(1, year);
    }

    public _DateTime StartOfAutumn(int year)
    {
        return StartOfSeason(2, year);
    }

    public _DateTime StartOfWinter(int year)
    {
        return StartOfSeason(3, year);
    }

    #endregion

    #region To Strings

    public override string ToString()
    {
        return $"Date: {DateToString()} Season: {season} Time: {TimeToString24()} " +
            $"\nTotal Days: {totalNumDays} | Total Weeks: {totalNumWeeks}";
    }
    public string DateToString()
    {
        return $"{Day} {Date}";
    }

    public string YearToString()
    {
        return $"Year {Year.ToString()}";
    }

    public string TimeToString12()
    {
        float adjustedHour = 0;

        if (hour == 0)
        {
            adjustedHour = 12;
        }
        else if (hour >= 13)
        {
            adjustedHour = hour - 12;
        }
        else
        {
            adjustedHour = hour;
        }

        string AmPm = hour < 12 ? "AM" : "PM";

        return $"{adjustedHour.ToString("00")}:{Mathf.Floor(minutes).ToString("00")}";
    }

    public string TimeToString24()
    {
        return $"{hour.ToString("00")}:{Mathf.Floor(minutes).ToString("00")}";
    }

    #endregion
}
[System.Serializable]
public struct Continental
{
    private bool railwayTime;

    public bool RailwayTime => railwayTime;

    public Continental(bool railwayTime)
    {
        this.railwayTime = railwayTime;
    }
}

[System.Serializable]
public enum Days
{
    NULL = 0,
    Mon = 1,
    Tue = 2,
    Wed = 3,
    Thu = 4,
    Fri = 5,
    Sat = 6,
    Sun = 7
}

