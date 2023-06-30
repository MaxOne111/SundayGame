using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void CloseScene(int _index)
    {
        SceneManager.UnloadSceneAsync(_index);
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
    }

#if UNITY_ANDROID
    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                if (SceneManager.GetSceneByName("Fullscreen").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Fullscreen");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
                
            else
            {
                Application.Quit();
            }
        }
    }
#endif
    
}
