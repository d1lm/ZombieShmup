using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    //Variables for healthPowerUp 

    //Such as adding health points or adding a life?


    public float duration = 0f;


    public GameObject pickupEffect; //we want a special effect when the player picks up the power up.

    void OnTriggerEnter(Collider other) //called by unity only when the object is triggered.
    {
        if (other.CompareTag("HitBox")) //checks if the object has the HitBox because hitbox stores the health stat.
        {
            StartCoroutine(Pickup(other)); //if it is then the player picks it up. and starts Co-Routine function
        }
    }

    IEnumerator Pickup(Collider player) //Coroutine function to allow for a timer. 
    {
        //debugging 
        //Debug.Log("Power up picked up"); 

        HealthSFX.Instance.PlayHealthSFX(); //plays health sound effect.

        //apply a pick up effect.
        var SpecialEffect = Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply the "health" boost
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.health += 50;
        if(playerHealth.health >= 100)
        {
            playerHealth.health = 100;
        }

        GetComponent<MeshRenderer>().enabled = false; //disables the MeshRenderer for our object so it does not stay bc of yield return new WairforSeconds
        GetComponent<Collider>().enabled = false; //disables the Collider for our object so it does not stay bc of yield return new WairforSeconds
        Destroy(SpecialEffect, 2f);


        //wait the amount of time for power up. (if needed later)
        yield return new WaitForSeconds(duration);

        //reverts the health boost if needed later.

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
