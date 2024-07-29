using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAgent : MonoBehaviour
{
   public EnemyMovemt Movement { get; protected set; }
   public Animator Animator { get; protected set; }

    public bool IsDie { get; protected set; }

    protected virtual void Awake()
    {
        Movement = GetComponent<EnemyMovemt>();
        Movement.Initialize(this);

        Animator = transform.Find("Visual").GetComponent<Animator>();
    }
}
