using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool canOpen = false;
    private bool enable = true;
    private Animator _anim;
    public int ScenNum;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
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
    }

    private void Update()
    {
        if (KeyCardManager.instance._keycard && canOpen && enable)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                enable = false;
                GetComponent<AudioSource>().Play();
                _anim.SetBool("Open", true);
                SceneManager.LoadScene(ScenNum);
            }
        }
    }
}
