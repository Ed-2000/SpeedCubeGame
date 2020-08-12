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
        _oldSpeed = Player.Speed;
    }

    private void Update()
    {
        if (Player.Speed != _oldSpeed)
        {
            PrintSpeed();
            _oldSpeed = Player.Speed;
        }
    }

    public void PrintSpeed()
    {
        _speedText.text = "speed:" + Mathf.Round(Player.Speed).ToString();
    }
}