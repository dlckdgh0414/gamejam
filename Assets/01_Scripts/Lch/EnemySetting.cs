using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySetting : EnemyAgent
{
    public float minX, maxX;
    public float minY, maxY;

    public bool CanStateChangeble { get; protected set; } = true;

    protected override void Awake()
    {
        base.Awake();
    }

    public Vector3 GetRandomVector()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 vec = new Vector3(x, y);
        return vec;
    }
    public abstract void AnimationEndTrigger();
}
