using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //manages scene.

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Gets the next scene in Queue in build settings.
        }
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game app
    }
}
