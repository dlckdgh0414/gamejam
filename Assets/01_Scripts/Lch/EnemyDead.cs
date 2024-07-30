using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EnemyState<EnemyEnum>
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadEnemy");
    private bool _onExplosion = false;
    public EnemyDead(EnemySetting owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.gameObject.layer = _deadLayer;
        _agent.Movement.StopMove();
        _agent.SetDead(true);
        _onExplosion = false;
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
