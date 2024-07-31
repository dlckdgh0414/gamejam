using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingGame : MonoBehaviour
{

    [SerializeField] List<GameObject> gameObjects;

    void Start()
    {
        if (EnemyKillCounter.instance.killCount == 20)
        {
            gameObjects[0].SetActive(true);
        }
        else if (EnemyKillCounter.instance.killCount == 0)
        {
            gameObjects[1].SetActive(true);
        }
        else
        {
            gameObjects[2].SetActive(true);
        }
    }

}
