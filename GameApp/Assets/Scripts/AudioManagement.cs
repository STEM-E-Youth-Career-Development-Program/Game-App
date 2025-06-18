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
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume")*0.01f;
    }
}
