using System;
using System.Collections.Generic;
using System.Linq;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return plaintext.ToLower().Aggregate("", (s, c) => Char.IsLetterOrDigit(c) ? s+c : s);
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        plaintext = NormalizedPlaintext(plaintext);
        int col = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));
        for (int i = 0; i < plaintext.Length; i+=col)
        {
            yield return plaintext.Substring(i, Math.Min(col, (plaintext.Length-i)));
        }
    }

    public static string Encoded(string plaintext)
    {
        var textSegment = PlaintextSegments(NormalizedPlaintext(plaintext));
        if (textSegment.Count() == 0)
        {
            return "";
        }

        var result = "";
        for (int i = 0; i < textSegment.First().Length; i++)
        {
            textSegment.ToList().ForEach(s => {
                if (i < s.Length)
                {
                    result += s[i];
                }
            });
        }
        return result;
    }

    public static string Ciphertext(string plaintext)
    {
        plaintext = Encoded(plaintext);
        int col = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));
        for (int i = 0; i < plaintext.Length; i+=col)
        {
            yield return plaintext.Substring(i, Math.Min(col, (plaintext.Length-i)));
        }
    }
}