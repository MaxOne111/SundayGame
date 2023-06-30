using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    [SerializeField] private Orientation _orientation;
    private enum Orientation
    {
        Portrait,
        PortraitUpsideDown,
        LandscapeRight,
        LandscapeLeft,
        AutoRotation
    }
    private void Awake()
    {
        switch (_orientation)
        {
            case Orientation.Portrait: Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                break;
            case Orientation.PortraitUpsideDown: Screen.orientation = UnityEngine.ScreenOrientation.PortraitUpsideDown;
                break;
            case Orientation.LandscapeRight: Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
                break;
            case Orientation.LandscapeLeft: Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                break;
            case Orientation.AutoRotation: Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
                break;
        }
    }
}
