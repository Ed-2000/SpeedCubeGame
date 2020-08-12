using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private static Text _coins;

    private void Start()
    {
        _coins = GameObject.Find("Coins").GetComponent<Text>();
    }

    public static void ShowMoney()
    {
        _coins.text = (Player.Singleton.AllCoins).ToString() + "$";
    }
}
