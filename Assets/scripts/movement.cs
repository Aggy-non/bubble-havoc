using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    float horizontalMovement;
    public Vector2 boxSize;
    public float groundCheckSize;
    public LayerMask groundLayer;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        rb.linearVelocity= new Vector2(horizontalMovement*speed, rb.linearVelocity.y); 

    }

    public void move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void jump(InputAction.CallbackContext context) 
    {
        if(context.performed && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
        else if(context.canceled)
        {
            rb.linearVelocityY=rb.linearVelocityY * 0.5f;
        }
    
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, groundCheckSize, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckSize, boxSize);
    }

}

