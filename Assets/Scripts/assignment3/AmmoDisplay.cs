using UnityEngine;
using TMPro;

/**
 * Displays ammunition count and rapid fire timer on screen.
 */
[RequireComponent(typeof(TextMeshProUGUI))]
public class AmmoDisplay : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LaserShooterWithCooldown shooter;
    [SerializeField] string textFormat = "Ammo: {0}/{1}";
    [SerializeField] string rapidFireFormat = " RAPID FIRE: {0:F1}s ";

    private TextMeshProUGUI ammoText;

    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (shooter != null && ammoText != null)
        {
            // Show rapid fire countdown.
            if (shooter.IsRapidFireActive())
            {
                float timeLeft = shooter.GetRapidFireTimeRemaining();
                ammoText.text = string.Format(rapidFireFormat, timeLeft);
                ammoText.color = Color.yellow;
            }
            // Show normal ammo count.
            else
            {
                int current = shooter.GetCurrentAmmo();
                int max = shooter.GetMaxAmmo();
                ammoText.text = string.Format(textFormat, current, max);
                ammoText.color = Color.white;
            }
        }
    }
}