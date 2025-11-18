using UnityEngine;

/**
 * Ammo pickup.
 */
public class AmmoPickup : MonoBehaviour
{
    private float lifetime = 3f;
    private int ammoAmount = 5;
    private float rotationSpeed = 100f;

    private void Start()
    {
        // Destroy if not pucked up on time.
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Rotate
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LaserShooterWithCooldown shooter = other.GetComponent<LaserShooterWithCooldown>();
            if (shooter)
            {
                // Collect ammo.
                shooter.AddAmmo(ammoAmount);

                // Destroy when picked up. 
                Destroy(gameObject);
            }
        }
    }
}