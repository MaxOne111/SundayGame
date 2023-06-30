using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private Vector3  _Offset;
    
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = _Player.transform.position + _Offset;
    }
}
