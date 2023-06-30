using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Picture : MonoBehaviour, IPointerClickHandler
{

    private Image _Image;
    private Sprite _Current_Sprite;

    private void Awake()
    {
        _Image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneData.Sprite = _Image.sprite;
        GameEvents.ClickOnPicture();
    }
}
