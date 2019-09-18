using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSLogic : MonoBehaviour
{
    public Text scoreText;
    public Text text;
    public Text noOfGamesText;
    public Text aiText;

    private System.Random random = new System.Random();

    public InputField nameText;

    public int aiNumber;
    public int playerChoice;
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
        aiNumber = random.Next(1, 4);
        text.text = "Can you Best the AI ?";
        aiText.text = "AI Choice";
    }

    //Will send the player choice to the CompareChoice function.
    public void RockChoice()
    {
        playerChoice = 1;
        CompareChoice();
    }

    //Will send the player choice to the CompareChoice function.
    public void PapirChoice()
    {
        playerChoice = 2;
        CompareChoice();
    }

    //Will send the player choice to the CompareChoice function.
    public void ScissorsChoice()
    {
        playerChoice = 3;
        CompareChoice();
    }

    //Will check who wins from the choices the player made and the random number generated for the AI.
    void CompareChoice()
    {
        DisplayAIChoice();
        if (aiNumber == playerChoice)
        {
            text.text = "It´s a Draw. You both get a point" + "\n" + "A new game will start soon";
            score++;
            noOfGames++;          
        }

        if (aiNumber == 1 && playerChoice == 2)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score+3;
            noOfGames++;
        }

        if (aiNumber == 1 && playerChoice == 3)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;
        }

        if (aiNumber == 2 && playerChoice == 3)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score + 3;
            noOfGames++;
        }

        if (aiNumber == 2 && playerChoice == 1)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;
        }
        if (aiNumber == 3 && playerChoice == 1)
        {
            text.text = "You Win. You 3 points" + "\n" + "A new game will start soon";
            score = score + 3;            
            noOfGames++;
            playerNoOfGames = noOfGames;
        }

        if (aiNumber == 3 && playerChoice == 2)
        {
            text.text = "You Loose. You do not get any points" + "\n" + "A new game will start soon";
            noOfGames++;            
        }
        playerScore = score;
        playerNoOfGames = noOfGames;
        scoreText.text = "Score: " + System.Convert.ToString(playerScore);
        noOfGamesText.text = "Number of Games played: " + System.Convert.ToString(playerNoOfGames);
        StartCoroutine(WaitAndRestart());
    }

    //Will display the choice for the ai in the text field.
    public void DisplayAIChoice()
    {
        if (aiNumber == 1)
        {
            aiText.text = "AI Choice is ROCK";
        }

        if (aiNumber == 2)
        {
            aiText.text = "AI Choice is Papir";
        }

        if (aiNumber == 3)
        {
            aiText.text = "AI Choice is Scissors";
        }
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
        StartCoroutine(WaitAndRestart());
    }

    //Post data to database
    public void PostToDatabase()
    {
                RPSUser user = new RPSUser();
                RestClient.Post("https://pba-web-52d02.firebaseio.com/" + playerName + ".json", user);         
        }   
}
