using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script uses a Singleton to keep track of the high score, and is what we created back in the MissionDemolition game

public class HighScoreManager
{
    // Static variable for the single instance of SingletonHighScore
    private static HighScoreManager singleInstance;

    // Static property used to retrieve the single instance of SingletonHighScoree
    public static HighScoreManager Instance
    {
        get
        {
            // If we don't have the single instance, create it
            if (singleInstance == null)
                singleInstance = new HighScoreManager();
            // Return the single instance
            return singleInstance;
        }
    }

    // Private constructor that restricts the creation of a HighScoreManager
    // to the HighScoreManager class itself
    private HighScoreManager()
    {
        singleInstance = this;
    }

    // Public instance variables for storing the current instance of score and HighScore
    public int score;
    public int highScore;

    // Method to increment the score
    public void AddScore()
    {
        score += 100; //Awards player 100 points per enemy killed
    }

    // Method to check if the current score is less than existing HighScore
    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    // Property to get the current score
    public int CurrentScore
    {
        get { return score; }
    }

    // Method to reset the score
    public void ResetScore()
    {
        score = 0;
    }
}
