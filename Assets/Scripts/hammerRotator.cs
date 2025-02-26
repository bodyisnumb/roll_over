using UnityEngine;

public class hammerRotator : MonoBehaviour
{
    [Tooltip("Швидкість обертання молота (в градусах за секунду)")]
    public float rotationSpeed = 90f;

    void Update()
    {
        // Обертаємо весь об'єкт навколо Z-осі (2D)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}