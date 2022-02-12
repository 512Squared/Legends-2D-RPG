using UnityEngine;
using UnityEngine.Events;
using System;
using Sirenix.OdinInspector;

public class TimeManager : MonoBehaviour
{
    [Header("Date & Time Settings")]
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
        dateTime = new _DateTime(dateInMonth, season, year, hour, minutes * 10);
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

    #endregion

    #region Constructors

    public _DateTime(int date, int season, int year, int hour, float minutes)
    {
        this.day = (Days)(date % 7);
        if (day == 0) day = (Days)7;
        this.date = date;
        this.season = (Season)season;
        this.year = year;

        this.hour = hour;
        this.minutes = minutes;


        totalNumDays = date + (28 * (int)this.season) + (112 * (year - 1));

        totalNumWeeks = 1 + totalNumDays / 7;
    }

    #endregion

    #region Time Advancement

    public void AdvanceMinutes(float SecondsToAdvanceBy)
    {
        if (minutes + SecondsToAdvanceBy >= 60)
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
            if (IsMorning()) Actions.OnDawn?.Invoke();
            else if (IsAfternoon()) Actions.OnDawn?.Invoke();
            else if (IsNight()) Actions.OnDusk?.Invoke();
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
        return hour > 17 || hour < 6;
    }

    public bool IsMorning()
    {
        return hour >= 7 && hour <= 12;
    }

    public bool IsAfternoon()
    {
        return hour > 12 && hour < 17;
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
        return new _DateTime(1, 0, year, 6, 0);
    }

    public _DateTime SummerSolstice(int year)
    {
        if (year == 0) year = 1;
        return new _DateTime(28, 1, year, 6, 0);
    }
    public _DateTime PumpkinHarvest(int year)
    {
        if (year == 0) year = 1;
        return new _DateTime(28, 2, year, 6, 0);
    }

    #endregion

    #region Start Of Season

    public _DateTime StartOfSeason(int season, int year)
    {
        season = Mathf.Clamp(season, 0, 3);
        if (year == 0) year = 1;

        return new _DateTime(1, season, year, 6, 0);
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

        return $"{adjustedHour.ToString("00")}:{minutes.ToString("00")}";
    }

    public string TimeToString24()
    {
        return $"{hour.ToString("00")}:{minutes.ToString("00")}";
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



#region Old Code

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class TimeManager : SingletonMonoBehaviour<TimeManager>
//{
//    [Range(1, 99)]
//    public int TimeController;

//    private int gameYear = 1;
//    private Season gameSeason = Season.Spring;
//    public int gameDay = 1;
//    private int gameHour = 6;
//    private int gameMinute = 30;
//    private int gameSecond = 0;
//    private string gameDayOfWeek = "Mon";

//    public float dayDurationSecs = 0f;



//    private bool gameClockPaused = false;
//    public bool advanceGameTime = false;

//    private float gameTick = 0f;

//    private string _iSaveableUniqueID;
//    public string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; } }


//    protected override void Awake()
//    {
//        base.Awake();

//    }

//    private void Start()
//    {
//        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
//        //dayDurationSecs = Mathf.Floor(gameSecond);
//        Debug.Log($"gameSecond/dayDurationSecs: {dayDurationSecs}");
//    }

//    private void Update()
//    {
//        if (!gameClockPaused)
//        {
//            GameTick();
//        }

//        totalTime += Time.deltaTime;
//        currentTime = gameTick % gameDay; // changed from totalTime to gameTick and dayDurationSecs to gameDay

//        if (advanceGameTime)
//        {
//            TestAdvanceGameMinute();
//        }
//    }

//    private void GameTick()
//    {
//        gameTick += Time.deltaTime; // frameRate

//        if (gameTick >= Settings.secondsPerGameSecond)
//        {
//            gameTick -= Settings.secondsPerGameSecond;

//            UpdateGameSecond();
//            //Debug.Log($"gameTick registered: {gameTick}");
//        }
//    }

//    private void UpdateGameSecond()
//    {
//        gameSecond++;

//        if (gameSecond > 59)
//        {
//            gameSecond = 0;
//            gameMinute++;


//            if (gameMinute > 59)
//            {
//                gameMinute = 0;
//                gameHour++;

//                if (gameHour > 23)
//                {
//                    gameHour = 0;
//                    gameDay++;

//                    if (gameDay > 30)
//                    {
//                        gameDay = 1;

//                        int gs = (int)gameSeason;
//                        gs++;

//                        gameSeason = (Season)gs;

//                        if (gs > 3)
//                        {
//                            gs = 0;
//                            gameSeason = (Season)gs;

//                            gameYear++;

//                            if (gameYear > 9999)
//                                gameYear = 1;


//                            EventHandler.CallAdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
//                        }

//                        EventHandler.CallAdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
//                    }

//                    gameDayOfWeek = GetDayOfWeek();
//                    EventHandler.CallAdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
//                }

//                EventHandler.CallAdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
//            }

//            EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);

//            //Debug.Log($"Year: {gameYear} | Season: {gameSeason} | Day: {gameDay} | Hour: {gameHour} | Minute:  {gameMinute}");

//        }

//        // Call to advance game second event would go here if required
//    }

//    private string GetDayOfWeek()
//    {
//        int totalDays = (((int)gameSeason) * 30) + gameDay;
//        int dayOfWeek = totalDays % 7;

//        switch (dayOfWeek)
//        {
//            case 1:
//                return "Mon";

//            case 2:
//                return "Tue";

//            case 3:
//                return "Wed";

//            case 4:
//                return "Thu";

//            case 5:
//                return "Fri";

//            case 6:
//                return "Sat";

//            case 0:
//                return "Sun";

//            default:
//                return "";
//        }
//    }

//    public TimeSpan GetGameTime()
//    {
//        TimeSpan gameTime = new TimeSpan(gameHour, gameMinute, gameSecond);

//        return gameTime;
//    }

//    public Season GetGameSeason()
//    {
//        return gameSeason;
//    }


//    public void TestAdvanceGameMinute()
//    {
//        int multiplier = TimeController * 60;



//        for (int i = 0; i < multiplier; i++)
//        {
//            UpdateGameSecond();
//        }
//    }

//    public void TestAdvanceGameDay()
//    {
//        for (int i = 0; i < 86400; i++)
//        {
//            UpdateGameSecond();
//        }
//    }



//    /// <summary>
//    /// Everything after this is the original nightdayCycle code 
//    /// </summary>

//    [Space]
//    public const int hoursInDay = 24, minutesInHour = 60;



//    float totalTime = 0;
//    float currentTime = 0;

//    public float nightDuration = .4f;
//    public float sunriseHour = 6;

//    public float GetHour()
//    {
//        return currentTime * hoursInDay / dayDurationSecs;
//    }

//    public float GetMinutes()
//    {
//        return (currentTime * hoursInDay * minutesInHour / dayDurationSecs)%minutesInHour;
//    }

//    public string Clock24Hour()
//    {
//        //00:00
//        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
//    }

//    public string Clock12Hour()
//    {
//        int hour = Mathf.FloorToInt(GetHour());
//        string abbreviation = "AM";

//        if (hour >= 12)
//        {
//            abbreviation = "PM";
//            hour -= 12;
//        }

//        if (hour == 0) hour = 12;

//        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
//    }
//    public float GetSunsetHour()
//    {
//        return (sunriseHour + (1 - nightDuration) * hoursInDay) % hoursInDay;
//    }
//}

#endregion
