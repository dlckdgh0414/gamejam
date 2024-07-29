using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState<EnemyEnum>
{
    public EnemyIdle(EnemyAgent owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.Movement.StopMove(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        new WaitForSeconds(2f);
        _stateMachine.ChangeState(EnemyEnum.Walk);
    }
}
