using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using System.Linq;

public class CaptchaPicture : MonoBehaviour
{
    public CardSOList cardList;
    private CardSO _currentCard;
    private List<CardSO> _cardList = new List<CardSO>();
    private List<int> _selectedCard = new List<int>();

    private void Awake()
    {
        foreach (CardSO card in cardList.list)
        {
            _cardList.Add(card);
        }

        Initialize();
    }

    private void Initialize()
    {
        int rand = Random.Range(0, _cardList.Count);
        _currentCard = _cardList[rand];

        for (int i = 0; i < 16; i++)
        {
            GameObject.Find($"Card ({i})")
                .GetComponent<Image>().sprite = _cardList[rand].sprite[i];
        }
    }

    public void OnCardClick()
    {
        Image image = EventSystem.current
            .currentSelectedGameObject.GetComponent<Image>();

        int n = int.Parse(Regex.Replace(image.name, @"\D", ""));

        if (!_selectedCard.Contains(n))
        {
            _selectedCard.Add(n);
            image.color = Color.HSVToRGB(0, 0, 0.5f);
        }
        else
        {
            _selectedCard.Remove(n);
            image.color = Color.HSVToRGB(0, 0, 1f);
        }
    }

    public void OnSkipClick()
    {
        _selectedCard.Sort();

        bool isEaual = Enumerable.SequenceEqual
            (_selectedCard, _currentCard.correctCard);

        if (isEaual)
            OnSucess();
        else
            OnFail();
    }

    private void OnSucess()
    {
        Debug.Log("성공");
    }

    private void OnFail()
    {
        Debug.Log("실패");
    }
}
