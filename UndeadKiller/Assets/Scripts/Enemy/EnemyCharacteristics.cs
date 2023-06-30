using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private int _Health;
    private Animator _Animator;
    private EnemyMovement _Movement;
    private EnemyAttack _Attack;
    private void Start()
    {
        _Animator = GetComponent<Animator>();
        _Movement = GetComponent<EnemyMovement>();
        _Attack = GetComponent<EnemyAttack>();
    }  
    public virtual void GetDamage(int _damage)
    {
        _Health -= _damage;
        if( _Health > 0)
        {
            _Animator.SetTrigger("Hit");
        }
        else
        {
            Death();
        } 
        
    }
    private void Death()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject.GetComponent<EnemyCharacteristics>());
        gameObject.tag = "Untagged";
        
        _Health = 0;
        
        GameEvents.CurrentScore();
        GameEvents.NewWave();
        
        _Movement.enabled = false;
        _Attack.enabled = false;
        _Movement.StartDis();

        _Animator.SetTrigger("Death");
        Destroy(gameObject, 2.5f);
    }
}
