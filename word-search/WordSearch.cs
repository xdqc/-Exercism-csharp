using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class WordSearch
{
    readonly List<string> rows = new List<string>();
    readonly List<string> cols = new List<string>();

    public WordSearch(string puzzle)
    {
        this.rows = puzzle.Split('\n').ToList();
        Enumerable.Range(0, rows[0].Length)
            .Select(i => rows.Select(row => row[i]))
            .ToList()
            .ForEach(col => this.cols.Add(string.Concat(col)));
    }

    public Tuple<Point, Point> Find(string word) => FindWord(word) != null
        ? FindWord(word)
        : FindWord(string.Concat(word.Reverse())) != null
        ? Tuple.Create(FindWord(string.Concat(word.Reverse())).Item2, FindWord(string.Concat(word.Reverse())).Item1)
        : null;

    private Tuple<Point, Point> FindWord(string word)
    {
        Point p1, p2 = new Point();
        //horizontal
        for (int i = 0; i < rows.Count; i++)
        {
            if (rows[i].IndexOf(word) >= 0)
            {
                p1.X = rows[i].IndexOf(word) + 1;
                p2.X = rows[i].IndexOf(word) + word.Length;
                p1.Y = i + 1;
                p2.Y = i + 1;
                goto FOUND;
            }
        }
        //verticle
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i].IndexOf(word) >= 0)
            {
                p1.X = i + 1;
                p2.X = i + 1;
                p1.Y = cols[i].IndexOf(word) + 1;
                p2.Y = cols[i].IndexOf(word) + word.Length;
                goto FOUND;
            }
        }
        //main diagonal
        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < cols.Count; j++)
            {
                int k = 0, r = i, c = j;
                while (k < word.Length && r < rows.Count && c < cols.Count && rows[r][c] == word[k])
                    k++; r++; c++;
                if (k == word.Length)
                {
                    p1.X = j + 1;
                    p2.X = c;
                    p1.Y = i + 1;
                    p2.Y = r;
                    goto FOUND;
                }
            }
        }
        //anti diagonal
        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = cols.Count - 1; j >= 0; j--)
            {
                int k = 0, r = i, c = j;
                while (k < word.Length && r < rows.Count && c > 0 && rows[r][c] == word[k])
                    k++; r++; c--;
                if (k == word.Length)
                {
                    p1.X = j + 1;
                    p2.X = c + 2;
                    p1.Y = i + 1;
                    p2.Y = r;
                    goto FOUND;
                }
            }
        }

    FOUND:
        return p1.X == 0 ? null : new Tuple<Point, Point>(p1,p2);
    }
}