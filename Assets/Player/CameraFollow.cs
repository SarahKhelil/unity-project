using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    /*public Transform target ; 

    public float smoothSpeed = 0.1f ; 
    public Vector3 offset ; 
    

    void LateUpdate() 
    {
        Vector3 desiredPosition = target.position +  offset ; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed);
        transform.position = smoothedPosition ; 
        transform.LookAt(target); 
    }*/





    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }





    
}
