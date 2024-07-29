using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 moveDir { get; set; }

    private void Update()
    {
        GetMoveInput();
    }

    public void GetMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(x, y);
        moveDir.Normalize();
    }
}
