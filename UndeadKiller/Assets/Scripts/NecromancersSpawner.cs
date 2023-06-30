using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NecromancersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _Necromancer;

    [SerializeField] private Transform[] _Spawn_Positions;
    private float _Time_Until_Spawn = 10;
    private GameUI _Game_UI;
    private void Awake()
    {
        _Game_UI = GameObject.FindWithTag("UI").GetComponent<GameUI>();
    }

    private void Start()
    {
        GameEvents._New_Wave += NewWave;
        Spawn();
    }

    private void Spawn()
    {
        for(int i = 0; i < _Spawn_Positions.Length; i++)
        {
            Instantiate(_Necromancer, _Spawn_Positions[i].position, _Spawn_Positions[i].rotation);
        }
        GameEvents.CurrentScore();
    }

    private void NewWave()
    {
        if (EnemyCount.GetEnemies <= 0)
        {
            StartCoroutine(StartSpawn());
        }
    }

    private IEnumerator StartSpawn()
    {
        EnemyCount.CurrentWave++;
        GameEvents.CurrentScore();

        int _time_Delay = 1;
        float _next_Wave_time = _Time_Until_Spawn + _time_Delay;
        
        while (_next_Wave_time > 0)
        {
            yield return new WaitForSeconds(1);
            _next_Wave_time--;
            _Game_UI.ShowTime(_next_Wave_time);
        }
        _Game_UI.HideTime();
            
        Spawn();
    }
}
