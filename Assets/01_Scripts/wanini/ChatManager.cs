using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;
    [SerializeField] private TMP_Text txtObj;
    [SerializeField] private RectTransform chatwindow;
    [SerializeField] private AudioSource asudio;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private RawImage fade;
    [SerializeField] private List<string> chat;
    public PlayerLight _Light;



    public bool isended;
    public bool isclosed;
    public bool _canskip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _canskip = true;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        StartCoroutine(Test());
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
            yield return new WaitUntil(() => isended);
            isended = false;
            yield return wait;
        }

        txtObj.DOFade(0, 1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void OpenChat(string name)
    {
        chatwindow.DOAnchorPos(new Vector2(0, -135), 1).SetEase(Ease.InSine);
        isclosed = true;
        _name.text = name;
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

        isended = true;
        _canskip = false;  // Reset _canskip here
    }

    public void CloseChat()
    {
        txtObj.text = "";
        chatwindow.DOAnchorPos(new Vector2(0, -450), 1f).SetEase(Ease.OutSine);
        isclosed = false;

        _Light.PlayerLightInts?.Invoke();
    }

    public IEnumerator Test()
    {
        OpenChat("");
        yield return new WaitUntil(() => isclosed);
        isclosed = false;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Typing("여기서 나가겠어.", 0.1f));
        yield return new WaitUntil(() => isended);
        isended = false;
        yield return new WaitForSeconds(1.5f);
        CloseChat();
    }
}
