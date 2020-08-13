﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    [SerializeField] private GameObject[]       _obstacles;
    [SerializeField] private bool               _IsFloor;
    [SerializeField] private int                _obstacleNumber = 2;

    private List<int>                           _indicesForActivatingObstacles;
    private float                               _distanceForActivate;
    private float                               _distanceForDeactivate;

    private void Start()
    {
        _indicesForActivatingObstacles = new List<int>();

        for (int i = 0; i < _obstacles.Length; i++)
        {
            if (_obstacles[i].activeSelf)   _obstacles[i].SetActive(false);
        }

        if (_IsFloor)
        {
            _distanceForActivate = 1;
            _distanceForDeactivate = -1;
        }
        else
        {
            _distanceForActivate = -1;
            _distanceForDeactivate = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            while (_indicesForActivatingObstacles.Count < _obstacleNumber)
            {
                int index = Random.Range(0, _obstacles.Length);

                if (!EntryCheck(index, _indicesForActivatingObstacles))
                {
                    _indicesForActivatingObstacles.Add(index);
                }
            }

            for (int i = 0; i < _indicesForActivatingObstacles.Count; i++)
            {
                _obstacles[_indicesForActivatingObstacles[i]].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < _indicesForActivatingObstacles.Count; i++)
            {
                _obstacles[_indicesForActivatingObstacles[i]].SetActive(false);
            }
            _indicesForActivatingObstacles.Clear();
        }
    }

    private bool EntryCheck(int number, List<int> numbers)
    {
        foreach (var num in numbers)
        {
            if (number == num) return true;
        }

        return false;
    }
}
