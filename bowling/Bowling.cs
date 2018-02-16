using System;

public class BowlingGame
{
    private int frame = 0, score = 0;
    private char pT = 'o', ppT;     //(previous of) previous roll Type: x-strike, s-spare, o-open, i-fillball
    private int? op = null;         //knocked pins by first throw
    private void NextFrame(char t, int? pins)
    {
        if (pins == null && frame < 10) frame++;
        op = pins < 10 ? pins : null;
        (ppT, pT) = t == 'i' ? ('o', pT == 'x' ? 's' : 'o') : (pT, t);
    }
    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10 || pT == 'o' && frame == 10 || op + pins > 10) throw new ArgumentException();
        score += pins * (1 + (frame != 10 && pT != 'o' ? 1 : 0) + (ppT == 'x' ? 1 : 0));
        NextFrame(frame == 10 ? 'i' : pins == 10 ? 'x' : op + pins == 10 ? 's' : 'o', !op.HasValue && pins < 10 ? (int?)pins : null);
    }
    public int Score() => frame == 10 && pT == 'o' ? score : throw new ArgumentException();
}
