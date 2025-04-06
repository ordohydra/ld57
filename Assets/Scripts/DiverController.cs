using UnityEngine;

public class DiverController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 4f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(moveX * moveSpeed, moveY * verticalSpeed);
        rb.linearVelocity = velocity;
        // Optional: Rotate the diver based on movement direction
        if (velocity.sqrMagnitude > 0.01f) // Avoid errors when not moving
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}
