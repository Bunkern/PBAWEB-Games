using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberToGuess : MonoBehaviour
{
    public Text scoreText;
    public Text text;
    public Text noOfGamesText;

    public InputField nameText;

    public InputField input;

    private System.Random random = new System.Random();

    public int numberToGuess;
    public int guessTime;
    public int noOfGames;
    public int score;
    public string game;

    //There can be only one
    public static string playerName;
    public static int playerScore;
    public static string playerGame = "Guess_A_Number";
    public static int playerNoOfGames;

    // Start is called before the first frame update
    void Start()
    {
        numberToGuess = random.Next(1, 10);
        guessTime = 3;
    }

    void Awake()
    {
        text.text = "Can you guess the correct number ?";
        
    }

    public void GetNumberInput ()
    {
        string guess = input.text;
        int guessInt = System.Convert.ToInt32(guess);
        CompareNumbers(guessInt);
         input.text = "";
    }

    public void GetNameInput()
    {
        playerName = nameText.text;
    }

    void CompareNumbers(int guessInt)
    {
        
        if (guessTime > 1) {
            guessTime--;
            if (guessInt == numberToGuess)
            {
                text.text = "You Guessed it" + "\n" + "a new Game has startet";
                noOfGames++;
                noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(noOfGames);
                score = guessTime + 1;
                playerScore = playerScore + score;
                scoreText.text = "Score: " + System.Convert.ToString(playerScore);
                playerNoOfGames = noOfGames;
                NewGame();
            } else if (guessInt != numberToGuess)
            {
                text.text = "Guess again";
            }
        } else
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
        
        GANUser user = new GANUser();
        RestClient.Post("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);
    }
}
