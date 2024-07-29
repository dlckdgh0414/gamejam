using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FuelScreenEffect : MonoBehaviour
{
    private FuelHandler fuelHandler;
    private Volume volume;

    [Header("Effects")]
    [SerializeField] private ChromaticAberration chromaticAberration;
    [SerializeField] private Vignette vignette;
    [SerializeField] private ColorAdjustments colorAdjustments;

    private void Start()
    {
        GetElements();
    }

    private void GetElements()
    {
        fuelHandler = GameObject.FindWithTag("Player").GetComponent<FuelHandler>();
        volume = GetComponent<Volume>();
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

        colorAdjustments.active = false;
        chromaticAberration.active = false;
        vignette.active = false;
    }

    private void ScreenEffect(int fuel)
    {
        if (fuel < 10)
        {
            colorAdjustments.active = true;
        }
        else if (fuel < 30)
        {
            vignette.active = true;
        }
        else if (fuelHandler.fuel < 50)
        {
            chromaticAberration.active = true;
        }
    }
}
