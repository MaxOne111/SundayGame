using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animations : MonoBehaviour
{
    protected Animator _Animator;
    protected PlayerMovement _Movement;
    private void Start()
    {
        _Animator = GetComponent<Animator>();
        _Movement = GetComponent<PlayerMovement>();
    }

    
}
