using System;
using System.Linq;
using System.Collections.Generic;

public class DNA
{
    public DNA(string sequence)
    {
        this.Sequence = sequence;
    }

    public string Sequence { get; set; }

    public IDictionary<char, int> NucleotideCounts
    {
        get
        {
            return new Dictionary<char, int>(){
                {'A', Sequence.Count(n => n=='A')},
                {'T', Sequence.Count(n => n=='T')},
                {'C', Sequence.Count(n => n=='C')},
                {'G', Sequence.Count(n => n=='G')}
            };
        }
    }

    public int Count(char nucleotide)
    {
        if (!"ATCG".Contains(nucleotide))
        {
            throw new InvalidNucleotideException();
        }
        return Sequence.Count(n => n == nucleotide);
    }
}

public class InvalidNucleotideException : Exception { }
