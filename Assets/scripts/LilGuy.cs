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
    private float ogSpeed;
    float currentSpeed;
    

    [Header("UI")]
    [SerializeField] Text scoreText;
    public int scoreValue;   
    public Slider StaminaBar;

    [Header("Stamina")]
    public float stamina;
    private float minStamina = 0f;
    public float maxStamina;
    public float staminaRegenSpeed;
    public float StaminaDrainSpeed;
    private float regenDelayTimer;
    public float regenDelay;


    [Header("sprint")]
    public float sprintMultiplier;
    private float sprintSpeed;
    bool canSprint;
    bool sprintPressed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Rigidbody2D rb = GameObject.GetComponent<Rigidbody2D>();
        ogSpeed = speed;
        stamina = maxStamina;
        sprintSpeed = speed * sprintMultiplier;
        
    }

    // Update is called once per frame
    void Update()
    {
        GettingDirection();
        StaminaDrainGain();
        scoreText.text = scoreValue.ToString();
        StaminaBar.value = stamina;
        //sprint();
        if (Input.GetKey(KeyCode.E))
        {
            dribble();
        }

        
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
                //scoreValue += 1;
                
            }

        }
    }

    private void FixedUpdate()
    {
        
        canSprint = (stamina > minStamina);
        sprintPressed = (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Fire2") > 0.1f) && canSprint;
        currentSpeed = sprintPressed ? sprintSpeed : ogSpeed;
        rb.linearVelocity = direction.normalized * currentSpeed;
        //direction = direction.normalized;
    }


    public void dribble()
    {

    }

    public void GettingDirection()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }

    public void StaminaDrainGain()
    {
        if (sprintPressed)
        {
            stamina -= StaminaDrainSpeed * Time.deltaTime;
            stamina = Mathf.Max(stamina, minStamina);
            regenDelayTimer = regenDelay;

        }
        else
        {
            // count down timer
            if (regenDelayTimer > 0f)
            {
                regenDelayTimer -= Time.deltaTime;
            }
            else
            {
                // only regen after delay has passed
                stamina += staminaRegenSpeed * Time.deltaTime;
                stamina = Mathf.Min(stamina, maxStamina);
            }
        }

    }
}