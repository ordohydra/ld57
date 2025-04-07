using UnityEngine;

public class MurmaidChase : MonoBehaviour
{
    public Transform player;         // Assign the player Transform in the Inspector
    public float speed = 3f;         // Movement speed
    public float stopDistance = 1f;  // How close the enemy gets before stopping

    public float startChaseDistance = 6f; // Distance at which the enemy starts chasing

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
}
