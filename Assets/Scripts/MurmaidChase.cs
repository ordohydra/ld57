using UnityEngine;

public class MurmaidChase : MonoBehaviour
{
    public Transform player;         // Assign the player Transform in the Inspector
    public float speed = 3f;         // Movement speed
    public float stopDistance = 1f;  // How close the enemy gets before stopping

    public float startChaseDistance = 6f; // Distance at which the enemy starts chasing

    public OxygenManager oxygenManager; // Reference to the OxygenManager script

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance && distance < startChaseDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            oxygenManager.DepleteOxygen(30f); // Deplete oxygen when colliding with an enemy
            return;
        }
    }
}
