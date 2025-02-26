using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenuManager : MonoBehaviour
{
    [Header("Панелі меню")]
    public GameObject panelMainMenu;
    public GameObject panelLevelSelect;

    [Header("Кнопки")]
    public Button buttonPlay;
    public Button buttonSound;
    public Button buttonMusic;
    public Button buttonInfiniteLives;

    [Header("Налаштування іконок")]
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;

    private bool isSoundOn = true;
    private bool isMusicOn = true;

    void Start()
    {
        // Прив’язуємо обробники подій
        buttonPlay.onClick.AddListener(OnPlayClicked);
        buttonSound.onClick.AddListener(OnSoundClicked);
        buttonMusic.onClick.AddListener(OnMusicClicked);
        buttonInfiniteLives.onClick.AddListener(OnInfiniteLivesClicked);

        // За замовчуванням відображаємо головне меню
        panelMainMenu.SetActive(true);
        panelLevelSelect.SetActive(false);

        LoadSettings();
        UpdateSoundIcon();
        UpdateMusicIcon();
        Application.targetFrameRate = 60;
    }

    void OnPlayClicked()
    {
        // Вимикаємо головне меню, вмикаємо вибір рівнів
        panelMainMenu.SetActive(false);
        panelLevelSelect.SetActive(true);
    }

    void OnSoundClicked()
    {
        isSoundOn = !isSoundOn;
        UpdateSoundIcon();
        // Викликаємо ваш AudioManager, щоб вимкнути/ввімкнути звуки
        // AudioManager.instance.SetSFXMute(!isSoundOn);
        SaveSettings();
    }

    void OnMusicClicked()
    {
        isMusicOn = !isMusicOn;
        UpdateMusicIcon();
        // Викликаємо ваш AudioManager, щоб вимкнути/ввімкнути музику
        // AudioManager.instance.SetBGMMute(!isMusicOn);
        SaveSettings();
    }

    void OnInfiniteLivesClicked()
    {
        Debug.Log("Покупка безкінечних життів!");
        // Тут логіка IAP, якщо використовуєте Unity IAP
        // IAPManager.instance.BuyProductID("infinite_lives");
    }

    // Оновлення іконок
    void UpdateSoundIcon()
    {
        Image img = buttonSound.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = isSoundOn ? soundOnIcon : soundOffIcon;
        }
    }

    void UpdateMusicIcon()
    {
        Image img = buttonMusic.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = isMusicOn ? musicOnIcon : musicOffIcon;
        }
    }

    // Збереження налаштувань
    void SaveSettings()
    {
        PlayerPrefs.SetInt("SoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.SetInt("MusicOn", isMusicOn ? 1 : 0);
    }

    void LoadSettings()
    {
        isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
    }

    // Метод для кнопки "Назад" з панелі LevelSelect
    public void OnBackFromLevelSelect()
    {
        panelMainMenu.SetActive(true);
        panelLevelSelect.SetActive(false);
    }

    public void LoadLevel(string levelName)
{
    // Завантажуємо сцену рівня
    SceneManager.LoadScene(levelName);
}
}