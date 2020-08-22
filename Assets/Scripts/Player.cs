using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player                    Singleton   { get; private set; }

    public float                            distance;
    public int                              earnedСoins;

    [SerializeField] private GameObject     _destroyedBodyPrefab;
    [SerializeField] private UnityEvent     _deadAudioEvent;

    private GameObject                      _body;
    private GameObject                      _destroyedBody;
    private GameObject                      _buttons;
    private bool                            _isLeave;
    private Vector3                         _startPos;
    private Vector3                         _startCameraPos;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _isLeave = true;
        _startPos = transform.position;
        _startCameraPos = Camera.main.transform.position;
        _buttons = GameObject.Find("Buttons");

        _body = GameObject.Find("Body");
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Obstacle") Dead();
    }

    public void Restart()
    {
        transform.position = _startPos;
        Camera.main.transform.position = _startCameraPos;
        PlayerMove.Speed = 8f;
        DeadMenu.ActivationControl(false);
        _body.SetActive(true);
        Destroy(_destroyedBody);
        _buttons.SetActive(true);
        _isLeave = true;
    }

    private void Dead()
    {
        if (_isLeave)
        {
            _destroyedBody = Instantiate(_destroyedBodyPrefab);
            _destroyedBody.transform.parent = transform;
            _destroyedBody.transform.localPosition = Vector3.zero;

            _isLeave = false;
        }
        _body.SetActive(false);
        PlayerMove.Speed = 0;
        _deadAudioEvent.Invoke();

        DeadMenu.ActivationControl(true);
        _buttons.SetActive(false);
    }
}