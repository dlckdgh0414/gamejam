using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaint : EnemyState<EnemyEnum>
{
    public EnemyFaint(EnemySetting owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }
}
