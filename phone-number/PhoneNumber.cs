using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var pattern = @"^(?:\+?1\-?\s*)?\(?([2-9]\d{2})\)?\s*(?:\.|\-)?\s*([2-9]\d{2})\s*(?:\.|\-)?\s*(\d{4})\s*$";
        return Regex.IsMatch(phoneNumber, pattern) 
             ? Regex.Replace(phoneNumber, pattern, "$1$2$3")
             : null;
    }
}