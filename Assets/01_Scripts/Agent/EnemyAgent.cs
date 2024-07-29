using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAgent : MonoBehaviour
{
   public EnemyMovement Movement { get; protected set; }
   public Animator Animator { get; protected set; }

    public bool IsDie { get; protected set; }

    protected virtual void Awake()
    {
        Movement = GetComponent<EnemyMovement>();
        Movement.Initialize(this);

        Animator = transform.Find("Visual").GetComponent<Animator>();
    }

    public abstract void AnimationEndTrigger();
}
