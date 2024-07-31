using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFade2 : MonoBehaviour
{
    void Start()
    {
        Color c = Color.black;
        c.a = 0;
        Image img = GetComponent<Image>();
        img.color = Color.black;
        img.DOColor(c, 2f).SetDelay(2);
    }
}
