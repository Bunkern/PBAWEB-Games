using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberToGuess : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;

    private System.Random random = new System.Random();
    public int numberToGuess;

    //There can be only one
    public static int playerScore;
    public static string playerName;

    // Start is called before the first frame update
    void Start()
    {
        numberToGuess = random.Next(1, 10);
    }

    //When the submit button is activated
    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    //Post data to database
    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Post("https://pba-web-52d02.firebaseio.com/.json", user);
    }

}
