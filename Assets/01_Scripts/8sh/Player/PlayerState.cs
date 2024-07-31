using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSecondsRealtime(0.2f);
        GameObject.FindWithTag("MainCamera").GetComponent<AudioListener>().enabled = false;
        gameOverUI.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Stage1_REMOTE_556");
    }
}
