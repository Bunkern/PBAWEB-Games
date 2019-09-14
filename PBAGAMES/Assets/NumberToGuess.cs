using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberToGuess : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;
    public InputField numberText;

    private System.Random random = new System.Random();
    public int numberToGuess;
    public int guessTime;

    //There can be only one
    public static string playerNumber;
    public static string playerName;
    public static int playerScore;
    public static string playerGame;

    // Start is called before the first frame update
    void Start()
    {
        numberToGuess = random.Next(1, 10);
    }

    //When the submit button is activated
    public void OnSubmit()
    {
        if (guessTime < 3) {
            playerName = nameText.text;
            playerNumber = numberText.text;
            guessTime++;
            if (guessTime == 3)
            {
                PostToDatabase();
            }
            
        }
        
    }

    //Post data to database
    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Post("https://pba-web-52d02.firebaseio.com/.json", user);
    }

}
