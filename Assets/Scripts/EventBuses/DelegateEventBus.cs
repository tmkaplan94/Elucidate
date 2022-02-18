
using System.Collections.Generic;
using System;


public abstract class DelegateEventBus<T>
{
    private static readonly IDictionary<T, Action> Events = new Dictionary<T, Action>();

    public static void Subscribe(T eventType, Action listener)
    {
        Action thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            Events[eventType] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(T eventType, Action listener)
    {
        Action thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            //Remove event from the existing one
            thisEvent -= listener;

            //Update the Dictionary
            Events[eventType] = thisEvent;
        }
    }

    public static void Publish(T eventType)
    {
        Action thisEvent = null;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
            // OR USE instance.eventDictionary[eventName]();
        }
    }
}
