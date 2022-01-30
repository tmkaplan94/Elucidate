using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventBus : MonoBehaviour
{
    private static readonly
        IDictionary<GameEvent, UnityEvent> Events = new Dictionary<GameEvent, UnityEvent>();

    public static void Subscribe(GameEvent eventType, UnityAction listener)
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

    public static void Unsubscribe(GameEvent eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(GameEvent eventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
