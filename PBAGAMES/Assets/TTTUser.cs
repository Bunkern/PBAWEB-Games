using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TTTUser 
{
    public string userName;
    public string userGame;
    public int userScore;
    public int userNoOfGames;

    public TTTUser()
    {
        userName = TTTLogic.playerName;
        userScore = TTTLogic.playerScore;
        userGame = TTTLogic.playerGame;
        userNoOfGames = TTTLogic.playerNoOfGames;
    }
}
