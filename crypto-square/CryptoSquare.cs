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
        var textSegments = PlaintextSegments(plaintext);
        if (textSegments.Count() == 0)
            return "";

        return string.Concat(Enumerable.Range(0, textSegments.First().Length)
                        .Select(i => textSegments.Aggregate("", (acc, seg) => 
                                        (i < seg.Length) ? acc+seg[i] : acc)));
    }

    public static string Ciphertext(string plaintext)
    {
        plaintext = Encoded(plaintext);
        if (plaintext == "")
            return "";

        int row = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));
        int col = (int)Math.Floor(Math.Sqrt(plaintext.Length));
        int fullRow = plaintext.Length / row;
        return String.Join(" ", Enumerable.Range(0, row)
                     .Select(i =>  (i < fullRow) 
                        ? plaintext.Substring(i*col, col)
                        : plaintext.Substring(fullRow*col + (i-fullRow)*(col-1), (col-1)) + ' '));
    }
}