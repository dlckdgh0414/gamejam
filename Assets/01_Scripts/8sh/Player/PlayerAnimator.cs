using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Test();
        animator.SetBool("Walking", playerMovement.moving);
        animator.SetFloat("MoveX", playerInput.moveDir.x);
        animator.SetFloat("MoveY", playerInput.moveDir.y);
    }

    private void Test()
    {
        if(playerInput.moveDir.x == 0 && playerInput.moveDir.y < 0)
        {
            animator.SetBool("Front", true);
            animator.SetBool("Back", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }else if (playerInput.moveDir.x == 0 && playerInput.moveDir.y > 0)
        {
            animator.SetBool("Front", false);
            animator.SetBool("Back", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }else if (playerInput.moveDir.x < 0 && playerInput.moveDir.y == 0)
        {
            animator.SetBool("Front", false);
            animator.SetBool("Back", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }else if (playerInput.moveDir.x > 0 && playerInput.moveDir.y == 0)
        {
            animator.SetBool("Front", false);
            animator.SetBool("Back", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
        }
    }
}
