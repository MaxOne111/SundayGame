using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : Animations
{
    private Jump _Jump_Script;

    private void Awake()
    {
        _Jump_Script = GetComponent<Jump>();
    }

    public void StartJump()
    {
        _Animator.SetTrigger("Jump");
    }

    private void Update()
    {
        if (_Jump_Script.IsGround)
        {
            _Animator.SetBool("IsGround", true);
        }
        else
        {
            _Animator.SetBool("IsGround", false);
        }
    }
}
