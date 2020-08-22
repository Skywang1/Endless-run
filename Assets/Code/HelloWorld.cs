using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    

    public GameObject ourGameObject;


    void Update()
    {
        Vector3 gameObjectPosition = ourGameObject.transform.position;

        gameObjectPosition.z = gameObjectPosition.z + (5f * Time.deltaTime);

        ourGameObject.transform.position = gameObjectPosition;


    }
}
