using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateStartObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[]   _obstacles;
    public List<int>                        _indicesForActivatingObstacles;

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _obstacles.Length; i++)
        {
            if (_obstacles[i].activeSelf) _obstacles[i].SetActive(false);
        }

        //for (int i = 0; i < _indicesForActivatingObstacles.Count; i++)
        //{
        //    _obstacles[_indicesForActivatingObstacles[i]].SetActive(false);
        //}
        //_indicesForActivatingObstacles.Clear();
    }
}
