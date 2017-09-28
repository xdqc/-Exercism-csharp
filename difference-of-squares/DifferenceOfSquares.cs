using System;
using System.Linq;
using System.Collections.Generic;

public static class Squares
{
    public static int SquareOfSums(int max)
    {
        var nums = Enumerable.Range(1, max).ToArray();
        return nums.Sum() * nums.Sum();
    }

    public static int SumOfSquares(int max)
    {
        return Enumerable.Range(1, max).Sum(x => x*x);
    }

    public static int DifferenceOfSquares(int max)
    {
        return SquareOfSums(max) - SumOfSquares(max);
    }
}