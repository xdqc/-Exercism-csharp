using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 8019809fbef7aefe5f6631ae08556f40e494633b
        }
    }
}