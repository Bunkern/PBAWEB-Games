using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSLogic : MonoBehaviour
{
    public Text scoreText;
    public Text text;
    public Text noOfGamesText;
    public Text aiText;

    private System.Random random = new System.Random();

    public InputField nameText;

    public int aiNumber;
    public int playerChoice;
    public int noOfGames;
    public int score;

    //There can be only one
    public static string playerName;
    public static int playerScore;
    public static string playerGame = "Rock_Papir_Scissors";
    public static int playerNoOfGames;

    // Start is called before the first frame update
    void Start()
    {
        aiNumber = random.Next(1, 4);
        text.text = "Can you Best the AI ?";
        aiText.text = "AI Choice";
    }

    public void RockChoice()
    {
        playerChoice = 1;
        CompareChoice();
    }

    public void PapirChoice()
    {
        playerChoice = 2;
        CompareChoice();
    }

    public void ScissorsChoice()
    {
        playerChoice = 3;
        CompareChoice();
    }

    void CompareChoice()
    {
        DisplayAIChoice();
        if (aiNumber == playerChoice)
        {
            text.text = "It´s a Draw. You both get a point" + "\n" + "A new game will start soon";
            score++;
            playerScore = score;
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine( WaitAndRestart());            
        }

        if (aiNumber == 1 && playerChoice == 2)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score+3;
            playerScore = score;
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }

        if (aiNumber == 1 && playerChoice == 3)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }

        if (aiNumber == 2 && playerChoice == 3)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score + 3;
            playerScore = score;
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }

        if (aiNumber == 2 && playerChoice == 1)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }

        if (aiNumber == 3 && playerChoice == 1)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score + 3;
            playerScore = score;
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }

        if (aiNumber == 3 && playerChoice == 2)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;
            playerNoOfGames = noOfGames;
            scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
            StartCoroutine(WaitAndRestart());
        }
    }

    public void DisplayAIChoice()
    {
        if (aiNumber == 1)
        {
            aiText.text = "AI Choice is ROCK";
        }

        if (aiNumber == 2)
        {
            aiText.text = "AI Choice is Papir";
        }

        if (aiNumber == 3)
        {
            aiText.text = "AI Choice is Scissors";
        }
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
        if (playerName == "")
        {
            text.text = "You need to input player name, before you can upload";
        }
        if (playerNoOfGames == 0)
        {
            text.text = "You need to play a game, before you can upload";
        }

        if (playerName != "")
        {
            text.text = "You did it";
        }

    }

    //Post data to database
    public void PostToDatabase()
    {
                RPSUser user = new RPSUser();
                RestClient.Post("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);         
        }   
}
