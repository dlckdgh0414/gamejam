using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour
{
    private List<Transform> _scientistTrm;

    [SerializeField] private int _transformCount;
    [SerializeField] private GameObject _scientist;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Initialize();
        }
    }

    private void Initialize()
    {
        _scientistTrm = new List<Transform>();
        int rand = Random.Range(0, _transformCount);

        for (int i = 1; i <= _transformCount; i++)
        {
            _scientistTrm.Add(GameObject.Find($"pos{i}").transform);
        }

        _scientist.transform.position = _scientistTrm[rand].position;
    }
}
