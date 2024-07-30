using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Check : MonoBehaviour
{
    public EnemySetting _enemy;
    [SerializeField] private GameObject fire;
    [SerializeField] private float _dlay;

    public Transform player;
    public LayerMask wallLayer;
    private Light2D light2D;

    private bool active = true;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (IsPlayerInLight() && !IsPlayerBlockedByWall() && active)
        {
            active = false;
            Debug.Log("Player is in the light and not blocked by a wall.");
            StartCoroutine(DelayTime(_dlay));
        }
    }

    bool IsPlayerInLight()
    {
        // 플레이어 위치가 라이트 범위 안에 있는지 확인
        Vector2 playerPos = player.position;
        Vector2 lightPos = transform.position;
        float lightRadius = light2D.pointLightOuterRadius;
        float distanceToPlayer = Vector2.Distance(lightPos, playerPos);

        if (distanceToPlayer > lightRadius)
        {
            return false;
        }

        Vector2 directionToPlayer = (playerPos - lightPos).normalized;
        float lightAngle = Vector2.Angle(light2D.transform.up, directionToPlayer);

        if (lightAngle <= light2D.pointLightOuterAngle / 2f)
        {
            return true;
        }

        return false;
    }

    bool IsPlayerBlockedByWall()
    {
        Vector2 direction = player.position - transform.position;
        float distance = Vector2.Distance(transform.position, player.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, wallLayer);
        return hit.collider != null;
    }

    private IEnumerator DelayTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (IsPlayerInLight() && !IsPlayerBlockedByWall())
        {
            Debug.Log("죽어랑");
            if (!_enemy.IsDie)
            {
                fire.SetActive(true);
                _enemy.GetPlayerEvent?.Invoke();
            }
        }else
        {
            active = true;
        }
    }
}
