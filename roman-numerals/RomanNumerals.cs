using System;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        if (value > 3999 || value < 1) {
            throw new ArgumentException("value not representable in Roman numerals");
        }

        var romanNumber = string.Empty;
        var romanDigit = "IVXLCDM??";

        int b = 1000;
        while (b > 0)
        {
            int digit = value / b;
            int e = (int)Math.Log10(b);
            romanNumber += OneDigtiToRoman(digit, romanDigit[2*e],romanDigit[2*e+1],romanDigit[2*e+2]);
            value %= b;
            b /= 10;
        }
        return romanNumber;
    }

    private static string OneDigtiToRoman(int digit, char one, char five, char ten){
        switch (digit)
        {
            case 0:
            return "";
            case 1:
            return ""+one;
            case 2:
            return ""+one+one;
            case 3:
            return ""+one+one+one;
            case 4:
            return ""+one+five;
            case 5:
            return ""+five;
            case 6:
            return ""+five+one;
            case 7:
            return ""+five+one+one;
            case 8:
            return ""+five+one+one+one;
            case 9:
            return ""+one+ten;
            default:
            return "";
        }
    }
}