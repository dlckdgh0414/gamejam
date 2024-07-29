using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyEnum
{
    Idle,
    Walk,
    Dead
}

public class Enemy : EnemySetting
{
    public StateMachine<EnemyEnum> StateMachine { get; private set; }

    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyEnum.Dead);
    }

    public int EnemyCount;
    protected override void Awake()
    {
        base.Awake();

        StateMachine = new StateMachine<EnemyEnum>();

        StateMachine.AddState(EnemyEnum.Idle, new EnemyIdle(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Walk, new EnemyWalk(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyEnum.Dead, new EnemyFaint(this, StateMachine, "Dead"));

    }

    private void Start()
    {
        StateMachine.Init(EnemyEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        Debug.Log(StateMachine.CurrentState);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
}
