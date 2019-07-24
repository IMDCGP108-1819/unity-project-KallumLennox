using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // When this code is run, the next scene in the build index will be made active. 
    }

    public void quitGame ()
    {
        Application.Quit();
        Debug.Log("quit"); //this allows to quit the game, however it doesn't work in the unity engine, therefore I put a debug log function in to make sure that the function worked
    }

    public void RetryGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // This function will take you back and load the previous scene in the build index. 
    }
}
    