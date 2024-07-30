using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartFade : MonoBehaviour
{

    private RawImage fade;

    void Start()
    {

        fade = GetComponent<RawImage>();
        fade.DOFade(0, 1).SetDelay(1);
    }

 
}
