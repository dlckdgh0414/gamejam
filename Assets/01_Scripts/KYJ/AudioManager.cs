using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource sfxSource;

    public void MusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }


    public void OnSfx()
    {
        sfxSource.Play();
    }
}
