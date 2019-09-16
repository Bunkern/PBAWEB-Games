using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{

    private TTTLogic myController;
    public Button myButton;
    public Text buttonText;
    public string playerSide;


    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
    }

    //  
    public void SetText()
    {
        buttonText.text = myController.GetPlayerSide();
        myButton.interactable = false;
        //myController.EndTurn();
    }

    public void SetController(TTTLogic controller)
    {
        myController = controller;
    }
}
