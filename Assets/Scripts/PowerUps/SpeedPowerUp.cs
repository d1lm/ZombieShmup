using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* In order to implement powerups into our game, we referred to this video: https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys
 * which was created by the YouTuber "Brackeys" which explains how to make powerups in Unity */

public class SpeedPowerUp : MonoBehaviour
{
    public float smallMultiplier = 0.5f; //used to make the player smaller
    public float speedMultiplier = 2f;
    public float duration = 5f;

    public GameObject pickupEffect; //we want a special effect when the player picks up the power up. 

    void OnTriggerEnter(Collider other) //called by unity only when the object is triggered.
    {
        if (other.CompareTag("Player")) //checks if the object has the player tag.
        {
           StartCoroutine( Pickup(other)); //if it is then the player picks it up. and starts Co-Routine function
        }
    }

    IEnumerator Pickup(Collider player) //Coroutine function to allow for a timer. 
    {
        //debugging 
        //Debug.Log("Power up picked up"); 

        SpeedSFX.Instance.PlaySpeedSFX(); //play speed sound power up sound effect.

        //apply a pick up effect.
        var SpecialEffect = Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply the speed boost!
       //player.transform.localScale *= smallMultiplier; //make the player smaller that way we know he is in boosted mode.
        PlayerController speed = player.GetComponent<PlayerController>(); //Grabs the current player speed from player controller
        speed.moveSpeed *= speedMultiplier; //uses the speed multiplier to speed up the character

        GetComponent<MeshRenderer>().enabled = false; //disables the MeshRenderer for our object so it does not stay bc of yield return new WairforSeconds
        GetComponent<Collider>().enabled = false; //disables the Collider for our object so it does not stay bc of yield return new WairforSeconds
        Destroy(SpecialEffect, 2f);


        //wait the amount of time for power up.
        yield return new WaitForSeconds(duration);

        //revert back to original speed.
        speed.moveSpeed /= speedMultiplier;
       //Player.transform.localScale /= smallMultiplier;


        //Destroy the object after being picked up
        Destroy(gameObject);
        
        

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
