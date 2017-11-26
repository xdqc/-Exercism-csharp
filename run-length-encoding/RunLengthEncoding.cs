using System;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input.Length <= 1)
            return input;

        int num = 1;
        char prev = input[0];
        string output = "";
        input += '0';
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == prev)
            {
                num++;
            }
            else
            {
                output += num == 1 ? "" : num.ToString();
                output += prev;
                num = 1;
            }
            prev = input[i];
        }
        return output;
    }

    public static string Decode(string input)
    {
        if (input.Length <= 1)
            return input;

        string num = "";
        string output = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                num += input[i];
            }
            else
            {
                output += num.Length == 0 ? input[i].ToString() : new string(input[i], Int32.Parse(num));
                num = "";
            }
        }
        return output;
    }
}
