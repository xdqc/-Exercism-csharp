using System;

public class BowlingGame
{
    private int? frame = 0, score = 0, op = null, pT = 'o', ppT = 'o'; //op: knocked pins by first throw  //(previous of) previous roll Type: x-strike, s-spare, o-open, i-fillball
    public void Roll(int pins) => (score, op, frame, (ppT, pT)) = (score + (pins < 0 || pins > 10 || pT == 'o' && frame == 10 || op + pins > 10 ? throw new ArgumentException() : pins * (1 + Convert.ToInt16(pT != 'o' && frame < 10) + Convert.ToInt16(ppT == 'x'))), !op.HasValue && pins < 10 ? (int?)pins : null, frame + Convert.ToInt16((!op.HasValue && pins < 10 ? (int?)pins : null) == null && frame < 10), (frame == 10 ? 'i' : pins == 10 ? 'x' : op + pins == 10 ? 's' : 'o') == 'i' ? ('o', pT == 'x' ? 's' : 'o') : (pT, (frame == 10 ? 'i' : pins == 10 ? 'x' : op + pins == 10 ? 's' : 'o')));
    public int? Score() => frame == 10 && pT == 'o' ? score : throw new ArgumentException();
}
