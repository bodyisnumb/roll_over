using UnityEngine;
using System.Collections;

public class pipeShooter : MonoBehaviour
{
    [Tooltip("Префаб проектилу, який вилітає з труби")]
    public GameObject projectilePrefab;

    [Tooltip("Точка, з якої вилітає проектиль (дитячий об'єкт труби)")]
    public Transform spawnPoint;

    [Tooltip("Інтервал між пострілами (в секундах)")]
    public float spawnInterval = 2f;

    [Tooltip("Початкова швидкість проектилу (вектор, задайте напрямок і величину)")]
    public Vector2 projectileVelocity = new Vector2(5f, 0f);

    void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnProjectile()
    {
        if (projectilePrefab != null && spawnPoint != null)
        {
            GameObject proj = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            // Додаємо початкову швидкість до проектилю через його Rigidbody2D
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.rotation * projectileVelocity;
            }
        }
    }
}