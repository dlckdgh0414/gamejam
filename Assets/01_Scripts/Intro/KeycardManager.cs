using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class KeycardManager : MonoBehaviour
{
    public static KeycardManager instance;

    [SerializeField] private GameObject keycard;
    [SerializeField] private TMP_Text alarm;


    public bool _keycard;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void getkeycard()
    {
        if (_keycard == false)
        {
            alarm.DOFade(1, 1);
            keycard.SetActive(true);
            _keycard = true;
            alarm.DOFade(0, 1).SetDelay(2);
        }
        else
        {

        }
    }

    public void minuskeycard()
    {
        if (_keycard == true)
        {
            keycard.SetActive(false);
            _keycard = false;

        }
    }
}
