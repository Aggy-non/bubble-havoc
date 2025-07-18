using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody2D rb;

    [Header("Movement")]
    public float speed;
    float horizontalMovement;

    [Header("Air control")]
    public float AirControlMultiplier;
    public float AirSpeed;
    
    [Header("jump")]
    public float jumpForce;
    public int TotalJump;
    public int JumpRemaining;

    [Header("Ground Check")]
    public Vector2 boxSize;
    public float groundCheckSize;
    public LayerMask groundLayer;
    public bool grounded;

    [Header("Gravity")]
    public float baseGravity;
    public float maxFallSpeed;
    public float fallSpeedMultiplier;
    

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Movement(horizontalMovement);
        isGrounded();
        Gravity();
        //AirControl();
    }

    public void Movement(float Facing)
    {
        float moveSpeed = grounded ? speed : AirSpeed * AirControlMultiplier;
        rb.linearVelocity = new Vector2(Facing * moveSpeed, rb.linearVelocity.y);
    }
    //public void AirControl()
    //{
    //    if (!grounded)
    //    {
    //        speed = speed * AirControlMultiplier;
    //        //speed= airspeed
    //    }
    //    else if(grounded)
    //    {
    //        speed = speed;
    //    }
    //}

    public void Gravity()
    {
        if (rb.linearVelocityY < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocityY= Mathf.Max(rb.linearVelocityY, -maxFallSpeed);
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    public void move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x; 
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (JumpRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocityY = jumpForce;
                JumpRemaining--;
            }
            else if (context.canceled && rb.linearVelocityY > 0)
            {
                rb.linearVelocityY = rb.linearVelocityY * 0.5f;
                //JumpRemaining--;
            }

        }
    }

    public void isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, groundCheckSize, groundLayer))
        {
            JumpRemaining = TotalJump;
            grounded = true;
        }

        else
        {
            grounded = false;
        }
    }
    
    public bool CanJump()
    {
        return JumpRemaining > 0;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position - transform.up * groundCheckSize, boxSize);
    //}

}

