using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    private EnemyAgent _owner;
    public Rigidbody2D rbcompo { get; private set; }
    public float _xMove;
    public float _yMove;
    protected bool _canMove = true;
    public bool CanStateChangeble { get; protected set; } = true;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public void Initialize(EnemyAgent agent)
    {
        _owner = agent;
        rbcompo = GetComponent<Rigidbody2D>();
    }

    public void StopMove(bool isYstop = false)
    {
        if (isYstop)
        {
            rbcompo.velocity = Vector2.zero;
        }
    }

    public void EnemyMove()
    {
        if (waypoints.Length == 0) return;

        // ���� ��ǥ ��������Ʈ
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        // ��ǥ ��������Ʈ���� ���� ���
        Vector3 direction = targetWaypoint.position - transform.position;
        // �̵�
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // ��������Ʈ�� �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // ������ ��������Ʈ�� �����ϸ� ó������ ���ư���
            }
        }
    }
}
