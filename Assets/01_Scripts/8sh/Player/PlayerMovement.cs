using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rigidbody2d;
    private FuelHandler fuelHandler;

    [Header("Setting")]
    public float speed = 3;
    [SerializeField] private float maxSpeed;

    [Header("State")]
    public bool active = true;
    public bool moving = false;

    private float h;
    private float v;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        fuelHandler = GetComponent<FuelHandler>();

        maxSpeed = speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetSpeed()
    {
        if (fuelHandler.fuel < 10)
        {
            speed = maxSpeed;
        }else if (fuelHandler.fuel < 30)
        {
            speed = maxSpeed - (maxSpeed / 4);
        }
        else if (fuelHandler.fuel < 50)
        {
            speed = maxSpeed - (maxSpeed / 2);
        }
    }

    private void Move()
    {
        SetSpeed();
        rigidbody2d.velocity = playerInput.moveDir * speed;
    }
}