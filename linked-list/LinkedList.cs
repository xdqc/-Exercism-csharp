using System;

public class Deque<T>
{
    private T val;
    private Deque<T> Next, Prev, Head, Tail;
    private bool Init;

    public Deque()
    {
        Init = true;
        Head = this;
        Tail = this;
    }

    public Deque(T value)
    {
        this.val = value;
        Init = false;
        Head = this;
        Tail = this;
    }

    public void Push(T value)
    {
        Tail.Next = new Deque<T>(value);
        Tail.Next.Prev = Tail;
        Tail = Tail.Next;
        if (Init)
        {
            Head = Tail;
            Init = false;
        }
    }

    public T Pop()
    {
        if (this != null)
        {
            var value = Tail.val;
            Tail = Tail.Prev;
            return value;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public void Unshift(T value)
    {
        Head.Prev = new Deque<T>(value);
        Head.Prev.Next = Head;
        Head = Head.Prev;
        if (Init)
        {
            Tail = Head;
            Init = false;
        }
    }

    public T Shift()
    {
        if (this != null)
        {
            var value = Head.val;
            Head = Head.Next;
            return value;
        }
        else
        {
            throw new NullReferenceException();
        }
    }
}
