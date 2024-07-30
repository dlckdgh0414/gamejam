using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rigidbody2d;
    private FuelHandler fuelHandler;

    [Header("Setting")]
    public float speed = 3;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float dashCooldown = 2;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashPower = 10;
    [SerializeField] private AudioSource dashAudio;

    [Header("State")]
    public bool active = true;
    public bool moving = false;
    private bool dashable = true;
    private bool isDashing = false;

    private WaitForSecondsRealtime dashCooldownWFSR;
    private WaitForSecondsRealtime dashDurationWFSR;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        fuelHandler = GetComponent<FuelHandler>();

        playerInput.OnDashInput += Dash;
        maxSpeed = speed;

        dashCooldownWFSR = new WaitForSecondsRealtime(dashCooldown);
        dashDurationWFSR = new WaitForSecondsRealtime(dashDuration);
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            Move();
        }
    }

    private void SetSpeed()
    {
        if (fuelHandler.fuel < 10)
        {
            speed = maxSpeed / 2;
        }
        else if (fuelHandler.fuel < 30)
        {
            speed = maxSpeed - (maxSpeed / 3);
        }
        else if (fuelHandler.fuel < 50)
        {
            speed = maxSpeed - (maxSpeed / 4);
        }
    }

    private void Move()
    {
        if (playerInput.moveDir != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        SetSpeed();
        rigidbody2d.velocity = playerInput.moveDir * speed;
    }

    private void Dash()
    {
        if (dashable)
        {
            dashable = false;
            isDashing = true;
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        Vector2 dashDirection = playerInput.moveDir;
        rigidbody2d.velocity = dashDirection * dashPower;
        dashAudio.Play();

        yield return dashDurationWFSR;

        isDashing = false;

        rigidbody2d.velocity = playerInput.moveDir * speed;

        // 대쉬 쿨다운 시작
        yield return dashCooldownWFSR;
        dashable = true;
    }
}
