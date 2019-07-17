using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // this function reads the build index of the game and ads one when the button is pressed and the changes scene
    }

    public void quitGame ()
    {
        Application.Quit();
        Debug.Log("quit"); //this allows to quit the game, however it doesn't work in the unity engine, therefore I put a debug log function in to make sure that the function worked
    }

    public void RetryGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //this function takes you back to the game 
    }
}
    