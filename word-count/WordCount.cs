using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> Countwords(string phrase) => phrase.ToLower().Split(new[] { ',', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => Regex.Replace(s, @"[^\w\']", string.Empty).Trim('\'')).GroupBy(s => s, (k, s) => s).ToDictionary(s => s.FirstOrDefault(), s => s.Count());
}