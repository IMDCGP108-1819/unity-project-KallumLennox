using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //This function allows for manipulation of the scenes in the code. Allowing to decide which scenes are are on screen at anytime. 

public class Spinner : MonoBehaviour
   
{// these functions reset the level if a player hit one of the spinners
    private Scene  Scene;

    
    private void OnTriggerEnter2D(Collider2D collision) 
       
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}