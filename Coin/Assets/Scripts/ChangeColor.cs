using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
    private Renderer _Renderer;
    private float _R_Color;
    private float _G_Color;
    private float _B_Color;
    private float _Emission_Intensity = 4f;

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }

    private void SetColor()
    {
        _R_Color = Random.Range(0f, 1f);
        _G_Color = Random.Range(0f, 1f);
        _B_Color = Random.Range(0f, 1f);

        _Renderer.material.color = new Color(_R_Color, _G_Color, _B_Color);
        _Renderer.material.SetColor("_EmissionColor", new Color(_R_Color * _Emission_Intensity, _G_Color * _Emission_Intensity, _B_Color * _Emission_Intensity));
    }

    private void OnMouseDown()
    {
        SetColor();
    }
}
