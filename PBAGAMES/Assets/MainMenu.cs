using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string playerGame = "Guess_A_Number";

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

    public void GetScore()
    {
        GetScoreFromDatabase();
    }

    private void GetScoreFromDatabase()
    {
        RestClient.Get<User>("https://pba-web-52d02.firebaseio.com/" + playerGame + ".json");
    }
}
