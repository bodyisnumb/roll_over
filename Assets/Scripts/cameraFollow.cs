using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [Header("Ціль для слідкування")]
    public Transform target;

    [Header("Налаштування камери")]
    [Tooltip("Відстань від цілі (зсув). Наприклад, (0, 0, -10) для 2D-камери")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    [Tooltip("Час згладжування руху камери")]
    public float smoothTime = 0.3f;
    [Tooltip("Максимальна швидкість руху камери")]
    public float maxSpeed = 50f;

    // Внутрішня змінна для зберігання поточної швидкості (не редагується)
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Обчислюємо бажану позицію камери, додаючи offset до позиції цілі
        Vector3 targetPosition = target.position + offset;

        // Плавно переміщуємо камеру від поточної позиції до бажаної позиції
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, maxSpeed);
    }
}
