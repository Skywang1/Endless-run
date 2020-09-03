using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tests : MyBase
{
    private void Start()
    {
        SceneEvents.GameStart.Event += MyFunction;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneEvents.GameStart.CallEvent();
        }
    }



    void MyFunction()
    {
        Debug.Log("hi");
    }
}

public abstract class MyBase : MonoBehaviour
{
    protected virtual void Start()
    {
        Debug.Log("Base start");
    }

    protected virtual void OnDisable()
    {
        Debug.Log("OnDisable");
    }
}