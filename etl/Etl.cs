using System;
using System.Collections.Generic;

public static class ETL
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        var newScore = new Dictionary<string, int>();
        foreach (var letterlist in old)
        {
            foreach (var letter in letterlist.Value)
            {
                newScore.Add(letter.ToLowerInvariant(), letterlist.Key);
            }
        }
        return newScore;
    }
}