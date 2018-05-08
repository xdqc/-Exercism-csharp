using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth)
    {
        if(nth < 1) throw new ArgumentOutOfRangeException();
	    return Sieve().Take(nth).Last();
    }

    public static IEnumerable<int> Sieve(){
        List<int> primes = new List<int>();
        for (int n = 2; ; ++n)
        {
            if (primes.All(p => n%p>0)){
                primes.Add(n);
                yield return n;
            }
        }
    }
}
