using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody; // A reference to the Rigidbody2D that will not be accessible outside of its own class
    public float MoveSpeedModifier = 0.5f;
    public float moveForce = 10f; //move Force is the force of which the player is moved when the player hits a movement key. 
    public float SoarForce = 15f;

    public bool canJump = true; //A boolean variable is a true or flase variable and this function will control if the player can jump 
    public bool InAir = false; // A true or false variable that checks if the player is jumping. 

    public Sprite PlayerIdle, PlayerFly; //This public variable defines my two sprites and lets me reference them later. 
    
    // A FixedUpdate is called at a set rate, this is set to be called every 60 frames. 
    
    void FixedUpdate()
    {
        float newXposition = Input.GetAxis("Horizontal") * MoveSpeedModifier;  // this gets the input for horizontal movement then multiplies the movement value with the MoveSpeedModifier
        rigidBody.velocity = new Vector3(newXposition, rigidBody.velocity.y); // Sets the player velocity

        Vector3 characterScale = transform.localScale; //Allows me to directly manipulate the scale transform of the charater sprite to change the way it is facing. 

        //If the player presses the "Jump" key and the boolean canJump is true
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            rigidBody.AddForce(new Vector2(0.0f, moveForce), ForceMode2D.Impulse); //the moveForce is applied to the rigidBody of the player. 

            canJump = false; // Then sets to canJump to false to stop the player from jumping whislt in the air.
            InAir = true; // Sets InAir to true, so that the sprite can be changed. 
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump == true) // If the "W" key is pressed and the canJump varible is true.
        {

            rigidBody.AddForce(new Vector2(0.0f, SoarForce), ForceMode2D.Impulse); //the SoarForce is applied to the rigidBody of the player. 

            canJump = false; 
            InAir = true; // canJump is set to false to stop dounle jumps and InAir is set to true, so that the sprite can be changed. 
        }

        if (InAir == true) 
        {
            this.GetComponent<SpriteRenderer>().sprite = PlayerFly; //If InAir is true render the PlayerFly sprite
        }
        else // if InAir isn't true render the PlayerIdle sprite
        {
            this.GetComponent<SpriteRenderer>().sprite = PlayerIdle; 
        }

        if (Input.GetAxis("Horizontal") < 0) // if the player is moving left 
        {
            characterScale.x = 1.4f; // change the charater scale to postive, thus changing the way the sprite is facing
        }

        if (Input.GetAxis("Horizontal") > 0) // if the player is moving right 
        {
            characterScale.x = -1.4f; // set the character scale to negative making the sprite face right.
        }
        transform.localScale = characterScale;
    }

    private void OnCollisionEnter2D(Collision2D collision) // A private variable used to detect incoming collisions 
    {
        if (collision.collider.CompareTag("Platform")) // If the player collides with any object with the "Platform" tag 
        {
            canJump = true; // canJump is set to true, allowing the player to jump again if they want to. 
            InAir = false; // InAir is set to false so that the sprite will change back to the PlayerIdle sprite. 
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag ("Border")) // If the player collides with any object with the "Border" tag 
        {
            rigidBody.velocity = Vector3.zero; // The horizontal movement is set to zero so they cannot go any further and go off the screen. 
        }
    }
}