using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    public Slider oxygenSlider;
    public OxygenManager oxygenManager; // Reference to your oxygen logic script

    void Update()
    {
        if (oxygenManager != null && oxygenSlider != null)
        {
            float ratio = oxygenManager.currentOxygen / oxygenManager.maxOxygen;
            oxygenSlider.value = ratio;
        }
    }
}