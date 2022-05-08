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


    private TimeDate _timeDate;
    private Continental _continental;

    [Header("Tick Settings")]
    public float minsAddedPerTick = 10;

    public float tickInSecs = 1;
    private float _currentTimeBetweenTicks = 0;

    [Space]
    [Header("Lighting Controls")]
    public static UnityAction<TimeDate, Continental> OnDateTimeChanged;

    private void Awake()
    {
        _timeDate = new TimeDate(dateInMonth, season, year, hour, minutes * 10, streetLightsOnAt, streetLightsOffAt);
        _continental = new Continental(railwayTime);
    }

    private void Start()
    {
        OnDateTimeChanged?.Invoke(_timeDate, _continental);
    }

    private void Update()
    {
        _currentTimeBetweenTicks += Time.deltaTime;

        if (_currentTimeBetweenTicks >= tickInSecs)
        {
            _currentTimeBetweenTicks = 0;
            Tick();
        }
    }

    private void Tick()
    {
        AdvanceTime();
    }

    private void AdvanceTime()
    {
        _timeDate.AdvanceMinutes(minsAddedPerTick);

        OnDateTimeChanged?.Invoke(_timeDate, _continental);
    }
}

[Serializable]
public struct TimeDate
{
    #region Fields

    private Days _day;
    private int _date;
    private int _year;

    private int _hour;
    private float _minutes;

    private Season _season;

    private int _totalNumDays;
    private int _totalNumWeeks;
    private int _streetLightsOffAt;
    private int _streetLightsOnAt;

    #endregion

    #region Properties

    public Days Day => _day;
    public int Date => _date;
    public float Hour => _hour;
    public float Minutes => _minutes;
    public Season Season => _season;
    public int Year => _year;
    public int TotalNumDays => _totalNumDays;
    public int TotalNumWeeks => _totalNumWeeks;
    public int CurrentWeek => _totalNumWeeks % 16 == 0 ? 16 : _totalNumWeeks % 16;

    public int StreetLightsOnAt => _streetLightsOnAt;
    public int StreetLightsOffAt => _streetLightsOffAt;

    #endregion

    #region Constructors

    public TimeDate(int date, int season, int year, int hour, float minutes, int streetLightsOnAt,
        int streetLightsOffAt)
    {
        _day = (Days)(date % 7);
        if (_day == 0) { _day = (Days)7; }

        _date = date;
        _season = (Season)season;
        _year = year;

        _hour = hour;
        _minutes = minutes;
        _streetLightsOffAt = streetLightsOffAt;
        _streetLightsOnAt = streetLightsOnAt;

        _totalNumDays = date + (28 * (int)_season) + (112 * (year - 1));

        _totalNumWeeks = 1 + (_totalNumDays / 7);
    }

    #endregion

    #region Time Advancement

    public void AdvanceMinutes(float secondsToAdvanceBy)
    {
        if (_minutes + secondsToAdvanceBy >= 60) // changed this from >=
        {
            _minutes = (_minutes + secondsToAdvanceBy) % 60;
            AdvanceHour();
        }
        else
        {
            _minutes += secondsToAdvanceBy;
        }
    }

    private void AdvanceHour()
    {
        if (_hour + 1 == 24)
        {
            _hour = 0;
            AdvanceDay();
        }
        else
        {
            _hour++;
        }
    }

    private void AdvanceDay()
    {
        _day++;

        if (_day > (Days)7)
        {
            _day = (Days)1;
            _totalNumWeeks++;
        }

        _date++;

        if (_date % 29 == 0)
        {
            AdvanceSeason();
            _date = 1;
        }

        _totalNumDays++;
    }

    private void AdvanceSeason()
    {
        if (Season == Season.Winter)
        {
            _season = Season.Spring;
            AdvanceYear();
        }
        else { _season++; }
    }

    private void AdvanceYear()
    {
        _date = 1;
        _year++;
    }

    public void AdvanceHourKey()
    {
        _hour++;
    }

    public void AdvanceDayKey()
    {
        _day++;
    }

    #endregion

    #region Bool Checks

    public bool IsNight()
    {
        return _hour > _streetLightsOnAt - 1 || _hour < _streetLightsOffAt;
    }

    public bool IsMorning()
    {
        return _hour >= _streetLightsOffAt && _hour <= 12;
    }

    public bool IsAfternoon()
    {
        return _hour > 12 && _hour < _streetLightsOnAt - 1;
    }

    public bool IsWeekend()
    {
        return _day > Days.Fri ? true : false;
    }

    public bool IsParticularDay(Days day)
    {
        return _day == day;
    }

    #endregion

    #region Key Dates

    public TimeDate NewYearsDay(int year)
    {
        if (year == 0) { year = 1; }

        return new TimeDate(1, 0, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    public TimeDate SummerSolstice(int year)
    {
        if (year == 0) { year = 1; }

        return new TimeDate(28, 1, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    public TimeDate PumpkinHarvest(int year)
    {
        if (year == 0) { year = 1; }

        return new TimeDate(28, 2, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    #endregion

    #region Start Of Season

    public TimeDate StartOfSeason(int season, int year)
    {
        season = Mathf.Clamp(season, 0, 3);
        if (year == 0) { year = 1; }

        return new TimeDate(1, season, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    public TimeDate StartOfSpring(int year)
    {
        return StartOfSeason(0, year);
    }

    public TimeDate StartOfSummer(int year)
    {
        return StartOfSeason(1, year);
    }

    public TimeDate StartOfAutumn(int year)
    {
        return StartOfSeason(2, year);
    }

    public TimeDate StartOfWinter(int year)
    {
        return StartOfSeason(3, year);
    }

    #endregion

    #region To Strings

    public override string ToString()
    {
        return $"Date: {DateToString()} Season: {_season} Time: {TimeToString24()} " +
               $"\nTotal Days: {_totalNumDays} | Total Weeks: {_totalNumWeeks}";
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

        if (_hour == 0)
        {
            adjustedHour = 12;
        }
        else if (_hour >= 13)
        {
            adjustedHour = _hour - 12;
        }
        else
        {
            adjustedHour = _hour;
        }

        string amPm = _hour < 12 ? "AM" : "PM";

        return $"{adjustedHour.ToString("00")}:{Mathf.Floor(_minutes).ToString("00")}";
    }

    public string TimeToString24()
    {
        return $"{_hour.ToString("00")}:{Mathf.Floor(_minutes).ToString("00")}";
    }

    #endregion
}

[Serializable]
public struct Continental
{
    private bool _railwayTime;

    public bool RailwayTime => _railwayTime;

    public Continental(bool railwayTime)
    {
        _railwayTime = railwayTime;
    }
}

[Serializable]
public enum Days
{
    Null = 0,
    Mon = 1,
    Tue = 2,
    Wed = 3,
    Thu = 4,
    Fri = 5,
    Sat = 6,
    Sun = 7
}