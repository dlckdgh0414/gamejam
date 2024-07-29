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
    public float rotationSpeed = 5f;
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
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // 이동 방향 설정
        Vector3 moveDirection = direction.normalized;

        // 2D 회전 처리 (Up 방향을 기준으로 회전)
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.up, moveDirection, singleStep, 0.0f);
        transform.up = newDirection;

        // 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

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
