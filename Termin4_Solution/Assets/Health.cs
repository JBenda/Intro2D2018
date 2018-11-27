using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth;


    public void AddDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Debug.Log("I'm dead...");
            _health = 0;
        }

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

}
