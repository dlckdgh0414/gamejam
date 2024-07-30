using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyState<EnemyEnum>
{
    Vector3 moveDirection;
    public EnemyWalk(EnemySetting owner, StateMachine<EnemyEnum> state, string animHashName) : base(owner, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        EnemyMove();
        _agent.AnimatorCopo.SetFloat("moveX",moveDirection.x);
        _agent.AnimatorCopo.SetFloat("moveY",moveDirection.y);
    }

    private void EnemyMove()
    {

            Transform targetWaypoint =_agent.waypoints[_agent.currentWaypointIndex];
            Vector3 direction = targetWaypoint.position - _agent.transform.position;

            // �̵� ���� ����
           moveDirection = direction.normalized;
            // �̵�
            _agent.transform.position += moveDirection *_agent.Movement.moveSpeed * Time.deltaTime;

            // ��������Ʈ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(_agent.transform.position, targetWaypoint.position) < 0.1f)
            {
               _agent.currentWaypointIndex++;
                if (_agent.currentWaypointIndex >= _agent.waypoints.Length)
                {
                    _agent.currentWaypointIndex = 0; // ó�� ��������Ʈ�� ���ư���
             }
            _stateMachine.ChangeState(EnemyEnum.Idle);
        }
    }
}
