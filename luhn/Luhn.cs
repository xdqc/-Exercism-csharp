using System;
using System.Linq;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");
        if (number.Length<=1 || number.Any(c => !char.IsDigit(c)))
            return false;

        int sum = number
            .ToCharArray()
            .Select(c => c-'0')
            .Reverse()
            .Select((x,i) => i%2!=0 ? x*2 : x)
            .Select(x => x>9? x-9: x)
            .Aggregate(0, (s,x) => s+x);
        return sum % 10 == 0;
    }
}