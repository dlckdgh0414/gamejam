using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class AudioSpacktrum : MonoBehaviour
{
    public static AudioSpacktrum Instance;
    public float[] _samples;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    public float GetSpectrumAudioSource(int start, int end, int mult)
    {
        return _samples.ToList().GetRange(start, end).Average() * mult;
    }
}