using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    [SerializeField]
    private float _force = 200;
    [SerializeField]
    private float _offset = 0.7f;
    [SerializeField]
    private GameObject _spawnObject;

    public void SpawnObject(Vector2 dir)
    {
        if (_spawnObject != null)
        {
            //--Create object and set position and rotation--//
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject obj = Instantiate(_spawnObject);
            obj.transform.position = transform.position;
            obj.transform.position += new Vector3(dir.x, dir.y) * _offset;
            obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //--Apply velocity--//
            Rigidbody2D rgbd = obj.GetComponent<Rigidbody2D>();
            rgbd.velocity = dir * _force;
        }
    }

}
