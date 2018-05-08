using System;
using System.Linq;

public static class PigLatin
{
    static string vowals = "aoeui";
    static string[] multiConsonants = new string[]{"thr","sch","squ","ch","qu","th","rh"};

    public static string Translate(string str){
        string output="";
        str.Split(' ').ToList().ForEach(w => output += TranslateWord(w)+" ");
        return output.Trim();
    }
    public static string TranslateWord(string word)
    {
        string output = "";
        if (vowals.IndexOf(word[0])>=0 || word.StartsWith("yt")|| word.StartsWith("xr"))
        {
            output = word + "ay";
        } 
        else if (multiConsonants.Any(mc => word.StartsWith(mc)))
        {
            string cg = multiConsonants.Where(mc => word.StartsWith(mc)).First();
            output = word.Substring(cg.Length, word.Length-cg.Length) + cg + "ay";
        }
        else
        {
            output = word.Substring(1,word.Length-1) + word[0] + "ay";
        }
        return output;
    }
}