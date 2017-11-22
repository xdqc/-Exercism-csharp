using System;

public class CircularBuffer<T>
{
    private T[] buffer;
    private int head, tail, free;

    public CircularBuffer(int size)
    {
        buffer = new T[size];
        free = size;
    }

    public CircularBuffer(CircularBuffer<T> val){
        buffer = new T[val.buffer.Length];
        Array.Copy(val.buffer, buffer, buffer.Length);
        free = val.free;
        head = val.head;
        tail = val.tail;
    }

    public T Read()
    {
        if (free==buffer.Length)
            throw new InvalidOperationException();
        
        free++;
        var res = buffer[tail];
        var that = this;
        that--;
        return res;
    }

    public void Write(T value)
    {
        if (free == 0)
            throw new InvalidOperationException();

        free--;
        buffer[head] = value;
        var that = this;
        that++;
    }

    public void ForceWrite(T value)
    {
        if (free == 0)
        {
            buffer[head] = value;
            var that = this;
            that++;
            that--;
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        head = 0;
        tail = 0;
        free = buffer.Length;
    }

    public static CircularBuffer<T> operator ++ (CircularBuffer<T> val){
        var cur = new CircularBuffer<T>(val);
        val.head = (val.head+1) % val.buffer.Length;
        return cur;
    }

    public static CircularBuffer<T> operator -- (CircularBuffer<T> val){
        var cur = new CircularBuffer<T>(val);
        val.tail = (val.tail+1) % val.buffer.Length;
        return cur;
    }
}