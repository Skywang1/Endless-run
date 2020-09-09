using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_deleteThisAfterward : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveinput;
    private Rigidbody2D rb;    
    
    public bool onGround;
    public Transform Checkground;
    public float radiuscheck;
    public LayerMask TheGround;
    
    private bool canJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //We want to put the game logic into their individual methods, because in future, this script will become very big. Having everything in their methods allow us to 
        //design the big picture easily. 
        OnGroundDetection();
        MoveMentUpdate();
    }

    void Update()
    {
        JumpUpdate();
    }

    void OnGroundDetection ()
    {
        onGround = Physics2D.OverlapCircle(Checkground.position, radiuscheck, TheGround);
    }

    void MoveMentUpdate ()
    {
        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
    }

    void JumpUpdate ()
    {
        //If we are on ground and our velocity is moving downward, then allow the character to jump. 
        //The reason we do this is becauase, overlapCircle still returns true when the player is slightly offground, since the detection is in a circular radius.
        if (onGround == true && rb.velocity.y < 0)
        {
            //Here we can use a boolean. 
            canJump = true;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canJump)
        {
            rb.velocity = Vector2.up * jumpforce;
            canJump = false;
        }
    }
}     