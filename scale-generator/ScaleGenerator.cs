using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    public static string[] Pitches(string tonic, string pattern)
    {
        var scales = Scales(tonic);
        var pitches = new List<string>();
        tonic = char.ToUpper(tonic[0]) + tonic.Substring(1).ToLower();
        int note = Array.IndexOf(scales, tonic);
        foreach (var step in pattern.Select(c => steps[c]))
        {
            pitches.Add(scales[note]);
            note = (note + step) % scales.Count();
        }
        return pitches.ToArray();
    }


    static readonly Dictionary<char, int> steps = new Dictionary<char, int>(){
        ['m'] = 1,
        ['M'] = 2,
        ['A'] = 3,
    };

    static readonly string[] majorScales = new string[]{ "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    static readonly string[] minorScales = new string[]{ "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    static readonly string[] flatKeys = { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" };
    static string [] Scales(string tonic) => flatKeys.Contains(tonic) ? minorScales : majorScales;

}