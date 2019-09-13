using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberToGuess : MonoBehaviour
{

    private System.Random random = new System.Random();
    public int numberToGuess;

    // Start is called before the first frame update
    void Start()
    {
        numberToGuess = random.Next(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
