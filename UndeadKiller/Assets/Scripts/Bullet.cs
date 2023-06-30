using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _Bullet_Speed;
    [field: SerializeField] public int Damage { get; set; }
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _Bullet_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyCharacteristics _enemy))
        {
            _enemy.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}
