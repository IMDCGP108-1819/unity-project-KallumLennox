using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody;//provides a reference to the rigidbody on the player
    public float MoveSpeedModifier = 0.5f;
    public float moveForce = 10f; //move Force is the force of which the player is moved when the player hits a movement key. 
    public float SoarForce = 15f;

    public bool canJump = true; //A boolean variable is a true or flase variable and this function will control if the player can jump 
    public bool InAir = false; // A true or false variable that checks if the player is jumping. 

    public Sprite PlayerIdle, PlayerFly; //This public variable defines my two sprites and lets me reference them later. 
    
    // A FixedUpdate is called at a set rate, this is set to be called every 60 frames. 
    // These functions control the horizontal movement of the player and the players ability to jump. 
    void FixedUpdate()
    {
        float newXposition = Input.GetAxis("Horizontal") * MoveSpeedModifier; 
        rigidBody.velocity = new Vector3(newXposition, rigidBody.velocity.y); 

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            rigidBody.AddForce(new Vector2(0.0f, moveForce), ForceMode2D.Impulse);

            canJump = false;
            InAir = true; //this statatement recognises when the jump button is pressed and will send the player up, while also making sure that we can jump again while in the air. 
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump == true) // this is the function that allows the player to soar when the canJump variable is true.
        {

            rigidBody.AddForce(new Vector2(0.0f, SoarForce), ForceMode2D.Impulse);

            canJump = false;
            InAir = true;
        }

        if (InAir == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = PlayerFly;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = PlayerIdle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //this function ensures that when we land back on to the platform we will be able to jump again. 
    {
        if (collision.collider.CompareTag("Platform"))
        {
            canJump = true;
            InAir = false;
        }
    }

    private void OnCollisionEnter(Collision collision) //these function stop the player going passed the games borders. 
    {
        if(collision.gameObject.CompareTag ("Border"))
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}