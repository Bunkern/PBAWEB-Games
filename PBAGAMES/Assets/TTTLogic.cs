using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTTLogic : MonoBehaviour
{
    public Text[] buttonList;

    public Text scoreText;
    public Text text;
    public Text noOfGamesText;

    public InputField nameText;

    private string playerSide;

    public int noOfGames;
    public int score;
    public int noOfMoves;
    public int winner;

    //There can be only one
    public static string playerName;
    public static int playerScore;
    public static string playerGame = "Tick_Tack_Toe";
    public static int playerNoOfGames;

    // Start is called before the first frame update
    void Start()
    {
        playerSide = "X";
        text.text = "Can you Best the AI ?";
        winner = 1;
    }

    //Set up when the game starts.
    private void Awake()
    {
        playerSide = "X";
        SetControllerOnButtons();
    }

    //sets the buttons text for the current playerside.
    void SetControllerOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<ButtonLogic>().SetController(this);
        }
    }

    //Returns an X or O, based on players turn.
    public string GetPlayerSide()
    {
        return playerSide;
    }

    //End current players turn.
    public void EndTurn()
    {
        noOfMoves++;
        if (buttonList[0].text == buttonList[1].text && buttonList[1].text == buttonList[2].text && buttonList[0].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[3].text == buttonList[4].text && buttonList[4].text == buttonList[5].text && buttonList[3].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[6].text == buttonList[7].text && buttonList[7].text == buttonList[8].text && buttonList[6].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[0].text == buttonList[3].text && buttonList[3].text == buttonList[6].text && buttonList[0].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[1].text == buttonList[4].text && buttonList[4].text == buttonList[7].text && buttonList[1].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[2].text == buttonList[5].text && buttonList[5].text == buttonList[8].text && buttonList[2].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[0].text == buttonList[4].text && buttonList[4].text == buttonList[8].text && buttonList[0].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (buttonList[2].text == buttonList[4].text && buttonList[4].text == buttonList[6].text && buttonList[2].text == playerSide)
        {
            score = 3;
            PlayerWins();
            winner = 0;
            GameOver();
        }
        else if (noOfMoves == 9 && winner == 1)
        {
            text.text = "It's A Draw !!. You get 1 Point";
            score++;
            playerScore = playerScore + score;
            GameOver();
        }
        else
        {
            ChangeSides();
            if (playerSide == "O")
            {
                ComputerTurn();
            }
        }        
    }

    void ComputerTurn()
    {
        bool foundEmptySPot = false;

        while (!foundEmptySPot)
        {
            int rndNumber = Random.Range(0, 9);
            if (buttonList[rndNumber].GetComponentInParent<Button>().IsInteractable())
            {
                buttonList[rndNumber].GetComponentInParent<Button>().onClick.Invoke();
                foundEmptySPot = true;
            }

        }
    }

    //Changes the player´s turn.
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void PlayerWins()
    {
        if (playerSide == "X")
        {
            text.text = "Cool you won !!. You get 3 Point";
            playerScore = playerScore + score;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
        }
        if (playerSide == "O")
        {
            text.text = "Darn You lost. You don't get any points!";
        }
    }

    //When it is a draw or one player has won.
    void GameOver()
    {
        noOfGames++;
        playerNoOfGames = noOfGames;
        scoreText.text = "Score: " + System.Convert.ToString(playerScore);
        noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
            StartCoroutine(WaitAndRestart());
        }
    }

    //Game will waif for 2 seconds and then call the NewGame function.
    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(2);
        noOfMoves = 0;
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
        NewGame();
    }

    //Gets the input from the name input field.
    public void GetNameInput()
    {
        playerName = nameText.text;
    }

    //Calles the Start function.
    void NewGame()
    {
        Start();
    }

    //Checks if there has been played a game and if there has been entered a name in the name input field. If so it calls the PostToDatabase function.
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
