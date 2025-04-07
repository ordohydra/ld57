using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool isGoingLeft = true;
    public float speed = 0.05f;

    private Vector3 target;

    private Rigidbody2D rb;

    public OxygenManager oxygenManager; // Reference to the OxygenManager script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            oxygenManager.DepleteOxygen(20f); // Deplete oxygen when colliding with an enemy
            return;
        }

        isGoingLeft = !isGoingLeft; // Reverse direction on collision
        Vector3 scale = transform.localScale;
        scale = new Vector3(-scale.x, scale.y, scale.z);
        transform.localScale = scale;

        if (isGoingLeft) {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        } else {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
    }
}