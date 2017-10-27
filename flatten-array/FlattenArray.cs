using System;
using System.Collections.Generic;
using System.Linq;

public static class Flattener
{
    public static IEnumerable<object> Flatten(IEnumerable<object> input) =>
        input.Where(x => x != null)
             .SelectMany(x => x is IEnumerable<object> 
             ? Flatten(x as IEnumerable<object>)
             : new object[]{x});
}