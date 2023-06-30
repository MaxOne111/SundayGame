using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAttack : EnemyAttack, IAttacking
{
    [SerializeField] private GameObject _Projectile;
    [SerializeField] private GameObject _Skeleton;

    [SerializeField] private Transform _Staff;

    [SerializeField] private int _Cool_Down;
    [SerializeField] private int _Skeletons_Count;

    [SerializeField] private Transform[] _Skeletons_Positions;

    private void Start()
    {
        StartCoroutine(StartSummoming());
    }
    public void Attack()
    {
       Instantiate(_Projectile, _Staff.position,transform.rotation);
    } 

    private IEnumerator StartSummoming()
    {    
        yield return new WaitForSeconds(5);   
        SkeletonSummoning();
        yield return new WaitForSeconds(_Cool_Down);     
        if(_Skeletons_Count > 0)
        {
            StartCoroutine(StartSummoming());
        }
        else
        {
            StopCoroutine(StartSummoming());
        }
    }

    private void SkeletonSummoning()
    {
        for (int i =0; i< _Skeletons_Positions.Length; i++)
        {
            Instantiate(_Skeleton, _Skeletons_Positions[i].transform.position, Quaternion.identity);            
        }
        _Skeletons_Count -= _Skeletons_Positions.Length;
        GameEvents.CurrentScore();
    }
   
}
