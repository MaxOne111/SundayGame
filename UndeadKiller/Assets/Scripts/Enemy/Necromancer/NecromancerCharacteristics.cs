using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerCharacteristics : EnemyCharacteristics
{
    [SerializeField] private ParticleSystem _Blood;
      
    public override void GetDamage(int _damage)
    {
        base.GetDamage(_damage);
        _Blood.Play();
    }
}
