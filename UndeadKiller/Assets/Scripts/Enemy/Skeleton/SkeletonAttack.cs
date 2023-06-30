using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : EnemyAttack, IAttacking
{
    public void Attack()
    {
        Vector3 _enemy_Position = new Vector3(this.transform.position.x, this.transform.position.y + RayOffsetY, this.transform.position.z);

        RaycastHit _hit;

        if (Physics.Raycast(_enemy_Position, this.transform.forward, out _hit, DistanceToAttack))
        {
            if (_hit.collider.gameObject.GetComponent<PlayerCharacteristics>())
            {
                _hit.collider.gameObject.GetComponent<PlayerCharacteristics>().GetDamage(Damage);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
