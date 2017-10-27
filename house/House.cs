using System;

public static class House
{
    public static string Verse(int number)
    {
        var theIdx = Lines[12-number].IndexOf("the");
        var verse = "This is " + Lines[12-number].Substring(theIdx);
        for (int i = 13-number; i <= 11; i++)
            verse += Lines[i];

        return verse;
    }

    public static string Verses(int first, int last)
    {
        var verses = "";
        for (int i = first; i <= last; i++)
            verses += Verse(i) + "\n\n";

        return verses.TrimEnd();
    }

    static readonly string[] Lines = new string[]{
            "This is the horse and the hound and the horn\n",
            "that belonged to the farmer sowing his corn\n",
            "that kept the rooster that crowed in the morn\n",
            "that woke the priest all shaven and shorn\n",
            "that married the man all tattered and torn\n",
            "that kissed the maiden all forlorn\n",
            "that milked the cow with the crumpled horn\n",
            "that tossed the dog\n",
            "that worried the cat\n",
            "that killed the rat\n",
            "that ate the malt\n",
            "that lay in the house that Jack built."
    };
}