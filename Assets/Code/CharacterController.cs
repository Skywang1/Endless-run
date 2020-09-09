using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveinput;
    private Rigidbody2D rb;
    
    
    public bool Ground;
    public Transform Checkground;
    public float radiuscheck;
    public LayerMask TheGround;
    
    private int Jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        Ground = Physics2D.OverlapCircle(Checkground.position, radiuscheck, TheGround);

        moveinput = Input.GetAxis("Horizontal");
        //Debug.Log(moveinput);
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);


    }

    void Update()
    {
        if(Ground == true)
        {
            Jump = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Jump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            Jump--;
        }
        
    }

}     
    


