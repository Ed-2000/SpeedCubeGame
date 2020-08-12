using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float       _speed = 4;
    private Transform   _player;
    private Vector3     _position;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 currentPosition = _player.position;
        currentPosition.y = transform.position.y;
        currentPosition.z -= 3;
        transform.position = Vector3.Lerp(transform.position, currentPosition, _speed * Time.deltaTime);
    }

    public void CamerTeleportTo(float dist)
    {
        Vector3 pos = transform.position;
        pos.z = dist;
        transform.position = pos;
    }
}
