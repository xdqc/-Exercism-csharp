using System;

public class Clock : IEquatable<Clock>
{
    public Clock(int hours)
    {
        Hour = hours;
    }

    public Clock(int hours, int minutes)
    {
        Hour = hours;
        Minute = minutes;
    }

    public int Hour
    {
        get
        {
            _minute = _minute < 0 ? _minute - 60 : _minute;
            _hour += _minute / 60;
            return mod(_hour, 24);
        }
        set
        {
            _hour = value;
        }
    }
    public int Minute
    {
        get
        {
            return mod(_minute, 60);
        }
        set
        {
            _minute = value;
        }
    }

    int _hour;
    int _minute;

    public Clock Add(int minutesToAdd)
    {
        Minute += minutesToAdd;
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        Minute -= minutesToSubtract;
        return this;
    }

    public override string ToString()
    {
        return $"{Hour.ToString().PadLeft(2, '0')}:{Minute.ToString().PadLeft(2, '0')}";
    }

    int mod(int a, int n)
    {
        return ((a % n) + n) % n;
    }

    public bool Equals(Clock other)
    {
        return other.Hour == Hour && other.Minute == Minute;
    }
}