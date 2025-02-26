using UnityEngine;

public class timedDestroy : MonoBehaviour
{
    // Час у секундах, після якого об'єкт буде знищено
    public float lifetime = 5f;

    void Start()
    {
        // Викликаємо Destroy через 'lifetime' секунд
        Destroy(gameObject, lifetime);
    }
}