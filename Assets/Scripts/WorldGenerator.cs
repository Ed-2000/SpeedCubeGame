using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _groundElementPrefab;

    private List<GameObject>    _groundElements;
    private GameObject          _world;
    private GameObject          _startGroundElements;
    private GameObject          _player;
    private int                 _numberOfGroundElements = 8;
    private int                 _iGlobal = 0;
    private float               _lengthOfGroundElement = 6;


    private void Awake()
    {
        _groundElements = new List<GameObject>();
        _groundElements.Add(GameObject.Find("GroundElementZero"));
        _world = GameObject.Find("World");
        _startGroundElements = GameObject.Find("StartGroundElements");
        _player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 1; i < _numberOfGroundElements; i++)
        {
            GameObject newGroundElement = Instantiate(_groundElementPrefab);
            newGroundElement.transform.SetParent(_world.transform); 
            _groundElements.Add(newGroundElement);
            _groundElements[i].transform.position = _groundElements[i-1].transform.position + new Vector3(0, 0, _lengthOfGroundElement);
        }
    }

    private void Update()
    {
        if (_iGlobal >= _numberOfGroundElements)
        {
            _iGlobal = 0;
        }

        if (_groundElements[_iGlobal].transform.position.z < _player.transform.position.z - _lengthOfGroundElement - 10)
        {
            if (_startGroundElements.activeSelf)
            {
                _startGroundElements.SetActive(false);
            }

            _groundElements[_iGlobal].transform.position += new Vector3(0, 0, _lengthOfGroundElement * _numberOfGroundElements);
            _iGlobal++;
        }
    }
}