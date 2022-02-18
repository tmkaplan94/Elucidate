/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: ScriptableObject list can provide more functionality than a regular list.
 *
 * Renamed from Hipple's RuntimeSet, classes can inherit from this to make a ScriptableObjectList of type T.
 * Need to implement more functionality in the future, like unique identifiers for items, tags, etc.
 * Maybe attach specific SpecialLists to specific MonoBehavior Managers in the future.
 */
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SOList<T> : ScriptableObject
{
    // list of T items with unique int identifiers
    public readonly Dictionary<int, T> Items = new Dictionary<int, T>();

    // if item is not in list, it gets added
    public void Add(int id, T item)
    {
        if (!Items.ContainsKey(id))
        {
            Items.Add(id, item);
            //Debug.Log("I was added to the list of players!");
        }
    }

    // if item is in list, it gets removed
    public void Remove(int id)
    {
        if (Items.ContainsKey(id))
        {
            Items.Remove(id);
            //Debug.Log("I was removed from list of players!");
        }
    }

    public int Length()
    {
        return Items.Count;
    }

}
