using System;
using System.Collections.Generic;

public static class TwelveDaysSong
{
    public static string Sing()
    {
        return Verses(1,12);
    }

    public static string Verse(int verseNumber)
    {
        string result = $"On the {Things[verseNumber].Item1} day of Christmas my true love gave to me, ";
        for (int i = verseNumber; i > 1; i--)
        {
            result += Things[i].Item2 + Things[i].Item3 + ", ";
        }
        if (verseNumber>1)
        {
            result += "and ";
        }
        result += Things[1].Item2 + Things[1].Item3;
        return result +=  " in a Pear Tree.\n";
    }

    public static string Verses(int start, int end)
    {
        string result = "";
        for (int i = start; i <= end; i++)
        {
            result += Verse(i) + '\n';
        }
        return result;
    }

    static readonly List<string> Lines = new List<string>{

    };

    static readonly Dictionary<int, Tuple<string,string,string>> Things = new Dictionary<int, Tuple<string, string, string>>{
        [1] = new Tuple<string,string,string>("first","a ","Partridge"),
        [2] = new Tuple<string,string,string>("second","two ","Turtle Doves"),
        [3] = new Tuple<string,string,string>("third","three ","French Hens"),
        [4] = new Tuple<string,string,string>("fourth","four ","Calling Birds"),
        [5] = new Tuple<string,string,string>("fifth","five ","Gold Rings"),
        [6] = new Tuple<string,string,string>("sixth","six ","Geese-a-Laying"),
        [7] = new Tuple<string,string,string>("seventh","seven ","Swans-a-Swimming"),
        [8] = new Tuple<string,string,string>("eighth","eight ","Maids-a-Milking"),
        [9] = new Tuple<string,string,string>("ninth","nine ","Ladies Dancing"),
        [10] = new Tuple<string,string,string>("tenth","ten ","Lords-a-Leaping"),
        [11] = new Tuple<string,string,string>("eleventh","eleven ","Pipers Piping"),
        [12] = new Tuple<string,string,string>("twelfth","twelve ","Drummers Drumming"),
    };

    
}