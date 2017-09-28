using System;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var cipher = "";
        foreach (var c in text)
        {
            if (Char.IsLower(c))
            {
                cipher += c + shiftKey > 'z' ? (char)(c + shiftKey - 26) : (char)(c + shiftKey);
            }
            else if (Char.IsUpper(c))
            {
                cipher += c + shiftKey > 'Z' ? (char)(c + shiftKey - 26) : (char)(c + shiftKey);
            }
            else
            {
                cipher += c;
            }
        }
        return cipher;
    }
}