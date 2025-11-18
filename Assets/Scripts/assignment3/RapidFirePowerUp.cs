using UnityEngine;

/**
 * Power-up that grants temporary rapid fire ability.
 */
public class RapidFirePowerUp : MonoBehaviour
{
    [Header("Power-Up Settings")]
    [SerializeField] float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LaserShooterWithCooldown shooter = other.GetComponent<LaserShooterWithCooldown>();
            if (shooter)
            {
                // Activate rapid fire mode
                shooter.ActivateRapidFire(duration);

                // Remove power-up object
                Destroy(gameObject);
            }
        }
    }
}