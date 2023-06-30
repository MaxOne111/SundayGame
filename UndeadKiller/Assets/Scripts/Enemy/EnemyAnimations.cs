using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _Animator;
    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    public void MovementAnimation()
    {
        _Animator.SetBool("Move", true);
    }
    public void IdleAnimation()
    {
        _Animator.SetBool("Move", false);
    }

    public void AttackAnimation()
    {
        _Animator.SetBool("Move", false);
        _Animator.SetTrigger("Attack");
    }

}
