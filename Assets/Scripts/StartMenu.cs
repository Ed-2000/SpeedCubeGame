using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCloseHandler(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void OnOpenHandler(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void OnQuitHendler()
    {
        Application.Quit();
    }
}
