using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private Animator _anim;
    public int ScenNum;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (KeyCardManager.instance._keycard)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _anim.SetBool("Open", true);
                SceneManager.LoadScene(ScenNum);
            }
        }
    }
}
