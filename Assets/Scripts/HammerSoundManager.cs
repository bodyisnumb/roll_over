using UnityEngine;

public class HammerSoundManager : MonoBehaviour
{
    public AK.Wwise.Event playBladeEvent;  // Reference to the Play_Blade event

    private void Start()
    {
        // Make sure to check if the playBladeEvent is set
        if (playBladeEvent != null)
        {
            // Play the event from the Hammer GameObject
            playBladeEvent.Post(gameObject);
            Debug.Log("Play_Blade event triggered.");
        }
        else
        {
            Debug.LogError("Play_Blade event not assigned in the Inspector.");
        }
    }
}
