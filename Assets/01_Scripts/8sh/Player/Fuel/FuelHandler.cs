using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelHandler : MonoBehaviour
{
    public event Action<int> OnFuelChanged;
    public UnityEvent OnDead;
    private PlayerState playerState;

    [Header("Values")]
    public bool active = true;
    public int fuel;
    public int maxFuel = 100;

    [Header("Rates")]
    public float decreasePerSeconds = 1f;
    public int decreaseAmount = 1;
    private WaitForSecondsRealtime waitForSecondsRealtime;

    private void Awake()
    {
        waitForSecondsRealtime = new WaitForSecondsRealtime(decreasePerSeconds);
        fuel = maxFuel;
        playerState = GetComponent<PlayerState>();
        StartCoroutine(DecreaseFuel(fuel));

    }

    public void ChangeFuelDecreasePerSeconds(float time)
    {
        waitForSecondsRealtime.waitTime = time;
    }

    private IEnumerator DecreaseFuel(int _fuel)
    {
        if (!(fuel - decreaseAmount < 0) && active)
        {
            fuel -= decreaseAmount;
            OnFuelChanged?.Invoke(fuel);
            if (fuel <= 5)
            {
                waitForSecondsRealtime.waitTime *= 1.5f;
            }
            yield return waitForSecondsRealtime;
            StartCoroutine(DecreaseFuel(fuel));
        }else
        {
            fuel = 0;
            OnFuelChanged?.Invoke(fuel);
            active = false;
            OnDead?.Invoke();
            playerState.Death();
        }
    }
}
