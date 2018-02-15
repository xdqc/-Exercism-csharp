using System;
using System.Linq;


public class BowlingGame
{
    private int frame = 0;
    private char prevType = 'o';
    private char prevPrevType = 'o';
    private int? prevPin = null;
    private int score = 0;

    private void NextFrame(char t)
    {
        this.frame++;
        this.prevPin = null;
        this.prevPrevType = this.prevType;
        this.prevType = t;
    }

    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10 || (prevType == 'o' && frame == 10))
            throw new ArgumentException();
        if (prevPin != null && prevPin + pins > 10)
            throw new ArgumentException();

        score += pins;
        if (prevPrevType == 'x') score += pins;
        if (frame == 10) //fill ball
        {
            if (pins < 10) prevPin = pins;
            prevType = prevType == 'x' ? 's' : 'o';
            prevPrevType = 'o';
        }
        else
        {
            if (prevType == 's' || prevType == 'x') score += pins;
            if (prevPin == null)
            {
                if (pins == 10) NextFrame('x');                //strike
                else
                {
                    prevPin = pins;
                    prevPrevType = prevType;
                    prevType = 'o';
                }
            }
            else
            {
                if (prevPin + pins == 10) NextFrame('s');   //spare
                else NextFrame('o');                        //open
            }
        }
    }

    public int Score()
    {
        if (frame != 10 || prevType != 'o')
            throw new ArgumentException();
        return this.score;
    }
}
