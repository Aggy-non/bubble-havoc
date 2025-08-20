using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int bubbleLevel;
    public int maxAir;
    public int minAir;
    void Start()
    {
        
    }

    
    void Update()
    {
        pop();  
    }

    void pop()
    {
        if (bubbleLevel>maxAir || bubbleLevel<=minAir)
        {
            Debug.Log(gameObject.name + " popped!");
            Destroy(gameObject);
        }
    }

    public void ModifyAir(int amount)
    {
        bubbleLevel += amount; // here "amount" comes from the parameter
        Debug.Log(gameObject.name + " air changed by " + amount + ". Current: " + bubbleLevel);
    }

}
