﻿using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    const float WarpEdge_leftX = -18.219f;
    const float Spawn_rightX = 36.438f;

    public float fastSpeed = 5f;
    public float slowSpeed = 2f;

    float acceleration = 99f;
    float moveSpeed;
    float targetSpeed;

    private void Start()
    {
        SceneManager.OnCharacterEnter += StartsRunning;
        SceneManager.OnCharacterDead += PlayerDead;

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

    #region Setting speed
    void SetTargetSpeed(float s)
    {
        targetSpeed = s;
    }

    void StartsRunning()
    {
        SetTargetSpeed(fastSpeed);
    }

    void PlayerDead ()
    {
        SetTargetSpeed(slowSpeed);
    }
    #endregion

    void OnDisable()
    {
        SceneManager.OnCharacterEnter -= StartsRunning;
        SceneManager.OnCharacterDead -= PlayerDead;
    }
}