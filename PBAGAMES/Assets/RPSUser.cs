using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RPSUser
{
    public string userName;
    public string userGame;
    public int userScore;
    public int userNoOfGames;

    public RPSUser()
    {
        userName = RPSLogic.playerName;
        userScore = RPSLogic.playerScore;
        userGame = RPSLogic.playerGame;
        userNoOfGames = RPSLogic.playerNoOfGames;
    }
}
