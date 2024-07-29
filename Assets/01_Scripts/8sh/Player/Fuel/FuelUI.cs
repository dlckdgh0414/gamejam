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
        //������ ������ UI�� ���� ������ŭ ������ ��� �弼�� ^^
    }
}
