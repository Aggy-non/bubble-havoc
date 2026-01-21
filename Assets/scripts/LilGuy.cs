using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LilGuy : MonoBehaviour
{
    //private float horizontal;
    //private float vertical;
    [Header("Player")]
    [SerializeField] float speed;
    [SerializeField] float kickForce;
    private float FacingDirection;
    public Rigidbody2D rb;
    private Vector2 direction;
    public int sprintMultiplier;
    private float sprintSpeed;
    private float ogSpeed;

    [Header("UI")]
    [SerializeField] Text scoreText;
    private int scoreValue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GameObject.GetComponent<Rigidbody2D>();
        ogSpeed = speed;
        sprintSpeed = speed * sprintMultiplier;
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        //sprint();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Rigidbody2D ballrb=collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballrb != null)
            {
                // Push away from player center
                Vector2 kickDir = (collision.transform.position - transform.position).normalized;

                ballrb.AddForce(kickDir * kickForce, ForceMode2D.Impulse);
                scoreValue += 1;
                scoreText.text=scoreValue.ToString();
            }

        }
    }

    private void FixedUpdate() 
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : ogSpeed;
        rb.linearVelocity=direction.normalized*currentSpeed;
       //direction = direction.normalized;
    }

    private void sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else 
        {
            speed = ogSpeed;
        }
    }
}