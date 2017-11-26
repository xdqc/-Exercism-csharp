using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int x = 0;
        int y = 0;
        Direction dir = Direction.Right;
        int[,] spiral = new int[size, size];
        for (int i = 1; i <= size * size; i++)
        {
            switch (dir)
            {
                case Direction.Right:
                    if (y >= size || spiral[x, y] != 0)
                    {
                        y--;
                        x++;
                        dir = Direction.Down;
                        goto case Direction.Down;
                    }
                    spiral[x, y++] = i;
                    break;
                case Direction.Down:
                    if (x >= size || spiral[x, y] != 0)
                    {
                        x--;
                        y--;
                        dir = Direction.Left;
                        goto case Direction.Left;
                    }
                    spiral[x++, y] = i;
                    break;
                case Direction.Left:
                    if (y < 0 || spiral[x, y] != 0)
                    {
                        y++;
                        x--;
                        dir = Direction.Up;
                        goto case Direction.Up;
                    }
                    spiral[x, y--] = i;
                    break;
                case Direction.Up:
                    if (x < 0 || spiral[x, y] != 0)
                    {
                        x++;
                        y++;
                        dir = Direction.Right;
                        goto case Direction.Right;
                    }
                    spiral[x--, y] = i;
                    break;
            }
        }
        return spiral;
    }
}

public enum Direction
{
    Left,
    Down,
    Right,
    Up,
}