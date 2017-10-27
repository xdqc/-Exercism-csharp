using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var prevRow = new int []{1};
        for (int i = 1; i <= rows; i++)
        {
            var row = new int [i];
            row[0] = 1;
            for (int j = 1; j < i-1; j++)
            {
                row[j] = prevRow[j-1] + prevRow[j];
            }
            row[i-1] = 1;
            yield return row;
            prevRow = row;
        }
    }
}