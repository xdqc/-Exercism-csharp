using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static List<T> Added<T>(List<T> input, T val)
    {
        input.Add(val);
        return input;
    }
    public static int Length<T>(List<T> input)
    {
        return Foldl((acc, item) => acc + 1, 0, input);
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        return Foldr((item, acc) => Added(acc, item), new List<T>(), input);
    }

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
    {
        return Foldl((acc, item) => Added(acc, map(item)), new List<TOut>(), input);
    }

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
    {
        return Foldl((acc, item) => predicate(item) ? Added(acc, item) : acc, new List<T>(), input);
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
        for(int i = Length(input)-1; i >= 0; i--)
        {
            start = func(input[i], start);
        }
        return start;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        return Foldl(Added, new List<T>(left), right);
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        return Foldl(Append, new List<T>(), input);
    }


}