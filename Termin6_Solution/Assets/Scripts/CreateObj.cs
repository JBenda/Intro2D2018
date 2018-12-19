using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{

    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _reloadTime;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void Create()
    {
        if (_ball && _timer >= _reloadTime)
        {
            GameObject obj = Instantiate(_ball);
            obj.transform.position = transform.position;
            _timer = 0;

            if (_target)
            {
                Vector2 dir = _target.transform.position - transform.position;
                Rigidbody2D rgbd = obj.GetComponent<Rigidbody2D>();
                dir.Normalize();

                obj.transform.position += new Vector3(dir.x, dir.y);
                rgbd.velocity = dir * _speed;
            }
        }
    }

}
