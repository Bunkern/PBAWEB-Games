using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGANBtn (string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    public void StartSSPBtn (string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    public void StartTTTBtn (string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    public void QuitGameBtn ()
    {
        Application.Quit();
    }

    public void BackBtn (string MenuScene)
    {
        SceneManager.LoadScene(MenuScene);
    }

}
