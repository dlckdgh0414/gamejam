using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptchaRotate : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    private Sprite _currentSprite;
    private Image _picture;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        int rand = Random.Range(0, _sprites.Length);
        _currentSprite = _sprites[rand];
        _picture.sprite = _currentSprite;
    }
}
