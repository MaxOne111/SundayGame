using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _Jump_Force;
    private Rigidbody _Rigidbody;
    public bool IsGround { get; private set; }

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    public void Jumping()
    {
        if (IsGround)
        {
            _Rigidbody.AddForce(Vector3.up * _Jump_Force, ForceMode.Impulse);
            IsGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            IsGround = true;
        }
    }
}
