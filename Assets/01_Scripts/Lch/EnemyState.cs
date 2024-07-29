using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EnemyState<T> where T : Enum
{
    protected EnemySetting _agent;
    protected int _animBoolHash;
    protected StateMachine<T> _stateMachine;
    protected bool _endTriggerCalled;

    public EnemyState(EnemySetting owner, StateMachine<T> state, string animHashName)
    {
        _agent = owner;
        _stateMachine = state;
        _animBoolHash = Animator.StringToHash(animHashName);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Enter()
    {
        _agent.Animator.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _agent.Animator.SetBool(_animBoolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
