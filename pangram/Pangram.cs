using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        for (char c = 'a'; c <= 'z'; c++)
        {
            if(!Regex.IsMatch(input, c.ToString(), RegexOptions.IgnoreCase))
                return false;
        }
        return true;
    }
}
