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
    bool _already2;

    private void Start()
    {
        //lego();
    }

    private void Update()
    {
        if (_already && Input.GetKeyDown(KeyCode.F))
        {
            Initialized();
            _already2 = false;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void lego() // 버튼 생성
    {
        _already2 = true;
        _already = false; // Add this line to reset _already
        father.DOScale(new Vector2(0.6817501f, 0.3f), 0.2f).SetEase(Ease.InBounce);
        question.DOScale(new Vector2(1, 2.73f), 0.2f).SetEase(Ease.InBounce).SetDelay(0.6f);
        success = false;
        // 플레이어 멈추기
    }

    public void PressEmpty() // 버튼 클릭
    {
        if (!_already) // 이미 클릭되었는지 확인
        {
            check.DOFade(1, .5f);
            StartCoroutine(Check());
            _already = true;
        }
    }

    IEnumerator Check() // 미션창 띄우기
    {
        yield return new WaitForSeconds(.5f);
        question.DOScale(new Vector2(0, 0), 0.2f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(.4f);
        father.DOScale(new Vector2(0.6817501f, 0.8f), 0.2f).SetEase(Ease.InBounce);

        stroke.DOSizeDelta(new Vector2(1367, 1338.75f), 0.5f);
        back.DOSizeDelta(new Vector2(3018.52f, 2448), 0.5f);

        yield return new WaitForSeconds(0.2f);
        canvasGroup.DOFade(1, 0.1f);
        yield return new WaitForSeconds(0.3f);
        card[Random.Range(0, card.Count)].SetActive(true); // 카드 선택 범위 수정
        canvasGroup.DOFade(0, 0.4f);
    }

    public void Initialized() // 미션창 초기화 (위치 등)
    {
        back.sizeDelta = new Vector2(3021f, 2448f);
        stroke.sizeDelta = new Vector2(1367f, 1338.75f);
        question.DOScale(new Vector2(0, 0), 0.2f);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().active = true;

        foreach (GameObject cards in card)
        {
            cards.SetActive(false);
        }
        check.DOFade(0, .5f);
        canvasGroup.alpha = 0;
        _already = false; // Add this line to reset _already
    }

    public void Good() // 성공
    {
        StartCoroutine(ShowResult(false));
    }

    public void Bad() // 실패
    {
        StartCoroutine(ShowResult(true));
    }

    IEnumerator ShowResult(bool isBad) // 결과 표시
    {
        canvasGroup.DOFade(1, .5f);
        yield return new WaitForSeconds(0.2f);

        if (isBad)
        {
            success = false;
            bad.DOFade(1, .5f);
            yield return new WaitForSeconds(.5f);
            bad.DOFade(0, .5f);
        }
        else
        {
            success = true;
            good.DOFade(1, .5f);
            yield return new WaitForSeconds(.5f);
            good.DOFade(0, .5f);
        }

        yield return new WaitForSeconds(0.2f);
        father.DOScale(new Vector2(0.6817501f, 0f), 0.2f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(.5f);

        Initialized();
    }
}
