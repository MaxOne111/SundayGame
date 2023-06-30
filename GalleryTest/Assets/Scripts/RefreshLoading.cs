using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshLoading : MonoBehaviour
{
    [SerializeField] private ScrollRect _Scroll_Rect;
    [SerializeField] private GameObject _Picture_Loading;
    private float _Rect_Down_Border = -0.5f;
    
    private void Awake()
    {
        GameEvents._Waiting_For_Request += EnablePictureLoading;
        GameEvents._Request_Recieved += DisablePictureLoading;
    }

    private void EnablePictureLoading()
    {
        _Picture_Loading.SetActive(true);
    }

    private void DisablePictureLoading()
    {
        _Picture_Loading.SetActive(false);
    }
    
    public void Refresh()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_Scroll_Rect.normalizedPosition.y < _Rect_Down_Border)
            {
                GameEvents.StartLoadingImages();
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents._Waiting_For_Request -= EnablePictureLoading;
        GameEvents._Request_Recieved -= DisablePictureLoading;
    }
}
