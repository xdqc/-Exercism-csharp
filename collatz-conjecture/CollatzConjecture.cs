using System;

public static class CollatzConjecture
{
    public static int GetSteps(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException();
        }
        
        int step = 0;
        while (n>1)
        {
            n = n % 2 == 0 ? n / 2 : 3 * n + 1;
            step++;
        }
        return step;
    }

    // static int collatz(int n)
    // {
    //     return n % 2 == 0 ? n / 2 : 3 * n + 1;
    // }

}