using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 _dir = Vector2.zero;
    [SerializeField]
    private float _speed = 80;
    [SerializeField]
    private Rigidbody2D _rb2d = null;
    [SerializeField]
    private EMovementControl _control = EMovementControl.Arrows;
    private CreateObj _createObj = null;

    // Use this for initialization
    void Start()
    {
        //--Get Component if not set--//
        if (!_rb2d)
            _rb2d = GetComponent<Rigidbody2D>();
        _createObj = GetComponent<CreateObj>();
    }

    // Update is called once per frame
    void Update()
    {
        //--Reset direction--//
        _dir.x = 0;
        _dir.y = 0;

        //--Update user input--//
        switch (_control)
        {
            case EMovementControl.Arrows:
                if (Input.GetKey(KeyCode.UpArrow))
                    _dir.y += 1;
                if (Input.GetKey(KeyCode.DownArrow))
                    _dir.y -= 1;
                if (Input.GetKey(KeyCode.LeftArrow))
                    _dir.x -= 1;
                if (Input.GetKey(KeyCode.RightArrow))
                    _dir.x += 1;
                if (Input.GetKeyDown(KeyCode.RightControl) && _createObj != null)
                    _createObj.Create();
                break;
            case EMovementControl.WASD:
                if (Input.GetKey(KeyCode.W))
                    _dir.y += 1;
                if (Input.GetKey(KeyCode.S))
                    _dir.y -= 1;
                if (Input.GetKey(KeyCode.A))
                    _dir.x -= 1;
                if (Input.GetKey(KeyCode.D))
                    _dir.x += 1;
                if (Input.GetKeyDown(KeyCode.Space) && _createObj != null)
                    _createObj.Create();
                break;
        }

        //--Normalize vector--//
        _dir.Normalize();
        //--Also possible--// 
        //_dir = _dir.normalized;

        //--Move object with the rigidbody component--//
        _rb2d.velocity = _dir * _speed * Time.deltaTime;
    }
}
