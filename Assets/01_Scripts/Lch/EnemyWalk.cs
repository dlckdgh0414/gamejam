using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyState<EnemyEnum>
{
    Vector2 dir;
    public EnemyWalk(EnemyAgent owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _agent.Movement.EnemyMove();
    }
}
