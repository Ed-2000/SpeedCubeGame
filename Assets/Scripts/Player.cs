using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player    Singleton   { get; private set; }
    public static float     Speed       { get { return _speed; } }
    public int              AllCoins    { get { return _allCoins; } }

    public float            distance;
    public int              earnedСoins;

    [SerializeField] private UnityEvent     _deadAudioEvent;
    [SerializeField] private GameObject     _camera;
    
    private static float    _speed;
    private int             _allCoins;
    private float           _maxSpeed;
    private GameObject      _body;
    private GameObject      _destroyedBody;
    private bool            _onGround;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _speed = 5f;
        _maxSpeed = 20f;
        _onGround = true;

        _body = GameObject.Find("Body");
        _destroyedBody = GameObject.Find("DestroyedBody");

        _destroyedBody.SetActive(false);
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);
        if (transform.position.z >= 100)
        {
            float dist = _camera.transform.position.z - transform.position.z;

            _camera.GetComponent<CameraMove>().CamerTeleportTo(dist);
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") Dead();
    }

    private void Dead()
    {
        _deadAudioEvent.Invoke();
        _speed = 0;
        distance = Mathf.RoundToInt(transform.position.z);

        if (distance > 100) earnedСoins = Mathf.RoundToInt(distance + (distance * ((distance - (distance % 100)) / 100)));
        earnedСoins = Mathf.RoundToInt(earnedСoins / 100);

        _allCoins += earnedСoins;

        _body.SetActive(false);
        _destroyedBody.SetActive(true);
        DeadMenu.ActiveDeadMenu();
        GameObject.Find("Buttons").SetActive(false);
    }

    public void Move(string direction)
    {
        Vector3 newPos = transform.position;

        switch (direction)
        {
            case "right":
                newPos.x += 1;
                break;
            case "left":
                newPos.x += -1;
                break;
            case "up":
                if (_onGround)
                {
                    newPos.y = 3f;
                    _onGround = !_onGround;
                }
                else
                {
                    newPos.y = 1f;
                    _onGround = !_onGround;
                }
                break;
        }

        if (newPos.x > 2)
            newPos.x = 2;
        else if (newPos.x < -2)
            newPos.x = -2;

        if (_speed <= _maxSpeed)
        {
            _speed += _speed * 0.01f;
        }
        transform.position = newPos;
    }
}