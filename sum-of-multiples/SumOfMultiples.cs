using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int To(IEnumerable<int> multiples, int max)
    {
        var mul = new HashSet<int>();
        foreach (int n in multiples)
        {
            int i = 1;
            while (n*i < max)
            {
                mul.Add(n*i++);
            }
        }
        return mul.Sum();
    }
}