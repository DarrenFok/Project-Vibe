using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 12f;
    public float deacceleration = 5;
    public InputAction playerControls;

    private float moveInput;
    private bool isFacingRight = true;
    private float acceleration = 3f;
    private float decceleration = -3f; //ignore that theres two imma fix it later
    private float velPower = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerControls.ReadValue<Vector2>().x; //basically the direction that the player is moving 
    }

    //needed for unitys *new* input system (Window -> Package Manager -> Select search for Packages in Unity Registry -> Search for Input System)
    private void OnEnable()
    {
        playerControls.Enable(); //idk what these do 

    }
    
    private void OnDisable()
    {
        playerControls.Disable();
        
    }

    void FixedUpdate()
    {
        if(moveInput != 0) //copied this from a video
        {
            float targetSpeed = moveInput * maxSpeed;

            float velocityDifference = targetSpeed - rb.velocity.x;

            float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

            float movement = Mathf.Pow(Mathf.Abs(velocityDifference) * accelerationRate, velPower) * Mathf.Sign(velocityDifference);

            rb.AddForce(movement * Vector2.right);
        }
        
        else //deccelerate player when not pressing keys
        {
            float currentVelocity = rb.velocity.x;
            float newVelocity = 0f;
            if(currentVelocity < 0) //going left
            {
                rb.AddForce(deacceleration * -currentVelocity * Vector2.right);
            }
            else if(currentVelocity > 0) //going right
            {
                rb.AddForce(deacceleration * currentVelocity * Vector2.left);
            }
        }
        

        Debug.Log(rb.velocity.x);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}