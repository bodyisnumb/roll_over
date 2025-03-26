using UnityEngine;
using UnityEngine.UI; // Required for UI Button

public class JumpButtonSound : MonoBehaviour
{
    // Reference to the UI Button in the scene
    public Button jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that the button is assigned
        if (jumpButton != null)
        {
            // Add a listener to the button's onClick event
            jumpButton.onClick.AddListener(PlayJumpSound);
        }
        else
        {
            Debug.LogError("JumpButton is not assigned in the inspector.");
        }
    }

    // This function will be called when the button is pressed
    private void PlayJumpSound()
    {
        // Log to verify that the method is triggered
        Debug.Log("Jump Button Pressed - Playing Jump Sound");

        // Post the event to play the jump sound
        AkSoundEngine.PostEvent("Play_Jump", gameObject);
    }
}
