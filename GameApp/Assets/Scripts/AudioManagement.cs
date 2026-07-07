using System;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public static AudioManagement instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] AudioSource BGMusicSource, SFXSource;

    public AudioClip bg, click;

    private void Start()
    {
        BGMusicSource.clip = bg;
        BGMusicSource.Play();
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 100f) * .01f;
        BGMusicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 100f) * .01f;
        SFXSource.volume = PlayerPrefs.GetFloat("SFXVolume", 100f) * .01f;
    }

    public void SetMusicVolume(float value)
    {
        BGMusicSource.volume = value * .01f;
    }

    public void SetSFXVolume(float value)
    {
        SFXSource.volume = value * .01f;
    }

    public void PlayClick()
    {
        SFXSource.PlayOneShot(click);
    }

}
