using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* In order to implement the gun and it's basic behavior, we again referenced another tutorial video by the YouTuber "gamesplusjames"
 * Specifically, we referenced the second video in his series titled "Unity Top Down Shooter #2 - Guns"
 * which can be found at this link: https://www.youtube.com/watch?v=JVibUZugFAQ&ab_channel=gamesplusjames
 * We followed his guide, and made sure that we understood everything that the code did. */

// This gun controller can also be used to determine the behavior of different projectile weapons
public class GunController : MonoBehaviour
{

    public bool shooting; //Public variable to determine weapon state
    public BulletBehavior bullet; //Creating a variable bullet of type BulletBehavior
    public float bulletVelocity; //Public variable for determining bullet speed

    // Variables to determine the gun's fire rate
    public float fireDelay; //Amount of time between shots
    private float fireCountdown; //Private variable to keep track of how much time has passed after a shot, used to set time between shots

    public Transform muzzle; //Reference to transform of empty game object that will be used to instantiate bullet (at muzzle area of gun)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting) //If gun is firing
        {
            fireCountdown -= Time.deltaTime; //Decrement fireCountdown variable by the amount of time that has passed since last frame
            if(fireCountdown <= 0) //Once the countdown reaches 0
            {
                fireCountdown = fireDelay; //Reset the countdown to the fire delay that is specified

                // Create bullet at the transform of the muzzle game object
                // This new bullet will have all of the properties of BulletBehavior meaning that we can pass in the bullet velocity
                BulletBehavior newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as BulletBehavior;

                // Setting the speed of the new bullet to the specified bullet velocity
                newBullet.velocity = bulletVelocity;
            }
            else //Behavior if gun is not shooting
            {
                fireCountdown = 0; //Reset fireCountdown to zero so that as soon as the mouse is clicked, the bullet gets instantiated
            }
        }
    }
}
