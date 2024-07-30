using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUi;

    private void Awake()
    {
        //settingUi.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //settingUi.SetActive(true);
            settingUi.transform.DOMoveX(130f, 0.5f);
            //Time.timeScale = 0;
        }
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1;
    }

    public void OnClickContinue()
    {
        settingUi.transform.DOMoveX(-130f, 0.5f);
        //settingUi.SetActive(false);
        //Time.timeScale = 1;
    }

    public void OnClickExit()
    {
        //SceneManager.LoadScene();
        //첫 번째 메인화면 씬 넘버를 입력해주세요.
    }
}
