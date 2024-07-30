using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    [SerializeField] private List<Transform> objReactbass, objReactNB, objReactMiddles, objReactHight;
    [SerializeField] private float maxScale;
    [SerializeField] private float width;

    private AudioSpacktrum _audioSpacktrum;

    private void Awake()
    {
        _audioSpacktrum = new AudioSpacktrum();
    }

    private void FixedUpdate()
    {
        MakeSpacktrum();
    }

    private void MakeSpacktrum()
    {
        foreach (Transform obj in objReactbass)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(width,
                AudioSpacktrum.Instance.GetSpectrumAudioSource(0, 7, 10), 1), maxScale);
        }

        foreach (Transform obj in objReactNB)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(width,
                AudioSpacktrum.Instance.GetSpectrumAudioSource(7, 15, 100), 1), maxScale);
        }

        foreach (Transform obj in objReactMiddles)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(width,
                AudioSpacktrum.Instance.GetSpectrumAudioSource(15, 30, 200), 1), maxScale);
        }

        foreach (Transform obj in objReactHight)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(width,
                AudioSpacktrum.Instance.GetSpectrumAudioSource(30, 32, 2000), 1), maxScale);
        }
    }
}
