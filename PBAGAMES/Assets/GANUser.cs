using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GANUser
{

    public string userName;
    public string userGame;
    public int userScore;
    public int userNoOfGames;

    public GANUser( )
    {
        userName = NumberToGuess.playerName;
        userScore = NumberToGuess.playerScore;
        userGame = NumberToGuess.playerGame;
        userNoOfGames = NumberToGuess.playerNoOfGames;
    }

}
