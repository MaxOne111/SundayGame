using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToFullscreenMode : MonoBehaviour
{
    [SerializeField] private int _Fullscreen_Index = 2;
    private void Awake()
    {
        GameEvents._Click_On_Picture += ToFullscreenMode;
    }

    private void ToFullscreenMode()
    {
        SceneManager.LoadScene(_Fullscreen_Index, LoadSceneMode.Additive);
    }

    private void OnDestroy()
    {
        GameEvents._Click_On_Picture -= ToFullscreenMode;
    }
}
