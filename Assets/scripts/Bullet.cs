using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int AirValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyController enemy=col.gameObject.GetComponent<EnemyController>();

        if (enemy != null )
        {
            enemy.ModifyAir(AirValue);
            Destroy(gameObject);
        }

        else if (!col.CompareTag("Player"))
        {
            // Hit something that's NOT the player ? pop
            Destroy(gameObject);
        }
    }

}
