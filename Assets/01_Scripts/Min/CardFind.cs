using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class CardFind : MonoBehaviour
{
    public FindCardSOList cardList;
    private FindCardSO _currentCard;
    private List<FindCardSO> _cardList = new List<FindCardSO>();

    private Image _selectedCard;
    private Image _prevCard;

    private void Awake()
    {
        foreach (FindCardSO card in cardList.list)
        {
            _cardList.Add(card);
        }

        Initialize();
    }

    private void Initialize()
    {
        int rand = Random.Range(0, _cardList.Count);
        _currentCard = _cardList[rand];

        _currentCard.sprite.Add(_currentCard.correctSprite);

        Shuffle(_currentCard.sprite);

        for (int i = 0; i < 6; i++)
        {
            GameObject.Find($"FindCard ({i})")
                .GetComponent<Image>().sprite = _cardList[rand].sprite[i];
        }

        _currentCard.sprite.Remove(_currentCard.correctSprite);
    }

    public List<Sprite> Shuffle(List<Sprite> list)
    {
        int random1, random2;
        Sprite temp;

        for (int i = 0; i < list.Count; ++i)
        {
            random1 = Random.Range(0, list.Count);
            random2 = Random.Range(0, list.Count);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }

        return list;
    }

    public void SelectCard()
    {
        _selectedCard = EventSystem.current
            .currentSelectedGameObject.GetComponent<Image>();

        _selectedCard.color = Color.HSVToRGB(0, 0, 0.5f);

        if (_prevCard == null)
        {
            _prevCard = _selectedCard;
            return;
        }

        if (!_prevCard.Equals(_selectedCard))
        {
            _prevCard.color = Color.HSVToRGB(0, 0, 1f);
        }

        _prevCard = _selectedCard;
    }

    public void OnSubmit()
    {
        if (_selectedCard.sprite == _currentCard.correctSprite)
            OnSucess();
        else
            OnFail();

    }

    private void OnSucess()
    {
        CheckButton.instance.Good();


    }

    private void OnFail()
    {
        CheckButton.instance.Bad();

    }
}
