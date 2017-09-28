using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (!Regex.IsMatch(digits, @"^\d*$") || span > digits.Length || span < 0)
            throw new ArgumentException();

        return Enumerable.Range(0, digits.Length - span + 1)
                         .Select(i => digits.Substring(i, span))
                         .Select(s => s.Select(c => (long)(c - '0')))
                         .Select(n => n.Aggregate(1, (long acc, long i) => acc * i))
                         .Max();
    }
}