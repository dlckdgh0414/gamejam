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

        // �̵� ���� ����
        Vector3 moveDirection = direction.normalized;

        // �̵�
        transform.position += moveDirection *Movement.moveSpeed * Time.deltaTime;

        // ��������Ʈ�� �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // ó�� ��������Ʈ�� ���ư���
            }
        }
    }
}
