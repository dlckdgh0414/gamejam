using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySee : MonoBehaviour
{
    Vector3 moveDirection;
    public Transform[] waypoints;
    int currentWaypointIndex = 0;
    float moveSpeed = 2f;
    Vector3 direction;

    void Update()
    {
        EnemySeeR();
    }

    private void EnemySeeR()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        direction = targetWaypoint.position - transform.position;

        // �̵� ���� ����
        Vector3 moveDirection = direction.normalized;

        StartCoroutine(DelayTime());

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // ó�� ��������Ʈ�� ���ư���
            }
        }
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1F);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); // 2D ȸ������ Up ������ �������� ��
    }
}
