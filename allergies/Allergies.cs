using System;
using System.Linq;
using System.Collections.Generic;

public class Allergies
{
    public Allergies(int mask)
    {
        allergyToTest = Convert.ToByte(mask % 256);
    }

    byte allergyToTest;
    Dictionary<string, byte> aDict = new Dictionary<string, byte>
    {
        {"eggs", Convert.ToByte(1)},
        {"peanuts", Convert.ToByte(2)},
        {"shellfish", (4)},
        {"strawberries", (8)},
        {"tomatoes", (16)},
        {"chocolate", (32)},
        {"pollen", (64)},
        {"cats", (128)}
    };

    public bool IsAllergicTo(string allergyToTest)
    {
        return List().Contains(allergyToTest);
    }

    public IList<string> List()
    {
        return (from a in aDict
                where (a.Value & allergyToTest) == a.Value
                select a.Key).ToList();
    }
}