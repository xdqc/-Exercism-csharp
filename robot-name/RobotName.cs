using System;

public class Robot
{
    public Robot()
    {
        Reset();
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }

    string _name;

    public void Reset()
    {
        Random rand = new Random();
        _name = string.Empty;
        _name += (char)rand.Next('A','Z');
        _name += (char)rand.Next('A','Z');
        _name += (char)rand.Next('0','9');
        _name += (char)rand.Next('0','9');
        _name += (char)rand.Next('0','9');
    }
}