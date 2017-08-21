using System;
using System.Linq;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene
}

public static class Triangle
{
    public static TriangleKind Kind(decimal side1, decimal side2, decimal side3)
    {
        var sides = new decimal[3] { side1, side2, side3 };
        if (sides.Any(s => s <= 0))
        {
            throw new TriangleException();
        }
        if (sides.Any(s => s >= sides.Sum() / 2))
        {
            throw new TriangleException();
        }

        if (side1 == side2 && side1 == side3)
        {
            return TriangleKind.Equilateral;
        }
        else if(side1 != side2 && side1 != side3 && side2 != side3)
        {
            return TriangleKind.Scalene;
        }
        else
        {
            return TriangleKind.Isosceles;
        }

    }
}

public class TriangleException : Exception { }