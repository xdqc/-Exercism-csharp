using System;

public static class BeerSong
{
    public static string Verse(int number)
    {
        if (number>2 && number<100)
        {
            return $"{number} bottles of beer on the wall, {number} bottles of beer.\nTake one down and pass it around, {number-1} bottles of beer on the wall.\n";
        }
        else if (number == 2)
        {
            return $"{number} bottles of beer on the wall, {number} bottles of beer.\nTake one down and pass it around, {number-1} bottle of beer on the wall.\n";
        }
        else if (number == 1)
        {
            return $"{number} bottle of beer on the wall, {number} bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
        }
        else if (number == 0)
        {
            
            return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public static string Verses(int begin, int end)
    {
        var song = "";
        for (int i = begin; i > end; i--)
        {
            song += Verse(i) + '\n';
        }
        song += Verse(end);
        return song;
    }
}