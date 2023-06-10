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

    //Ground collider stuff 
    public Transform groundCheckCollider;
    const float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;
    public bool isGrounded = false; //checks to see if player is grounded

    //jump
    private float jumpPower = 10f;

    private float moveInput;
    private bool isFacingRight = true;
    private float acceleration = 3f;
    private float decceleration = -3f; //ignore that theres two imma fix it later
    private float velPower = 1f;

    private bool lowGravityMode = false;
    public bool noGravityMode = false;
    private bool reverseGravityMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerControls.ReadValue<Vector2>().x; //basicall
        //if(playerControls.ReadValue)
        //if(playerControls.ReadValue)
        
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

    void GroundCheck()
    {
        //check if groundCheck object is colliding with "Walkable"; if yes then true, if no then false
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer); //add whatever is contacted to array
        if(colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    public void Jump(InputAction.CallbackContext context) //context is command "space"
    {
        if(context.performed && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); //jump
        }
        if(context.canceled && rb.velocity.y > 0f) //higher jump depending on time held
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void activateNo(InputAction.CallbackContext context)
    {
        //if isGravity true, context performed, turn off gravity
        if (noGravityMode == true && context.performed)
        {
            noGravityMode = false;
            Debug.Log("gravity on");
        }

        //else if isGravity false, context performed, turn on gravity
        else if (noGravityMode == false && context.performed)
        {
            noGravityMode = true;
            Debug.Log("gravity off");
        }
    }

    void FixedUpdate()
    {
        if(moveInput != 0) //copied this from a video
        {
            float targetSpeed = moveInput * maxSpeed;

            float velocityDifference = targetSpeed - rb.velocity.x;

            float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

            float movement = Mathf.Pow(Mathf.Abs(velocityDifference) * accelerationRate, velPower) * Mathf.Sign(velocityDifference);

            if(isGrounded == false) 
            {
                rb.AddForce(0.1f * movement * Vector2.right); //deaccelerate side to side movement when in the air
                rb.AddForce(5f * Vector2.down); //make them fall quicker in air
            }
            else
            {
                rb.AddForce(movement * Vector2.right);
            }
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
        

        //Debug.Log(rb.velocity.x);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
