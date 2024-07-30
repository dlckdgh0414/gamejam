using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelUI : MonoBehaviour
{
    private FuelHandler fuelHandler;
    private TextMeshProUGUI fuelText;
    private Image battery;
    private int splitedFuel = 100;
    [SerializeField] private Sprite[] sprites = new Sprite[5];

    private void Start()
    {
        fuelHandler = GameObject.FindWithTag("Player").GetComponent<FuelHandler>();
        fuelText = GetComponentInChildren<TextMeshProUGUI>();
        battery = GetComponentInChildren<Image>();
        battery.sprite = sprites[3];
        splitedFuel = fuelHandler.maxFuel / 4;
        fuelHandler.OnFuelChanged += UpdateFuelGage;
        battery.sprite = sprites[4];
    }
    public void UpdateFuelGage(int fuel)
    {
        fuelText.text = $"{fuelHandler.fuel}%";
        switch (fuel)
        {
            case 5: battery.sprite = sprites[0]; break;
            case 25: battery.sprite = sprites[1]; break;
            case 50: battery.sprite = sprites[2]; break;
            case 75: battery.sprite = sprites[3]; break;
        }
    }
}
