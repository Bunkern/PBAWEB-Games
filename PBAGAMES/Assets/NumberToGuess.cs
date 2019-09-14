using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberToGuess : MonoBehaviour
{
    public Text scoreText;
    public Text text;

    public InputField nameText;

    public InputField input;

    private System.Random random = new System.Random();

    public int numberToGuess;
    public int guessTime;

    //There can be only one
    public static string playerName;
    public static int playerScore;
    public static string playerGame = "Guess_A_Number";

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
                text.text = "You Guessed it";
                playerScore = guessTime + 1;
                scoreText.text = "Score: " + System.Convert.ToString(playerScore);
            } else if (guessInt != numberToGuess)
            {
                text.text = "Guess again";
            }
        } else
        {
            text.text = "No more guesses";
        }
    }    

    //Post data to database
    public void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);
    }
}
