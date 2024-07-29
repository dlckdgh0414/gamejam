using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelUI : MonoBehaviour
{
    public FuelHandler fuelHandler;
    private TextMeshProUGUI fuelText;
    private Image gage;

    private void OnEnable()
    {
        fuelText = GetComponent<TextMeshProUGUI>();
        gage = GetComponent<Image>();
        fuelHandler.OnFuelChanged += UpdateFuelGage;
    }

    public void UpdateFuelGage(int fuel)
    {
        fuelText.text = $"{fuelHandler.fuel}%";
        //여따가 게이지 UI에 현재 엔진만큼 게이지 깎아 드세용 ^^
    }
}
