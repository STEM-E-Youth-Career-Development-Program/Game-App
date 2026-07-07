using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //
    [SerializeField] Slider sfxSlider;
    void Start()
    {
        Load();
    }

    public void Changed()
    {
        if (AudioManagement.instance != null)
        {
            AudioManagement.instance.SetSFXVolume(sfxSlider.value);
        }
        Save();
    }

    private void Load()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 100f);
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
    }
    


}
