using UnityEngine;
using System.Collections;

public class SceneEvent : ScriptableObject
{
    public delegate void delegateContainer();
    public event delegateContainer Event;

    public void CallEvent ()
    {
        Event?.Invoke();
    }
}