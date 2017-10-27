using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2 || inputDigits.Length == 0 || inputDigits.FirstOrDefault() == 0 || inputDigits.Any(x => x < 0 || x >= inputBase))
            throw new ArgumentException();

        inputDigits = inputDigits.Reverse().ToArray();
        int number = Enumerable.Range(0, inputDigits.Length)
                               .Aggregate(0, (sum, i) => sum + (int)Math.Pow(inputBase, i) * inputDigits[i]);

        var output = new List<int>();

        while (number != 0)
        {
            output.Add(number % outputBase);
            number /= outputBase;
        }

        output.Reverse();
        return output.ToArray();
    }
}