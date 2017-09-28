using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class Grep
{
    public static string Find(string pattern, string flags, string[] files)
    {
        var output = string.Empty;
        var foundLine = new List<Tuple<string, int, string>>();

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                bool predicate;
                if (flags.Contains("-x"))
                {
                    predicate = flags.Contains("-i") 
                        ? lines[i].ToLower() == pattern.ToLower() 
                        : lines[i] == pattern;
                }
                else
                {                    
                    predicate = flags.Contains("-i") 
                        ? lines[i].ToLower().Contains(pattern.ToLower()) 
                        : lines[i].Contains(pattern);
                }

                if (flags.Contains("-v"))
                {
                    predicate = !predicate;
                }

                if (predicate)
                {
                    foundLine.Add(new Tuple<string, int, string>(file, i+1, lines[i]));
                }
            }
        }

        if (flags.Contains("-l"))
        {
            output = string.Join("\n",foundLine.Select(t => t.Item1).Distinct());
        }
        else if (flags.Contains("-n"))
        {
            output = (files.Length == 1) 
                ? String.Join("\n", foundLine.Select(t => $"{t.Item2}:{t.Item3}"))
                : String.Join("\n", foundLine.Select(t => $"{t.Item1}:{t.Item2}:{t.Item3}"));
        }
        else
        {            
            output = (files.Length == 1) 
                ? String.Join("\n", foundLine.Select(t => t.Item3))
                : String.Join("\n", foundLine.Select(t => t.Item1 + ':' + t.Item3));
        }
        
        return output.Length > 0 ? output+'\n' : output;
    }
}