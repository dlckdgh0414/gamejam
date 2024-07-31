using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnAttackInput;
    public event Action OnDashInput;
    public Vector2 moveDir { get; set; }

    private void Awake()
    {
        moveComp = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        GetMoveInput();
        GetInputs();
    }

    public void GetMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(x, y);
        moveDir.Normalize();
    }

    private void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnAttackInput?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnDashInput?.Invoke();
        }
    }
}
