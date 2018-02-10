﻿using System;
using System.Linq;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        IEnumerable<int> digits = number.ToString().Select(d => d-'0');
        return digits.Aggregate(0, (s, i) => s + (int)Math.Pow(i,digits.Count())) == number;
    }
}