using System;
using System.Linq;

public class SpiralMatrix
{
    private int[,] matrix;
    private (int x, int y) dir = (1, 0);
    private (int x, int y) pos = (0, 0);
    private void RotateClockwise() => dir = dir.y == 0 ? (0, dir.x) : (-dir.y, 0);
    private void Step() => pos = (pos.x + dir.x, pos.y + dir.y);
    private void Stepback() => pos = (pos.x - dir.x, pos.y - dir.y);
    public int[,] GetMatrix(int size)
    {
        matrix = new int[size, size];
        for (int i = 1; i <= size * size; i++)
        {
            matrix[pos.y, pos.x] = i;
            try
            {
                Step();
                if (matrix[pos.y, pos.x] != 0) throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException)
            {
                Stepback();
                RotateClockwise();
                Step();
            }
        }
        return matrix;
    }
}
