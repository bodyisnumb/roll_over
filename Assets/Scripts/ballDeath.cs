using UnityEngine;
using System.Collections;

public class ballDeath : MonoBehaviour
{
    [Header("Респавн")]
    [Tooltip("Точка респавну (або чекпоінт)")]
    public Transform respawnPoint;
    [Tooltip("Затримка перед респавном (секунди)")]
    public float respawnDelay = 1f;

    [Header("Ефект смерті")]
    [Tooltip("Префаб з частинками (ефект вибуху)")]
    public GameObject deathEffectPrefab;

    private bool isDead = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private TrailRenderer tr;  // якщо у вас використовується Trail Renderer

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();

        // Якщо точка респавну не вказана, створюємо тимчасову на позиції батьківського об'єкта
        if (respawnPoint == null && transform.parent != null)
        {
            GameObject temp = new GameObject("RespawnPoint");
            temp.transform.position = transform.parent.position;
            respawnPoint = temp.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Die();
        }
    }

public    void Die()
    {
        if (isDead)
            return;

        isDead = true;

        // Запускаємо ефект смерті (вибух)
        if (deathEffectPrefab != null)
        {
            GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
                Destroy(effect, ps.main.duration);
            else
                Destroy(effect, 2f);
        }

        // Вимикаємо відображення шарика
        if (sr != null)
            sr.enabled = false;
        // Вимикаємо колайдер, щоб уникнути повторних зіткнень
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // Вимикаємо фізичну симуляцію, щоб шарик не падав
        if (rb != null)
            rb.simulated = false;

        // Вимикаємо трейл, якщо він є
        if (tr != null)
            tr.enabled = false;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        // Переміщаємо весь батьківський контейнер (Player) до точки респавну
        if (transform.parent != null && respawnPoint != null)
        {
            transform.parent.position = respawnPoint.position;
            transform.parent.rotation = Quaternion.identity;
        }
        // Скидаємо локальні координати та обертання шарика
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Вмикаємо фізику знову
        if (rb != null)
        {
            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
        }
        // Вмикаємо знову відображення
        if (sr != null)
            sr.enabled = true;
        // Вмикаємо колайдер
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = true;
        // Очищаємо та вмикаємо трейл, щоб старий слід зник
        if (tr != null)
        {
            tr.Clear();
            tr.enabled = true;
        }

        isDead = false;
    }
}