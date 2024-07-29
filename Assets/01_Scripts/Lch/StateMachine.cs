using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : Enum
{
    public Dictionary<T, EnemyState<T>> stateDict = new Dictionary<T, EnemyState<T>>();
    public EnemyState<T> CurrentState { get; private set; }
    private EnemyAgent _agnet;

    public void Init(T state, EnemyAgent agent)
    {
        _agnet = agent;
        CurrentState = stateDict[state];
        CurrentState.Enter();
    }

    public void ChangeState(T changeState)
    {
        CurrentState.Exit();
        CurrentState = stateDict[changeState];
        CurrentState.Enter();
    }
    public void AddState(T stateEnum, EnemyState<T> state)
    {
        stateDict.Add(stateEnum, state);
    }
}

