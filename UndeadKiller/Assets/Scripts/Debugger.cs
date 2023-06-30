using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private Transform _Position;
    [SerializeField] private GameObject _Player;
    
    public void ResetPosition()
    {
        _Player.transform.position = _Position.position;
    }
}
