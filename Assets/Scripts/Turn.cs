using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public static void TurnOn(GameObject turnObject, bool up = false)
    {
        if (!up)
        {
            turnObject.transform.rotation *= Quaternion.Euler(0, 0, 180);
        }
        else
        {
            turnObject.transform.rotation = Quaternion.identity;
        }
    }
}