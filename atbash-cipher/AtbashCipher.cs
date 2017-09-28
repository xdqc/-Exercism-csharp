using System;
using System.Linq;
using System.Collections.Generic;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        return String.Join(" ", Decode(plainValue).SplitInParts(5));
    }

    public static string Decode(string encodedValue)
    {
        encodedValue = String.Concat(encodedValue.ToLower().Where(char.IsLetterOrDigit));
        var plainValue = string.Empty;
        foreach (var c in encodedValue)
        {
            plainValue += char.IsLetter(c) ? (char)('z'+'a'-c) : c;
        }
        return plainValue;
    }

}

static class StringExtensions
{
    public static IEnumerable<string> SplitInParts(this string str, int partLength)
    {
        if (str == null || partLength <= 0)
        {
            throw new ArgumentException();
        }
        for (int i = 0; i < str.Length; i+=partLength)
        {
            yield return str.Substring(i, Math.Min(partLength, str.Length-i));
        }
    }
}