using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    private bool isGrounded;
    float horizontalMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
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
        if(context.performed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
        else if(context.canceled)
        {
            rb.linearVelocityY=rb.linearVelocityY * 0.5f;
        }
    
    }
}
