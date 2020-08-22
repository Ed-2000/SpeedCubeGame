using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float             Speed {
        get { return _speed; }
        set
        {
            if (value >= 0)
            {
                _speed = value;
            }
        }
    }

    [SerializeField] private float  _xMoveKoef = 1; //коеф руху вліво/вправо
    [SerializeField] private float  _jumpSpeed = 15; //коеф руху вліво/вправо

    private static float            _speed;
    private Vector3                 _newPos;
    private float                   _maxSpeed;
    private bool                    _onGround;
    private int                     _targetLinePos;
    private int                     _moveDirection;
    private GameObject              _camera;
    private GameObject              _jumpButton;

    private void Start()
    {
        _speed = 8f;
        _maxSpeed = 20f;
        _onGround = true;
        _targetLinePos = 0;

        _jumpButton = GameObject.Find("SpecialButton");
        _camera = Camera.main.gameObject;
    }

    private void FixedUpdate()
    {
        Move();

        transform.position = _newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        //переміщення на початок
        if (other.name == "Finish")
        {
            float dist = _camera.transform.position.z - transform.position.z;
            _camera.GetComponent<CameraMove>().CameraTeleportTo(dist);

            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;
        }

        //зменшення швидкості
        if (other.name == "Start")
        {
            _speed = 5;
        }

        //занулення значень
        if (other.name == "StartBox")
        {
            _onGround = true;
            _targetLinePos = 0;
        }

        //
        if (other.name == "FloorCollider")
        {
            Turn.TurnOn(_jumpButton, true);
            _onGround = true;
        }
    }

    private void Move()
    {
        //рух вперед 
        transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);

        //рух по осі Х (вліво/вправо)
        _newPos = transform.position;

        if (_moveDirection != 0)
        {
            _targetLinePos += _moveDirection;

            if (_targetLinePos < -2 || _targetLinePos > 2)
            {
                _targetLinePos -= _moveDirection;
            }

            _moveDirection = 0;

            if (_speed <= _maxSpeed)
            {
                _speed += _speed * 0.01f;
            }
        }

        _newPos.x = Mathf.Lerp(_newPos.x, _targetLinePos, 8 * _xMoveKoef * Time.deltaTime);
    }

    public void Jump()
    {
        if (_onGround)
        {
            Turn.TurnOn(_jumpButton);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        }                 
        else
        {
            Turn.TurnOn(_jumpButton);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * _jumpSpeed, ForceMode.Impulse);
        }

        if (_speed <= _maxSpeed)
        {
            _speed += _speed * 0.01f;
        }

        _onGround = !_onGround;
    }

    public void СhangeMoveLine(int direction)
    {
        _moveDirection = direction;
    }
}