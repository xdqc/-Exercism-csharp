using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        var brackets = new string(input.Where(c => "[]{}()".Contains(c)).ToArray());
        while (brackets.Length > 0)
        {
            var prevBracketsLength = brackets.Length;
            brackets = brackets.Replace("()", "").Replace("[]", "").Replace("{}", ""); 
            if (brackets.Length == prevBracketsLength)
                return false;
        }
        return true;
    }
}
