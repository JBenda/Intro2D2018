using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private Transform _following;
    private Rigidbody2D _rgbd;
    private float _speed = 60;


    private void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rgbd != null && _following != null)
        {
            Vector2 dir = _following.position - transform.position;
            dir.Normalize();

            _rgbd.velocity = dir * _speed * Time.deltaTime;
        }
    }

}
