using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class WordSearch
{
    readonly int width;
    readonly int height;
    readonly char[,] matrix;

    public WordSearch(string puzzle)
    {
        string[] rows = puzzle.Split('\n');
        this.width = rows[0].Length;
        this.height = rows.Length;
        matrix = new char[width, height];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                matrix[i, j] = rows[j][i];
    }

    private readonly static Point[] dir = new[] {
        new Point(0, 1),
        new Point(0, -1),
        new Point(1, 0),
        new Point(-1, 0),
        new Point(1, 1),
        new Point(-1, -1),
        new Point(1, -1),
        new Point(-1, 1),
    };

    public Tuple<Point, Point> Find(string word)
    {
        var result = Enumerable.Range(0, matrix.Length)
            .SelectMany(i => dir, (n, direc) => (Idx: n, Dir: direc))
            .FirstOrDefault(pnd => word.SequenceEqual(
                Enumerable.Range(0, word.Length)
                    .Select(l => new Point(pnd.Idx % width + l * pnd.Dir.Y, pnd.Idx / width + l * pnd.Dir.X))
                    .Where(p => p.X >= 0 && p.X < width && p.Y >= 0 && p.Y < height)
                    .Select(p => matrix[p.X, p.Y])
            ));
        if (result.Equals(default((int, Point)))) return null;
        int col = result.Idx % width + 1;
        int row = result.Idx / width + 1;
        return Tuple.Create(new Point(col, row), new Point(col + result.Dir.Y * (word.Length - 1), row + result.Dir.X * (word.Length - 1)));
    }
}