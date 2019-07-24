using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // Detects collisions on the collision box 
    {
        if (collision.collider.CompareTag("Player")) // If an object tagged as "Player" collised with the object
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // The next scene in the build index with become active. 
        }
    }
}
