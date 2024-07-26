using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ImageType
{
    Changho,
    Test1
}

public class CaptchaPicture : MonoBehaviour
{
    private Button[] _correctPics;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private Sprite[] _images;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject.Find($"Image ({i})")
                .GetComponent<Image>().sprite = _images[i];
        }
    }

    private void OnImageClick()
    {
        Button button = EventSystem.current
            .currentSelectedGameObject.GetComponent<Button>();


    }

    private void OnSkipClick()
    {

    }
}
