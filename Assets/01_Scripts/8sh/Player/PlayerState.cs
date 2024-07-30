using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private GameObject gameOverUI;

    private void Awake()
    {
        gameOverUI = GameObject.Find("Canvas/GameOver");
    }

    public void Death()
    {

    }
}
