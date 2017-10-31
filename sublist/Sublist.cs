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
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        bool aSubB = list1.Intersect(list2).SequenceEqual(list1);
        bool bSubA = list2.Intersect(list1).SequenceEqual(list2);

        if (aSubB && bSubA)
        {
            return SublistType.Equal;
        }
        else
        {
            if (aSubB)
            {
                return SublistType.Sublist;
            }
            else if (bSubA)
            {
                return SublistType.Superlist;
            }
            else
            {
                return SublistType.Unequal;
            }
        }
    }
}