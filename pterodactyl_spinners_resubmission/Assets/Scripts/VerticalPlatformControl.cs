using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformControl : MonoBehaviour
{
    private PlatformEffector2D effector; // This function allows me to referece the PlatformEffector2D in my code. 
    public float waitTime; // This waitTime variable will allow me to add a delay time to nay of my code. 

    // Start is called before the first frame update
    void Start()
    {

        effector = GetComponent<PlatformEffector2D>(); // This funtion attributes the variable to the platform effector on the object

    }
    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyUp(KeyCode.S)) //if the player presses the S key, a 0.1 second delay is made. 
        {
            waitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.S)) // If the S key is pressed
        {
            if (waitTime <=0) // And the waitTime is more or equal to 0, the effector on the platform is rotated 180 degrees and a delay is made 
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }
            else //if these conditions are not met then the waitTime will be waitTime - the time since the last frame (Time.deltaTime)
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))// If the S or Space key is not pressed, the effector stays right side up 
        {
            effector.rotationalOffset = 0f;
        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            effector.rotationalOffset = 0;
        }

        if (Input.GetKey(KeyCode.W)) // If the W key is not pressed the effector is the right way up.
        {
            effector.rotationalOffset = 0;
        }
    }
}
