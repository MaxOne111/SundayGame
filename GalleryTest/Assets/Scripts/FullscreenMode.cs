using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FullscreenMode : MonoBehaviour
{
    [SerializeField] private Image _Picture;
    private void Start()
    {
        _Picture.sprite = SceneData.Sprite;
    }
}
