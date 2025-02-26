using UnityEngine;

public class ballMovement : MonoBehaviour
{
    [Header("Параметри руху")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float rotationSpeed = 200f;

    [Header("Перевірка землі")]
    public Transform groundCheck; 
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Опції вводу")]
    public bool allowKeyboardInput = true;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float moveInput = 0f;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // Оновлюємо позицію groundCheck відносно шарика
        if (groundCheck != null)
        {
            groundCheck.position = (Vector2)transform.position + groundCheckOffset;
        }

        // Перевірка землі
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Клавіатурний ввід (для тесту)
        if (allowKeyboardInput)
        {
            moveInput = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
        }

        // Рух через UI-кнопки
        if (moveLeft)
        {
            moveInput = -1f;
        }
        else if (moveRight)
        {
            moveInput = 1f;
        }
        else if (!allowKeyboardInput)
        {
            moveInput = 0f;
        }
    }

    void FixedUpdate()
    {
        // Горизонтальний рух
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Обертання (тільки для візуального ефекту)
        float rotationAmount = moveInput * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(0f, 0f, -rotationAmount);
    }

    // Методи для UI-кнопок
    public void OnLeftButtonDown() => moveLeft = true;
    public void OnLeftButtonUp() => moveLeft = false;
    public void OnRightButtonDown() => moveRight = true;
    public void OnRightButtonUp() => moveRight = false;

    public void OnJumpButton()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // Візуалізація області перевірки землі в редакторі
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}