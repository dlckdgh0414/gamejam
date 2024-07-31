using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

<<<<<<<< HEAD:Assets/01_Scripts/Lch/KeyCardTest.cs
public class KeyCardTest : MonoBehaviour
{
    public static KeyCardTest instance;
========
public class KeyCardManager : MonoBehaviour
{
    public static KeyCardManager instance;
>>>>>>>> origin/Base2:Assets/01_Scripts/Lch/KeyCardManager.cs

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
