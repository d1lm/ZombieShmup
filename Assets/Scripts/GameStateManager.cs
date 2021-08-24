using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is a script to manage the game state and keep track of the high score

public class GameStateManager : MonoBehaviour
{
    // Static variable for the single instance of SingletonHighScore
    private static GameStateManager singleInstance;


    public static GameStateManager Instance
    {
        get
        {
            // If we don't have the single instance, create it
            if (singleInstance == null)
                singleInstance = new GameStateManager();
            // Return the single instance
            return singleInstance;
        }
    }

    // Private constructor that restricts the creation of a GameStateManager
    // to the GameStateManager class itself
    private GameStateManager()
    {
        singleInstance = this;
    }


    // Variables used to display UI text
    [Header("Set in Inspector")]
    public Text uitHighScore; // The UI text for HighScore
    public Text uitClearButton; // The UI text for the clear button
    public Text uitScore; // The UI text for the score

    // Variables for score and HighScore
    public int highScore;
    public bool noHighScore; // Flag to indicate when no HighScore exists
    //public bool resetHighScore;  // Flag to indicate when HighScore was reset by player

    // Start is called before the first frame update
    void Start()
    {
        // Check if a HighScore exists and read it in
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            noHighScore = false; // Set flag to false
            //Debug.Log("High Score does exist"); //Debug
            //Debug.Log(PlayerPrefs.GetInt("HighScore")); //Debug to display the high score with PlayerPrefs
        }
        else
        {
            noHighScore = true; // Set flag to true
            //Debug.Log("High Score does not exist"); //Debug
        }

        // Pass these HighScores into the HighScoreManager Singleton
        HighScoreManager.Instance.highScore = highScore;

        UpdateGUI();
    }

    void UpdateGUI()
    {
        // Displaying the HighScore
        // If no HighScore exists
        if (highScore == 0)
        {
            uitHighScore.text = "High Score: None"; // Display "None" if no HighScore exists
        }

        // If a HighScore does exist
        if (highScore != 0)
        {
            uitHighScore.text = "High Score: " + HighScoreManager.Instance.highScore; // Display the score for the level if it exists
        }

        // Displaying the current score
        uitScore.text = "Score: " + HighScoreManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        //UpdateHighScore();
    }

    // Method for resetting HighScore upon button press
    public void ResetHighScore()
    {
            PlayerPrefs.DeleteKey("HighScore");
            //resetHighScore = true;
            HighScoreManager.Instance.highScore = 0;
    }

    public void UpdateHighScore()
    {
        // Saving and updating the high score
        if (noHighScore == true) // If no HighScore exists, it will be set to the score of the first playthrough
        {
            highScore = HighScoreManager.Instance.CurrentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            //Debug.Log("High Score does not exist"); //Debug statement
        }
        else
        {
            // If a HighScore already exists, we check if we need to update it and update it if needed
            HighScoreManager.Instance.CheckHighScore(); //Check if high score should be updated, and update the internal score in the HighScoreManager singleton

            if (HighScoreManager.Instance.CurrentScore > highScore) //Check if the score stored within the singleton is greater than the high score from player prefs
            {
                highScore = HighScoreManager.Instance.CurrentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                //Debug.Log("High Score does exist"); //Debug statement
            }
        }

        //resetHighScore = false; // Set flag to false since player would want to keep HighScores initially
    }
}
