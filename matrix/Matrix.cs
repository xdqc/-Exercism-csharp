using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    public Matrix(string input)
    {
        var rows = input.Split('\n');
        var cols = rows[0].Split(' ');
        this.rows = rows.Count();
        this.cols = cols.Count();
        matrix = new int[Rows, Cols];

        for (int i = 0; i < Rows; i++)
        {
            var numbers = rows[i].Split(' ');
            for (int j = 0; j < Cols; j++)
            {
                matrix[i,j] = int.Parse(numbers[j]);
            }
        }

    }

    int rows;
    int cols;
    int [,] matrix;

    public int Rows
    {
        get
        {
            return rows;
        }
    }

    public int Cols
    {
        get
        {
            return cols;
        }
    }

    public int[] Row(int row) 
    {
        return Enumerable.Range(0,Cols).Select(c => matrix[row,c]).ToArray();
    }

    public int[] Col(int col)
    {
        return Enumerable.Range(0,Rows).Select(r => matrix[r,col]).ToArray();
    }
}