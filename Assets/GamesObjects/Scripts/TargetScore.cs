using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScore : MonoBehaviour
{
    public Text scoreUI;
    public int currentScore;

    void Start()
    {
        currentScore = 0;
    }

    void Update()
    {
        
    }
    //Basic function to increase score when a target is destroyed.
    //Grabs the points variable assigned to each individual target and updates the UI.
    public void increaseScore(int points)
    {
        currentScore = currentScore + points;
        scoreUI.text = currentScore.ToString();
    }
}
