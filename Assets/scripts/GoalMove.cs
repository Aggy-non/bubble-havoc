  using UnityEngine;

public class GoalMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards
            (transform.position,target.position,speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <0.1f)
        {
            target= (target==pointA) ? pointB : pointA;
        }
    }
}
