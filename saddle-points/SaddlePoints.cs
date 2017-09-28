using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    public SaddlePoints(int[,] values)
    {
        matrix = values;
        height = matrix.GetLength(0);
        width = matrix.GetLength(1);
    }

    readonly int[,] matrix;
    readonly int width, height;

    IEnumerable<int> row(int r) => Enumerable.Range(0, width).Select(c => matrix[r, c]);

    IEnumerable<int> col(int c) => Enumerable.Range(0, height).Select(r => matrix[r, c]);

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (matrix[i, j] == row(i).Max() && matrix[i, j] == col(j).Min())
                    yield return new Tuple<int, int>(i, j);
            }
        }

    }

}