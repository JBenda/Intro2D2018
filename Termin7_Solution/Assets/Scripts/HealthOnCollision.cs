using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnCollision : MonoBehaviour
{

    [SerializeField]
    private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle":
                Destroy(gameObject);
                break;
            case "Player":
                Health health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                    health.AddHealth(-_damage);
                Destroy(gameObject);
                break;
        }
    }

}
