using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpeedCounter : MonoBehaviour
{
    [SerializeField] private Text _speedText;

    private float _oldSpeed;

    private void Start()
    {
        _oldSpeed = PlayerMove.Speed;
    }

    private void Update()
    {
        if (PlayerMove.Speed != _oldSpeed)
        {
            PrintSpeed();
            _oldSpeed = PlayerMove.Speed;
        }
    }

    public void PrintSpeed()
    {
        _speedText.text = "speed:" + Mathf.Round(PlayerMove.Speed).ToString();
    }
}