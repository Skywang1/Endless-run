using UnityEngine;
using System.Collections;
using System;

public class SceneEvent 
{
    public delegate void delegateContainer();
    public event delegateContainer Event;

    public void CallEvent ()
    {
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