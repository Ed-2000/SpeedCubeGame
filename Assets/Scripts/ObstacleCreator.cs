using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    [SerializeField] private GameObject[]       _obstacles;
    [SerializeField] private bool               _IsFloor;
    [SerializeField] private int                _obstacleNumberLimit = 2;

    private List<int>                           _indicesForActivatingObstacles;
    private int                                 _obstacleNumber = 2;
    private float                               _distanceForActivate;
    private float                               _distanceForDeactivate;

    private void Start()
    {
        _indicesForActivatingObstacles = new List<int>();

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
        print("InTrigger");

        //_obstacleNumber = Random.Range(0, _obstacleNumberLimit + 1);

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
            TeleportTo(_obstacles[_indicesForActivatingObstacles[i]], _distanceForActivate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _indicesForActivatingObstacles.Count; i++)
        {
            TeleportTo(_obstacles[_indicesForActivatingObstacles[i]], _distanceForDeactivate);
            _obstacles[_indicesForActivatingObstacles[i]].SetActive(false);
        }
        _indicesForActivatingObstacles.Clear();
    }

    private void TeleportTo(GameObject obstacle, float dist)
    {
        Vector3 newPos = obstacle.transform.position;
        newPos.y += dist;
        obstacle.transform.position = newPos;
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
