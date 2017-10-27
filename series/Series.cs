using System;
using System.Linq;

public class Series
{
    string str;
    public Series(string number)
    {
        str = number;
    }

    public int[][] Slices(int sliceLength)
    {
        var size = str.Length>=sliceLength? str.Length - sliceLength + 1 : throw new ArgumentException();

        var result = new int[size][];

        for (int i = 0; i < size; i++)
        {
            result[i] = str.Skip(i).Take(sliceLength).Select(x => x-'0').ToArray();
        }

        return result;
        // Enumerable.Range(0, str.Length - sliceLength + 1)
        //                  .Select(i => str.Substring(i, sliceLength)
        //                                  .Select(x => x - '0')
        //                                  .ToArray())
        //                  .ToArray();
    }
}