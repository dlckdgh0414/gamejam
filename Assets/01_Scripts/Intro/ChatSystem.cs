using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatSystem : MonoBehaviour
{
    public static ChatSystem instance;
    private TMP_Text txtObj;
    [SerializeField] private RectTransform chatwindow;
    [SerializeField] private AudioSource asudio;
    [SerializeField] private List<string> chat;
    [SerializeField] private RawImage fade;
    public bool _isended;
    public bool _isclosed;
    public bool _canskip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_canskip)
        {
            _canskip = true;
        }
    }

    private void Awake()
    {
        txtObj = GetComponent<TMP_Text>();

        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartBtn()
    {
        StartCoroutine(StartingGame());
    }

    public IEnumerator StartingGame()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        fade.DOFade(1, 1);
        yield return new WaitForSeconds(2);

        for (int i = 0; i < chat.Count; i++)
        {
            _canskip = false;
            StartCoroutine(Typing(chat[i], 0.07f));
            yield return new WaitUntil(() => _isended);
            _isended = false;
            yield return wait;
        }

        txtObj.DOFade(0, 1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void OpenChat()
    {
        chatwindow.DOAnchorPos(new Vector2(18.72998f, -252), 1).SetEase(Ease.Flash);
        _isclosed = true;
    }

    public void Type(string text, float rate)
    {
        StartCoroutine(Typing(text, rate));
    }

    public IEnumerator Typing(string text, float rate)
    {
        txtObj.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            txtObj.text += text[i];
            if (text[i] != ' ')
            {
                asudio.Play();
            }

            if (_canskip)
            {
                txtObj.text = text;
                break;
            }

            yield return new WaitForSecondsRealtime(rate);
        }

        _isended = true;
        _canskip = true;
    }

    public void CloseChat()
    {
        chatwindow.DOAnchorPos(new Vector2(18.72998f, -787), 0.5f).SetEase(Ease.Flash);
        _isclosed = false;
    }
}
