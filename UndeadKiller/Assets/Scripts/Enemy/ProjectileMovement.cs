using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [SerializeField] private int _Damage;

    private void Start()
    {
        Destroy(gameObject, 3);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {      
            if (other.gameObject.GetComponent<PlayerCharacteristics>())
            {
                other.gameObject.GetComponent<PlayerCharacteristics>().GetDamage(_Damage);
                Destroy(gameObject);
            }        
       
    }
}
