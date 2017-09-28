using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        int[] prev = null;
        for (int i = 0; i < rows; i++)
        {
            var row = new int [i+1];
            row[0] = 1;
            for (int j = 1; j < i; j++)
            {
                row[j] = prev[j-1] + prev[j];
            }
            row[i] = 1;
            yield return row;
            prev = row;
        }
    }
}