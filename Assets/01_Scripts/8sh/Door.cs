using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool canOpen = false;
    public bool enable = true;
    [SerializeField] private GameObject verify;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpen = false;
    }

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.F))
        {
            DoorInteract();
        }
    }

    private void DoorInteract()
    {
        if (canOpen)
        {
            verify.SetActive(true);
            CheckButton.instance.lego();
        }
    }
}
