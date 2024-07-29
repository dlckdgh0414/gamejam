using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemySetting : EnemyAgent
{

    public UnityEvent OnDeadEvent;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public abstract void AnimationEndTrigger();

    public void SetDead(bool value)
    {
        IsDie = value;
        CanStateChangeble = !value;
    }

    public void EnemyMove()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // 이동 방향 설정
        Vector3 moveDirection = direction.normalized;

        // 이동
        transform.position += moveDirection *Movement.moveSpeed * Time.deltaTime;

        // 웨이포인트에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // 처음 웨이포인트로 돌아가기
            }
        }
    }
}
