using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string Line(int line)
    {
        var things = new Dictionary<int, string>{
            [1] = "nail",
            [2] = "shoe",
            [3] = "horse",
            [4] = "rider",
            [5] = "message",
            [6] = "battle",
            [7] = "kingdom"
        };

        if (line > 0 && line < 7)
        {
            return $"For want of a {things[line]} the {things[line+1]} was lost.";
        }
        else if (line == 7)
        {
            return "And all for the want of a horseshoe nail.";
        }
        else
        {
            throw new ArgumentException();
        }

    }

    public static string AllLines()
    {
        string proverb = "";
        for (int i = 1; i <= 7; i++)
        {
            proverb += Line(i) + '\n';
        }
        return proverb.TrimEnd();
    }
}