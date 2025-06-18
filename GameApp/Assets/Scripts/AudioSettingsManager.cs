using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettingsManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider soundFXSlider;
    public Slider musicSlider;

    public TMP_Text masterVolumeValueText;
    public TMP_Text soundFXValueText;
    public TMP_Text musicValueText;

    private void Start()
    {
        // Initialize sliders with saved values if needed
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 100f);
        soundFXSlider.value = PlayerPrefs.GetFloat("SoundFX", 100f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 100f);

        // Update value displays
        UpdateValueDisplays();

        // Add listeners to sliders
        masterVolumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        soundFXSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        musicSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }


    public void ChangeVolume(){
    	AudioListener.volume = masterVolumeSlider.value*0.01f;
	OnSliderValueChanged();
    }

    private void OnSliderValueChanged()
    {
        // Update value displays
        UpdateValueDisplays();

        // Save values
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("SoundFX", soundFXSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);

        // Here, you would typically also set the volume in your audio mixer
        // Example: AudioMixer.SetFloat("MasterVolume", masterVolumeSlider.value / 100f);
    }

    private void UpdateValueDisplays()
    {
        masterVolumeValueText.text = masterVolumeSlider.value.ToString("0");
        soundFXValueText.text = soundFXSlider.value.ToString("0");
        musicValueText.text = musicSlider.value.ToString("0");
    }
}
