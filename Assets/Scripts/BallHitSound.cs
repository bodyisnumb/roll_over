using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    [Header("Звук удару")]
    [Tooltip("Звук, який грає при зіткненні")]
    public string hitSoundEvent = "Play_Fall"; // The name of the hit sound event in Wwise

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play fall sound when the ball collides with any object
        AkSoundEngine.PostEvent(hitSoundEvent, gameObject);
    }
}
