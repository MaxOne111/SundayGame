using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : Animations
{
    

    // Update is called once per frame
    private void Update()
    {
        if (_Movement._Is_Moving)
        {
            _Animator.SetBool("IsRun", true);
        }
        else
        {
            _Animator.SetBool("IsRun", false);
        }
    }
}
