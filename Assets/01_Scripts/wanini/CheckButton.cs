using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    public static CheckButton instance;
    
    [SerializeField] RectTransform question;
    [SerializeField] Image check;
    [SerializeField] List<GameObject> card;
    [SerializeField] List<CanvasGroup> canvasGroup;
    [SerializeField] RectTransform stroke;
    [SerializeField] RectTransform back;
    [SerializeField] RectTransform father;

    private void Start()
    {
        lego();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

     
    }
    public void lego()
    {
        father.DOScale(new Vector2(0.6817501f, 0.8f), 0.2f).SetEase(Ease.InBounce);
        question.DOScale(new Vector2(1, 1), 0.2f).SetEase(Ease.InBounce).SetDelay(1);
    }

    public void PressEmpty(int stage)
    {

        check.DOFade(1, 1f);
        StartCoroutine(Check(stage));
    }
    IEnumerator Check(int stage)
    {   
        yield return new WaitForSeconds(1.5f);
        question.DOScale(new Vector2(1, 0), 0.2f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(1.4f);
        stroke.DOSizeDelta(new Vector2(stroke.rect.width, 1711.25f), 1);
        back.DOSizeDelta(new Vector2(back.rect.width, 2274f), 1);
        back.DOAnchorPos(new Vector2(113.68f, -407), 1);
        yield return new WaitForSeconds(1.4f);
        card[stage].SetActive(true);
        canvasGroup[stage].DOFade(0, 1);
    }

}
