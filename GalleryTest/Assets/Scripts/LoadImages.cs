using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
   private UnityWebRequest _Request;
   private bool _Is_Loading;

   [SerializeField] private Transform _Content;
   [SerializeField] private Image _Image_Prefab;
   [SerializeField] private TextMeshProUGUI _Error_Text;
   [SerializeField] private TextMeshProUGUI _Text;
   [SerializeField] private int _Picture_Index = 9;

   private void Awake()
   {
      GameEvents._Start_Loading_Images += StartLoading;
   }

   private IEnumerator LoadImagesFromServer()
   {
      _Request = new UnityWebRequest($"http://data.ikppbb.com/test-task-unity-data/pics/{_Picture_Index}.jpg");
         
      GameEvents.WaitingForRequest();
         
      yield return _Request.SendWebRequest();
         
      GameEvents.RequestRecieved();
         
      switch (_Request.result)
      {
            case UnityWebRequest.Result.ConnectionError: ShowErrorMessage("Check your Internet connection");
               FinishLoading();
               yield break;
            case UnityWebRequest.Result.ProtocolError: ShowErrorMessage("Invalid operation");
               FinishLoading();
               yield break;
      }

      while (_Request.isDone)
      {
            _Request = new UnityWebRequest($"http://data.ikppbb.com/test-task-unity-data/pics/{_Picture_Index}.jpg");

            Image _empty_Image = Instantiate(_Image_Prefab, _Content);
         
            DownloadHandlerTexture _download_Handler = new DownloadHandlerTexture(true);
            _Request.downloadHandler = _download_Handler;
            _Picture_Index++;

            yield return _Request.SendWebRequest();

            switch (_Request.result)
            {
               case UnityWebRequest.Result.ConnectionError: ShowErrorMessage("Check your Internet connection");
                  Destroy(_empty_Image.gameObject);
                  FinishLoading();
                  yield break;
               
               case UnityWebRequest.Result.ProtocolError: ShowErrorMessage("Invalid operation");
                  Destroy(_empty_Image.gameObject);
                  FinishLoading();
                  yield break;
            }
         
            ShowImage(_empty_Image ,_download_Handler);
            HideErrorMessage();
      }
      FinishLoading();
      HideErrorMessage();
   }

   private void StartLoading()
   {
      if (!_Is_Loading)
      {
         _Is_Loading = true;
         StartCoroutine(LoadImagesFromServer());
      }
   }
   
   private void FinishLoading()
   {
      _Is_Loading = false;
      _Request?.Dispose();
   }

   private void ShowImage(Image _image, DownloadHandlerTexture _download_Handler)
   {
      Destroy(_image.transform.GetChild(0).gameObject);
      _image.sprite = Sprite.Create(_download_Handler.texture, new Rect(Vector2.zero, new Vector2(1000, 1000)), Vector2.zero);
      _image.raycastTarget = true;
   }

   private void ShowErrorMessage(string _text)
   {
      _Error_Text.gameObject.SetActive(true);
      _Error_Text.text = _text;
   }
   
   private void HideErrorMessage()
   {
      _Error_Text.gameObject.SetActive(false);
   }

   private void OnDestroy()
   {
      _Request?.Dispose();
      
      GameEvents._Start_Loading_Images -= StartLoading;
   }
}
