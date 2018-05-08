using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        int score = 0;
        switch (category)
        {
            case YachtCategory.Ones:
                score = dice.Where(d => d==1).Count();
                break;
            case YachtCategory.Twos:
                score = dice.Where(d => d==2).Count()*2;
                break;
            case YachtCategory.Threes:
                score = dice.Where(d => d==3).Count()*3;
                break;
            case YachtCategory.Fours:
                score = dice.Where(d => d==4).Count()*4;
                break;
            case YachtCategory.Fives:
                score = dice.Where(d => d==5).Count()*5;
                break;
            case YachtCategory.Sixes:
                score = dice.Where(d => d==6).Count()*6;
                break;
            case YachtCategory.FullHouse:
                if (dice.Distinct().Count()==2)
                {
                    score = dice.Sum();
                }
                break;
            case YachtCategory.FourOfAKind:
                for (int i = 1; i <= 6; i++)
                {
                    if (dice.Where(d => d==i).Count()>=4)
                    {
                        score = 4*i;
                    }
                }
                break;
            case YachtCategory.BigStraight:
                if (Enumerable.Range(2,5).All(n => dice.Contains(n)))
                {
                    return 30;
                }
                break;
            case YachtCategory.LittleStraight:
                if (Enumerable.Range(1,5).All(n => dice.Contains(n)))
                {
                    return 30;
                }
                break;
            case YachtCategory.Choice:
                score = dice.Sum();
                break;
            case YachtCategory.Yacht:
                if (dice.Distinct().Count()==1)
                {
                    return 50;
                }
                break;
            default:
                break;
        }
        return score;
    }
}

