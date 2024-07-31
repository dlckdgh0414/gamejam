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
            alarm.text = "키카드를 획득하셨습니다";
            alarm.DOFade(1, 1);
            keycard.SetActive(true);
            _keycard = true;
            alarm.DOFade(0, 1).SetDelay(2);
        }
        else
        {
            alarm.DOFade(1, 1);
            alarm.text = "이미 키카드를 가지고 있습니다";
            alarm.DOFade(0, 1).SetDelay(2);
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
