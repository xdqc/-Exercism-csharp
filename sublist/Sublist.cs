using System;
using System.Collections.Generic;

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
<<<<<<< HEAD
        throw new NotImplementedException("You need to implement this function.");
=======
        
>>>>>>> 8019809fbef7aefe5f6631ae08556f40e494633b
    }
}