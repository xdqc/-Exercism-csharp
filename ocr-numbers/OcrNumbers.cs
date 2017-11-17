using System;
using System.Collections.Generic;
using System.Linq;

public static class OcrNumbers
{
    public static string Convert(string input)
    {
        string[] lines = input.Split('\n');
        if (lines.Length % 4 != 0)
            throw new ArgumentException();
        if (lines.Any(s => s.Length % 3 != 0))
            throw new ArgumentException();

        string result = "";

        for (int i = 0; i < lines.Length; i += 4)
        {
            string[] chunck = new string[] { lines[i], lines[i + 1], lines[i + 2], lines[i + 3] };
            foreach (string digitResemblance in ProcessInput(chunck))
            {
                result += ConvertSingleDigit(digitResemblance);
            }
            result += ',';
        }

        return result.TrimEnd(',');
    }

    private static IEnumerable<string> ProcessInput(string[] lines)
    {
        for (int i = 0; i < lines[0].Length; i+=3)
        {
            string digitResemblance = "";
            for (int j = 0; j < lines.Length; j++) {
                digitResemblance += lines[j].Substring(i, 3);
                digitResemblance += '\n';
            }
            yield return digitResemblance.TrimEnd('\n');
        }
    }

    private static readonly string[] digits = new string[] {
        " _ | ||_|   ", "     |  |   ", " _  _||_    ",
        " _  _| _|   ", "   |_|  |   ",
        " _ |_  _|   ", " _ |_ |_|   ", " _   |  |   ",
        " _ |_||_|   ", " _ |_| _|   "
    };

    private static string ConvertSingleDigit(string input)
    {

        switch (input)
        {
            case    " _ " + "\n" +
                    "| |" + "\n" +
                    "|_|" + "\n" +
                    "   ":
                    return "0";
            case    "   " + "\n" +
                    "  |" + "\n" +
                    "  |" + "\n" +
                    "   ":
                    return "1";
            case    " _ " + "\n" +
                    " _|" + "\n" +
                    "|_ " + "\n" +
                    "   ":
                    return "2";
            case    " _ " + "\n" +
                    " _|" + "\n" +
                    " _|" + "\n" +
                    "   ":
                    return "3";
            case    "   " + "\n" +
                    "|_|" + "\n" +
                    "  |" + "\n" +
                    "   ":
                    return "4";
            case    " _ " + "\n" +
                    "|_ " + "\n" +
                    " _|" + "\n" +
                    "   ":
                    return "5";
            case    " _ " + "\n" +
                    "|_ " + "\n" +
                    "|_|" + "\n" +
                    "   ":
                    return "6";
            case    " _ " + "\n" +
                    "  |" + "\n" +
                    "  |" + "\n" +
                    "   ":
                    return "7";
            case    " _ " + "\n" +
                    "|_|" + "\n" +
                    "|_|" + "\n" +
                    "   ":
                    return "8";
            case    " _ " + "\n" +
                    "|_|" + "\n" +
                    " _|" + "\n" +
                    "   ":
                    return "9";
            default:
                return "?";
        }
    }
}