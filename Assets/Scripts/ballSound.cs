using UnityEngine;
using AK.Wwise;

public class BallSoundManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Mathf.Abs(rb.velocity.x) < 0.05f)
            {
                isGrounded = false;
                AkSoundEngine.SetState("Rollinnotrollin", "Notrollin");
            }
        }
    }

    private void Update()
    {
        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.05f)
        {
            AkSoundEngine.SetState("Rollinnotrollin", "Rollin");
        }
        else
        {
            AkSoundEngine.SetState("Rollinnotrollin", "Notrollin");
        }
    }
}