using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformControl : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {

        effector = GetComponent<PlatformEffector2D>(); // this funtion attributes the variable to the platform effector on the object

    }
    // Update is called once per frame
    void Update()
    {
     //This fucntion recognises when the player is pressing the down arrow and for how long.
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.S)) //This recognises that the player has pressed the down key and allows the player to drop down by flipping the rotational offest upside down.
        {
            if (waitTime <=0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            effector.rotationalOffset = 0f;
        }
        if (Input.GetKey(KeyCode.Space)) //these functions recognised that the player is pressing the jump key and flips the rotational offest to the correct side up. 
        {
            effector.rotationalOffset = 0;
        }

        if (Input.GetKey(KeyCode.W)) // this code recognised that the player is pressing the Soar button
        {
            effector.rotationalOffset = 0;
        }
    }
}
