using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
   [SerializeField] private float _Rotation_Speed;

   private void Update()
   {
      Rotation();
   }

   private void Rotation()
   {
      transform.Rotate(Vector3.forward * _Rotation_Speed * Time.deltaTime);
   }
}
