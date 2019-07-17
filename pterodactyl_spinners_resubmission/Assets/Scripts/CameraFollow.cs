using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float xMin = 1;
    [SerializeField] float xMax = 2;
    [SerializeField] float yMin = -1;
    [SerializeField] float yMax = 69;
    //these SerializeField functions set the paramaters of the camera, how far they can go horizontally and vertically. 

    Transform T; //this defines the transform of the camera so that I can refer to it later code.

    private Transform playerTransform; //This transform variable defines the movement of the player, so that I can refer to player positiion in further code.

    void Awake()
    {
        T = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //at the start of the game the player will find the position of the player object. 
    }

    // Update is called once per frame
    void FixedUpdate() // Every 60 frames, the camera will read the x and y position of the player object and adjust the camera so that it is centered on the player.
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        transform.position = temp;

        //these functions clamp the camera in place when they get to the boundries set by the Serialize Fields.
        float x = Mathf.Clamp(target.position.x, xMin, xMax); 
        float y = Mathf.Clamp(target.position.y, yMin, yMax);

        T.position = new Vector3(x, y, T.position.z); //this locks the camera Z axis 
       
    }
}
