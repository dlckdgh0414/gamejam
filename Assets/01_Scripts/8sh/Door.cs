using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool canOpen = false;
    private bool solving = false;
    public bool enable = true;
    [SerializeField] private GameObject verify;
    private Animator animator;
    [SerializeField] private GameObject doorCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enable)
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpen = false;
        solving = false;
    }

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.F) && enable)
        {
            DoorInteract();
        }
        if (solving && CheckButton.instance.success && enable)
        {
            enable = false;
            animator.SetBool("Open", true);
            doorCollider.SetActive(false);
            GetComponent<AudioSource>().Play();
        }
    }

    private void DoorInteract()
    {
        if (canOpen && enable)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().active = false;
            verify.SetActive(true);
            solving = true;
            CheckButton.instance.lego();
        }
    }
}
