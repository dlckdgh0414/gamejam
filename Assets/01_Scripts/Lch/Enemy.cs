using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyEnum
{
    Idle,
    Walk,
    faint
}

public class Enemy : EnemyAgent
{
    public StateMachine<EnemyEnum> StateMachine { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        StateMachine = new StateMachine<EnemyEnum>();

        StateMachine.AddState(EnemyEnum.Idle, new EnemyIdle(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Walk, new EnemyWalk(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.faint, new EnemyFaint(this, StateMachine, "Idle"));

    }

    private void Start()
    {
        StateMachine.Init(EnemyEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        if (Movement._xMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Debug.Log(StateMachine.CurrentState);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
}
