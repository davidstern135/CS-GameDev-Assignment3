using UnityEngine;

/**
 * Makes enemies drop ammo.
 */
public class EnemyAmmoDrop : MonoBehaviour
{
    [Header("Drop Settings")]
    [SerializeField] GameObject ammoPickup;
    [SerializeField][Range(0f, 1f)] float dropChance = 0.2f;

    private void OnDestroy()
    {
        // Random chance to drop ammo
        if (ammoPickup != null && Random.value <= dropChance)
        {
            Instantiate(ammoPickup, transform.position, Quaternion.identity);
        }
    }

    public void SetAmmoPickup(GameObject prefab)
    {
        ammoPickup = prefab;
    }
}