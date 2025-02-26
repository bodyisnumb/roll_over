using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Припускаємо, що DeathScript знаходиться на тому ж об'єкті, з яким відбувається зіткнення.
        ballDeath bd = other.GetComponent<ballDeath>();
        if (bd != null && !activated)
        {
            activated = true;
            // Встановлюємо нову точку респавну у DeathScript
            bd.respawnPoint = this.transform;

            // Робимо чекпоінт невидимим (просто вимикаємо SpriteRenderer)
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = false;
            }
            // Якщо бажаєте, можна і повністю відключити чекпоінт:
             gameObject.SetActive(false);
        }
    }
}