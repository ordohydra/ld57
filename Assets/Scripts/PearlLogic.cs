using UnityEngine;

public class PearlLogic : MonoBehaviour
{
    public OxygenManager oxygenManager; // Reference to the OxygenManager script
    void OnTriggerEnter2D(Collider2D collision)
    {
        oxygenManager.RefillOxygen(70.0f);
         Destroy(gameObject); // Destroys *this* object on collision
    }
}
