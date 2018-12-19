using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth;

    public void AddHealth(float value)
    {
        _health += value;
        if(_health <= 0)
        {
            _health = _maxHealth;

            PlayerController ctrl = GetComponent<PlayerController>();
            if (ctrl != null)
                ctrl.Reset();
        }

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    
}
