using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    private static GameObject   _deadMenu;
    private static Text         _coins;
    private static Text         _traveledDistance;

    private void Start()
    {
        _deadMenu = GameObject.Find("DeadMenu").gameObject;
        //_coins = GameObject.Find("Coins").GetComponent<Text>();
        //_traveledDistance = GameObject.Find("TraveledDistance").GetComponent<Text>();

        _deadMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public static void ActivationControl(bool isActive)
    {
        _deadMenu.SetActive(isActive);

        //_traveledDistance.text = "Traveled distancee: " + Player.Singleton.distance.ToString();
        //_coins.text = "Coins: +" + Player.Singleton.earnedСoins.ToString();
    }
}