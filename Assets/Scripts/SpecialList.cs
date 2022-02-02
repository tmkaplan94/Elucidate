/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: ScriptableObject list can provide more functionality than a regular list.
 *
 * Renamed from Hipple's RuntimeSet, classes can inherit from this to make a SpecialList of type T.
 * Need to implement more functionality in the future, like unique identifiers for items, tags, etc.
 * Maybe attach specific SpecialLists to specific MonoBehavior Managers in the future.
 */
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialList<T> : ScriptableObject
{
    // list of T items
    public List<T> Items = new List<T>();
    
    // if item is not in list, it gets added
    public void Add(T item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
        }
    }

    // if item is in list, it gets removed
    public void Remove(T item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
        }
    }

}
