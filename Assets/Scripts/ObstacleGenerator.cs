using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private List<GameObject>    _obstacles;
    private List<int>           _obstacleIndexes;
    private float               _obstacleSpeed;
    private int                 _obstacleNumberLimit;
    private int                 _obstacleNumber;

    private void Start()
    {
        _obstacleNumberLimit = 2;
        _obstacleNumber = 0;

        _obstacles = new List<GameObject>();
        _obstacleIndexes = new List<int>();

        foreach (Transform child in transform)
        {
            _obstacles.Add(child.transform.gameObject);
            _obstacles[_obstacles.Count - 1].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _obstacleSpeed = 0.5f / Player.Speed;
        _obstacleNumber = Random.Range(0, _obstacleNumberLimit + 1);

        for (int i = 0; i < _obstacleNumber; i++)
        {
            _obstacleIndexes.Add(Random.Range(0, _obstacles.Count - 1));
            _obstacles[_obstacleIndexes[i]].SetActive(true);
            ActivateObstacle(_obstacles[_obstacleIndexes[i]]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _obstacleIndexes.Count; i++)
        {
            DeactivateObstacle(_obstacles[_obstacleIndexes[i]]);
        }
        _obstacleIndexes.Clear();
    }

    private void ActivateObstacle(GameObject obstacle)
    {
        if (obstacle.transform.position.y == 0)
            TeleportTo(obstacle, 1);
        else if (obstacle.transform.position.y == 4)
            TeleportTo(obstacle, 3);
    }

    private void DeactivateObstacle(GameObject obstacle)
    {
        if (obstacle.transform.position.y == 1)
            TeleportTo(obstacle, 0);
        else if (obstacle.transform.position.y == 3)
            TeleportTo(obstacle, 4);
        obstacle.SetActive(false);
    }

    private void TeleportTo(GameObject obstacle, float posY)
    {
        Vector3 newPos = obstacle.transform.position;
        newPos.y = posY;
        obstacle.transform.position = newPos;
    }
}