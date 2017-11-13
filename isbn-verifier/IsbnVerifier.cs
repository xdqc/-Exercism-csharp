using System;
using System.Linq;
using System.Collections.Generic;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        number = number.Replace("-","");
        if (number.Length != 10)
            return false;
        if (number.Substring(0, 9).Any(c => !Char.IsDigit(c)) || (number[9] != 'X' && !Char.IsDigit(number[9])))
            return false;

        return Enumerable.Range(0, 10).Aggregate(0, (acc, i) => acc + (10-i)*parseInt(number[i])) % 11 == 0;
    }

    private static Func<char, int> parseInt = c => c=='X' ? 10 : c-'0';
}