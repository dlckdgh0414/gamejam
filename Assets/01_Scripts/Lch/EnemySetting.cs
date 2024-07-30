using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public abstract class EnemySetting : EnemyAgent
{

    public UnityEvent OnDeadEvent;

    public UnityEvent GetPlayerEvent;

    public UnityEvent GetAttackEvenet;

    public GameObject _light2D;

    public AudioSource _SFX;

    public Transform[] waypoints;
    public int currentWaypointIndex = 0;

    public abstract void AnimationEndTrigger();

    public void SetDead(bool value)
    {
        IsDie = value;
        CanStateChangeble = !value;
    }

}
