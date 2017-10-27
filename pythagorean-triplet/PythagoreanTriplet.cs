using System;
using System.Collections.Generic;

public class Triplet
{
    int a,b,c;
    public Triplet(int a, int b, int c)
    {
        List<int> nums = new List<int>{a, b, c};
        nums.Sort();
        this.a = nums[0];
        this.b = nums[1];
        this.c = nums[2];
    }

    public int Sum()
    {
        return a+b+c;
    }

    public int Product()
    {
        return a*b*c;
    }

    public bool IsPythagorean()
    {
        return a*a + b*b == c*c;
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)    
            {
                for (int k = j; k <= maxFactor; k++)
                {
                    if (i*i+j*j==k*k)
                    {
                        if(sum == 0)
                            yield return new Triplet(i,j,k);
                        else
                        {
                            if (i+j+k == sum)
                                yield return new Triplet(i,j,k);
                        }
                    }
                }
            }
        }
    }
}