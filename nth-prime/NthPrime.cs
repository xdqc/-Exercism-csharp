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
        List<int> primes = new List<int>(){2};
        yield return 2;
        for (int n = 3; ; n+=2)
        {
            if (primes.All(p => n%p>0)){
                primes.Add(n);
                yield return n;
            }
        }
    }
}
