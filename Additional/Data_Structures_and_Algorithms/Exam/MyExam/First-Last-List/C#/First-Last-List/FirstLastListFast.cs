using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private LinkedList<T> linkedElements = new LinkedList<T>();
    private OrderedBag<T> orderedElements = new OrderedBag<T>(); 


    public void Add(T newElement)
    {
        this.linkedElements.AddLast(newElement);
        this.orderedElements.Add(newElement);
    }

    public int Count
    {
        get { return this.orderedElements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.linkedElements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.linkedElements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.linkedElements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.linkedElements.Skip(Math.Max(0, this.linkedElements.Count - count)).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.orderedElements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.orderedElements.Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.orderedElements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.orderedElements.Skip(Math.Max(0, this.linkedElements.Count - count)).Reverse();
    }

    public int RemoveAll(T element)
    {
        
        //var elementsToRemoved = this.linkedElements.RemoveAll(x => x.CompareTo(element) == 0);

        //return elementsToRemoved;
        return 0;
    }

    public void Clear()
    {
        this.linkedElements = new LinkedList<T>();
        this.orderedElements = new OrderedBag<T>();
    }
}
