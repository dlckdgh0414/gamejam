using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DctorDead : MonoBehaviour
{
    public UnityEvent DctorDeadEvent;
    [SerializeField] private GameObject KeyCard;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void DeadAnim()
    {
        _anim.SetBool("Dead", true);
        KeyCard.SetActive(true);
    }
}
