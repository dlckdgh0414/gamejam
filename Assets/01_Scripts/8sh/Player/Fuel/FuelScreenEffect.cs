using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using TMPro;

public class FuelScreenEffect : MonoBehaviour
{
    private FuelHandler fuelHandler;
    private Volume volume;
    private new AudioSource audio;
    private TextMeshProUGUI requireChargingText;

    [Header("Effects")]
    [SerializeField] private ChromaticAberration chromaticAberration;
    [SerializeField] private Vignette vignette;
    [SerializeField] private ColorAdjustments colorAdjustments;
    [SerializeField] private WhiteBalance whitebalance;

    private void Start()
    {
        GetElements();
    }

    private void GetElements()
    {
        fuelHandler = GameObject.FindWithTag("Player").GetComponent<FuelHandler>();
        volume = GetComponent<Volume>();
        audio = GetComponent<AudioSource>();
        requireChargingText = GameObject.Find("Canvas/UI/Fuel/Notice").GetComponent<TextMeshProUGUI>();
        fuelHandler.OnFuelChanged += ScreenEffect;
        if (volume.profile.TryGet(out Vignette v))
        {
            vignette = v;
        }
        if (volume.profile.TryGet(out ColorAdjustments c2))
        {
            colorAdjustments = c2;
        }
        if (volume.profile.TryGet(out ChromaticAberration c))
        {
            chromaticAberration = c;
        }
        if (volume.profile.TryGet(out WhiteBalance w))
        {
            whitebalance = w;
        }

        colorAdjustments.active = false;
        chromaticAberration.active = false;
        vignette.active = false;
        whitebalance.active = false;
    }

    private void ScreenEffect(int fuel)
    {
        Color c = Color.white;
        c.a = 0;
        if (fuel == 10)
        {
            requireChargingText.color = Color.white;
            requireChargingText.DOColor(c, 3f);
            audio.Play();
            whitebalance.active = true;
            DOTween.To(() => 0, x => whitebalance.temperature.value = x, 100f, 2f);
            DOTween.To(() => 0, x => whitebalance.tint.value = x, -100, 2f);
        }
        else if (fuel == 30)
        {
            requireChargingText.color = Color.white;
            requireChargingText.DOColor(c, 3f);
            audio.Play();
            colorAdjustments.active = true;
            DOTween.To(() => 0, x => colorAdjustments.saturation.value = x, -65, 2f);
            vignette.active = true;
            DOTween.To(() => 0, x => vignette.intensity.value = x, 0.4f, 2f);
        }
        else if (fuelHandler.fuel == 50)
        {
            requireChargingText.color = Color.white;
            audio.Play();
            chromaticAberration.active = true;
            DOTween.To(() => 0, x => chromaticAberration.intensity.value = x, 0.2f, 2f);
        }
    }
}
