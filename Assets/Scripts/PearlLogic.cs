using UnityEngine;

public class PearlLogic : MonoBehaviour
{
    public OxygenManager oxygenManager; // Reference to the OxygenManager script
    void OnTriggerEnter2D(Collider2D collision)
    {
        oxygenManager.depletionRate /= 2; // Decrease the regeneration rate by half
         Destroy(gameObject); // Destroys *this* object on collision
    }
}
