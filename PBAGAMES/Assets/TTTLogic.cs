using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTTLogic : MonoBehaviour
{
    public Text scoreText;
    public Text text;
    public Text noOfGamesText;

    public InputField nameText;

    public int turn;
    public int turnCount;
    public int noOfGames;
    public int score;

    //There can be only one
    public static string playerName;
    public static int playerScore;
    public static string playerGame = "Tick_Tack_Toe";
    public static int playerNoOfGames;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Can you Best the AI ?";
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(2);
        NewGame();
    }

    public void GetNameInput()
    {
        playerName = nameText.text;
    }

    void NewGame()
    {
        Start();
    }

    public void Submit()
    {

        if (playerNoOfGames == 0)
        {
            text.text = "You need to play a game, before you can upload";

        }
        if (playerNoOfGames > 0)
        {
            if (playerName == "")
            {
                text.text = "You need to input player name, before you can upload" + "\n" + "A new game will start soon.";
            }
            else if (!playerName.Equals(""))
            {
                PostToDatabase();
            }
        }
    }

    //Post data to database
    public void PostToDatabase()
    {
        RPSUser user = new RPSUser();
        RestClient.Post("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);
    }
}
