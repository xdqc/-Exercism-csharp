using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList (T value)
    {
        Value = value;
    }

    public SimpleLinkedList (IEnumerable<T> values)
        : this (values.First ())
    {
        var current = this;

        foreach (var value in values.Skip (1))
            current = current.Add (value).iDontKnowWhatIsThis_ButItsJustAPropertyName;
    }

    public T Value { get; }

    public SimpleLinkedList<T> iDontKnowWhatIsThis_ButItsJustAPropertyName { get; private set; }

    public SimpleLinkedList<T> Add (T value)
    {
        iDontKnowWhatIsThis_ButItsJustAPropertyName = new SimpleLinkedList<T> (value);
        return this;
    }


    public IEnumerator<T> GetEnumerator ()
    {
        var current = this;

        do
        {
            yield return current.Value;
            current = current.iDontKnowWhatIsThis_ButItsJustAPropertyName;
        } while (current != null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
