using System;

public static class FoodChain
{
    public static string Verse(int number) 
    {
        var sentence = $"I know an old lady who swallowed a {animals[number-1]}.\n";

        if (number>1)
        {
            sentence += secondLine[number-2];
            while (number>1 && number<8)
            {
                sentence += $"She swallowed the {animals[number-1]} to catch the {animals[number-2]}.\n";
                if (number==3)
                {
                    sentence = sentence.Substring(0,sentence.Length-2);
                    sentence += " that wriggled and jiggled and tickled inside her.\n";
                }
                number--;
            }
        }

        if (number<8)
        {
            sentence += "I don't know why she swallowed the fly. Perhaps she'll die.";
        }

        return sentence;
    }

    public static string Verse(int begin, int end) 
    {
        var verse = new string[end-begin+1];
        for (int i = begin; i <= end; i++)
        {
            verse[i-begin] = Verse(i);
        }
        return String.Join("\n\n", verse);
    }

    public static string[] animals = new string[]{
        "fly",
        "spider",
        "bird",
        "cat",
        "dog",
        "goat",
        "cow",
        "horse"
    };

    public static string[] secondLine = new string[]{
        "It wriggled and jiggled and tickled inside her.\n",
        "How absurd to swallow a bird!\n",
        "Imagine that, to swallow a cat!\n",
        "What a hog, to swallow a dog!\n",
        "Just opened her throat and swallowed a goat!\n",
        "I don't know how she swallowed a cow!\n",
        "She's dead, of course!"
    };

}