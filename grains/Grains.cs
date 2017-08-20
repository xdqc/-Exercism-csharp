using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total()
    {
        return (ulong)Enumerable.Range(1, 64).Sum(x => (int)Square(x));
    }
}