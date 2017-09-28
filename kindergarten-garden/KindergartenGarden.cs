using System;
using System.Linq;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class Garden
{
    public Garden(IEnumerable<string> children, string windowSills)
    {
        string[] sills = windowSills.Split('\n');
        var sill = new Queue<char>();
        for (int i = 0; i < sills[0].Length; i += 2)
        {
            sill.Enqueue(sills[0][i]);
            sill.Enqueue(sills[0][i + 1]);
            sill.Enqueue(sills[1][i]);
            sill.Enqueue(sills[1][i + 1]);
        }

        var childrens = children.ToList();
        childrens.Sort();
        int index = 0;
        while (sill.Count > 0)
        {
            var plants = new Plant[4];
            for (int i = 0; i < 4; i++)
            {
                plants[i] = PlantTranslater(sill.Dequeue());
            }
            KidsPlants.Add(childrens[index++], plants);
        }
    }

    readonly Dictionary<string, IEnumerable<Plant>> KidsPlants = new Dictionary<string, IEnumerable<Plant>>();

    public IEnumerable<Plant> GetPlants(string child)
    {
        return KidsPlants.ContainsKey(child) ? KidsPlants[child] : new Plant[0];
    }

    public static Garden DefaultGarden(string windowSills)
    {
        string[] children = new string[]{"Alice", "Bob", "Charlie", "David",
                                        "Eve", "Fred", "Ginny", "Harriet",
                                        "Ileana", "Joseph", "Kincaid", "Larry"};

        return new Garden(children, windowSills);
    }

    static Plant PlantTranslater(char p)
    {
        switch (p)
        {
            case 'C':
                return Plant.Clover;
            case 'G':
                return Plant.Grass;
            case 'R':
                return Plant.Radishes;
            case 'V':
                return Plant.Violets;
            default:
                throw new InvalidCastException();
        }
    }
}