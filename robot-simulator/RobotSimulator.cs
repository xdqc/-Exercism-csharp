using System;
using System.Linq;
using System.Collections.Generic;

public enum Bearing
{
    North,
    East,
    South,
    West
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X  { get; set; }
    public int Y  { get; set; }
}

public class RobotSimulator
{
    public RobotSimulator(Bearing bearing, Coordinate coordinate)
    {
        Bearing = bearing;
        Coordinate = coordinate;
    }

    public Bearing Bearing
    {
        get; private set;
    }

    public Coordinate Coordinate
    {
        get; private set ;
    }

    public void TurnRight()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Bearing = Bearing.East;
                break;
            case Bearing.East:
                Bearing = Bearing.South;
                break;
            case Bearing.South:
                Bearing = Bearing.West;
                break;
            case Bearing.West:
                Bearing = Bearing.North;
                break;
        }
    }

    public void TurnLeft()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Bearing = Bearing.West;
                break;
            case Bearing.East:
                Bearing = Bearing.North;
                break;
            case Bearing.South:
                Bearing = Bearing.East;
                break;
            case Bearing.West:
                Bearing = Bearing.South;
                break;
        }
    }

    public void Advance()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y+1);
                break;
            case Bearing.East:
                Coordinate = new Coordinate(Coordinate.X+1, Coordinate.Y);
                break;
            case Bearing.South:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y-1);
                break;
            case Bearing.West:
                Coordinate = new Coordinate(Coordinate.X-1, Coordinate.Y);
                break;
        }
    }

    public void Simulate(string instructions)
    {
        var move = new Dictionary<char, Action>{
            ['R'] = TurnRight,
            ['L'] = TurnLeft,
            ['A'] = Advance,
        };

        instructions.Where(c => move.ContainsKey(c))    //ignore unknown commands
                    .Select(c => move[c])
                    .ToList()
                    .ForEach(a => a.Invoke());
    }
}