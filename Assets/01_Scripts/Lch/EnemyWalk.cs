using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyState<EnemyEnum>
{
    Vector2 dir;
    public EnemyWalk(EnemySetting owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.StartCoroutine(Delaytime());
    }

    private IEnumerator Delaytime()
    {
        dir = _agent.GetRandomVector() - _agent.transform.position;
        yield return new WaitForSeconds(2f);

    }

    public override void Exit()
    {
        base.Exit();
        _agent.Movement.SetMovement(dir.normalized.x, dir.normalized.y);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
