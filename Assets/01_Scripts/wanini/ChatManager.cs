using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;
    [SerializeField] TMP_Text txtObj;
    [SerializeField] RectTransform chatwindow;
    [SerializeField] AudioSource asudio;
    [SerializeField] TMP_Text _name;
    public bool isended;
    public bool isclosed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

     StartCoroutine(Test());
    }

    public IEnumerator Test()
    {
        OpenChat("");

        yield return new WaitUntil(() => isclosed); isclosed = false;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Typing("���⼭ �����ھ�.", 0.1f));
        yield return new WaitUntil(() => isended); isended = false;
        yield return new WaitForSeconds(1.5f);
        CloseChat();

    }

    public void OpenChat(string name)
    {
        chatwindow.DOAnchorPos(new Vector2(0,   -135), 1).SetEase(Ease.InSine);
        isclosed = true;
        _name.text = name;
    }

    public IEnumerator Typing( string text, float rate)
    {
        for (int i = 0; i <= text.Length; i++)
        {
            txtObj.text = text.Substring(0, i);
            if (txtObj.text.Length > 0 && txtObj.text[txtObj.text.Length - 1] != ' ') asudio.Play();
            yield return new WaitForSecondsRealtime(rate);
        }
        isended = true;
    }

    public void CloseChat()
    {
        chatwindow.DOAnchorPos(new Vector2(0, -450), 1f).SetEase(Ease.OutSine);
    }


}
