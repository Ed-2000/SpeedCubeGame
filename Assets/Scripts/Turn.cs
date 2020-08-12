using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public void TurnOn()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 180);
    }
}
