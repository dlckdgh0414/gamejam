using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaint : EnemyState<EnemyEnum>
{
    public EnemyFaint(EnemyAgent owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
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
    }
}
