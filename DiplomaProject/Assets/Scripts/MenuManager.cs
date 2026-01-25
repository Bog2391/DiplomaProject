using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button optionMenu;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button Level1;
    [SerializeField] private Button Level2;
    [SerializeField] private Button Level3;

    [Header("Others")]
    [SerializeField] private GameObject optionsPanel;

    [Header("UI")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource buttonClickAudioSource;
    [SerializeField] private AudioClip buttonClickSound;
    private const string PrefMusVolume = "pref_music_volume";
    private const string PrefSfxVolume = "pref_sfx_volume";

    void Start()
    {
        float savedMusicVol = PlayerPrefs.HasKey(PrefMusVolume) ? PlayerPrefs.GetFloat(PrefMusVolume) : 1f;
        float savedSfxVol = PlayerPrefs.HasKey(PrefSfxVolume) ? PlayerPrefs.GetFloat(PrefSfxVolume) : 1f;

        ApplyMusicVolume(savedMusicVol, applyToSlider: false);
        ApplySFXVolume(savedSfxVol, applyToSlider: false);

        optionMenu.onClick.AddListener(() => OnButtonClicked(OnOptionsClicked));
        quitButton.onClick.AddListener(() => OnButtonClicked(OnExitClicked));

        if (musicVolumeSlider != null && sfxVolumeSlider != null)
        {
            musicVolumeSlider.value = savedMusicVol;
            musicVolumeSlider.onValueChanged.AddListener(ApplyMusicVolume);
            sfxVolumeSlider.value = savedSfxVol;
            sfxVolumeSlider.onValueChanged.AddListener(ApplySFXVolume);
        }

        if (buttonClickAudioSource == null)
        {
            buttonClickAudioSource = GetComponent<AudioSource>();

            if (buttonClickAudioSource == null)
            {
                buttonClickAudioSource = gameObject.AddComponent<AudioSource>();
                buttonClickAudioSource.playOnAwake = false;
            }
        }
    }

    private void OnButtonClicked(System.Action buttonAction)
    {
        PlayButtonClickSound();
        buttonAction?.Invoke();
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickAudioSource != null && buttonClickSound != null)
        {
            buttonClickAudioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnOptionsClicked()
    {
        optionsPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.RemoveListener(ApplyMusicVolume);

        if (sfxVolumeSlider != null)
            sfxVolumeSlider.onValueChanged.RemoveListener(ApplySFXVolume);
        
    }

    public void ApplyMusicVolume(float value)
    {
        ApplyMusicVolume(value, applyToSlider: true);
    }

    public void ApplySFXVolume(float value)
    {
        ApplySFXVolume(value, applyToSlider: true);
    }

    private void ApplyMusicVolume(float value, bool applyToSlider)
    {
        PlayerPrefs.SetFloat(PrefMusVolume, value);

        if (audioMixer != null)
        {
            float dB = Mathf.Log10(value) * 20;
            audioMixer.SetFloat("Music", dB);
        }

        if (applyToSlider && musicVolumeSlider != null && musicVolumeSlider.value != value)
            musicVolumeSlider.value = value;

        PlayerPrefs.Save();
    }

    private void ApplySFXVolume(float value, bool applyToSlider)
    {
        PlayerPrefs.SetFloat(PrefSfxVolume, value);

        if (audioMixer != null)
        {
            float dB = Mathf.Log10(value) * 20;
            audioMixer.SetFloat("SFX", dB);
        }

        if (applyToSlider && sfxVolumeSlider != null && sfxVolumeSlider.value != value)
            sfxVolumeSlider.value = value;

        PlayerPrefs.Save();
    }

}
