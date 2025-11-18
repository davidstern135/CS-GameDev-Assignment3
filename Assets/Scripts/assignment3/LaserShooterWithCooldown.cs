using UnityEngine;

/**
 * Laser  with cooldown, limited ammunition, and rapid fire power-up.
 */
public class LaserShooterWithCooldown : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject = new Vector3(0, 15f, 0);

    [Header("Cooldown Settings")]
    [SerializeField] float cooldownTime = 0.5f;
    [SerializeField] float cooldownTimeRapidFire = 0.1f;

    [Header("Ammunition Settings")]
    [SerializeField] int maxAmmo = 30;

    [Header("Score Settings")]
    [SerializeField] int pointsToAdd = 1;

    [Header("Rapid Fire Settings")]
    [SerializeField] GameObject rapidFireIndicator;

    private int currentAmmo;
    private float lastShotTime = -999f;
    private NumberField scoreField;
    private bool isRapidFireActive = false;
    private float rapidFireEndTime;

    private void Start()
    {
        scoreField = GetComponentInChildren<NumberField>();
        currentAmmo = maxAmmo;

        // Hide rapid fire indicator at start
        if (rapidFireIndicator)
        {
            rapidFireIndicator.SetActive(false);
        }
    }

    private void Update()
    {
        // Fire laser when space is held.
        if (Input.GetKey(KeyCode.Space))
        {
            ShootLaser();
        }

        // Check if rapid fire is over.
        if (isRapidFireActive && Time.time >= rapidFireEndTime)
        {
            DeactivateRapidFire();
        }
    }

    void ShootLaser()
    {
        // Check cooldown and ammo.
        if (!isRapidFireActive)
        {
            if (Time.time - lastShotTime < cooldownTime)
            {
                return;
            }
            if (currentAmmo <= 0)
            {
                return;
            }
        }
        // Only check rapid fire cooldown.
        else
        {
            if (Time.time - lastShotTime < cooldownTimeRapidFire)
            {
                return;
            }
        }

        // Spawn laser
        GameObject newObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        // Set laser velocity
        Mover mover = newObject.GetComponent<Mover>();
        if (mover)
        {
            mover.SetVelocity(velocityOfSpawnedObject);
        }

        lastShotTime = Time.time;

        // Decrease ammo only in normal mode
        if (!isRapidFireActive)
        {
            currentAmmo--;
        }

        // Setup score tracking
        DestroyOnTrigger2D destroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (destroyer && scoreField)
            destroyer.onHit += AddScore;
    }

    private void AddScore()
    {
        if (scoreField)
            scoreField.AddNumber(pointsToAdd);
    }

    // Start rapid fire mode
    public void ActivateRapidFire(float duration)
    {
        isRapidFireActive = true;
        rapidFireEndTime = Time.time + duration;

        if (rapidFireIndicator)
        {
            rapidFireIndicator.SetActive(true);
        }
    }

    // Stop rapid fire mode
    private void DeactivateRapidFire()
    {
        isRapidFireActive = false;

        if (rapidFireIndicator)
        {
            rapidFireIndicator.SetActive(false);
        }
    }

    public void ReloadAmmo()
    {
        currentAmmo = maxAmmo;
    }

    public int GetCurrentAmmo() => currentAmmo;
    public int GetMaxAmmo() => maxAmmo;
    public bool IsRapidFireActive() => isRapidFireActive;

    public float GetRapidFireTimeRemaining()
    {
        if (isRapidFireActive)
        {
            return Mathf.Max(0, rapidFireEndTime - Time.time);
        }
        return 0;
    }
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
    }
}