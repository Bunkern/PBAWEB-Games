﻿using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSLogic : MonoBehaviour
{
    public Text scoreText;
    public Text text;
    public Text noOfGamesText;

    private System.Random random = new System.Random();

    public InputField nameText;

    public int aiNumber;

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
        aiNumber = random.Next(1, 3);
    }

    void Awake()
    {
        text.text = "Can you Best the AI ?";

    }

    public void RockChoice()
    {

    }

    public void PapirChoice()
    {

    }

    public void ScissorsChoice()
    {

    }

    public void GetNameInput()
    {
        playerName = nameText.text;
    }

    void CompareNumbers(int guessInt)
    {

        if (guessInt > 1)
        {

            if (guessInt == 5)
            {
                text.text = "You Guessed it" + "\n" + "a new Game has startet";
                noOfGames++;
                noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(noOfGames);

                playerScore = playerScore + score;
                scoreText.text = "Score: " + System.Convert.ToString(playerScore);
                playerNoOfGames = noOfGames;
                NewGame();
            }
            else if (guessInt != 5)
            {
                text.text = "Guess again";
            }
        }
        else
        {
            noOfGames++;
            noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(noOfGames);
            text.text = "No more guesses for this game" + "\n" + "a new Game has startet";
            playerNoOfGames = noOfGames;
            NewGame();
        }
    }

    void NewGame()
    {
        Start();
    }

    //Post data to database
    public void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);
    }
}
