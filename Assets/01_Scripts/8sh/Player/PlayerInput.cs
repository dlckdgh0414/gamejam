using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnPressAttack;
    public Vector2 moveDir { get; set; }

    private void Update()
    {
        GetMoveInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPressAttack?.Invoke();
        }
    }

    public void GetMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(x, y);
        moveDir.Normalize();
    }
}
