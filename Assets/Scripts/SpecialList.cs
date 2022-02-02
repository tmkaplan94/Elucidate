using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialList<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
        }
    }

    public void Remove(T item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
        }
    }
    
    public void Pop()
    {
        if (Count() > 0)
        {
            Items.RemoveAt(Count() - 1);
        }
    }

    public int Count()
    {
        return Items.Count;
    }
}
