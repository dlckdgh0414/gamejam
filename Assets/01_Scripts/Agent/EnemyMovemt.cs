using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemt : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    private EnemyAgent _owner;
    public Rigidbody2D rbcompo { get; private set; }
    public float _xMove;
    public float _yMove;
    protected bool _canMove = true;

    public void Initialize(EnemyAgent agent)
    {
        _owner = agent;
        rbcompo = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(float xMove, float yMove)
    {
        _xMove = xMove;
        _yMove = yMove;
    }

    public void StopMove(bool isYstop = false)
    {
        _xMove = 0;
        _yMove = 0;
        if (isYstop)
        {
            rbcompo.velocity = Vector2.zero;
        }
        else
        {
            rbcompo.velocity = new Vector2(_xMove, _yMove);
        }
    }

    private void FixedUpdate()
    {
        XYMovement();
    }

    private void XYMovement()
    {
        if (_canMove == false) return;

        rbcompo.velocity = new Vector2(_xMove, _yMove) * moveSpeed;
    }
}
