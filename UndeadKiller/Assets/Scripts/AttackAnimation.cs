using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : Animations
{

    public void Attack()
    {
        _Animator.SetTrigger("Attack");              
    }

    public void StopAttack()
    {
        _Animator.ResetTrigger("Attack");
    }
}
