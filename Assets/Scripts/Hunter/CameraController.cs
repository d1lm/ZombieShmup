using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a script to have the camera follow the player, based on the one we made back in the Roll-A-Ball Tutorial from the Unity website
 * Available at: https://learn.unity.com/tutorial/camera-and-play-area?uv=2019.3&projectId=5c51479fedbc2a001fd5bb9f#5c7f8529edbc2a002053b78c */

public class CameraController : MonoBehaviour
{
    public GameObject player; //Public variable to gett a reference to the player GameObject

    private Vector3 offset; //Private variable to determine how far the camera trails behind the player

    // Start is called before the first frame update
    void Start()
    {
        // Get the current transform position of the camera, and subtract the position of the player to calculate the offset
        offset = transform.position - player.transform.position;
    }

    // We use LateUpdate for follow cameras since anything under this lifecycle method is guaranteed to run after all items have been processed in the Update method
    void LateUpdate()
    {

        if(player == null) //checking if player is still alive or not. If we do not do this, the game will crash because the camera is still looking for the player.
        {
            transform.position = transform.position;
        }
        else
        {
            //Every frame, we set the camera's transform position to our player's transform position plus the calculated offset
            transform.position = player.transform.position + offset;
        }
       
           
       
        

        
    }
}
