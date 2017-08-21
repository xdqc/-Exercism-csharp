using System;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        return Enumerable.Range(2, limit - 1)
                  .Where(x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(n => x % n != 0))
                  .ToArray();
    }
}