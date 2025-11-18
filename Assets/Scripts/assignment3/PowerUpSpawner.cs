using UnityEngine;

/**
 * Spawns a power-up once at game start.
 */
public class PowerUpSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] GameObject powerUpPrefab;

    [Header("Spawn Position")]
    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    //[SerializeField] bool useRandomPosition = true;
    //[SerializeField] float maxXDistance = 8f;
    //[SerializeField] float maxYDistance = 4f;

    void Start()
    {
        if (powerUpPrefab != null)
        {
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    { 
         Vector3 finalPosition;

        finalPosition = spawnPosition;
        

        // Create power-up
        Instantiate(powerUpPrefab, finalPosition, Quaternion.identity);
    }
}