using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tests : MyBase
{


    void Update()
    {
        
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