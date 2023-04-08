using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    //serializefield means to have a field in the unity UI that you can drag and drop stuff into eg. for rb you can drag and drop the players rigidbody component into it
    //you can also do a public variable to do the same thing i think (see CameraFollow script for example)
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck; //checks if player is on the ground for jumping purposes
    [SerializeField] private LayerMask groundLayer; //groundLayer denotes which surfaces are walkable or not
    //[SerializeField] private float acceleration = 3f;
    //[SerializeField] private float maxSpeed = 12f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //returns -1, 0 or 1 depending on direction player is moving
        
        //NOTE: "Input" referes to the input system you can find in Edit > Project Settings > Search for "Input Manager"
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //longer jump press time means a higher jump
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
        Flip();
        
    }

    private void FixedUpdate() //FixedUpdate is called every fixed framerate - frame
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip() //
    {
        if((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
