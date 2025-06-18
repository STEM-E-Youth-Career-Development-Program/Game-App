using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //
    [SerializeField] Slider MasterVolumeSlider;
    void Start()
    {

    }

    public void Changed()
    {
        AudioListener.volume = MasterVolumeSlider.value*.01f;
        Save();
    }

    public void Load()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 100f);
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeSlider.value);
    }
    


}
