using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float detectRange = 3;
    void Start()
    {
        
    }

    private void DetectEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {

            }
        }
    }
}
