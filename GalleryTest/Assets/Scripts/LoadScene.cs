using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private AsyncOperation _Async_Operation;
    private float _Delay = 1;
    
    [SerializeField] private int _Scene_ID;
    [SerializeField] private TextMeshProUGUI _Progress_Text;
    [SerializeField] private Image _Pogress_Bar;

    private IEnumerator Loading()
    {
        yield return new WaitForSeconds(_Delay);
        _Async_Operation = SceneManager.LoadSceneAsync(_Scene_ID);

        while (!_Async_Operation.isDone)
        {
            _Progress_Text.text = $"Loading...{_Async_Operation.progress * 100}%";
            _Pogress_Bar.fillAmount = _Async_Operation.progress / 1f;
            yield return null;
        }
    }

    public void StartLoading()
    {
        StartCoroutine(Loading());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
