using UnityEngine;
using System.Collections;

public class SceneEvent
{
    public delegate void delegateContainer();
    public event delegateContainer Event;

    public void CallEvent ()
    {
        Event?.Invoke();
    }
}