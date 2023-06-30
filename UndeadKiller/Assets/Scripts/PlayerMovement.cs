using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _Joystick;
    [SerializeField] private float _Speed;

    private float _Move_X;
    private float _Move_Z;

    private Vector3 _Move;

    public bool _Is_Moving { get; private set; }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _Move_X = _Joystick.Horizontal;
        _Move_Z = _Joystick.Vertical;
        _Move = new Vector3(_Move_X, 0, _Move_Z);       
        if(_Joystick.Vertical !=0 || _Joystick.Horizontal != 0)
        {
            _Is_Moving = true;
            transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(_Move);
        }
        else
        {
            _Is_Moving = false;
        }
    }  
    
}
