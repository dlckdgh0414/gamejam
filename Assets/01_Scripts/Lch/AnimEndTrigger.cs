using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEndTrigger : MonoBehaviour
{
    [SerializeField] private EnemyStateAdd _enemy;

    public void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
}
