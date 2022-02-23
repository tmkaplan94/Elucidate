/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan, Grant Reed
 * Description: ScriptableObject list can provide more functionality than a regular list.
 *
 * Renamed from Hipple's RuntimeSet, classes can inherit from this to make a ScriptableObjectList of type T.
 * Added functionality includes Length(), GetItem(), ClearAll(), etc.
 */
using System.Collections.Generic;
using UnityEngine;

public abstract class SOList<T> : ScriptableObject where T : Component
{
    // list of T items with unique int identifiers
    private readonly Dictionary<int, T> Items = new Dictionary<int, T>();

    // if item is not in list, it gets added
    public void Add(int id, T item)
    {
        if (!Items.ContainsKey(id))
        {
            Items.Add(id, item);
        }
    }

    // if item is in list, it gets removed
    public void Remove(int id)
    {
        if (Items.ContainsKey(id))
        {
            Items.Remove(id);
        }
    }

    // returns how many items are in dictionary
    public int Length()
    {
        return Items.Count;
    }

    // returns a specific script component based on the gameobject's unique ID
    public T GetItem(int id)
    {
        if (!Items.TryGetValue(id, out T item))
        {
            Debug.Log("Player " + id + "Does not exist.");
        }

        return item;
    }

    // returns all the transforms of the items in the dictionary
    public List<Transform> GetAllTransforms()
    {
        List<Transform> transforms = new List<Transform>();
        foreach (var item in Items)
        {
            transforms.Add(item.Value.gameObject.transform);
        }

        return transforms;
    }

    // clears all items from the dictionary
    public void ClearAll()
    {
        Items.Clear();
    }
}
