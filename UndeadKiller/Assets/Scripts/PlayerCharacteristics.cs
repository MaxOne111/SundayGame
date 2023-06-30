using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private int _Health;
    public void GetDamage(int _damage)
    {
        _Health -= _damage;
    }      
}
