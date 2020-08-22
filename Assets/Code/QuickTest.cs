using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        foreach (var item in resolutions)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
