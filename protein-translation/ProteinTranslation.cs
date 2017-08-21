﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public static class ProteinTranslation
{
    public static string[] Translate(string rna)
    {
        if (!Regex.IsMatch(rna, @"^[AUCG]+$"))
            throw new Exception();

        var codonToAA = new Dictionary<string[], string>
        {
            [new string[] { "AUG" }] = "Methionine",
            [new string[] { "UUU", "UUC" }] = "Phenylalanine",
            [new string[] { "UUA", "UUG" }] = "Leucine",
            [new string[] { "UCU", "UCC", "UCA", "UCG" }] = "Serine",
            [new string[] { "UAU", "UAC" }] = "Tyrosine",
            [new string[] { "UGU", "UGC" }] = "Cysteine",
            [new string[] { "UGG" }] = "Tryptophan",
            [new string[] { "UAA", "UAG", "UGA" }] = "STOP"
        };


        var peptide = new List<string>();
        for (int i = 0; i < rna.Length; i += 3)
        {
            var aa = codonToAA.Where(a => a.Key.Contains(rna.Substring(i, 3)))
                              .Select(a => a.Value).FirstOrDefault();
            if (aa == "STOP")
            {
                break;
            }
            peptide.Add(aa);
        }

        return peptide.ToArray();
    }
}