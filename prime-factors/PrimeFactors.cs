using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static IEnumerable<int> Factors(long number)
    {
        while (number % 2 == 0)
        {
            yield return 2;
            number /= 2;
        }

        int factor = 3;
        
        while (factor * factor <= number)
        {
            if (number % factor == 0)
            {
                yield return factor;
                number /= factor;
            }
            else
            {
                factor += 2;
            }
        }

        if (number != 1)
        {
            yield return (int)number;
        }
    }
}