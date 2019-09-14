using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{

    public string userName;
    public int userNumber;
    public string userGame;
    public int userScore;

    public User()
    {
        userName = NumberToGuess.playerName;
 //       userNumber = NumberToGuess.playerNumber;
        userScore = NumberToGuess.playerScore;
        userGame = NumberToGuess.playerGame;
    }
}
