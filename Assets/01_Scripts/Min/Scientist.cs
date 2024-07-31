using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour
{
    private List<Transform> _trmList;

    [SerializeField] private int posCount;
    [SerializeField] private GameObject _scientist;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        int rand = Random.Range(0, posCount);
        _trmList = new List<Transform>();

        for (int i = 0; i < posCount; i++)
        {
            _trmList.Add(GameObject.Find($"pos{i + 1}").transform);
        }

        _scientist.transform.position = _trmList[rand].position;
    }
}
