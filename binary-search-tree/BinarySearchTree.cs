using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{

    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        foreach (var value in values)
        {
            if (Value==null)
            {
                Value = value;
            }
            else
            {
                this.Add(value);
            }
        }
    }

    public int? Value
    {
        get;set;
    }

    public BinarySearchTree Left
    {
        get;set;
    }

    public BinarySearchTree Right
    {
        get;set;
    }

    public BinarySearchTree Add(int value)
    {       
        if (value <= Value)
        {
            if (this.Left != null)
            {
                this.Left.Add(value);
            }
            else
            {
                this.Left = new BinarySearchTree(value);
            }
        }
        else if (value > Value)
        {
            if (this.Right != null)
            {
                this.Right.Add(value);
            }
            else
            {
                this.Right = new BinarySearchTree(value);
            }
        }
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (this.Left != null)
        {
            this.Left.GetEnumerator();
        }
        yield return this.Value.Value;
        if (this.Right != null)
        {
            this.Right.GetEnumerator();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}