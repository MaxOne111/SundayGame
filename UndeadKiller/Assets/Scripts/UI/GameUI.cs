using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Must;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Waves_Count_Text;
    [SerializeField] private TextMeshProUGUI _Enemy_Count_Text;
    [SerializeField] private TextMeshProUGUI _Time_Until_Wave_Text;
    
    private void Start()
    {        
        GameEvents._Current_Score += ShowWavesCount;
        GameEvents._Current_Score += ShowEnemyCount;
        ShowEnemyCount();
    }

    private void ShowWavesCount()
    {
        _Waves_Count_Text.text = "Waves passed: " + EnemyCount.CurrentWave;
    }

    private void ShowEnemyCount()
    {
        _Enemy_Count_Text.text = "Enemy left: " + EnemyCount.GetEnemies;
    }

    public void ShowTime(float _time)
    {
        _Time_Until_Wave_Text.enabled = true;
        _Time_Until_Wave_Text.text = _time.ToString();
    }

    public void HideTime()
    {
        _Time_Until_Wave_Text.enabled = false;
    }
    
}
