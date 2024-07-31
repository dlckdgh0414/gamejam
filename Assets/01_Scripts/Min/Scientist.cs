using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour
{
    [SerializeField] private GameObject _scientist;
    [SerializeField] private int _trmCount;

    private List<Transform> _spawnList;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _spawnList = new List<Transform>();
        int rand = Random.Range(0, _trmCount);

        for (int i = 0; i < _trmCount; i++)
        {
            _spawnList.Add(GameObject.Find($"pos{i + 1}").transform);
        }

        _scientist.transform.position = _spawnList[rand].position;
    }
}
