using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{  
    private Transform _Target;

    private float _Distance_To_Target;

    private NavMeshAgent _Agent;
   
    private EnemyAnimations _Animations;
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Animations = GetComponent<EnemyAnimations>();
        _Target = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Transform>();
    }

    private void Update()
    {
        ChasingToTarget();
    }

    private void ChasingToTarget()
    {
        _Distance_To_Target = (_Target.position - transform.position).magnitude;
        Vector3 _destination = _Target.position;

        transform.LookAt(_Target);
        if (_Distance_To_Target > _Agent.stoppingDistance)
        {
            _Animations.MovementAnimation();
            _Agent.destination = _destination;
        }   
        else
        {
            _Animations.AttackAnimation();
        }
    }

    public void StartDis()
    {
        StartCoroutine(AgentDisable());
    }
    private IEnumerator AgentDisable()
    {
        yield return new WaitForSeconds(1.5f);
        _Agent.enabled = false;
    }
}
