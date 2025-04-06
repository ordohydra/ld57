using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currentOxygen;
    public float depletionRate = 5f;
    public float regenerationRate = 10f;

    public GameObject gameOverPanel;

    private bool isGameOver = false;

    public MonoBehaviour diver;

    void Start()
    {
        currentOxygen = maxOxygen;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        if (diver.transform.position.y < -0.1) {
            currentOxygen -= depletionRate * Time.deltaTime;
        } else {
            currentOxygen += regenerationRate * Time.deltaTime;
        }
        
        if (currentOxygen <= 0)
        {
            currentOxygen = 0;
            TriggerGameOver();
        }
    }

    public void RefillOxygen(float amount)
    {
        currentOxygen = Mathf.Min(currentOxygen + amount, maxOxygen);
    }

     void TriggerGameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Optionally: Pause the game
        Time.timeScale = 0f;
    }
}
