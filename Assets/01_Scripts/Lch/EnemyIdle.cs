using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState<EnemyEnum>
{
    public EnemyIdle(EnemySetting owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.Movement.StopMove(true);
        _agent.StartCoroutine(MoveDelay());
    }

    private IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(1f);
        _stateMachine.ChangeState(EnemyEnum.Walk);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
