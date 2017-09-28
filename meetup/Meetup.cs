using System;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    public Meetup(int month, int year)
    {
        Year = year;
        Month = month;
    }

    int Year;
    int Month;
    
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        Dictionary<Schedule, int> DayOffset = new Dictionary<Schedule, int>{
            {Schedule.First, 1},
            {Schedule.Second, 8},
            {Schedule.Third, 15},
            {Schedule.Fourth, 22},
            {Schedule.Teenth, 13},
            {Schedule.Last, DateTime.DaysInMonth(Year, Month)-6}
        };

        var day = new DateTime(Year, Month, DayOffset[schedule]);

        while (day.DayOfWeek != dayOfWeek)
        {
            day = day.AddDays(1);
        }

        return day;
    }
}