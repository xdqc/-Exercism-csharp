using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    private static Dictionary<(bool, bool), SublistType> sublistType = new Dictionary<(bool, bool), SublistType>(){
        {(true, true), SublistType.Equal},
        {(true, false), SublistType.Sublist},
        {(false, true), SublistType.Superlist},
        {(false, false), SublistType.Unequal}
    };

    public static SublistType Classify<T>(List<T> list1, List<T> list2) where T : IComparable =>
        sublistType[(IsSublist(list1, list2), IsSublist(list2, list1))];

    public static bool IsSublist<T>(List<T> shortList, List<T> longList) where T : IComparable
    {
        try
        {
            return Enumerable.Range(0, longList.Count - shortList.Count + 1).Any(i =>
                    longList.GetRange(i, shortList.Count).SequenceEqual(shortList));
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
    }
}