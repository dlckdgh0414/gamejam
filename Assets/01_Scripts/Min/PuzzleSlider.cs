using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSlider : MonoBehaviour
{
    [SerializeField] private GameObject _puzzle;
    [SerializeField] private GameObject _target;

    [SerializeField] private Slider _horizontalSlider;
    [SerializeField] private Slider _verticalSlider;

    [SerializeField] private float _moveXSize;
    [SerializeField] private float _moveYSize;
    [SerializeField] private float _sucessDistance;

    private RectTransform _puzzleTrm;
    private bool _isHoldingSucess = false;

    private void Awake()
    {
        _puzzleTrm = _puzzle.GetComponent<RectTransform>();

        Initialize();
    }

    private void Update()
    {
        CheckTargetDistance();
    }

    private void Initialize()
    {
        _horizontalSlider.onValueChanged.AddListener(delegate { HorizontalValueChanged(); });
        _verticalSlider.onValueChanged.AddListener(delegate { VerticalValueChanged(); });
    }

    public void HorizontalValueChanged()
    {
        float xPos = _horizontalSlider.value * _moveXSize;

        _puzzleTrm.localPosition =
            new Vector3(xPos, _puzzleTrm.localPosition.y, 0);
    }

    public void VerticalValueChanged()
    {
        float yPos = _verticalSlider.value * _moveYSize;

        _puzzleTrm.localPosition = 
            new Vector3(_puzzleTrm.localPosition.x, yPos, 0);
    }

    private void CheckTargetDistance()
    {
        float distance =
            Vector3.Distance(_target.transform.position, _puzzleTrm.position);

        if (distance < _sucessDistance && !_isHoldingSucess)
        {
            StartCoroutine(SucessHoldingRoutine(distance));
        }
    }

    private IEnumerator SucessHoldingRoutine(float distance)
    {
        _isHoldingSucess = true;
        yield return new WaitForSeconds(1f);

        if (distance < _sucessDistance)
            OnSucess();
    }

    private void OnSucess() //성공했을때 실행되는 함수
    {
        _isHoldingSucess = false;
        Debug.Log("Sucess");
    }
}
