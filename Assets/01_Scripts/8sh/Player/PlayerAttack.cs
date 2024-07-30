using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float detectRange = 3;
    [SerializeField] private LayerMask targetLayer;
    public bool canAttack = false;

    private Collider2D target { get; set; } = null;

    private void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().OnPressAttack += Attack;
    }

    private void Update()
    {
        DetectEnemy();
    }

    private void DetectEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectRange, targetLayer);

        foreach (Collider2D collider in colliders)
        {
            print("°¨Áö");
            canAttack = true;
            target = collider;
        }
    }

    public void Attack()
    {
        if (canAttack && target)
        {
            canAttack = false;
            transform.position = target.transform.position;
            target.transform.GetComponent<EnemySetting>().OnDeadEvent?.Invoke();
            Destroy(target.transform.Find("Head").gameObject);
            target.transform.GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<AudioSource>().Play();
        }
    }
}
