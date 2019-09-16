﻿using Proyecto26;
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

    private void Awake()
    {
        playerSide = "X";
        SetControllerOnButtons();
    }

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

    }

    //Game will waif for 2 seconds and then call the NewGame function.
    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(2);
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
