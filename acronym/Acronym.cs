using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var words = phrase.Split(' ','-');
        return string.Concat(words.Select(w => w.ToUpper().First()));
        
    }
}