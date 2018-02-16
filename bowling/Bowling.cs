using System;
using System.Linq;


public class BowlingGame
{
    private int frame = 0;
    private char prevType = 'o';
    private char prevPrevType = 'o';
    private int? prevPin = null;
    private int score = 0;
    private void NextFrame(char t, int? pins)
    {
        if (pins == null) frame++;
        prevPin = (pins.HasValue && pins < 10) ? pins : null;
        prevPrevType = t == 'i' ? 'o' : prevType;
        prevType = t == 'i' ? prevType == 'x' ? 's' : 'o' : t;
    }
    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10 || prevType == 'o' && frame == 10 || prevPin.HasValue && prevPin + pins > 10) throw new ArgumentException();
        score += prevPrevType == 'x' ? pins * 2 : pins;
        if (frame == 10) NextFrame('i', pins);          //fill ball
        else
        {
            if (prevType == 's' || prevType == 'x') score += pins;
            if (prevPin == null) NextFrame(pins == 10 ? 'x' : 'o', pins == 10 ? null : (int?)pins);     //strike
            else NextFrame((prevPin + pins == 10) ? 's' : 'o', null);                                   //spare:open
        }
    }
    public int Score() => frame == 10 && prevType == 'o' ? score : throw new ArgumentException();
}
