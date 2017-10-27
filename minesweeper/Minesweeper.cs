using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public static class Minesweeper
{
    public static string Annotate(string input)
    {
        var rows = input.Split('\n');
        var width = rows.Length;
        var height = rows[0].Length;
        var dots = new List<Dot>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                dots.Add(new Dot(i,j,rows[i][j]=='*'));
            }
        }

        var grid = new Grid(dots, width, height);
        grid.LabelHint();

        var output = string.Empty;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (grid.Dots[i,j].IsMine)
                {
                    output+='*';
                }
                else
                {
                    if (grid.Dots[i,j].Hint == 0)
                    {
                        output+=' ';
                    }
                    else
                    {
                        output+=grid.Dots[i,j].Hint.ToString();
                    }
                }
            }
            output+='\n';
        }
        return output.TrimEnd('\n');
    }


}

public class Dot
{
    public Dot(int x, int y, bool isMine)
    {
        Position = new Tuple<int, int>(x, y);
        IsMine = isMine;
    }
    public Tuple<int,int> Position { get; }
    public bool IsMine { get; set; }
    public int Hint { get; set; }
}

public class Grid
{
    public Grid(IEnumerable<Dot> dots, int width, int height)
    {
        Width = width;
        Height = height;
        Dots = new Dot[Width,Height];
        foreach (var dot in dots)
        {
            Dots[dot.Position.Item1,dot.Position.Item2] = dot;
        }
    }
    
    public int Width { get; }
    public int Height { get; }

    public Dot[,] Dots { get; } 

    public IEnumerable<Dot> Neighbors(Dot dot){
        for (int i = dot.Position.Item1-1; i <= dot.Position.Item1+1; i++)
        {
            for (int j = dot.Position.Item2-1; j <= dot.Position.Item2+1; j++)
            {
                if (i>=0 && i<Width && j>=0 && j<Height)
                {
                    if (Dots[i,j] != dot)
                    {
                        yield return Dots[i,j];
                    }
                }
            }
        }
    }

    public void LabelHint()
    {
        foreach (var dot in Dots)
        {
            if (!dot.IsMine)
            {
                dot.Hint = Neighbors(dot).Where(d => d.IsMine).Count();
            }
        }
    }
}
