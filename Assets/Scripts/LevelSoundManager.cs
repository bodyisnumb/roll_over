using UnityEngine;
using AK.Wwise;

public class WwiseStartEvent : MonoBehaviour
{
    public string wwiseEventName = "Play_Start";
    public AK.Wwise.Bank soundBank; // Банк, содержащий событие

    void Start()
    {
        // Загружаем банк (если не загружен автоматически)
        soundBank.Load();

        // Проверяем, что событие существует
        uint eventId = AkSoundEngine.GetIDFromString(wwiseEventName);
        if (eventId != 0)
        {
            AkSoundEngine.PostEvent(wwiseEventName, gameObject);
        }
        else
        {
            Debug.LogError($"Wwise событие {wwiseEventName} не найдено! Проверьте SoundBanks.");
        }
    }
}