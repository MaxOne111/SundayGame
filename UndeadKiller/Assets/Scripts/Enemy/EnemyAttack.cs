using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _Damage;
    [SerializeField] private float _Distance_To_Attack;
    [SerializeField] private float _Ray_Offset_Y;
    public int Damage { get { return _Damage; }}
    public float DistanceToAttack { get { return _Distance_To_Attack; }}
    public float RayOffsetY { get { return _Ray_Offset_Y; }}

  
}
