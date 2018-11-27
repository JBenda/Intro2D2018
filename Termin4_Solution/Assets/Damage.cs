using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private float _damageOnEnter;
    [SerializeField]
    private float _damageOnStay;
    [SerializeField]
    private float _damageOnExit;

    private float _damageOverTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _damageOverTime = 0;
        if (collision.gameObject.tag == "Player")
        {
            Health player = collision.gameObject.GetComponent<Health>();
            if (player != null)
            {
                player.AddDamage(_damageOnEnter);
                _damageOverTime += _damageOnEnter;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health player = collision.gameObject.GetComponent<Health>();
        if (player != null)
        {
            player.AddDamage(_damageOnStay);
            _damageOverTime += _damageOnStay;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Health player = collision.gameObject.GetComponent<Health>();
        if (player != null)
        {
            player.AddDamage(_damageOnExit);
            _damageOverTime += _damageOnExit;
        }

        if (_damageOverTime > 0)
            Debug.Log("Damage: " + _damageOverTime);
        else if (_damageOverTime < 0)
            Debug.Log("Healing: " + _damageOverTime * -1);
    }

}
