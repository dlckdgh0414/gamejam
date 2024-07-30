using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Check : MonoBehaviour
{
    public EnemySetting _enemy;
    [SerializeField] private GameObject fire;
    [SerializeField] private float _dlay;

    public Light2D lightSource;
    public Transform player;
    public LayerMask wallLayer;
    public LayerMask playerLayer;

    private void Update()
    {
        Vector3 directionToPlayer = player.position - lightSource.transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer <= lightSource.pointLightOuterRadius)
        {
            RaycastHit2D hit = Physics2D.Raycast(lightSource.transform.position, directionToPlayer, distanceToPlayer, wallLayer);
            if (hit.collider == null)
            {
                Collider2D playerCollider = Physics2D.OverlapCircle(player.position, 0.1f, playerLayer);
                if (playerCollider != null)
                {
                    Debug.Log("Player is visible.");

                    if (!_enemy.IsDie)
                    {
                        StartCoroutine(DelayTime(_dlay));
                    }
                }
            }
        }
    }

    private IEnumerator DelayTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Vector3 directionToPlayer = player.position - lightSource.transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer <= lightSource.pointLightOuterRadius)
        {
            RaycastHit2D hit = Physics2D.Raycast(lightSource.transform.position, directionToPlayer, distanceToPlayer, wallLayer);
            if (hit.collider == null)
            {
                Collider2D playerCollider = Physics2D.OverlapCircle(player.position, 0.1f, playerLayer);
                if (playerCollider != null)
                {
                    Debug.Log("Player is visible.");

                    if (!_enemy.IsDie)
                    {
                        fire.SetActive(true);
                        _enemy.GetPlayerEvent?.Invoke();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (lightSource != null && player != null)
        {
            Gizmos.color = Color.red;
            Vector3 directionToPlayer = player.position - lightSource.transform.position;
            Gizmos.DrawRay(lightSource.transform.position, directionToPlayer);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(player.position, 0.1f);
        }
    }
}
