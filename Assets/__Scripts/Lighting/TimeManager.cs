using UnityEngine;
using UnityEngine.Events;


public class TimeManager : MonoBehaviour, ISaveable
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
        GameManager.Instance.startTime = hour;
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

    private void Tick()
    {
        AdvanceTime();
    }

    private void AdvanceTime()
    {
        dateTime.AdvanceMinutes(MinsAddedPerTick);

        OnDateTimeChanged?.Invoke(dateTime, continental);
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.timeData.date = dateTime.Date;
        a_SaveData.timeData.minutes = dateTime.Minutes;
        a_SaveData.timeData.hour = dateTime.Hour;
        a_SaveData.timeData.season = dateTime.Season;
        a_SaveData.timeData.year = dateTime.Year;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        dateTime.Minutes = a_SaveData.timeData.minutes;
        dateTime.Hour = a_SaveData.timeData.hour;
        dateTime.Season = a_SaveData.timeData.season;
        dateTime.Year = a_SaveData.timeData.year;
        dateTime.Date = a_SaveData.timeData.date;

        Debug.Log(
            $"Time settings - Year: {dateTime.Year} | Season: {dateTime.Season} | Day: {dateTime.Date} | Time:{dateTime.Hour}:{dateTime.Minutes}");
    }

    #endregion
}

[System.Serializable]
public struct _DateTime
{
    #region Fields

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

    public Days Day { get; private set; }

    public int Date
    {
        get => _date;
        set => _date = value;
    }

    public float Hour
    {
        get => _hour;
        set => _hour = (int)value;
    }

    public float Minutes
    {
        get => _minutes;
        set => _minutes = value;
    }

    public Season Season
    {
        get => _season;
        set => _season = value;
    }

    public int Year
    {
        get => _year;
        set => _year = value;
    }

    public int TotalNumDays => _totalNumDays;
    public int TotalNumWeeks => _totalNumWeeks;
    public int CurrentWeek => _totalNumWeeks % 16 == 0 ? 16 : _totalNumWeeks % 16;

    public int StreetLightsOnAt => _streetLightsOnAt;
    public int StreetLightsOffAt => _streetLightsOffAt;

    #endregion

    #region Constructors

    public _DateTime(int date, int season, int year, int hour, float minutes, int streetLightsOnAt,
        int streetLightsOffAt)
    {
        Day = (Days)(date % 7);
        if (Day == 0) { Day = (Days)7; }

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

    public void AdvanceMinutes(float SecondsToAdvanceBy)
    {
        if (_minutes + SecondsToAdvanceBy >= 60) // changed this from >=
        {
            _minutes = (_minutes + SecondsToAdvanceBy) % 60;
            AdvanceHour();
        }
        else
        {
            _minutes += SecondsToAdvanceBy;
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
        Day++;

        if (Day > (Days)7)
        {
            Day = (Days)1;
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
        Day++;
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
        return Day > Days.Fri ? true : false;
    }

    public bool IsParticularDay(Days _day)
    {
        return Day == _day;
    }

    #endregion

    #region Key Dates

    public _DateTime NewYearsDay(int year)
    {
        if (year == 0) { year = 1; }

        return new _DateTime(1, 0, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    public _DateTime SummerSolstice(int year)
    {
        if (year == 0) { year = 1; }

        return new _DateTime(28, 1, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    public _DateTime PumpkinHarvest(int year)
    {
        if (year == 0) { year = 1; }

        return new _DateTime(28, 2, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
    }

    #endregion

    #region Start Of Season

    public _DateTime StartOfSeason(int season, int year)
    {
        season = Mathf.Clamp(season, 0, 3);
        if (year == 0) { year = 1; }

        return new _DateTime(1, season, year, 6, 0, StreetLightsOnAt - 1, StreetLightsOffAt);
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

        string AmPm = _hour < 12 ? "AM" : "PM";

        return $"{adjustedHour.ToString("00")}:{Mathf.Floor(_minutes).ToString("00")}";
    }

    public string TimeToString24()
    {
        return $"{_hour.ToString("00")}:{Mathf.Floor(_minutes).ToString("00")}";
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