using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class CheckButton : MonoBehaviour
{
    public static CheckButton instance;

    [SerializeField] RectTransform question;
    [SerializeField] Image check;
    [SerializeField] List<GameObject> card;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform stroke;
    [SerializeField] RectTransform back;
    [SerializeField] RectTransform father;
    [SerializeField] TextMeshProUGUI good;
    [SerializeField] TextMeshProUGUI bad;

    public int stage;
    public bool success;
    bool _already;

    private void Start()
    {
        //lego();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void lego() // ��ư ����
    {
        father.DOScale(new Vector2(0.6817501f, 0.8f), 0.2f).SetEase(Ease.InBounce);
        question.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.InBounce).SetDelay(1);
        success = false;
        // �÷��̾� ���߱�
    }

    public void PressEmpty() // ��ư Ŭ��
    {
        if (!_already) // �̹� Ŭ���Ǿ����� Ȯ��
        {
            check.DOFade(1, 1f);
            StartCoroutine(Check());
            _already = true;
        }
    }

    IEnumerator Check() // �̼�â ����
    {
        yield return new WaitForSeconds(0.5f);
        question.DOScale(new Vector2(1, 0), 0.2f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(0.5f);
        _already = false;
        stroke.DOSizeDelta(new Vector2(stroke.rect.width, 1711.25f), 0.6f);
        back.DOSizeDelta(new Vector2(back.rect.width, 2274f), 0.6f);
        back.DOAnchorPos(new Vector2(113.68f, -407), 0.6f);

        yield return new WaitForSeconds(0.7f);
        canvasGroup.DOFade(1, 0.1f);
        yield return new WaitForSeconds(0.3f);
        card[Random.Range(0, card.Count)].SetActive(true); // ī�� ���� ���� ����
        canvasGroup.DOFade(0, 1);
    }

    public void Initialized() // �̼�â �ʱ�ȭ (��ġ ��)
    {
        back.anchoredPosition = new Vector2(113.68f, -237.05f);
        back.sizeDelta = new Vector2(2193.13f, 913.59f);
        stroke.sizeDelta = new Vector2(2030.79f, 717f);


        check.DOFade(0, 0f);
        foreach (GameObject cards in card)
        {
            cards.SetActive(false);
        }
        canvasGroup.alpha = 0;
    }

    public void Good() // ����
    {
        StartCoroutine(ShowResult(false));
    }

    public void Bad() // ����
    {
        StartCoroutine(ShowResult(true));
    }

    IEnumerator ShowResult(bool isBad) // ��� ǥ��
    {
        canvasGroup.DOFade(1, 1);
        yield return new WaitForSeconds(0.5f);

        if (isBad)
        {
            success = false;
            bad.DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.5f);
            bad.DOFade(0, 0.5f);
        }
        else
        {
            success = true;
            good.DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.5f);
            good.DOFade(0, 0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        father.DOScale(new Vector2(0.6817501f, 0f), 0.2f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(0.6f);

        Initialized();
    }
}
