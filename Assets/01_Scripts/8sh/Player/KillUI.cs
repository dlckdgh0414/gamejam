using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class KillUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Effect()
    {
        Color c = Color.red;
        c.a = 0;
        image.color = Color.red;
        image.DOColor(c, 0.3f);
        //GameObject.Find("")GetComponent<ParticleSystem>().Play();
    }
}
