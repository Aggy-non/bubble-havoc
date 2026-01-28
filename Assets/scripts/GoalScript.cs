using System.Collections;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    EdgeCollider2D trig;
    public LilGuy boy;
    bool BallInGoal;
    public int waiting;
    public GameObject ball;
    public Transform respawnPoint;
    Rigidbody2D rb;
    public GameObject centerCirc;
    public GameObject CircleClear;
    private bool isRespawning; // ensures only one respawn runs

    void Start()
    {
        trig = gameObject.GetComponent<EdgeCollider2D>();
        rb = ball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball") && !BallInGoal)
        {
            boy.scoreValue++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ball") && !BallInGoal && !isRespawning)
        {
            BallInGoal = true;
            stopBall();
            respawnLogic();
        }
    }

    private void respawnLogic()
    {
        Debug.Log("ball is in goal");
        isRespawning = true;
        StartCoroutine(RespawnSequence());
    }

    private void stopBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private IEnumerator RespawnSequence()
    {
        Debug.Log("respawn sequence started");
        yield return StartCoroutine(centerCircleSpawn());
        yield return StartCoroutine(RespawnBall());
        yield return StartCoroutine(centerCircleDespawn());

        BallInGoal = false;
        isRespawning = false; // allow new respawns
    }

    private IEnumerator RespawnBall()
    {
        Debug.Log("respawn started");
        yield return new WaitForSeconds(waiting - 1);
        ball.transform.position = respawnPoint.position;
    }

    private IEnumerator centerCircleSpawn()
    {
        CircleClear.SetActive(true);
        yield return new WaitForSeconds(1);
        centerCirc.SetActive(true);
        CircleClear.SetActive(false);
    }

    private IEnumerator centerCircleDespawn()
    {
        Debug.Log("despawn started");
        yield return new WaitForSeconds(waiting);
        centerCirc.SetActive(false);
    }
}