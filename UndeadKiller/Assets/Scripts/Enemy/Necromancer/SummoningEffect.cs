using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningEffect : MonoBehaviour
{

    [SerializeField]private float _Angle = 0;
    [SerializeField]private float _Cicle_Speed;
    [SerializeField] private float _Speed;
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        _Angle += _Cicle_Speed;
        float _x = Mathf.Cos(_Angle/360);
        float _z = Mathf.Sin(_Angle/360);
        Vector3 move = new Vector3(_x, 0, _z);
        transform.Translate(move * Time.deltaTime * _Speed);
    }
}
