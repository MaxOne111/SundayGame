using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameEvents
{
    public static Action _Start_Loading_Images;
    public static Action _Waiting_For_Request;
    public static Action _Request_Recieved;
    public static Action _Click_On_Picture;

    public static void StartLoadingImages()
    {
        _Start_Loading_Images?.Invoke();
    }
    
    public static void WaitingForRequest()
    {
        _Waiting_For_Request?.Invoke();
    }

    public static void RequestRecieved()
    {
        _Request_Recieved?.Invoke();
    }

    public static void ClickOnPicture()
    {
        _Click_On_Picture?.Invoke();
    }

}
