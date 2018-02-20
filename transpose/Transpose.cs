using System;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        string[] rows = input.Split("\n");
        int colNum = rows.Max(r => r.Length);
        rows = rows.Select(r => r.PadRight(colNum)).ToArray();
        StringBuilder[] cols = new StringBuilder[colNum];

        for (int j = 0; j < colNum; j++)
        {
            cols[j] = new StringBuilder();
            for (int i = 0; i < rows.Length; i++)
            {
                cols[j].Append(rows[i][j]);
            }
        }
        return string.Join('\n', cols.Select(c => c.ToString())).TrimEnd();
    }
}