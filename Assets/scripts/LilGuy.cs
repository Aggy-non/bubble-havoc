using UnityEngine;

public class LilGuy : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;
    private float FacingDirection;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
       rb.linearVelocityX=horizontal*speed;
       rb.linearVelocityY=vertical*speed;
    }
}
