using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spinner : MonoBehaviour
   
{// these functions reset the level if a player hit one of the spinners
    private Scene  Scene;

    
    private void OnTriggerEnter2D(Collider2D collision) 
       
    {
        if (collision.CompareTag("Player"))
        {
            Scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level1");
        }
    }
}
