// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;
using System;

public class NthPrimeTest
{
    [Fact]
    public void First_prime()
    {
        Assert.Equal(2, NthPrime.Prime(1));
    }

    [Fact(Skip = "")]
    public void Second_prime()
    {
        Assert.Equal(3, NthPrime.Prime(2));
    }

    [Fact(Skip = "")]
    public void Sixth_prime()
    {
        Assert.Equal(13, NthPrime.Prime(6));
    }

    [Fact(Skip = "")]
    public void Big_prime()
    {
        Assert.Equal(104743, NthPrime.Prime(10001));
    }

    [Fact(Skip = "")]
    public void There_is_no_zeroth_prime()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => NthPrime.Prime(0));
    }
}