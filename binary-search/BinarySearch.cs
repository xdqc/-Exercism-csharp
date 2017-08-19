using System;

public class BinarySearch
{
    public BinarySearch(int[] input)
    {
        arr = input;
    }

    int[] arr;

    public int Find(int value)
    {
        if (arr.Length <= 0)
        {
            return -1;
        }

        int low = 0;
        int high = arr.Length - 1;
        while (low <= high)
        {
            int index = (low + high) / 2;
            if (value == arr[index])
            {
                return index;
            }
            else if (value < arr[index])
            {
                high = index - 1;
            }
            else
            {
                low = index + 1;
            }
        }

        return -1;
    }
}