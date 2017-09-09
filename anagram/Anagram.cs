using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    string baseWord;

    public string[] Anagrams(string[] potentialMatches)
    {
        var occurrence = baseWord.ToLower().OrderBy(c => c);

        return potentialMatches
                .Where(s => s.ToLower() != baseWord.ToLower())
                .Where(s => s.ToLower()
                             .OrderBy(c => c)
                             .SequenceEqual(occurrence))
                .ToArray();
    }
}