using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DctorDead : MonoBehaviour
{
    public UnityEvent DeadEvent;

    private Animator _anim;

    [SerializeField] private GameObject CardKey;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void DeadAnim()
    {
        _anim.SetBool("Dead", true);
        CardKey.SetActive(true);
    }
}
