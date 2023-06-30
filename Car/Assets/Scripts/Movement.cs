using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _Movement_Speed = 75f;
    [SerializeField] private float _Rotation_Speed = 50f;
    private float _Acceleration_Time;
    private float _Braking_Time;

    private Vector3 _Move_Forward;
    private Vector3 _Move_Back;
    private Vector3 _Rotate;

    private bool _Move_Button_Down;
    private bool _Rotate_Button_Down;
    private bool _Is_Stopped;

    [SerializeField]
    [Range(0, 1)]
    private float _Acceleration_Coef = 0.25f;
    [SerializeField]
    [Range(0, 1)]
    private float _Braking_Coef = 0.1f;
    
    private int _Rotate_Direction;
    

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        Acceleration();
        AutoBraking();
        PlayerBraking();
        
        _Move_Forward = Vector3.forward * _Movement_Speed * _Acceleration_Time;
        _Move_Back = -Vector3.forward  * _Movement_Speed * _Braking_Time;
        
        _Rotate = Vector3.up * _Rotate_Direction * _Rotation_Speed;
        
        transform.Translate((_Move_Back + _Move_Forward) * Time.deltaTime);
        if((_Rotate_Button_Down && _Move_Button_Down) || (_Rotate_Button_Down && _Move_Forward.magnitude + _Move_Back.magnitude > 0))
            transform.Rotate(_Rotate * Time.deltaTime);
    }
    
    private void AutoBraking()
    {
        if(!_Move_Button_Down)
        {
            if(_Braking_Time > 0)
                _Braking_Time -= Time.deltaTime * _Braking_Coef;
            else
            {
                _Braking_Time = 0;
            }
            
            if (_Acceleration_Time > 0)
            {
                _Acceleration_Time -= Time.deltaTime * _Braking_Coef;
                
            }
                
            else
            {
                _Acceleration_Time = 0;
            }
        }
    }

    private void PlayerBraking()
    {
        if (_Move_Button_Down)
        {
            if (_Is_Stopped)
            {
                _Braking_Time += Time.deltaTime * _Braking_Coef;
                if (_Acceleration_Time > 0)
                {
                    _Acceleration_Time -= Time.deltaTime * _Braking_Coef;
                
                }
                else
                {
                    _Acceleration_Time = 0;
                }
            }
        }
    }

    private void Acceleration()
    {
        if (_Move_Button_Down)
        {
            if (!_Is_Stopped)
            {
                if (_Braking_Time > 0)
                {
                    _Braking_Time -= Time.deltaTime * _Braking_Coef;
                }
                else
                {
                    _Braking_Time = 0;
                }
                
                if (_Move_Forward.magnitude < _Movement_Speed)
                {
                    _Acceleration_Time += Time.deltaTime * _Acceleration_Coef;
                }
            }
            
        }
    }

    public void CarIsStopping()
    {
        _Is_Stopped = true;
    }

    public void CarIsMoving()
    {
        _Is_Stopped = false;
    }
    
    public void MoveButtonDown()
    {
        _Move_Button_Down = true;
    }

    public void MoveButtonUp()
    {
        _Move_Button_Down = false;
    }
    
    public void RotateButtonDown()
    {
        _Rotate_Button_Down = true;
    }

    public void RotateButtonUp()
    {
        _Rotate_Button_Down = false;
    }

    public void RotateRight()
    {
        _Rotate_Direction = 1;
    }

    public void RotateLeft()
    {
        _Rotate_Direction = -1;
    }
    

}
