using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents
{
    public static Action _Current_Score;
    public static Action _New_Wave;

    public static void CurrentScore()
    {
        _Current_Score.Invoke();
    }

    public static void NewWave()
    {
        _New_Wave.Invoke();
    }
   
}
