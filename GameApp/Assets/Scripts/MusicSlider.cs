using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //
    [SerializeField] Slider MusicVolumeSlider;
    void Start()
    {
        Load();
    }

    public void Changed()
    {
        if (AudioManagement.instance != null)
        {
            AudioManagement.instance.SetMusicVolume(MusicVolumeSlider.value);
        }
        Save();
    }

    private void Load()
    {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 100f);
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeSlider.value);
    }
    


}
