/*
 * Author: Tyler Kaplan
 * Contributors:
 * Description: EventBus, aka Pub/Sub, abstracts communication between systems and objects.
 * 
 * Decouples data. Objects can communicate via the event bus rather than direct referencing.
 * Requires a global enum of an event type T. See GameEvent.cs for an example.
 * To use, Subscribe() should be called in OnEnable() and
 * Unsubscribe() needs to be called per every Subscribe() in OnDisable(). (don't forget)
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventBus<T> : MonoBehaviour
{
    // stores event type T and delegate method as key/value pairs
    private static readonly IDictionary<T, UnityEvent> Events = new Dictionary<T, UnityEvent>();

    // subscribes method listener to given event type if it's not already in Events
    // any class/object can subscribe to any event
    public static void Subscribe(T eventType, UnityAction listener)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }
    
    // unsubscribes method listener from given event type if it's currently in Events
    // needs to be called per every subscribe call
    public static void Unsubscribe(T eventType, UnityAction listener)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // publish that T event has occurred
    // any class/object can publish that any event has occurred
    public static void Publish(T eventType)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
