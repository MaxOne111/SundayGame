using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttacking
{
    [SerializeField] private int _Damage;
    [SerializeField] private float _Attack_Speed;
    private float _Fire_Rate;

    [SerializeField] private Transform _Bullet_Start;
    [SerializeField] private Bullet _Bullet;
    

    private void Awake()
    {
        _Bullet.Damage = _Damage;
    }

    public void Attack()
    {
        if (Time.time > _Fire_Rate)
        {
            _Fire_Rate = Time.time + 1f / _Attack_Speed;
            Instantiate(_Bullet.gameObject, _Bullet_Start.position, _Bullet_Start.transform.rotation);
        }
    }
    
}
