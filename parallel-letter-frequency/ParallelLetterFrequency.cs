using System;
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts) =>
        texts.SelectMany(s => s.ToLower().Where(char.IsLetter))
             .GroupBy(c => c, (k,c) => new Tuple<char,int>(k, c.Count()))
             .ToDictionary(k => k.Item1, k => k.Item2);

}