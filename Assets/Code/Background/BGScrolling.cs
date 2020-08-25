using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    const float WarpEdge_leftX = -18.3f;
    const float Spawn_rightX = 18.3f;

    public float fastSpeed = 5f;
    public float slowSpeed = 2f;

    float acceleration = 5f;
    float moveSpeed;
    float targetSpeed;

    private void Start()
    {
        SetTargetSpeed(slowSpeed);
    }

    void Update()
    {
        //Move speed transition
        moveSpeed = Mathf.Lerp(moveSpeed, targetSpeed, acceleration * Time.deltaTime);

        //Move
        transform.Translate(new Vector3(-moveSpeed *Time.deltaTime, 0f, 0f));

        //Warp: left to right
        if (transform.position.x < WarpEdge_leftX)
        {
            Vector3 p = transform.position;
            p.x = Spawn_rightX;
            transform.position = p;
        }
    }

    void SetTargetSpeed (float s)
    {
        targetSpeed = s;
    }
}