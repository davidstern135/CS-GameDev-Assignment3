using UnityEngine;
using TMPro;

/**
 * Displays the score in a fixed position on screen.
 */
public class ScoreDisplay : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    [Tooltip("The NumberField component that tracks the score")]
    NumberField scoreField; 

    [SerializeField]
    [Tooltip("Text format - use {0} for score")]
    string textFormat = "Score: {0}"; 

    private TextMeshProUGUI scoreText; 

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    void Update()
    {
        // Update the score display every frame.
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        // Check if both references are valid.
        if (scoreField != null && scoreText != null)
        {
            // Get current score and update the text
            int score = scoreField.GetNumber();
            scoreText.text = string.Format(textFormat, score);
        }
    }
}