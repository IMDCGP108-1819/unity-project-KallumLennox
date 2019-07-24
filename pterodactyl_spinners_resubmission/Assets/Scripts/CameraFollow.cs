using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float xMin = 1; // Sets the minumum amount I want the camera to move on the x axis  
    [SerializeField] float xMax = 2; // Sets the maximum amount I want the camera to move on the x axis
    [SerializeField] float yMin = -1; // Sets the minumum amount I want the camera to move on the y axis 
    [SerializeField] float yMax = 69; // Sets the maximum amount I want the camera to move on the y axis
    // SerializeField allows private variables to be seen and changed in the editor

    Transform T; //this defines the transform of the camera so that I can refer to it later code.

    private Transform playerTransform; //This transform variable defines the movement of the player, so that I can refer to player positiion in further code.

    void Awake() // Awake is called only once on first load
    {
        T = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // At the start of the level, this funtion will find the position of any game object tagged "Player" 
    }

    // Update is called once per frame
    void FixedUpdate() // Every 60 frames, the camera will read the x and y position of the player object and adjust the camera so that it is centered on the player.
    {
        Vector3 temp = transform.position; 
        // the temp variable stores the camera's current position.

        temp.x = playerTransform.position.x; 
        // Here we set the camera's position on the x axis the same as the postion of the player on the x axis

        temp.y = playerTransform.position.y;
        // Here we set the camera's position on the y axis the same as the postion of the player on the y axis

        transform.position = temp; 
        // This sets the camera's new temp position to the camara's current position allowing it to follow the players movement. 

        
        float x = Mathf.Clamp(target.position.x, xMin, xMax); 
        float y = Mathf.Clamp(target.position.y, yMin, yMax);
         //This clamps the camera on the players x and y axis position, not letting the camera go further than the range given in the SerializeField

        T.position = new Vector3(x, y, T.position.z); //this locks the camera Z axis 
       
    }
}
