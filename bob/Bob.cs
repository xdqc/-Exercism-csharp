using System;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.ToUpper() == statement && statement.ToLower() != statement)
        {
            return "Whoa, chill out!";
        }
        else if (statement.TrimEnd().EndsWith("?"))
        {
            return "Sure.";
        }
        else if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }
        else
        {
            return "Whatever.";
        }
    }

}