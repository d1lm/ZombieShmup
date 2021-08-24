using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* In order to implement the player movement and have the player look at whatever the mouse is pointing at, we followed a video tutorial by the YouTuber "gamesplusjames"
   Specifically, we referenced his video "Unity Top Down Shooter #1 - Player Movement & Look" available at this link: https://www.youtube.com/watch?v=lkDGk3TjsIE&ab_channel=gamesplusjames
   We also studied his video guide in order to understand how the code works*/

public class PlayerController : MonoBehaviour
{

    static public PlayerController S; //clever singletong method used in class.

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;


    private Camera mainCamera;

    // Implementing the gun
    public GunController playerGun; //Getting a reference to the player's gun


   // private AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>(); // We only have one camera in this game is we can just find the camera within the world 
    }

    // Update is called once per frame
    void Update()
    {
       // Audio = GetComponent<AudioSource>();

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //get axis raw because we want very specific controls for abrupt stop and go. 
        moveVelocity = moveInput * moveSpeed; //movement speed and stuff

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); //Returns a ray going from camera through a screen point. 
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //Vector3.up is plane that faces up , vector3.zero is the default point.
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) //set the raylength value to whatever value were our camera starts to where it hits in the world. 
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength); //we want our "point to look" to be the output of the raylength. 
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue); //creates a line to visualize the "pointToLook" Vector. only visual in scene. 

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z)); //makes our player object look at the point. However, we do not want the player to look at the ground thus we "lock" him with transform.position.y
        }

        // Making the gun fire
        if (Input.GetMouseButtonDown(0)) //If the left mouse button is clicked
            {
                playerGun.shooting = true; //Set the shooting boolean to true to update gun state
                //Audio.loop = true; //loops the audio 
                GunFire.Instance.PlayGunFire();
            }
            

        if (Input.GetMouseButtonUp(0)) //If the left mouse button is released
            {
                playerGun.shooting = false; //Set the shooting boolean to false to update gun state
                //Audio.loop = false; //loops the audio 
                GunFire.Instance.StopGunFire(); // gun fire audio
                ShellsFallingSFX.Instance.PlayShellsFallingSFX();
        }
            
    }
    void FixedUpdate ()
    {
        myRigidbody.velocity = moveVelocity;
    }


    public void DestroyHunter() //call this function when you want to destroy hunter HAHAHAHAHAHAHAHAHA.
    {
        gameObject.SetActive(false);
    }

   
}
