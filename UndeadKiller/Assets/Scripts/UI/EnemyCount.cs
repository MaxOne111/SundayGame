using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyCount
{
    private static int _Enemy_Count;
    private static int _Waves_Count = 0; 
    
    public static int GetEnemies
    {
        get
        {
            GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
            return _Enemy_Count = _enemies.Length;
        }
    }
    
    public static int CurrentWave
    {
        get { return _Waves_Count; }
        set
        {
            if (_Enemy_Count <= 0)
            {
                value = 1;
                _Waves_Count += value;
            }
        }
    }
    
}
