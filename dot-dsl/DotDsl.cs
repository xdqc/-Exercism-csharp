using System;
using System.Collections;
using System.Collections.Generic;
public class Node : IDictionary
{
    Dictionary<string, string> node = new Dictionary<string, string>();
    public Node()
    {
        
    }
    public Node(string a) 
    {
        
    }

    public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsFixedSize => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ICollection Keys => throw new NotImplementedException();

    public ICollection Values => throw new NotImplementedException();

    public int Count => node.Count;

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void Add(object key, object value)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(object key)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public IDictionaryEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Edge : IDictionary
{
    public Edge()
    {
        
    }
    public Edge(string a, string b)
    {
        
    }

    public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsFixedSize => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ICollection Keys => throw new NotImplementedException();

    public ICollection Values => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void Add(object key, object value)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(object key)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public IDictionaryEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Attr : IEnumerable
{
    public Attr()
    {
        
    }
    public Attr(string a, string b)
    {
        
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class Graph : IDictionary
{
    public List<Node> Nodes { get; set; }
    public List<Edge> Edges { get; set; }
    public List<Attr> Attrs { get; set; }

    public bool IsFixedSize => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public ICollection Keys => throw new NotImplementedException();

    public ICollection Values => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Graph()
    {
        this.Nodes = new List<Node>();
        this.Edges = new List<Edge>();
        this.Attrs = new List<Attr>();
    }

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public void Add(object key, object value)
    {
        throw new NotImplementedException();
    }

    public void Add(object key)
    {
        
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(object key)
    {
        throw new NotImplementedException();
    }

    IDictionaryEnumerator IDictionary.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }
}