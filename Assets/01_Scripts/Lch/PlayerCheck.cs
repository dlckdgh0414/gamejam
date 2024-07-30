using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public EnemySetting _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DelayTime());
        }
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        _enemy.GetPlayerEvent?.Invoke();
    }
}
