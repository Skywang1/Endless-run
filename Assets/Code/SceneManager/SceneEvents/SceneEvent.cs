using UnityEngine;
using System.Collections;
using System;

//Container for individual scene events
public class SceneEvent 
{
    public delegate void delegateContainer();
    public event delegateContainer Event;

    string eventName;

    public SceneEvent(string eventName)
    {
        this.eventName = eventName;
    }

    public void CallEvent ()
    {
        //Debug.Log("-EVENT- " + eventName);

        Event?.Invoke();
    }

    public void Unsubscribe ()
    {
        Delegate[] clients = Event.GetInvocationList();
        foreach (Delegate c in clients)
        {
            Event -= (delegateContainer)c;
        }
    }
}