using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private AInputController _inputController;
    [SerializeField]
    private float _speed = 150f;
    [SerializeField]
    private Rigidbody2D _rgbd;
    [SerializeField]
    private CreateObject _createObject;
    private Vector2 _spawnPos;

    // Use this for initialization
    private void Start()
    {
        if (_rgbd == null)
            _rgbd = GetComponent<Rigidbody2D>();
        _spawnPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inputController != null)
        {
            //--Update Movement--//
            Vector2 dir = _inputController.GetMoveDir();

            //--Update rotation--//
            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            //--Apply velocity--//
            if (_rgbd != null)
                _rgbd.velocity = dir * _speed * Time.deltaTime;

            //--Check if shoot is pressed and spawn bullet--//
            if (_inputController.IsShootDown() && _createObject != null)
                _createObject.SpawnObject(_inputController.GetShootDir());

        }
    }

    public void SetInputController(AInputController ctrl)
    {
        _inputController = ctrl;
    }

    public AInputController GetInputController()
    {
        return _inputController;
    }

    public void Reset()
    {
        transform.position = _spawnPos;
    }
}
