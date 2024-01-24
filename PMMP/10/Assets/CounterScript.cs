using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the Text UI element

    void Start()
    {
        // Initialize the counter text
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        // Update the Text component with the current counter value
        counterText.text = GreenPlatform.destroyedCount.ToString();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // Call the UpdateCounterText method in every frame (or as needed)
        UpdateCounterText();
    }
}
