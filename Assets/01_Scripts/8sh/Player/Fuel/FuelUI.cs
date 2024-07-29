using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FuelUI : MonoBehaviour
{
    public FuelHandler fuelHandler;
    private Image gage;

    private void OnEnable()
    {
        gage = GetComponent<Image>();
        fuelHandler.OnFuelChanged += UpdateFuelGage;
    }


    public void UpdateFuelGage(int fuel)
    {
        float fillAmount = (fuelHandler.maxFuel / fuel) / 100;
        print(fuel);
        print(fillAmount);
        DOTween.To(() => gage.fillAmount, x => gage.fillAmount = x, fillAmount, 0.25f);
    }
}
