using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAgent : MonoBehaviour
{
   public EnemyMovement Movement { get; protected set; }
   public Animator AnimatorCopo { get; protected set; }

    public bool IsDie { get; protected set; }

    public bool CanStateChangeble { get; protected set; } = true;

    protected virtual void Awake()
    {
        Movement = GetComponent<EnemyMovement>();
        Movement.Initialize(this);

        AnimatorCopo = transform.Find("Visual").GetComponent<Animator>();
    }

    public abstract void SetDeadState();
}
