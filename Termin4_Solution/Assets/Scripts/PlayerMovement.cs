using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector2 _dir = Vector2.zero;
    [SerializeField]
    private float _speed = 80;
    [SerializeField]
    private Rigidbody2D _rb2d = null;

	// Use this for initialization
	void Start () {
        //--Get Component if not set--//
        if (!_rb2d)
            _rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //--Reset direction--//
        _dir.x = 0;
        _dir.y = 0;

        //--Update user input--//
        if (Input.GetKey(KeyCode.UpArrow))
            _dir.y += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            _dir.y -= 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            _dir.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            _dir.x += 1;

        //--Normalize vector--//
        _dir.Normalize();
        //--Also possible--// 
        //_dir = _dir.normalized;

        //--Move object with the rigidbody component--//
        _rb2d.velocity = _dir * _speed * Time.deltaTime;
	}
}
