using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        //gameOverUI = GameObject.Find("Canvas/GameOver");
    }

    public void Death()
    {
        StartCoroutine(ShowUI());
    }

    private IEnumerator ShowUI()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        gameOverUI.SetActive(true);
    }
}
