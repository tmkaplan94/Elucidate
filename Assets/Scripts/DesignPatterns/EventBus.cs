using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventBus<T> : MonoBehaviour
{
    private static readonly
        IDictionary<T, UnityEvent> Events = new Dictionary<T, UnityEvent>();

    public static void Subscribe(T eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        
        if (Events.TryGetValue(eventType, out thisEvent))
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

    public static void Unsubscribe(T eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(T eventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
