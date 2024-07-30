using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI txt;
    string origintTxt;

    public AudioSource hoverAudio;

    void Start()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
        hoverAudio = transform.parent.GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        origintTxt = txt.text;
        txt.text = "I " + origintTxt;
        hoverAudio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        txt.text = origintTxt;
    }

    public void OnClick()
    {
        txt.text = origintTxt;
    }
}
