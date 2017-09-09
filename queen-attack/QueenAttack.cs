using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class Queens
{
    public static bool CanAttack(Queen white, Queen black)
    {
        bool sameRow = black.Row == white.Row;
        bool sameCol = black.Column == white.Column;
        bool diagonal = Math.Abs(black.Row - white.Row) == Math.Abs(black.Column - white.Column);
        bool overlap = sameRow && sameCol;

        if (overlap)
        {
            throw new ArgumentException();
        }

        if (sameRow|| sameCol || diagonal)
        {
            return true;
        }
        return false;
    }
}