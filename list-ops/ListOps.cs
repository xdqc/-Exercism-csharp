using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int i = 0;
        foreach (var item in input)
        {
            i++;
        }
        return i;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var output = new List<T>();
        for (int i = Length(input)-1; i >= 0; i--)
        {
            output.Add(input[i]);
        }
        return output;
    }

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
    {
        var output = new List<TOut>();
        foreach (var item in input)
        {
            output.Add(map(item));
        }
        return output;
    }

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
    {
        var output = new List<T>();
        foreach (var item in input)
        {
            if (predicate(item))
            {
                output.Add(item);
            }
        }
        return output;
    }

    public static TOut Foldl<TIn, TOut>(Func<TOut, TIn, TOut> func, TOut start, List<TIn> input)
    {
        foreach (var item in input)
        {
            start = func(start, item);
        }
        return start;
    }

    public static TOut Foldr<TIn, TOut>(Func<TIn, TOut, TOut> func, TOut start, List<TIn> input)
    {
        input = Reverse(input);
        foreach (var item in input)
        {
            start = func(item, start);
        }
        return start;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var output = new List<T>();
        foreach (var list in input)
        {
            foreach (var item in list)
            {
                output.Add(item);
            }
        }
        return output;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        foreach (var item in right)
        {
            left.Add(item);
        }
        return left;
    }
}