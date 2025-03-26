using UnityEngine;
using UnityEngine.UI;

public class MenuButtonSounds : MonoBehaviour
{
    public AK.Wwise.Event playUIEvent; // Drag "Play_UI" here in Inspector
    public Button[] buttons; // Drag all four buttons here

    private void Start()
    {
        // Add listener to each button
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        if (playUIEvent != null)
        {
            playUIEvent.Post(gameObject); // Play "Play_UI" sound
        }
        else
        {
            Debug.LogWarning("Play_UI event not assigned!");
        }
    }
}
