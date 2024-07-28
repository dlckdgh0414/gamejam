using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FuelUI : MonoBehaviour
{
    public FuelHandler fuelHandler;
    public Image gage;

    private void Start()
    {
        if (fuelHandler != null)
        {
            fuelHandler.OnFuelChanged += UpdateFuelGage;
        }
    }

    private void UpdateFuelGage(int currentFuel)
    {
        float fillAmount = Mathf.Lerp(0, fuelHandler.maxFuel, currentFuel);
        DOTween.To(() => gage.fillAmount, x => gage.fillAmount = x, fillAmount, 0.25f);
    }
}
