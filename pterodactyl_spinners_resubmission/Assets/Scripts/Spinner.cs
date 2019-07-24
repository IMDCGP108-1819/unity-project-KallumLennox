using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //This function allows for manipulation of the scenes in the code. Allowing to decide which scenes are are on screen at anytime. 

public class Spinner : MonoBehaviour
   
{
    private Scene  Scene;

    // A private variable that is only accessed by memebers of the same class
    // A void function is a function that will not return any values or information

    private void OnTriggerEnter2D(Collider2D collision) // This is a private function used to detect collisions with another object. 
       
    {
        if (collision.CompareTag("Player")) // If an object with tagged "Player" collides with the Spinner,
        {
            SceneManager.LoadScene("Level1"); // The Level will reload, thus starting the player back at the start of the level. 
        }
    }
}