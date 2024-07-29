using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CaptchaRotate : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites; //돌릴 이미지 리스트;+
    [SerializeField] private GameObject _picture; //돌릴 이미지 오브잭트
    [SerializeField] private int _angleSize; //클릭했을때 회전각 크기

    private Sprite _currentSprite;
    private Vector3 _currentAngle;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize() //이거 실행시켜주면 준비됨
    {
        int rand = Random.Range(0, _sprites.Length);
        _currentAngle = new Vector3(0, 0, Random.Range
            (1, 8) * _angleSize);
        _currentSprite = _sprites[rand];
        _picture.GetComponent<Image>().sprite = _currentSprite;
        _picture.transform.rotation = Quaternion.Euler(0, 0, _currentAngle.z);
    }

    public void OnRightClick()
    {
        Vector3 angle = new Vector3(0, 0, _angleSize);

        _picture.transform.DORotate(_currentAngle + angle, 0.2f)
            .SetEase(Ease.OutCubic);

        _currentAngle += angle;

        if (_currentAngle.z >= 360)
            _currentAngle = Vector3.zero;
    }

    public void OnCheck()
    {
        if (_currentAngle.z == 0)
        {
            Debug.Log("성공");
        }
        else
            Debug.Log("실패");
    }
}
