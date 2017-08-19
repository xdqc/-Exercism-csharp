using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Complement
{
    public static string OfDna(string nucleotides)
    {
        Regex regex = new Regex("[ATCG]");

        var map = new Dictionary<string, string> {
                    { "A", "U"},
                    { "T", "A"},
                    { "G", "C"},
                    { "C", "G"}
                };

        return regex.Replace(nucleotides, x => map[x.Value]);
    }
}