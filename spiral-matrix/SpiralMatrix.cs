using System;

public class SpiralMatrix
{
    private (int x, int y) dir = (1, 0);
    private (int x, int y) pos = (0, 0);
    private void Rotate() => dir = dir.y == 0 ? (0, dir.x) : (-dir.y, 0);
    private void Step((int x, int y) d) => pos = (pos.x + d.x, pos.y + d.y);
    public int[,] GetMatrix(int size)
    {
        int[,] m = new int[size, size];
        for (int i = 1; i <= size * size; i++)
        {
            m[pos.y, pos.x] = i;
            try
            {
                Step(dir);
                if (m[pos.y, pos.x] != 0) throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException)
            {
                Step((-dir.x, -dir.y));
                Rotate();
                Step(dir);
            }
        }
        return m;
    }

}
