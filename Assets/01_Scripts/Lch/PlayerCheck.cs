using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheck : MonoBehaviour
{
    public EnemySetting _enemy;

    public UnityEvent PlayerDaedEvent;

    private float _dlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !_enemy.IsDie)
        {
            _dlay = 0.5f;
            StartCoroutine(DelayTime(_dlay));
        }
    }

    private IEnumerator DelayTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _enemy.GetPlayerEvent?.Invoke();
    }
}
